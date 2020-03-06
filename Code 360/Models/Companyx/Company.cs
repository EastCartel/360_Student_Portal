
using Code_360.Models.EmployMentx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.Companyx
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        
        public List<Employment> StudentCompanies { get; set; }
    }
}
