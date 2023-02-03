using eHomeschool.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class Lecture : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 40 chars")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Week is required")]
        public string Week { get; set; }


        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        
        //Relationships
        public List<Lecture_Course> Lectures_Courses { get; set; }
    }
}
