﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eHomeschool.Data;

namespace eHomeschool.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eHomeschool.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EducationalStageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstructorInformationId")
                        .HasColumnType("int");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Short_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SyllabusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalStageId");

                    b.HasIndex("InstructorInformationId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("eHomeschool.Models.EducationalStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("StageName")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EducationalStages");
                });

            modelBuilder.Entity("eHomeschool.Models.InstructorInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InstructorsInformation");
                });

            modelBuilder.Entity("eHomeschool.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Week")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("eHomeschool.Models.Lecture_Course", b =>
                {
                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("LectureId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures_Courses");
                });

            modelBuilder.Entity("eHomeschool.Models.Syllabus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssessmentMethods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LearningMethods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Objective")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Outcome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Syllabi");
                });

            modelBuilder.Entity("eHomeschool.Models.Course", b =>
                {
                    b.HasOne("eHomeschool.Models.EducationalStage", "EducationalStage")
                        .WithMany("Courses")
                        .HasForeignKey("EducationalStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eHomeschool.Models.InstructorInformation", "InstructorInformation")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eHomeschool.Models.Syllabus", "Syllabus")
                        .WithMany("Courses")
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationalStage");

                    b.Navigation("InstructorInformation");

                    b.Navigation("Syllabus");
                });

            modelBuilder.Entity("eHomeschool.Models.Lecture_Course", b =>
                {
                    b.HasOne("eHomeschool.Models.Course", "Course")
                        .WithMany("Lectures_Courses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eHomeschool.Models.Lecture", "Lecture")
                        .WithMany("Lectures_Courses")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("eHomeschool.Models.Course", b =>
                {
                    b.Navigation("Lectures_Courses");
                });

            modelBuilder.Entity("eHomeschool.Models.EducationalStage", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("eHomeschool.Models.InstructorInformation", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("eHomeschool.Models.Lecture", b =>
                {
                    b.Navigation("Lectures_Courses");
                });

            modelBuilder.Entity("eHomeschool.Models.Syllabus", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
