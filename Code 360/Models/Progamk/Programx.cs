using Code_360.Models.Batches;
using Code_360.Models.Courses;
using Code_360.Models.ProgramCourses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.Progamk
{
    public class Programx
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Cost { get; set; }

        public List<Batch> Batches { get; set; }

        public List<Course> courses { get; set; }

        public List<ProgramCourse> ProgramCourses { get; set; }
    }
}
