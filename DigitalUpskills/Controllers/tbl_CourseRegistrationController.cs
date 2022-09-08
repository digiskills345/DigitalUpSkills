using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalUpskills.Models;

namespace DigitalUpskills.Controllers
{
    public class tbl_CourseRegistrationController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_CourseRegistration
        public ActionResult Index()
        {
            var tbl_CourseRegistration = db.tbl_CourseRegistration.Include(t => t.tbl_Course).Include(t => t.tbl_Student);
            return View(tbl_CourseRegistration.ToList());
        }

        // GET: tbl_CourseRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CourseRegistration tbl_CourseRegistration = db.tbl_CourseRegistration.Find(id);
            if (tbl_CourseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CourseRegistration);
        }

        // GET: tbl_CourseRegistration/Create
        public ActionResult Create()
        {
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name");
            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name");
            return View();
        }

        // POST: tbl_CourseRegistration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_Registraion_Id,Course_Registration_Detail,Payment,Payment_Mode,Student_Fid,Course_Fid")] tbl_CourseRegistration tbl_CourseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.tbl_CourseRegistration.Add(tbl_CourseRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_CourseRegistration.Course_Fid);
            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name", tbl_CourseRegistration.Student_Fid);
            return View(tbl_CourseRegistration);
        }

        // GET: tbl_CourseRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CourseRegistration tbl_CourseRegistration = db.tbl_CourseRegistration.Find(id);
            if (tbl_CourseRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_CourseRegistration.Course_Fid);
            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name", tbl_CourseRegistration.Student_Fid);
            return View(tbl_CourseRegistration);
        }

        // POST: tbl_CourseRegistration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_Registraion_Id,Course_Registration_Detail,Payment,Payment_Mode,Student_Fid,Course_Fid")] tbl_CourseRegistration tbl_CourseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_CourseRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_CourseRegistration.Course_Fid);
            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name", tbl_CourseRegistration.Student_Fid);
            return View(tbl_CourseRegistration);
        }

        // GET: tbl_CourseRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CourseRegistration tbl_CourseRegistration = db.tbl_CourseRegistration.Find(id);
            if (tbl_CourseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CourseRegistration);
        }

        // POST: tbl_CourseRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_CourseRegistration tbl_CourseRegistration = db.tbl_CourseRegistration.Find(id);
            db.tbl_CourseRegistration.Remove(tbl_CourseRegistration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
