using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentElevate.Models;

namespace TalentElevate.Controllers
{
    public class JobsController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();

        // GET: Jobs
        public ActionResult Jobs_Pageload()
        {
            // Populate dropdown list for job types
            List<jobtypecls> jobtype = new List<jobtypecls>
            {
                new jobtypecls { jId = 1, jName = "Full Time" },
                new jobtypecls { jId = 2, jName = "Part Time" },
                new jobtypecls { jId = 3, jName = "Internship" }
            };
            ViewBag.selectjobtype = new SelectList(jobtype, "jId", "jName");
            return View();
        }

        [HttpPost]
        public ActionResult AddJob_click(JobClass clsobj, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                // Populate dropdown list for job types
                List<jobtypecls> jobtype = new List<jobtypecls>
                {
                    new jobtypecls { jId = 1, jName = "Full Time" },
                    new jobtypecls { jId = 2, jName = "Part Time" },
                    new jobtypecls { jId = 3, jName = "Internship" }
                };
                ViewBag.selectjobtype = new SelectList(jobtype, "jId", "jName");

                int selectedId = Convert.ToInt32(form["ddljobtype"]);
                jobtypecls selectedItem = jobtype.FirstOrDefault(c => c.jId == selectedId);
                clsobj.jId = selectedItem.jId;
                clsobj.jName = selectedItem.jName;

                // Convert the date string to DateTime
                DateTime lastDate;
                if (!DateTime.TryParse(clsobj.date, out lastDate))
                {
                    ModelState.AddModelError("", "Invalid date format.");
                    return View("Jobs_Pageload", clsobj);
                }

                // Ensure the time component is set to 00:00:00
                lastDate = lastDate.Date;

                // Insert job
                string cid = Session["uid"].ToString();
                int companyid = Convert.ToInt32(cid);

                dbobj.sp_jobs(companyid, clsobj.job_title, clsobj.job_description, clsobj.jName, clsobj.vacancy, clsobj.salary, clsobj.skilset, clsobj.experience, clsobj.location, clsobj.status, lastDate);
                clsobj.msg = "Job Added Successfully";

                return View("Jobs_Pageload", clsobj);
            }
            else
            {
                return View("Jobs_Pageload", clsobj);
            }
        }
    }
}
