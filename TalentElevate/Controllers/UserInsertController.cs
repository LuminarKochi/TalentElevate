using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentElevate.Models;
namespace TalentElevate.Controllers
{
    public class UserInsertController : Controller
    {
        TalentElevateEntities dbobj = new TalentElevateEntities();
        // GET: UserInsert
        public ActionResult Insert_Pageload()
        {
            return View();
        }
        public ActionResult InsertUserClick(UserRegClass clsobj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file.ContentLength > 0)
                {
                    string filenamee = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/PHS");
                    string pa = Path.Combine(s, filenamee);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\PHS", filenamee);
                    clsobj.photo = fullpath;//set
                }
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
                //get
                dbobj.sp_user_reg(regid,clsobj.fname,clsobj.lname,clsobj.age,clsobj.gender,clsobj.address,clsobj.email,clsobj.phone,clsobj.qualification,clsobj.experience,clsobj.skills,clsobj.nationality,clsobj.city,clsobj.state,clsobj.pincode,clsobj.photo);
                dbobj.sp_login(regid, clsobj.username, clsobj.password, "user", "active");
                clsobj.usermsg = "Registration Successfull";
                return View("Insert_Pageload",clsobj);
            }
            return View("Insert_Pageload", clsobj);
        }
    }
}