﻿namespace eHomeschool.Models
{
    public class Lecture_Course
    {
        public int CourseId { get; set; }
        public Course Course{ get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }
    }
}
