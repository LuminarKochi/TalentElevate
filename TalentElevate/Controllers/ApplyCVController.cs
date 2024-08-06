using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentElevate.Models;

namespace TalentElevate.Controllers
{
    public class ApplyCVController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();

        // GET: ApplyCV
        public ActionResult ApplyCV_Load(int cid, int jid)
        {
            var model = new ApplyCVClass
            {
                company_id = cid, // Update property names to match model
                job_id = jid
            };
            return View(model);
        }

        public ActionResult Apply_click(ApplyCVClass clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                int cid = clsobj.company_id;
                int jid = clsobj.job_id;

                // Get the job's last date
                DateTime jobLastDate = GetJobLastDate(jid);

                // Check if the current date is after the job's last date
                if (DateTime.Now.Date > jobLastDate)
                {
                    clsobj.msg = "Cannot apply as the job application period has ended.";
                    return View("ApplyCV_Load", clsobj); // Ensure we pass the model
                }

                // Handle file upload
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/resu"), filename);
                    file.SaveAs(path);

                    // Set resume path
                    var fullpath = Path.Combine("~\\resu", filename);
                    clsobj.resume = fullpath;
                }

                int uid = Convert.ToInt32(Session["uid"]);
                string status = "Applied";

                // Call stored procedure to insert application
                dbobj.sp_apply(uid, jid, clsobj.resume, DateTime.Now.Date, status);

                clsobj.msg = "Application submitted successfully.";
            }

            return View("ApplyCV_Load", clsobj); // Ensure we pass the model
        }

        private DateTime GetJobLastDate(int jobId)
        {
            var job = dbobj.jobs_tb.FirstOrDefault(j => j.job_id == jobId);
            if (job != null)
            {
                return job.last_date;
            }
            throw new Exception("Job not found.");
        }

    }
}
