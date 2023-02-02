using eHomeschool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    public class LecturesController : Controller
    {
        private readonly AppDbContext _context;

        public LecturesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allLectures = await _context.Lectures.ToListAsync();
            return View(allLectures);
        }
    }
}
