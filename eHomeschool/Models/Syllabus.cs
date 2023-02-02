using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class Syllabus
    {
        [Key]
        public int Id { get; set; }
        public string Objective { get; set; }
        public string Outcome { get; set; }
        public string AssessmentMethods { get; set; }
        public string LearningMethods { get; set; }

        //Relationships
        public List<Course> Courses { get; set; }

    }
}
