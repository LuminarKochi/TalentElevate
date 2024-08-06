using System.Collections.Generic;
using System.Web.Mvc; // Include this for SelectListItem

namespace TalentElevate.Models
{
    public class ViewApplicants
    {
        public int ApplyId { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public string JobTitle { get; set; }
        public string ApplicantEmail { get; set; }
        public string ApplicantPhone { get; set; }
        public string ApplicantQualification { get; set; }
        public string ApplicantExperience { get; set; }
        public string ApplicantSkills { get; set; }
        public string ApplicantPhoto { get; set; }
        public string ApplicantResume { get; set; }
        public string vaccancy { get; set; }
        public string ApplicantStatus { get; set; }
        public string date { get; set; }
        public string ApplicantNewStatus { get; set; }
    }
}
