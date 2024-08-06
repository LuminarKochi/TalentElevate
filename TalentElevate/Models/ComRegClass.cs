using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TalentElevate.Models
{
    public class ComRegClass
    {
        [Required(ErrorMessage = "Company Name is required")]
        public string cname { get; set; }
        [Required(ErrorMessage = "Company Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string cemail { get; set; }
        [Required(ErrorMessage = "Company Phone is required")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Please enter a valid Phone Number")]
        public string cphone { get; set; }
        [Required(ErrorMessage = "Company Description is required")]
        public string description { get; set; }
        [Required(ErrorMessage = "Company Website is required")]
        [RegularExpression(@"^((http|https):\/\/)?(www.)?[a-z0-9\-\.]+\.[a-z]{2,}(\.[a-z]{2,})?\/?$", ErrorMessage = "Please enter a valid Website URL")]
        public string website { get; set; }
        [Required(ErrorMessage = "Company Username is required")]
        public string cusername { get; set; }
        [Required(ErrorMessage = "Company Password is required")]
        public string cpassword { get; set; }
        [Required(ErrorMessage = "Company Confirm Password is required")]
        public string cconfirmPassword { get; set; }
        public string msg { get; set; }
    }
}