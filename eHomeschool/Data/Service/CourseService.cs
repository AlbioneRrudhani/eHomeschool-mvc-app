using eHomeschool.Data.Base;
using eHomeschool.Data.ViewModels;
using eHomeschool.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eHomeschool.Data.Service
{
    public class CourseService : EntityBaseRepository<Course>, ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context) : base(context)
        {
            _context= context;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var courseDetails = await _context.Courses
                .Include(e => e.EducationalStage)    
                .Include(s => s.Syllabus)
                .Include(i => i.InstructorInformation)
                .Include(lc => lc.Lectures_Courses).ThenInclude(l => l.Lecture)
                 .FirstOrDefaultAsync(n => n.Id == id);

            return courseDetails;
        }

        public async Task<NewCourseDropDownVM> GetNewCourseDropDownsValue()
        {
            var response = new NewCourseDropDownVM()
            {
                InstructorsInformation = await _context.InstructorsInformation.ToListAsync(),
                Syllabi = await _context.Syllabi.ToListAsync(),
                EducationalStages = await _context.EducationalStages.ToListAsync(),
                Lectures = await _context.Lectures.ToListAsync()

            };
            return response;
        }


    }
}
