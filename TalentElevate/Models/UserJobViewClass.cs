using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TalentElevate.Models
{
    public class JobSearch 
    { 
        public JobSearch()
        {
            selectjob = new List<UserJobViewClass>();
            insertse = new UserJobViewClass();
        }
        public UserJobViewClass insertse { get; set; }
        public List<UserJobViewClass> selectjob { get; set; }
    }
    public class UserJobViewClass
    {
        public int company_id { get; set; }
        public int job_id { get; set; }
        public string job_title { get; set; }
        public string job_description { get; set; }
        public string job_type { get; set; } //full time, part time, contract
        public int vacancy { get; set; }
        public int salary { get; set; }
        public string skilset { get; set; }
        public int experience { get; set; }
        public string location { get; set; }
        public string status { get; set; } //active, inactive
        public DateTime date { get; set; } // Expecting date in string format
    }
}