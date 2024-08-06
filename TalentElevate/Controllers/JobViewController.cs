using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentElevate.Models;
using System.Configuration;

namespace TalentElevate.Controllers
{
    public class JobViewController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();
        // GET: JobView
        public ActionResult searchjob_Pageload()
        {
            return View(GetData());
        }
        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.jobs_tb.ToList();
            foreach (var e in job)
            {
                var jobcls = new UserJobViewClass();
                jobcls.company_id = e.company_id;
                jobcls.job_id = e.job_id;
                jobcls.job_title = e.job_title;
                jobcls.job_description = e.job_description;
                jobcls.job_type = e.job_type;
                jobcls.vacancy = e.vacancy;
                jobcls.salary = e.salary;
                jobcls.skilset = e.skillset;
                jobcls.experience = e.experiance;
                jobcls.location = e.location;
                jobcls.status = e.status;
                jobcls.date = e.last_date;

                joblist.selectjob.Add(jobcls);

                var s = jobcls.skilset;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }
        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            string experience = (clsobj.insertse.experience).ToString();
            if (!string.IsNullOrWhiteSpace(experience))
            {
                qry += " and experiance like '%" + clsobj.insertse.experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skilset))
            {
                qry += " and skillset like '%" + clsobj.insertse.skilset + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.job_type))
            {
                qry += " and job_type like '%" + clsobj.insertse.job_type + "%'";
            }
            return View("searchjob_Pageload", getdata1(clsobj, qry));
        }
        private JobSearch getdata1(JobSearch clsobj,string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                    con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new UserJobViewClass();
                    jobcls.company_id = Convert.ToInt32(dr["company_id"].ToString());
                    jobcls.job_title = dr["job_title"].ToString();
                    jobcls.job_description = dr["job_description"].ToString();
                    jobcls.job_type = dr["job_type"].ToString();
                    jobcls.vacancy = Convert.ToInt32(dr["vacancy"].ToString());
                    jobcls.salary = Convert.ToInt32(dr["salary"].ToString());
                    jobcls.skilset = dr["skillset"].ToString();
                    jobcls.experience = Convert.ToInt32(dr["experiance"].ToString());
                    jobcls.location = dr["location"].ToString();
                    jobcls.status = dr["status"].ToString();
                    jobcls.date = Convert.ToDateTime(dr["last_date"]);

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}