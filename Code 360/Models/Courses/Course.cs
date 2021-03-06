﻿using Code_360.Models.ProgramCourses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.Courses
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Level Level { get; set; }

        public List<ProgramCourse> ProgramCourses { get; set; }
    }
}
