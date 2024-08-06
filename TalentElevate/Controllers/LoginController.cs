using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentElevate.Models;
namespace TalentElevate.Controllers
{
    
    public class LoginController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();
        // GET: Login
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult CompanyHome()
        {
            return View();
        }
        public ActionResult LoginClick(LoginCredentialClass clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_loginCred(clsobj.username, clsobj.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_login_id(clsobj.username, clsobj.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_login_type(clsobj.username, clsobj.password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "company")
                    {
                        return RedirectToAction("CompanyHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.msg = "Invalid Credentials";
                    return View("Login_Pageload", clsobj);
                }
            }
            return View("Login_Pageload", clsobj);
        }
    }
}