using Code_360.Models.Batches;
using Code_360.Models.Companyx;
using Code_360.Models.Courses;
using Code_360.Models.EmployMentx;
using Code_360.Models.Guarantorx;
using Code_360.Models.Paymentx;
using Code_360.Models.ProgramCourses;
using Code_360.Models.Salaryx;
using Code_360.Models.StudentGurantorxx;
using Code_360.Models.StudentInBatches;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models
{
    public class StudentDbContext : IdentityDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext>options) 
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Guarantors> Guarantors { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Company> Companies { get; set; }

        

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<ProgramCourse> ProgramCourses { get; set; }

        public DbSet<StudentInBatch> StudentInBatches { get; set; }

        public DbSet<StudentGuarantor> StudentGurantors { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this is a many to many relationship
            //program course Relationship
            base.OnModelCreating(builder);

            builder.Entity<ProgramCourse>()
                .HasKey(x => new { x.ProgramId, x.CourseId });

            builder.Entity<ProgramCourse>()
                .HasOne(sg => sg.Program)
                .WithMany(sg => sg.ProgramCourses)
                .HasForeignKey(sg => sg.ProgramId);

            builder.Entity<ProgramCourse>()
                .HasOne(sg => sg.Course)
                .WithMany(sg => sg.ProgramCourses)
                .HasForeignKey(sg => sg.CourseId);

            //this is a many to many for Student Company
            builder.Entity<Employment>()
                .HasKey(x => new { x.StudentId, x.CompanyId });

            builder.Entity<Employment>()
                .HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentCompanies)
                .HasForeignKey(sc => sc.StudentId);

            builder.Entity<Employment>()
                .HasOne(sc => sc.Company)
                .WithMany(sc => sc.StudentCompanies)
                .HasForeignKey(sc => sc.CompanyId);

            //this is a many to many for StudentInBatch

            builder.Entity<StudentInBatch>()
                .HasKey(x => new { x.StudentId, x.BatchId });

            builder.Entity<StudentInBatch>()
                .HasOne(sb => sb.Student)
                .WithMany(sb => sb.StudentBatches)
                .HasForeignKey(sb => sb.StudentId);

            builder.Entity<StudentInBatch>()
                .HasOne(sb => sb.Batch)
                .WithMany(sb => sb.StudentBatches)
                .HasForeignKey(sb => sb.BatchId);

            //this is a many to many for StudentGuarantor

            builder.Entity<StudentGuarantor>()
                .HasKey(key => new { key.StudentId, key.GuarantorsId });

            builder.Entity<StudentGuarantor>()
                .HasOne(gs => gs.Student)
                .WithMany(gs => gs.StudentGuarantors)
                .HasForeignKey(gs => gs.StudentId);

            builder.Entity<StudentGuarantor>()
                .HasOne(g => g.Guarantors)
                .WithMany(g => g.StudentGuarantors)
                .HasForeignKey(g => g.GuarantorsId);





        }
    }
}
