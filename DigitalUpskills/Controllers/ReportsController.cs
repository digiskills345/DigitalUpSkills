using DigitalUpskills.Models;
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
        public ActionResult RegistrationReport(DateTime? DateFrom, DateTime? DateTo)
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
                ViewBag.DateFrom = DateFrom.Value.ToString("s");
                ViewBag.DateTo = DateTo.Value.ToString("s");
                ViewBag.CourseCategory = new SelectList(db.tbl_CourseCategory, "CourseCategory_Id", "CourseCategory_Name");
                ViewBag.Course = new SelectList(db.tbl_Course, "Course_Id", "Course_Name");

            }
            var register = db.tbl_CourseRegistration.Where(x => x.Status == "Registered" && x.Registration_Date >= DateFrom && x.Registration_Date <= DateTo).OrderByDescending(x => x.Registration_Date).ToList();
            return View(register);
        }

    }
}