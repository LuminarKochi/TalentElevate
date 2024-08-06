using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using TalentElevate.Models;

namespace TalentElevate.Controllers
{
    public class JobApplicantsController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();

        // GET: JobApplicants
        public ActionResult Applicant_PageLoad()
        {
            var companyId = Session["uid"] != null ? Convert.ToInt32(Session["uid"]) : 0;
            return View(GetViewApplicants(companyId));
        }

        private List<ViewApplicants> GetViewApplicants(int companyId)
        {
            var applicantsList = new List<ViewApplicants>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_applicantsView", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@company_id", companyId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var appcls = new ViewApplicants
                    {
                        ApplyId = Convert.ToInt32(dr["apply_id"]),
                        ApplicantId = Convert.ToInt32(dr["user_id"]),
                        ApplicantName = dr["name"].ToString(),
                        JobTitle = dr["job_title"].ToString(),
                        ApplicantEmail = dr["email"].ToString(),
                        ApplicantPhone = dr["phone"].ToString(),
                        ApplicantQualification = dr["qualification"].ToString(),
                        ApplicantExperience = dr["experiance"].ToString(),
                        ApplicantSkills = dr["skills"].ToString(),
                        ApplicantPhoto = dr["photo"].ToString(),
                        ApplicantResume = dr["resume"].ToString(),
                        vaccancy = dr["vacancy"].ToString(),
                        date = dr["date"].ToString(),
                        ApplicantStatus = dr["status"].ToString()
                    };
                    applicantsList.Add(appcls);
                }
                con.Close();
            }

            return applicantsList;
        }

        [HttpPost]
        public ActionResult StatusUpdate(int applyId, int applicantId, string status)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_sp_updateApplicantStatus", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@applicant_id", applicantId);
                cmd.Parameters.AddWithValue("@applyid", applyId);
                cmd.Parameters.AddWithValue("@statusname", status);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return RedirectToAction("Applicant_PageLoad");
        }
    }
}
