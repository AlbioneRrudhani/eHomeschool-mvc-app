using eHomeschool.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class EducationalStage
    {
        [Key]
        public int Id { get; set; }

        public GradeCategory Grade { get; set; } 
        public SemesterCategory Semester { get; set; }
        public StageNameCategory StageName { get; set; }
        public string Description { get; set; }

        //Relationships
        public List<Course> Courses { get; set; }
    }
}
