using Code_360.Models.Guarantorx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.StudentGurantorxx
{
    public class StudentGuarantor
    {
        public int Id { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }

        public int GuarantorsId { get; set; }

        public Guarantors Guarantors { get; set; }
    }
}
