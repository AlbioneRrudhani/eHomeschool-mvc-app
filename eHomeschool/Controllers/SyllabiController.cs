using eHomeschool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    public class SyllabiController : Controller
    {
        private readonly AppDbContext _context;

        public SyllabiController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allSyllabi = await _context.Syllabi.ToListAsync();
            return View(allSyllabi);
        }
    }
}
