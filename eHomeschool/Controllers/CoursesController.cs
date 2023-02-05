using eHomeschool.Data;
using eHomeschool.Data.Service;
using eHomeschool.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace eHomeschool.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }




        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCourses = await _service.GetAllAsync(n => n.EducationalStage);
            return View(allCourses);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allCourses = await _service.GetAllAsync(n => n.EducationalStage );

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResult = allCourses.Where(n => n.Title.ToLower().Contains(searchString.ToLower())  || n.Short_description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index", filteredResult);
            }

            return View(allCourses);
        }




        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var courseDetail = await _service.GetCourseByIdAsync(id);
            return View(courseDetail);
        }


        public async Task<IActionResult> Create()
        {
            var courseDropdownsData = await _service.GetNewCourseDropDownsValue();

            ViewBag.EducationalStages = new SelectList(courseDropdownsData.EducationalStages, "Id", "Grade");
            ViewBag.Syllabi = new SelectList(courseDropdownsData.Syllabi, "Id", "Objective", "Outcome", "AssessmentMethods");
            ViewBag.InstructorsInfo = new SelectList(courseDropdownsData.InstructorsInformation, "Id", "FullName");
            ViewBag.Lectures = new SelectList(courseDropdownsData.Lectures, "Id", "Name");



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCourseVM course)
        {
            if (!ModelState.IsValid)
            {
                var courseDropdownsData = await _service.GetNewCourseDropDownsValue();

                ViewBag.EducationalStages = new SelectList(courseDropdownsData.EducationalStages, "Id", "Grade");
                ViewBag.Syllabi = new SelectList(courseDropdownsData.Syllabi, "Id", "Objective", "Outcome", "AssessmentMethods");
                ViewBag.InstructorsInfo = new SelectList(courseDropdownsData.InstructorsInformation, "Id", "FullName");
                ViewBag.Lectures = new SelectList(courseDropdownsData.Lectures, "Id", "Name");

                return View(course);
            }
            await _service.AddNewCourseAsync(course);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var courseDetails = await _service.GetCourseByIdAsync(id);
            if (courseDetails == null) return View("NotFound");

            var response = new NewCourseVM()
            {
                Id = courseDetails.Id,
                Title = courseDetails.Title,
                Short_description = courseDetails.Short_description,
                Price = courseDetails.Price,
                StartDate = courseDetails.StartDate,
                EndDate = courseDetails.EndDate,
                PictureUrl = courseDetails.PictureUrl,
                Language = courseDetails.Language,
                EducationalStageId = courseDetails.EducationalStageId,
                SyllabusId = courseDetails.SyllabusId,
                InstructorInformationId = courseDetails.InstructorInformationId,
                LectureIds = courseDetails.Lectures_Courses.Select(n => n.LectureId).ToList(),
            };

            var courseDropdownsData = await _service.GetNewCourseDropDownsValue();

            ViewBag.EducationalStages = new SelectList(courseDropdownsData.EducationalStages, "Id", "Grade");
            ViewBag.Syllabi = new SelectList(courseDropdownsData.Syllabi, "Id", "Objective", "Outcome", "AssessmentMethods");
            ViewBag.InstructorsInfo = new SelectList(courseDropdownsData.InstructorsInformation, "Id", "FullName");
            ViewBag.Lectures = new SelectList(courseDropdownsData.Lectures, "Id", "Name");

            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCourseVM course)
        {
            if (id != course.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var courseDropdownsData = await _service.GetNewCourseDropDownsValue();

                ViewBag.EducationalStages = new SelectList(courseDropdownsData.EducationalStages, "Id", "Grade");
                ViewBag.Syllabi = new SelectList(courseDropdownsData.Syllabi, "Id", "Objective", "Outcome", "AssessmentMethods");
                ViewBag.InstructorsInfo = new SelectList(courseDropdownsData.InstructorsInformation, "Id", "FullName");
                ViewBag.Lectures = new SelectList(courseDropdownsData.Lectures, "Id", "Name"); ;

                return View(course);
            }

            await _service.UpdateCourseAsync(course);
            return RedirectToAction(nameof(Index));
        }





    }
}
