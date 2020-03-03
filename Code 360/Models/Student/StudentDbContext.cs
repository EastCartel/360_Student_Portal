using Code_360.Models.ProgramCourses;
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

        public DbSet<ProgramCourse> ProgramCourses { get; set; }

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
  
        }
    }
}
