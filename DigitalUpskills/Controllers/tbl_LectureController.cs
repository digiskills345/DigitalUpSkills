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
    public class tbl_LectureController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_Lecture
        public ActionResult Index()
        {
            var tbl_Lecture = db.tbl_Lecture.Include(t => t.tbl_Course);
            return View(tbl_Lecture.ToList());
        }

        // GET: tbl_Lecture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Lecture tbl_Lecture = db.tbl_Lecture.Find(id);
            if (tbl_Lecture == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Lecture);
        }

        // GET: tbl_Lecture/Create
        public ActionResult Create(int id)
        {
            ViewBag.Course_Fid = new SelectList(db.tbl_Course.Where(x=>x.Course_Id== id), "Course_Id", "Course_Name");
            return View();
        }

        // POST: tbl_Lecture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Lecture tbl_Lecture, HttpPostedFileBase Video)
        {
            string fullpath = Server.MapPath("~/Content/Lecture-Video/" + Video.FileName);
            Video.SaveAs(fullpath);
            tbl_Lecture.Video_Lecture_Path = ("~/Content/Lecture-Video/" + Video.FileName);
            db.tbl_Lecture.Add(tbl_Lecture);
            db.SaveChanges();
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_Lecture.Course_Fid);
            return View("Index");
        }


        // GET: tbl_Lecture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Lecture tbl_Lecture = db.tbl_Lecture.Find(id);
            if (tbl_Lecture == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_Lecture.Course_Fid);
            return View(tbl_Lecture);
        }

        // POST: tbl_Lecture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Lecture tbl_Lecture, HttpPostedFileBase Video)
        {
            if (Video != null)
            {
                string fullpath = Server.MapPath("~/content/Lecture-Video" + Video.FileName);
                Video.SaveAs(fullpath);
                tbl_Lecture.Video_Lecture_Path = "~/content/Lecture-Video" + Video.FileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(tbl_Lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_Lecture.Course_Fid);
            return View(tbl_Lecture);
        }

        // GET: tbl_Lecture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Lecture tbl_Lecture = db.tbl_Lecture.Find(id);
            if (tbl_Lecture == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Lecture);
        }

        // POST: tbl_Lecture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Lecture tbl_Lecture = db.tbl_Lecture.Find(id);
            db.tbl_Lecture.Remove(tbl_Lecture);
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
