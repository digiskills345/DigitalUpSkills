using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DigitalUpskills.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<tbl_Admin> tbl_Admin { get; set; }
        public virtual DbSet<tbl_Course> tbl_Course { get; set; }
        public virtual DbSet<tbl_CourseCategory> tbl_CourseCategory { get; set; }
        public virtual DbSet<tbl_CourseRegistration> tbl_CourseRegistration { get; set; }
        public virtual DbSet<tbl_Feedback> tbl_Feedback { get; set; }
        public virtual DbSet<tbl_Instructor> tbl_Instructor { get; set; }
        public virtual DbSet<tbl_Lecture> tbl_Lecture { get; set; }
        public virtual DbSet<tbl_Slide> tbl_Slide { get; set; }
        public virtual DbSet<tbl_Student> tbl_Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Course>()
                .HasMany(e => e.tbl_CourseRegistration)
                .WithRequired(e => e.tbl_Course)
                .HasForeignKey(e => e.Course_Fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Course>()
                .HasMany(e => e.tbl_Lecture)
                .WithRequired(e => e.tbl_Course)
                .HasForeignKey(e => e.Course_Fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Course>()
                .HasMany(e => e.tbl_Slide)
                .WithRequired(e => e.tbl_Course)
                .HasForeignKey(e => e.Course_Fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_CourseCategory>()
                .HasMany(e => e.tbl_Course)
                .WithRequired(e => e.tbl_CourseCategory)
                .HasForeignKey(e => e.CourseCategory_Fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Feedback>()
                .Property(e => e.Feedback_Rating)
                .HasPrecision(18, 1);

            modelBuilder.Entity<tbl_Instructor>()
                .HasMany(e => e.tbl_Course)
                .WithRequired(e => e.tbl_Instructor)
                .HasForeignKey(e => e.Instructor_Fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Student>()
                .HasMany(e => e.tbl_CourseRegistration)
                .WithRequired(e => e.tbl_Student)
                .HasForeignKey(e => e.Student_Fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Student>()
                .HasMany(e => e.tbl_Feedback)
                .WithRequired(e => e.tbl_Student)
                .HasForeignKey(e => e.Student_Fid)
                .WillCascadeOnDelete(false);
        }
    }
}
