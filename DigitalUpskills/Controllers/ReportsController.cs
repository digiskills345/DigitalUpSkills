using DigitalUpskills.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class ReportsController : Controller
    {
        Model1 db = new Model1();
        // GET: Reports
        public ActionResult RegistrationReport(DateTime? DateFrom, DateTime? DateTo,int? CourseCategory,int? Course)
        {
            if
                (DateFrom == null)
            {
                DateFrom = DateTime.Today;
            }
            if
                (DateTo == null) 
            {
                DateTo = DateTime.Now;
            }
            ViewBag.DateFrom = DateFrom.Value.ToString("s");
            ViewBag.DateTo = DateTo.Value.ToString("s");
            ViewBag.CourseCategory = new SelectList(db.tbl_CourseCategory, "CourseCategory_Id", "CourseCategory_Name");
            ViewBag.Course = new SelectList(db.tbl_Course, "Course_Id", "Course_Name");
            var register = new List<tbl_CourseRegistration>();
            if (CourseCategory != null)
            {
                register = db.tbl_CourseRegistration.Where(x => x.Status == "Registered" && x.Registration_Date >= DateFrom && x.Registration_Date <= DateTo).OrderByDescending(x => x.Registration_Date).ToList();
                register.All(c => c.tbl_Course.CourseCategory_Fid == CourseCategory);
            }
            else
            {
                register = db.tbl_CourseRegistration.Where(x => x.Status == "Registered" && x.Registration_Date >= DateFrom && x.Registration_Date <= DateTo).OrderByDescending(x => x.Registration_Date).ToList();
            }
             return View(register);
        }

    }
}