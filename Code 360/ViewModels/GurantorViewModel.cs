using Code_360.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.ViewModels
{
    public class GurantorViewModel
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Display(Name="Guarantor Name")]
        public string GurantorName { get; set; }

        [Display(Name = "Guarantor Email")]
        public string GurantorEmail { get; set; }

        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Office Phone")]
        public string OfficePhone { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public Gender Gender { get; set; }

        public Student Student { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
}
