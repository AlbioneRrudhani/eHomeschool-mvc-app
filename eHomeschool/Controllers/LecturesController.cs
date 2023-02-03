using eHomeschool.Data;
using eHomeschool.Data.Service;
using eHomeschool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ILecturesService _service;

        public LecturesController(ILecturesService service)
        {
            _service= service; 
        }
        public async Task<IActionResult> Index()
        {
            var allLectures = await _service.GetAllAsync();
            return View(allLectures);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Week", "Description")] Lecture lecture)
        {
            if (!ModelState.IsValid)
            {
                return View(lecture);
            }
             await _service.AddAsync(lecture);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Details(int id)
        {
            var lectureDetails =  await _service.GetByIdAsync(id);

            if (lectureDetails == null) return View("NotFound");
            return View(lectureDetails);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var lectureDetails = await _service.GetByIdAsync(id);
            if (lectureDetails == null) return View("NotFound");
            return View(lectureDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Week", "Description")] Lecture lecture)
        {
            if (!ModelState.IsValid)
            {
                return View(lecture);
            }
            await _service.UpdateAsync(id, lecture);
            return RedirectToAction(nameof(Index));
        }



       
        public async Task<IActionResult> Delete(int id)
        {
            var lectureDetails = await _service.GetByIdAsync(id);
            if (lectureDetails == null) return View("NotFound");
            return View(lectureDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lectureDetails = await _service.GetByIdAsync(id);
            if (lectureDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
