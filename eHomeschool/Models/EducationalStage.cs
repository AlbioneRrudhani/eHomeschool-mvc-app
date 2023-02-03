using eHomeschool.Data.Base;
using eHomeschool.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class EducationalStage : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public GradeCategory Grade { get; set; }


        [Required(ErrorMessage = "Semester is required")]
        public SemesterCategory Semester { get; set; }


        [Required(ErrorMessage = "Stage name is required")]
        public StageNameCategory StageName { get; set; }


        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Course> Courses { get; set; }
    }
}
