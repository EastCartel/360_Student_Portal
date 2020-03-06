using Code_360.Models.Companyx;
using Code_360.Models.Salaryx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.EmployMentx
{
    public class Employment
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Salary> Salaries { get; set; } 


        //this is the class that links up the student and company including a few characteristics
    }
}
