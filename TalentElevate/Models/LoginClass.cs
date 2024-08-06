using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TalentElevate.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage = "Please enter your Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Password and Confirmation Password do not match.")]
        public string confirmPassword { get; set; }
        public string role { get; set; } //admin, recruiter, jobseeker
        public string status { get; set; } //active, inactive
    }
}