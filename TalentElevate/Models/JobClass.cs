using System;
using System.ComponentModel.DataAnnotations;

namespace TalentElevate.Models
{
    public class jobtypecls
    {
        // For dropdown page load
        public int jId { get; set; }
        public string jName { get; set; }
    }

    public class JobClass
    {
        public int jId { get; set; }
        public string jName { get; set; }
        public int company_id { get; set; }
        [Required(ErrorMessage = "Job Title is required")]
        public string job_title { get; set; }
        [Required(ErrorMessage = "Job Description is required")]
        public string job_description { get; set; }
        [Required(ErrorMessage = "Job Type is required")]
        public int vacancy { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public int salary { get; set; }
        [Required(ErrorMessage = "Skillset is required")]
        public string skilset { get; set; }
        [Required(ErrorMessage = "Experience is required")]
        public int experience { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string location { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string status { get; set; } //active, inactive
        [Required(ErrorMessage = "Date is required")]
        public string date { get; set; } // Expecting date in string format
        public string msg { get; set; }
    }
}
