using eHomeschool.Data;
using eHomeschool.Data.Service;
using eHomeschool.Data.Static;
using eHomeschool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EducationalStagesController : Controller
    {
        private readonly IEducationalStagesService _service;

        public EducationalStagesController(IEducationalStagesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEducationalStages = await _service.GetAllAsync();
            return View(allEducationalStages);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var educationalStagesDetails = await _service.GetByIdAsync(id);

            if (educationalStagesDetails == null) return View("NotFound");
            return View(educationalStagesDetails);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Grade","Semester","StageName", "Description")]
        EducationalStage educationalStage)
        {
            if (!ModelState.IsValid) return View(educationalStage);

            await _service.AddAsync(educationalStage);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Edit(int id)
        {
            var educationalStagesDetails = await _service.GetByIdAsync(id);
            if (educationalStagesDetails == null) return View("NotFound");
            return View(educationalStagesDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Grade", "Semester", "StageName", "Description")]
        EducationalStage educationalStage)
        {
            if (!ModelState.IsValid) return View(educationalStage);

            if (id == educationalStage.Id)
            {
                await _service.UpdateAsync(id, educationalStage);
                return RedirectToAction(nameof(Index));
            }
            return View(educationalStage);


        }


        public async Task<IActionResult> Delete(int id)
        {
            var educationalStagesDetails = await _service.GetByIdAsync(id);
            if (educationalStagesDetails == null) return View("NotFound");
            return View(educationalStagesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationalStagesDetails = await _service.GetByIdAsync(id);
            if (educationalStagesDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }

}
