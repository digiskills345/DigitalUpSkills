using DigitalUpskills.Models;
using DigitalUpskills.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class CourseController : Controller
    {
        Model1 db = new Model1();
        // GET: Course
        public ActionResult CourseDetail(int id)
        {
            var courses = db.tbl_Course.Where(c => c.Course_Id == id).FirstOrDefault();
            return View(courses);
            //if (id == null)
            //{
            //   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //tbl_Course Course = db.tbl_Course.Find(id);
            //if (Course == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(Course);
        }

        public ActionResult Feedback(tbl_Feedback feedback)
        {
            if (CurrentUser.CurrentStudent == null)
            {
                return RedirectToAction("LoginStudent", "StudentLoginSystem");
            }
            feedback.Feedback_Date = DateTime.Now;
            feedback.Student_Fid = CurrentUser.CurrentStudent.Student_Id;
            db.tbl_Feedback.Add(feedback);
            db.SaveChanges();
            return RedirectToAction("CourseDetail", "Course", new { id = feedback.Course_Fid });
        }
    }
}