using DigitalUpskills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class AdminLoginSystemController : Controller
    {
        Model1 db = new Model1();
        // GET: AdminLoginSystem

        public ActionResult LoginAdmin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string Email, string Password)
        {

            int v = db.tbl_Admin.Where(x => x.Admin_Gmail == Email && x.Admin_Password == Password).Count();
            if (v > 0)
            {
                return RedirectToAction("IndexAdmin","Home");
            }
            else
            {
                ViewBag.loginerror = "Incorrect Email or Passsword";
                return View();
            }

        }
    }
}