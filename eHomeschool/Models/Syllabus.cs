using eHomeschool.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class Syllabus : IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Objective is required")]
        public string Objective { get; set; }


        [Required(ErrorMessage = "Outcome is required")]
        public string Outcome { get; set; }


        [Required(ErrorMessage = "Assessment Methods are required")]
        public string AssessmentMethods { get; set; }

        [Required(ErrorMessage = "Learning Methods are required")]
        public string LearningMethods { get; set; }

        //Relationships
        public List<Course> Courses { get; set; }

    }
}
