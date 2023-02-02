using eHomeschool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCourses = await _context.Courses.Include(n => n.EducationalStage).OrderBy(n => n.Title) .ToListAsync();
            return View(allCourses);
        }
    }
}
