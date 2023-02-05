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
    public class InstructorsInfoController : Controller
    {
        private readonly IInstructorInfoService _service;

        public InstructorsInfoController(IInstructorInfoService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allInstructors = await _service.GetAllAsync();
            return View(allInstructors);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL","FullName","Profession", "Bio")]
        InstructorInformation instructorInformation)
        {
            if (!ModelState.IsValid) return View(instructorInformation);

            await _service.AddAsync(instructorInformation);
            return RedirectToAction(nameof(Index));

        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var instructorInfoDetails = await _service.GetByIdAsync(id);

            if (instructorInfoDetails == null) return View("NotFound");
            return View(instructorInfoDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var instructorInfoDetails = await _service.GetByIdAsync(id);
            if (instructorInfoDetails == null) return View("NotFound");
            return View(instructorInfoDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "ProfilePictureURL", "FullName", "Profession", "Bio")]
        InstructorInformation instructorInformation)
        {
            if (!ModelState.IsValid)
            {
                return View(instructorInformation);
            }
            await _service.UpdateAsync(id, instructorInformation);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var instructorInfoDetails = await _service.GetByIdAsync(id);
            if (instructorInfoDetails == null) return View("NotFound");
            return View(instructorInfoDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructorInfoDetails = await _service.GetByIdAsync(id);
            if (instructorInfoDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
