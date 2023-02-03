using eHomeschool.Data.Base;
using eHomeschool.Data.ViewModels;
using eHomeschool.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task AddNewCourseAsync(NewCourseVM data)
        {
            var newCourse = new Course()
            {
                Title = data.Title,
                PictureUrl = data.PictureUrl,
                Short_description = data.Short_description,
                Price = data.Price,
                Language = data.Language,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                EducationalStageId = data.EducationalStageId,
                SyllabusId = data.SyllabusId,
                InstructorInformationId = data.InstructorInformationId,
            };
            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();

            //Add Lectures Courses
            foreach (var lectureId in data.LectureIds)
            {
                var newLectureCourse = new Lecture_Course()
                {
                    CourseId = newCourse.Id,
                    LectureId = lectureId
                };
                await _context.Lectures_Courses.AddAsync(newLectureCourse);
            }
            await _context.SaveChangesAsync();
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

        public async Task UpdateCourseAsync(NewCourseVM data)
        {
            var dbCourse = await _context.Courses.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbCourse != null)
            {
                dbCourse.Title = data.Title;
                dbCourse.PictureUrl = data.PictureUrl;
                dbCourse.Short_description = data.Short_description;
                dbCourse.Price = data.Price;
                dbCourse.Language = data.Language;
                dbCourse.StartDate = data.StartDate;
                dbCourse.EndDate = data.EndDate;
                dbCourse.EducationalStageId = data.EducationalStageId;
                dbCourse.SyllabusId = data.SyllabusId;
                dbCourse.InstructorInformationId = data.InstructorInformationId;

                await _context.SaveChangesAsync();
            }

            //Remove existing lecture
            var existingLecturesDb = _context.Lectures_Courses.Where(n => n.CourseId == data.Id).ToList();
             _context.Lectures_Courses.RemoveRange(existingLecturesDb);
            await _context.SaveChangesAsync();

            //Add Lectures Courses
            foreach (var lectureId in data.LectureIds)
            {
                var newLectureCourse = new Lecture_Course()
                {
                    CourseId = data.Id,
                    LectureId = lectureId
                };
                await _context.Lectures_Courses.AddAsync(newLectureCourse);
            }
            await _context.SaveChangesAsync();
        }
    }
}
