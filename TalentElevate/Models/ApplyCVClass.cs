using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TalentElevate.Models
{
    public class ApplyCVClass
    {
        public int user_id { get; set; }
        public int company_id { get; set; }
        public int job_id { get; set; }
       // [Required(ErrorMessage ="Please upload your resume")]
        public string resume { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public string msg { get; set; }
    }
}