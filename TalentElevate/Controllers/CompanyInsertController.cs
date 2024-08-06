using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentElevate.Models;
namespace TalentElevate.Controllers
{
    public class CompanyInsertController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();
        // GET: CompanyInsert
        public ActionResult Insert_Pageload()
        {
            return View();
        }
        public ActionResult ConpanyInsertClick(ComRegClass clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MAXidLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_company_reg(regid, clsobj.cname, clsobj.cemail, clsobj.cphone, clsobj.description, clsobj.website);
                dbobj.sp_login(regid, clsobj.cusername, clsobj.cpassword,"company","active");
               // Session["cid"] = regid;
                clsobj.msg = "Registration Successful";
                return View("Insert_Pageload", clsobj);
            }
            return View("Insert_Pageload", clsobj);
        }
    }
}