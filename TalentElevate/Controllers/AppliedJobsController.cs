using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentElevate.Models;

namespace TalentElevate.Controllers
{
    public class AppliedJobsController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();
        // GET: AppliedJobs
        public ActionResult appliedjob_pageload()
        {
            var userId = Session["uid"] != null ? Convert.ToInt32(Session["uid"]) : 0;
            return View(GetAppliedJobs(userId));
        }
        private List<AppliedJobsViewClass> GetAppliedJobs(int userid)
        {
            var appliedjobList = new List<AppliedJobsViewClass>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_appiedjobsview", con); // Corrected this line
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var appliedjob = new AppliedJobsViewClass
                    {
                        companyname = dr["company_name"].ToString(),
                        jobtitle = dr["job_title"].ToString(),
                        jobdescription = dr["job_description"].ToString(),
                        jobtype = dr["job_type"].ToString(),
                        salary = Convert.ToInt32(dr["salary"]),
                        vaccancy = Convert.ToInt32(dr["vacancy"]),
                        lastdate = dr["last_date"].ToString(),
                        status = dr["job_status"].ToString(),
                        applieddate = dr["apply_date"].ToString(),
                    };
                    appliedjobList.Add(appliedjob);
                }
                con.Close();
            }
            return appliedjobList;
        }
    }
}