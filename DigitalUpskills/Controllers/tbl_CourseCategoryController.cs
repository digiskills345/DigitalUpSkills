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
    public class tbl_CourseCategoryController : Controller
    {
        private Model1 db = new Model1();

        // GET: tbl_CourseCategory
        public ActionResult Index()
        {
            return View(db.tbl_CourseCategory.ToList());
        }

        // GET: tbl_CourseCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CourseCategory tbl_CourseCategory = db.tbl_CourseCategory.Find(id);
            if (tbl_CourseCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CourseCategory);
        }

        // GET: tbl_CourseCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_CourseCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_CourseCategory tbl_CourseCategory, HttpPostedFileBase pic)

        {
            string fullpath = Server.MapPath("~/Content/Projectpic/" + pic.FileName);
            pic.SaveAs(fullpath);
            tbl_CourseCategory.CourseCategory_Image = ("~/Content/Projectpic/" + pic.FileName);

            if (ModelState.IsValid)
            {
                db.tbl_CourseCategory.Add(tbl_CourseCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_CourseCategory);
        }

        // GET: tbl_CourseCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CourseCategory tbl_CourseCategory = db.tbl_CourseCategory.Find(id);
            if (tbl_CourseCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CourseCategory);
        }

        // POST: tbl_CourseCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_CourseCategory tbl_CourseCategory, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/content/projectpic" + pic.FileName);
                pic.SaveAs(fullpath);
                tbl_CourseCategory.CourseCategory_Image = "~/content/projectpic" + pic.FileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(tbl_CourseCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_CourseCategory);
        }
          

        // GET: tbl_CourseCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CourseCategory tbl_CourseCategory = db.tbl_CourseCategory.Find(id);
            if (tbl_CourseCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CourseCategory);
        }

        // POST: tbl_CourseCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_CourseCategory tbl_CourseCategory = db.tbl_CourseCategory.Find(id);
            db.tbl_CourseCategory.Remove(tbl_CourseCategory);
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
