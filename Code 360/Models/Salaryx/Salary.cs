using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models.Salaryx
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Role { get; set; }
        public double Amount { get; set; }
        public string Payday { get; set; }
    }
}
