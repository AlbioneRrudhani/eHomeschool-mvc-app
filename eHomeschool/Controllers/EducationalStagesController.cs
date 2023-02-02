using eHomeschool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    public class EducationalStagesController : Controller
    {
        private readonly AppDbContext _context;

        public EducationalStagesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allEducationalStages = await _context.EducationalStages.ToListAsync();
            return View(allEducationalStages);
        }
    }
}
