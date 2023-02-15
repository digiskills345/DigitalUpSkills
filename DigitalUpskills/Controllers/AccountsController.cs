using DigitalUpskills.Models;
using DigitalUpskills.Utills;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class AccountsController : Controller
    {
        Model1 db = new Model1();
        // GET: Accounts

        public ActionResult StudentDashboard()
        {
            return View();
        }

        public ActionResult RegisterdCourses(int? id)
        {
            if (id != null)
            {
                var registers = db.tbl_CourseRegistration.Where(x => x.Student_Fid == CurrentUser.CurrentStudent.Student_Id && x.Status == "Registered" && x.Student_Fid == id).OrderByDescending(x => x.Registration_Date).ToList();
                return View(registers);
            }
            var register = db.tbl_CourseRegistration.Where(x => x.Student_Fid == CurrentUser.CurrentStudent.Student_Id && x.Status == "Registered").OrderByDescending(x => x.Registration_Date).ToList();
            return View(register);
        }

        [HttpPost]
        public ActionResult EditImage(HttpPostedFileBase pic)
        {
            tbl_Student student = new tbl_Student();
            student = db.tbl_Student.Where(x => x.Student_Id == CurrentUser.CurrentStudent.Student_Id).FirstOrDefault();
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/content/projectpic" + pic.FileName);
                pic.SaveAs(fullpath);
                student.Student_Image = "~/content/projectpic" + pic.FileName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                CurrentUser.CurrentStudent=student; 
                return RedirectToAction("StudentDashboard");
            }
            //ViewData["]
            return View("StudentDashboard");
        }

        // GET: tbl_Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // POST: tbl_Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_Id,Student_Name,Student_CNIC,Student_Gmail,Student_PhoneNo,Student_Address")] tbl_Student tbl_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Student);
        }

        // GET: tbl_Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // POST: tbl_Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            db.tbl_Student.Remove(tbl_Student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult WatchVideo(int id)
        //{
        //    var video = GetVideoById(id);
        //    return View(video);
        //}

        //[HttpPost]
        //public ActionResult UpdateVideoStatus(int id, string videoWatched)
        //{
        //    UpdateVideoWatchedStatus(id, videoWatched == "true");
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult UpdateVideoStatus(int id, string videoWatched)
        //{
        //    UpdateVideoWatchedStatus(id, videoWatched == "true");
        //    if (videoWatched == "true")
        //    {
        //        var userId = GetCurrentUserId();
        //        var certificate = GenerateCertificate(userId);
        //        SaveCertificate(certificate);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public Certificate GenerateCertificate(int userId)
        //{
        //    var certificate = new Certificate
        //    {
        //        UserId = userId,
        //        CertificateNumber = GenerateCertificateNumber(),
        //        DateIssued = DateTime.Now
        //    };
        //    return certificate;
        //}

        //public ActionResult ViewCertificate()
        //{
        //    var userId = GetCurrentUserId();
        //    var certificate = GetCertificateByUserId(userId);
        //    return View(certificate);
        //}


        //public ActionResult MyAccount()
        //{
        //    ViewBag.Message = "Your Account page.";

        //    return View();
        //}
        //public ActionResult OrderHistory(int Orderid)
        //{
        //    var order = db.ORDER_DETAIL_tbl.Where(o => o.ORDER_FID == Orderid).ToList();
        //    return View(order);
        //}
        //public ActionResult Address()
        //{
        //    var address = db.CUSTOMER_tbl.Where(x => x.CUSTOMER_ID == CurrentUser.CurrentCustomer.CUSTOMER_ID).FirstOrDefault();
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult EditAddress(CUSTOMER_tbl cus)
        //{

        //    var updateCustomer = db.CUSTOMER_tbl.Where(x => x.CUSTOMER_ID == CurrentUser.CurrentCustomer.CUSTOMER_ID).FirstOrDefault();

        //    updateCustomer.CUSTOMER_NAME = CurrentUser.CurrentCustomer.CUSTOMER_NAME;
        //    updateCustomer.CUSTOMER_EMAIL = CurrentUser.CurrentCustomer.CUSTOMER_EMAIL;
        //    updateCustomer.CUSTOMER_CONTACT = CurrentUser.CurrentCustomer.CUSTOMER_CONTACT;
        //    updateCustomer.CUSTOMER_PASSWORD = CurrentUser.CurrentCustomer.CUSTOMER_PASSWORD;
        //    updateCustomer.CUSTOMER_ADDRESS = cus.CUSTOMER_ADDRESS;
        //    db.Entry(updateCustomer).State = EntityState.Modified;
        //    db.SaveChanges();
        //    CurrentUser.CurrentCustomer = cus;
        //    TempData["msg"] = "Address Updated Successfully";
        //    return RedirectToAction("MyAccount");

        //}



        //[HttpPost]
        //public ActionResult UpdateAccount(CUSTOMER_tbl cus)
        //{

        //    var updateCustomer = db.CUSTOMER_tbl.Where(x => x.CUSTOMER_ID == CurrentUser.CurrentCustomer.CUSTOMER_ID).FirstOrDefault();

        //    updateCustomer.CUSTOMER_ADDRESS = cus.CUSTOMER_ADDRESS;
        //    updateCustomer.CUSTOMER_NAME = cus.CUSTOMER_NAME;
        //    updateCustomer.CUSTOMER_EMAIL = cus.CUSTOMER_EMAIL;
        //    updateCustomer.CUSTOMER_CONTACT = cus.CUSTOMER_CONTACT;
        //    updateCustomer.CUSTOMER_PASSWORD = cus.CUSTOMER_PASSWORD;

        //    db.Entry(updateCustomer).State = EntityState.Modified;
        //    db.SaveChanges();
        //    CurrentUser.CurrentCustomer = cus;
        //    TempData["msg"] = "Account Updated Successfully";
        //    return RedirectToAction("MyAccount");

        //}
    }
}