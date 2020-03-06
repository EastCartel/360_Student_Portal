using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.ViewModels
{
    public class RegistrationViewModel
    {
        //[Required]
        [EmailAddress]
        [Remote(controller:"account", action: "IsEmailAvailable")]
        public string Email { get; set; }

        //[Required]
        [MinLength(5)]
        [DataType(DataType.Password)] //this property masks the password
        public string Password { get; set; }

        //[Required]
        [Display(Name ="Confirm Password")] //display attribute for confirpassword
        [Compare("Password", ErrorMessage ="Password and Confirm Password does not match")] //this compares the passwords
        [DataType(DataType.Password)] //this masks the password
        public string ConfirmPassword { get; set; }
        [Display(Name = "Remember Me")]
        public bool Remember_Me { get; set; }



    }
}
