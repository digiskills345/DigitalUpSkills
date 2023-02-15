using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalUpskills.Models;
using DigitalUpskills.Utills;

namespace DigitalUpskills.Controllers
{
    public class tbl_SlideController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_Slide
        public ActionResult Index()
        {
            var tbl_Slide = db.tbl_Slide.Include(t => t.tbl_Course);
            return View(tbl_Slide.ToList());
        }

        // GET: tbl_Slide/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Slide tbl_Slide = db.tbl_Slide.Find(id);
            if (tbl_Slide == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Slide);
        }

        // GET: tbl_Slide/Create
        public ActionResult Create()
        {
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name");
            return View();
        }

        // POST: tbl_Slide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Slide tbl_Slide, HttpPostedFileBase pdf)
        {
            string fullpath = Server.MapPath("~/Content/Slides/" + pdf.FileName);
            pdf.SaveAs(fullpath);
            tbl_Slide.Slide_PDF = "~/Content/Slides/" +pdf.FileName;
            db.tbl_Slide.Add(tbl_Slide);
            db.SaveChanges();
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_Slide.Course_Fid);
            return View(tbl_Slide);
        }

        // GET: tbl_Slide/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Slide tbl_Slide = db.tbl_Slide.Find(id);
            if (tbl_Slide == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_Slide.Course_Fid);
            return View(tbl_Slide);
        }

        // POST: tbl_Slide/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Slide tbl_Slide, HttpPostedFileBase pdf)
        {
            if (pdf != null)
            {
                string fullpath = Server.MapPath("~/content/Slides" + pdf.FileName);
                pdf.SaveAs(fullpath);
               // tbl_Slide.Slide_PDF = "~/content/Slides" + pdf.FileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(tbl_Slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Fid = new SelectList(db.tbl_Course, "Course_Id", "Course_Name", tbl_Slide.Course_Fid);
            return View(tbl_Slide);
        }

        // GET: tbl_Slide/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Slide tbl_Slide = db.tbl_Slide.Find(id);
            if (tbl_Slide == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Slide);
        }

        // POST: tbl_Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Slide tbl_Slide = db.tbl_Slide.Find(id);
            db.tbl_Slide.Remove(tbl_Slide);
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
