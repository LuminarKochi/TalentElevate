using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentElevate.Models
{
    public class AppliedJobsViewClass
    {
        public int userid { get; set; }
        public string companyname { get; set; }
        public string jobtitle { get; set; }
        public string jobdescription { get; set; }
        public string jobtype { get; set; }
        public int salary { get; set; }
        public int vaccancy { get; set; }
        public string lastdate { get; set; }
        public string status { get; set; }
        public string applieddate { get; set; }
    }
}