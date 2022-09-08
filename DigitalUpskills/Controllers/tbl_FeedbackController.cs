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
    public class tbl_FeedbackController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_Feedback
        public ActionResult Index()
        {
            var tbl_Feedback = db.tbl_Feedback.Include(t => t.tbl_Student);
            return View(tbl_Feedback.ToList());
        }

        // GET: tbl_Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Feedback tbl_Feedback = db.tbl_Feedback.Find(id);
            if (tbl_Feedback == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Feedback);
        }

        // GET: tbl_Feedback/Create
        public ActionResult Create()
        {
            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name");
            return View();
        }

        // POST: tbl_Feedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Feedback_Id,Feedback_Description,Feedback_Rating,Student_Fid")] tbl_Feedback tbl_Feedback)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Feedback.Add(tbl_Feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name", tbl_Feedback.Student_Fid);
            return View(tbl_Feedback);
        }

        // GET: tbl_Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Feedback tbl_Feedback = db.tbl_Feedback.Find(id);
            if (tbl_Feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name", tbl_Feedback.Student_Fid);
            return View(tbl_Feedback);
        }

        // POST: tbl_Feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Feedback_Id,Feedback_Description,Feedback_Rating,Student_Fid")] tbl_Feedback tbl_Feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_Fid = new SelectList(db.tbl_Student, "Student_Id", "Student_Name", tbl_Feedback.Student_Fid);
            return View(tbl_Feedback);
        }

        // GET: tbl_Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Feedback tbl_Feedback = db.tbl_Feedback.Find(id);
            if (tbl_Feedback == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Feedback);
        }

        // POST: tbl_Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Feedback tbl_Feedback = db.tbl_Feedback.Find(id);
            db.tbl_Feedback.Remove(tbl_Feedback);
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
