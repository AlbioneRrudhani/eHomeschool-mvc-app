using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class Lecture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Week { get; set; }
        public string Description { get; set; }
    }
}
