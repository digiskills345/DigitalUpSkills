using DigitalUpskills.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class AdminSideController : Controller
    {
        Model1 db = new Model1();
        //private int id;


        // GET: AdminSide
        public ActionResult NewRegistrations()
        {
            var registers = db.tbl_CourseRegistration.Where(x => x.Status == "Registered").OrderByDescending(x=>x.Registration_Date).ToList();
            return View(registers);
        }
        public ActionResult Invoice(int id)
        {
            var register = db.tbl_CourseRegistration.Where(x => x.Course_Registraion_Id ==id).FirstOrDefault();
            return View(register);
        }
        public ActionResult Addtoregister(int id)
        {
            var register = db.tbl_CourseRegistration.Where(x => x.Course_Registraion_Id == id).FirstOrDefault();
            register.Status = "Registered";
            db.Entry(register).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "<script> alert('Registration update')<script/> ";
            return RedirectToAction("NewRegistrations");
        }
    }
}