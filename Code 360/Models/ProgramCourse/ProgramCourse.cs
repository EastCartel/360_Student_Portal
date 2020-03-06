using Code_360.Models.Courses;
using Code_360.Models.Progamk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.ProgramCourses
{
    public class ProgramCourse
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int ProgramId { get; set; }
        public Programx Program { get; set; }
    }
}
