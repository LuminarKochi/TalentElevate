using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TalentElevate.Models
{
    public class UserRegClass
    {
        public string fname { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string lname { get; set; }
        [Range(18, 55, ErrorMessage = "Age should be between 18 to 55")]
        public int age { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your Phone Number")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Please enter a valid Phone Number")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Please enter your Qualification")]
        public string qualification { get; set; }
        [Required(ErrorMessage = "Please enter your Experience")]
        public int experience { get; set; }
        [Required(ErrorMessage = "Please enter your Skills")]
        public string skills { get; set; }
        [Required(ErrorMessage = "Please enter your Nationality")]
        public string nationality { get; set; }
        [Required(ErrorMessage = "Please enter your City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please enter your State")]
        public string state { get; set; }
        [Required(ErrorMessage = "Please enter your Pincode")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Please enter a valid Pincode")]
        public string pincode { get; set; }
       // [Required(ErrorMessage = "Please upload your Photo")]
        public string photo { get; set; }
        [Required(ErrorMessage = "Please enter your Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string password { get; set; }
        [Required(ErrorMessage = "Please confirm your Password")]
        [Compare("password", ErrorMessage = "Password and Confirmation Password do not match.")]
        public string confirmpassword { get; set; }
        public string usermsg { get; set; } //for displaying message
    }
}