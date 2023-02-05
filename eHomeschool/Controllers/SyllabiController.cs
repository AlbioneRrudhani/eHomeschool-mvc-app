using eHomeschool.Data;
using eHomeschool.Data.Service;
using eHomeschool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    [Authorize]
    public class SyllabiController : Controller
    {
        private readonly ISyllabiService _service;

        public SyllabiController(ISyllabiService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allSyllabi = await _service.GetAllAsync();
            return View(allSyllabi);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Objective","Outcome","AssessmentMethods", "LearningMethods")]
        Syllabus syllabus)
        {
            if (!ModelState.IsValid) return View(syllabus);

            await _service.AddAsync(syllabus);
            return RedirectToAction(nameof(Index));

        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var syllabusDetails = await _service.GetByIdAsync(id);

            if (syllabusDetails == null) return View("NotFound");
            return View(syllabusDetails);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var syllabusDetails = await _service.GetByIdAsync(id);
            if (syllabusDetails == null) return View("NotFound");
            return View(syllabusDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Objective", "Outcome", "AssessmentMethods", "LearningMethods")] Syllabus syllabus)
        {
            if (!ModelState.IsValid)
            {
                return View(syllabus);
            }
            await _service.UpdateAsync(id, syllabus);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var syllabusDetails = await _service.GetByIdAsync(id);
            if (syllabusDetails == null) return View("NotFound");
            return View(syllabusDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var syllabusDetails = await _service.GetByIdAsync(id);
            if (syllabusDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
