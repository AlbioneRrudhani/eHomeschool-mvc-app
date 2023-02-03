using eHomeschool.Models;
using Microsoft.EntityFrameworkCore;

namespace eHomeschool.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture_Course>().HasKey(am => new
            {
                am.LectureId,
                am.CourseId
            });

            modelBuilder.Entity<Lecture_Course>().HasOne(c => c.Course).WithMany(lc => lc.Lectures_Courses).HasForeignKey(c => c.CourseId);
            modelBuilder.Entity<Lecture_Course>().HasOne(c => c.Lecture).WithMany(lc => lc.Lectures_Courses).HasForeignKey(c => c.LectureId);


            base.OnModelCreating(modelBuilder);
        }

        //Course related tables

        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture_Course> Lectures_Courses { get; set; }
        public DbSet<EducationalStage> EducationalStages { get; set; }
        public DbSet<InstructorInformation> InstructorsInformation { get; set; }
        public DbSet<Syllabus> Syllabi { get; set; }


        //Order related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
