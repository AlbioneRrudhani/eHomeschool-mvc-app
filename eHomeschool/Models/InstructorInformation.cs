using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eHomeschool.Models
{
    public class InstructorInformation
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string Bio { get; set; }

        //Relationships
        public List<Course> Courses { get; set; }
    }
}
