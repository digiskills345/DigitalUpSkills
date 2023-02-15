using DigitalUpskills.Models;
using DigitalUpskills.Utills;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class InstructorControlsController : Controller
    {
        // GET: InstructorControls
        Model1 db = new Model1();

        public ActionResult UploadLecture(int id)
        {
            if (db.tbl_Course.Any(x => x.Course_Id == id && x.Is_Approved == true))
            {
                return RedirectToAction("Index", "tbl_Lecture");
            }
            else
            {
                TempData["msg"] = "Kindly wait for your Course approval......!";
                return RedirectToAction("Index", "tbl_Course");
            }

        }

        public ActionResult UploadSlides(int id)
        {
            if (db.tbl_Course.Any(x => x.Course_Id == id && x.Is_Approved == true))
            {
                return RedirectToAction("Index", "tbl_Lecture");
            }
            else
            {
                TempData["msg"] = "Kindly wait for your Course approval......!";
                return RedirectToAction("Index", "tbl_Course");
            }
        }
        public ActionResult InstructorDashboard()
        {
            return View();
        }

        public ActionResult Registrations(int? id)
        {
            if (id != null)
            {
                var registers = db.tbl_CourseRegistration.Where(x => x.tbl_Course.Instructor_Fid == CurrentUser.Currentinstructor.Instructor_Id && x.Status == "Registered").OrderByDescending(x => x.Registration_Date).ToList();
                return View(registers);
            }
            var register = db.tbl_CourseRegistration.Where(x => x.tbl_Course.Instructor_Fid == CurrentUser.Currentinstructor.Instructor_Id && x.Status == "Registered").OrderByDescending(x => x.Registration_Date).ToList();
            return View(register);
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
    
        public ActionResult Edit(tbl_Instructor tbl_Instructor, HttpPostedFileBase pic)
        {
            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    string fullpath = Server.MapPath("~/Content/Projectpic/" + pic.FileName);
                    pic.SaveAs(fullpath);
                    tbl_Instructor.Instructor_Image = ("~/Content/Projectpic/" + pic.FileName);
                }
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
        [HttpPost]

        public ActionResult EditImage( HttpPostedFileBase pic)
        {
            var ins = db.tbl_Instructor.Where(x => x.Instructor_Id ==CurrentUser.Currentinstructor.Instructor_Id).FirstOrDefault();
          
                if (pic != null)
                {
                    string fullpath = Server.MapPath("~/Content/Projectpic/" + pic.FileName);
                    pic.SaveAs(fullpath);
                    ins.Instructor_Image = ("~/Content/Projectpic/" + pic.FileName);
                }
                db.Entry(ins).State = EntityState.Modified;
                db.SaveChanges();
               CurrentUser.Currentinstructor = ins;
                return View("InstructorDashboard");
           
        }
    }
}