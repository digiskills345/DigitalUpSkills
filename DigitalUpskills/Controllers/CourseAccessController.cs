using DigitalUpskills.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
   
    public class CourseAccessController : Controller
    {
        private Model1 db = new Model1();
        // GET: CourseAccess

        public ActionResult Index()
        {
            var course = db.tbl_Course.Where(x => x.Is_Approved == true).ToList();
            return View(course);
        }

        // GET: SHOP_tbl
        public ActionResult NewCourses()
        {
            var newcourse = db.tbl_Course.Where(x => x.Is_Approved == false).ToList();
            return View(newcourse);
        }

        public ActionResult Approve(int id)
        {
            var courses = db.tbl_Course.Where(x => x.Course_Id == id).FirstOrDefault();
            courses.Is_Approved = true;
            db.Entry(courses).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "<script>alert('Course Approved')</script>";
            return RedirectToAction("Index");
        }


        // GET: SHOP_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Course tbl_Course = db.tbl_Course.Find(id);
            if (tbl_Course == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Course);
        }

        // POST: SHOP_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Course tbl_Course = db.tbl_Course.Find(id);
            db.tbl_Course.Remove(tbl_Course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}