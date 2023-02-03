using eHomeschool.Models;
using System.Collections.Generic;

namespace eHomeschool.Data.ViewModels
{
    public class NewCourseDropDownVM
    {
        public NewCourseDropDownVM()
        {
            EducationalStages = new List<EducationalStage>();
            Syllabi = new List<Syllabus>();
            InstructorsInformation = new List<InstructorInformation>();
            Lectures = new List<Lecture>();

        }

        public List<EducationalStage> EducationalStages { get; set; }
        public List<Syllabus> Syllabi { get; set; }
        public List<InstructorInformation> InstructorsInformation { get; set; }
        public List<Lecture> Lectures { get; set; }
    }
}

