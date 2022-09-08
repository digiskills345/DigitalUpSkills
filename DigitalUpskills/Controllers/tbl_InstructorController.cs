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
    public class tbl_InstructorController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_Instructor
        public ActionResult Index()
        {
            return View(db.tbl_Instructor.ToList());
        }

        // GET: tbl_Instructor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Instructor tbl_Instructor = db.tbl_Instructor.Find(id);
            if (tbl_Instructor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Instructor);
        }

        // GET: tbl_Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Instructor tbl_Instructor, HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/Content/Projectpic/" + pic.FileName);
            pic.SaveAs(fullpath);
            tbl_Instructor.Instructor_Image = ("~/Content/Projectpic/" + pic.FileName);

            if (ModelState.IsValid)
            {
                db.tbl_Instructor.Add(tbl_Instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: tbl_Instructor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Instructor tbl_Instructor = db.tbl_Instructor.Find(id);
            if (tbl_Instructor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Instructor);
        }

        // POST: tbl_Instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Instructor tbl_Instructor, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/content/projectpic/" + pic.FileName);
                pic.SaveAs(fullpath);
                tbl_Instructor.Instructor_Image = "~/content/projectpic/" + pic.FileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(tbl_Instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Instructor);
        }
            // GET: tbl_Instructor/Delete/5
            public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Instructor tbl_Instructor = db.tbl_Instructor.Find(id);
            if (tbl_Instructor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Instructor);
        }

        // POST: tbl_Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Instructor tbl_Instructor = db.tbl_Instructor.Find(id);
            db.tbl_Instructor.Remove(tbl_Instructor);
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
