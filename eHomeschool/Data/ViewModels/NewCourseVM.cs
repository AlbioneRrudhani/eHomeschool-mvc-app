using eHomeschool.Data.Enums;
using eHomeschool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace eHomeschool.Data.ViewModels
{
    public class NewCourseVM
    {
        public int Id { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Display(Name = "Course Picture")]
        [Required(ErrorMessage = "Picture is required")]
        public string PictureUrl { get; set; }

        [Display(Name = "Course Short description")]
        [Required(ErrorMessage = "Short description is required")]
        public string Short_description { get; set; }


        [Display(Name = "Price")]
        [Required(ErrorMessage = "Course Price is required")]
        public double Price { get; set; }


        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Language category is required")]
        public LanguageCategory Language { get; set; }

        [Display(Name = "Select a start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Select a end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }


        //Relationships

        [Display(Name = "Select a lecture")]
        [Required(ErrorMessage = "Lecture is required")]
        public List<int> LectureIds { get; set; }


        [Display(Name = "Select a educational stage")]
        [Required(ErrorMessage = "Educational stage is required")]
        public int EducationalStageId { get; set; }


        [Display(Name = "Select a syllabus")]
        [Required(ErrorMessage = "Syllabus is required")]
        public int SyllabusId { get; set; }


        [Display(Name = "Select a instructor")]
        [Required(ErrorMessage = "Instructor is required")]
        public int InstructorInformationId { get; set; }

    }
}
