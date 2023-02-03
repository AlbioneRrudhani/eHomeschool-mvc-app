using eHomeschool.Data.Base;
using eHomeschool.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace eHomeschool.Models
{
    public class Course : IEntityBase
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


        //Relationships
        public List<Lecture_Course> Lectures_Courses { get; set; }

        //Educational Stage
        public int EducationalStageId { get; set; }
        [ForeignKey("EducationalStageId")]
        public EducationalStage EducationalStage { get; set; }

        //Syllabus
        public int SyllabusId { get; set; }
        [ForeignKey("SyllabusId")]
        public Syllabus Syllabus { get; set; }

        //Instructor information
        public int InstructorInformationId { get; set; }
        [ForeignKey("InstructorInformationId")]
        public InstructorInformation InstructorInformation { get; set; }
    }
}
