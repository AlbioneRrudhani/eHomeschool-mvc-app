using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using eHomeschool.Models;
using System.Linq;
using eHomeschool.Data.Enums;

namespace eHomeschool.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();



                //Syllabus
                if (!context.Syllabi.Any())
                {
                    context.Syllabi.AddRange(new List<Syllabus>()
                  {
                        new Syllabus()
                    {
                        Objective = "The Acellus Grade 1 Math course focuses on addition, subtraction through the number 20, whole number relationships and place value, linear measurement, measuring lengths, and geometric shapes.",
                        Outcome = "Upon completion of Acellus Grade 1 Math, students will be able to recognize equal numbers of objects, number words for 0 – 29, and ordinal numbers; count 0 – 20; add within word problems and sentences; use the Order Property for Addition; count on 1 and on 2; use a number line; add zero, near doubles, and doubles; subtract within word problems and sentences; subtract zero and all; take numbers apart; subtract using 10; use the relational properties of addition and subtraction; use the correct operation; write addition and subtraction sentences; and compare amounts, and identify greater than and less than symbols, and use the symbols to compare numbers to include real-life situations. Students will also be able to sort, classify, and tally; make graphs and pictures to include real-life situations; correctly identify possible and impossible; compare, measure, and estimate length; use nonstandard units, inches, and centimeters; estimate capacity; and use length and estimation in real-life situations; identify shapes, plane figures, and solid figures as well as make new shapes; identify equal and unequal parts, halves, and fourths; use shapes and fractions in real-life situations; identify, extend, and create pictorial and number patterns; tell time with both analog and digital clocks to include identifying the half-hour; use spatial sense related to position, follow directions to include everyday situations, and find distances on a map.",
                        AssessmentMethods = "Lesson Practice, Unit Exams, Mid-Term Exam, Final Exam",
                        LearningMethods = "Lectures, Projects",
                    },
                        new Syllabus()
                    {
                        Objective = "The Acellus Earth Science course provides an opportunity to study the earth on which we live. The course investigates the earth's structure and composition, its changing surface and the role that energy plays in earth systems. It explores the earth's ecological resources and atmosphere, its water cycle and weather. It further discusses the earth's landmasses and its relationships with its neighbors in space. Along the way, students are shown how to use scientific thinking, investigations, tools and technologies.",
                        Outcome = "In the end of the course the students will have knowledge about :minerals, rocks, weathering and soil, erosion and deposition, etc.",
                        AssessmentMethods = "Pre-Test, Lesson Practice, Unit Exams, Mid-Term Exam, Final Exam",
                        LearningMethods = "Lectures, Projects",
                    },
                        new Syllabus()
                    {
                        Objective = "Acellus Psychology introduces students to the science of psych.  Students learn foundational knowledge regarding the scientific method, and human anatomy, and apply this to the study of memory, learning, stress, thought and personality, and states of consciousness.  Students also analyze common psychological disorders career paths within Psychology. Acellus Psychology is taught by Doug Day. Acellus Psychology is A-G Approved through the University of California.",
                        Outcome = "In the end of the course the students will have knowledge about: central nervous system, the peripheral nervous system, the neuron, and sending and receiving a signal, types of memory, classification of disorders, psychology vs. psychiatry, etc.",
                        AssessmentMethods = ": Pre-Test, Lesson Practice, Unit Exams, Mid-Term Exam, Final Exam",
                        LearningMethods = "Lectures, Projects",
                    },
                  });
                    context.SaveChanges();
                }




                //Instructor info
                if (!context.InstructorsInformation.Any())
                {
                    context.InstructorsInformation.AddRange(new List<InstructorInformation>()
                  {
                        new InstructorInformation()
                    {
                        ProfilePictureURL = "https://www.science.edu/acellus/wp-content/uploads/2016/12/Jennifer-Blank-225x300.jpg",
                        FullName = "JENNIFER BLANK",
                        Profession = "Course Instructor",
                        Bio = "Jennifer Blank is recognized by the International Academy of Science for her contribution to Acellus in fifteen elementary-level courses. Ms. Blank earned a Bachelor's degree in English and a Master of Arts degree in Education, both from Truman State University in Kirksville, Missouri, where she graduated magna cum laude and summa cum laude, respectively. Before entering classroom education, Ms. Blank served as a conservation educator at Walt Disney World’s Animal Kingdom park, where she taught children about animals and conservation. Following this adventure, Ms. Blank returned to Missouri to begin teaching elementary school. She earned gifted certification taking classes through the University of Missouri- Columbia and now teaches gifted students in grades K-5.",
                    },
                        new InstructorInformation()
                    {
                        ProfilePictureURL = "https://www.science.edu/acellus/wp-content/uploads/2016/12/Jennifer-Morgan-225x300.jpg",
                        FullName = "JENNIFER MORGAN",
                        Profession = "Course Instructor",
                        Bio = "Ms. Jennifer Morgan is recognized by the International Academy of Science for her work in the Earth Science course. Ms. Morgan received her Bachelor of Science in Biology, followed by her Bachelor of Science in Education from the University of South Dakota. She went on to receive her Master's degree in Education, specializing in Health, Physical Education, Recreation and Dance, from Northwest Missouri State University. Ms. Morgan has taught Freshman and Sophomore Science at Fort Osage School District in Missouri, and 7th Grade Science, 8th Grade Science, and split team at Lee's Summit School District, also in Missouri.",
                    },
                        new InstructorInformation()
                    {
                        ProfilePictureURL = "https://www.science.edu/acellus/wp-content/uploads/2017/01/Doug-Day-225x300.jpg",
                        FullName = "DOUG DAY",
                        Profession = "Course Instructor",
                        Bio = "Doug Day is recognized by the International Academy of Science for his contribution to the Acellus Psychology Course. Mr. Day presents this course in a professional but personable manner that helps students to readily understand this fairly sophisticated subject, and enjoy the journey as they do.",
                    },

                  });
                    context.SaveChanges();
                }




                //Educational stage
                if (!context.EducationalStages.Any())
                {
                    context.EducationalStages.AddRange(new List<EducationalStage>()
                    {
                        new EducationalStage()
                        {
                           Grade = GradeCategory.Grade1,
                           Semester = SemesterCategory.SecondPeriod,
                           StageName = StageNameCategory.ElementarySchool,
                           Description = "Elementary program offers a wide variety of online courses, taught by some of America’s finest teachers.Within each Power Homeschool course, students learn concepts that build off topics that were taught in previous classes while preparing for more complex concepts as they advance through the grade levels.You can select up to seven courses for your student, such as mathematics, language arts and reading, science, social studies, and electives. Our elementary homeschool curriculum helps you build your student’s skills, knowledge, and confidence that they can succeed in learning."
                        },
                        new EducationalStage()
                        {
                           Grade = GradeCategory.Grade7,
                           Semester = SemesterCategory.FirstPeriod,
                           StageName = StageNameCategory.MiddleSchool,
                           Description = "Our program offers online middle school courses to help homeschool parents prepare their students for the rigor of a high school education. Choose up to seven video-based courses from a full range of subjects including mathematics, reading, language arts, science, history and social studies, as well as emotional and physical health.  Foreign language courses including: German, French, and Spanish, are also available.The courses are self-paced and adapt to accommodate the needs of each student.  Students will move quickly through areas they are confident in, and receive extra instruction and practice to master material that is difficult for them.Learn more about our homeschool program to see if it is the right fit for your student."
                        },
                         new EducationalStage()
                        {
                           Grade = GradeCategory.Grade12,
                           Semester = SemesterCategory.FirstPeriod,
                           StageName = StageNameCategory.HighSchool,
                           Description = "Online high school program offers a wide variety of online high school courses, taught by some of America’s finest teachers.Our high school curriculum is carefully designed to introduce students to potential career paths with material often unavailable in a homeschool environment, such as career-specific and technical education, in addition to core subjects and foreign languages."
                        },

                    });
                    context.SaveChanges();

                }



                // Lecture
                if (!context.Lectures.Any())
                {
                    context.Lectures.AddRange(new List<Lecture>()
                    {
                         new Lecture()
                        {
                           Name = "Unit 1 - Numbers to 20",
                           Week ="Week 1",
                           Description ="In this unit student learn about equal groups and number words to 20. They also explore counting objects and ordinal numbers."
                        },
                         new Lecture()
                        {
                           Name = "Unit 2 - Addition",
                           Week ="Week 1",
                           Description ="In this unit students discuss addition stories, the equal sign, and addition sentences. They learn the order property for addition, how to use addition to make numbers, and how to count on. They use a number line to count on, learn about adding zero and about near doubles and doubles, and learn about vertical addition sentences. They learn about real-life uses for addition, and they are introduced to math tiles."
                        },

                          new Lecture()
                        {
                           Name = "Unit 1 – Minerals",
                           Week ="Week 1",
                           Description ="This unit covers what minerals are and how they are identified, mined, and used."
                        },
                             new Lecture()
                        {
                           Name = "Unit 2 – Rocks",
                           Week ="Week 2",
                           Description ="This unit discusses the 'rock cycle,' as well as igneous, sedimentary, and metamorphic rock."
                         },
                             new Lecture()
                        {
                           Name = "Unit 1",
                           Week ="Week 1",
                           Description ="Students begin this unit by learning about early observations in psychology, psychology as a science, the scientific method, and the nature of nature. Students will also begin learning about structuralism, functionalism, psychoanalysis, as well as other influences the affect psychology, ending with an integrated concept review on the origins of psychology."
                         },
                             new Lecture()
                        {
                           Name = "Unit 2",
                           Week ="Week 1",
                           Description ="This unit focuses on the parts and functions of the brain and it's importance in the field of psychology.  Areas of focus include the hemispheres, the hindbrain, the midbrain, the forebrain, and the lobes of the brain. This unit ends with an integrated concept review on the brain."
                         },
                    });
                    context.SaveChanges();
                }




                //Course
                if (!context.Courses.Any())
                {
                    context.Courses.AddRange(new List<Course>()
                    {
                        new Course()
                        {
                            Title = "Grade 1 Math",
                            PictureUrl = "https://getwallpapers.com/wallpaper/full/3/f/2/94261.jpg",
                            Short_description ="Understand all the concepts of Grade 1 Math",
                            Price = 15.99,
                            Language = LanguageCategory.English,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            EducationalStageId = 1,
                            SyllabusId = 1,
                            InstructorInformationId = 1
                        },
                          new Course()
                        {
                            Title = "Physical Geography",
                            PictureUrl = "http://windynookprimary.org/wp-content/uploads/2020/04/geography-image.jpg",
                            Short_description ="World Physical Geography.",
                            Price = 19.99,
                            Language = LanguageCategory.English,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            EducationalStageId = 2,
                            SyllabusId = 2,
                            InstructorInformationId = 2
                        },
                              new Course()
                        {
                            Title = "Learn Social Psychology",
                            PictureUrl = "https://psychology-spot.com/wp-content/uploads/2019/07/study-psychology.jpg",
                            Short_description ="Understand How People Think, Feel, and Behave",
                            Price = 19.99,
                            Language = LanguageCategory.English,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            EducationalStageId = 3,
                            SyllabusId = 3,
                            InstructorInformationId = 3
                        },
                    });
                    context.SaveChanges();
                }



                //Lectures & Courses
                if (!context.Lectures_Courses.Any())
                {
                    context.Lectures_Courses.AddRange(new List<Lecture_Course>()
                    {
                        new Lecture_Course()
                        {
                            LectureId = 1,
                            CourseId = 1
                        },
                         new Lecture_Course()
                        {
                            LectureId = 2,
                            CourseId = 2
                        },
                         new Lecture_Course()
                        {
                            LectureId = 3,
                            CourseId = 3
                        },

                    });
                    context.SaveChanges();
                }










            }

        }
    }
}
