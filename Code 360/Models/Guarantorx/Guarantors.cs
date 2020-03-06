using Code_360.Models.StudentGurantorxx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.Guarantorx
{
    public class Guarantors
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string GurantorName { get; set; }

        public string CompanyName { get; set; }

        public string GurantorEmail { get; set; }

        public string HomePhone { get; set; }

        public string OfficePhone { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public Gender Gender { get; set; }

        //public Student Student { get; set; }

        public IList<StudentGuarantor> StudentGuarantors { get; set; }
    }
}
