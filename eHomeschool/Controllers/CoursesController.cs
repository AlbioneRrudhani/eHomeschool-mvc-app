using eHomeschool.Data;
using eHomeschool.Data.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace eHomeschool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCourses = await _service.GetAllAsync(n => n.EducationalStage);
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




    }
}
