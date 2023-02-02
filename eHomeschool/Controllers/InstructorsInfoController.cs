using eHomeschool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eHomeschool.Controllers
{
    public class InstructorsInfoController : Controller
    {
        private readonly AppDbContext _context;

        public InstructorsInfoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allInstructorsInfo = await _context.InstructorsInformation.ToListAsync();
            return View();
        }
    }
}
