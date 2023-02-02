using eHomeschool.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public string Short_description { get; set; }

        public double Price { get; set; }

        public LanguageCategory Language { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
