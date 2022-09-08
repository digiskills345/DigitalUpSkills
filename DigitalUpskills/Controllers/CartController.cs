using DigitalUpskills.Models;
using DigitalUpskills.Utills;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        //private object system;

        // GET: Cart
        public ActionResult Addtocart(int id)
        {
            List<tbl_Course> CartList = new List<tbl_Course>();
            if (Session["cart"] != null)
            {
                CartList = (List<tbl_Course>)Session["cart"];
            }
            tbl_Course tbl_Course = db.tbl_Course.Where(x => x.Course_Id == id).FirstOrDefault();
            CartList.Add(tbl_Course);
            Session["cart"] = CartList;

            return RedirectToAction("DisplayCart");

        }

        public ActionResult RemoveFromCart(int id)
        {
            List<tbl_Course> list = new List<tbl_Course>();
            list = (List<tbl_Course>)Session["cart"];
            list.RemoveAt(id);
            Session["cart"] = list;
            return View("DisplayCart");
        }

        public ActionResult DisplayCart()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            if (CurrentUser.CurrentStudent == null)
            {
                return RedirectToAction("LoginStudent", "Home");
            }
            return View();
        }

        public ActionResult CourseRegistered(tbl_CourseRegistration registered)
        {
            List<tbl_Course> list = new List<tbl_Course>();
            list = (List<tbl_Course>)Session["cart"];
            var data = list.FirstOrDefault();
            registered.Status = "Registered";
            registered.Student_Fid = CurrentUser.CurrentStudent.Student_Id;
            registered.Registration_Date = DateTime.Now;
            registered.Course_Fid = data.Course_Id;
            db.tbl_CourseRegistration.Add(registered);
            db.SaveChanges();
            string mailBody = "Your Course Has Been Registered!";
            EmailProvider.Email(registered.Gmail, "Course Registered", mailBody);
            TempData["registered"] = Session["cart"];
            Session["cart"] = null;
            return RedirectToAction("RegistrationCompleted");
        }
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
           var student= db.tbl_Student.Where( x=> x.Student_Gmail==email).FirstOrDefault();
            if (student == null)
            {
                TempData["error"] = "Invalid Email";
                return RedirectToAction("LoginStudent");
            }
           Random random = new Random();
            int code = random.Next(1001, 9999);
            Session["code"]=code;
            Session["userforgotpassword"]=student;
            Email.SendEmail(student.Student_Gmail,code);
            return RedirectToAction("codeverify");
            //string RecieverEmail = "";
            //string SubjEmail = "Subject";
            //Random R = new Random();
            //int a= R.Next(1000,9999);
            //string EmailBody = "Your Code Is" + a;
            //EmailProvider.Email(RecieverEmail, SubjEmail, EmailBody);
        }

        public ActionResult RegistrationCompleted()
        {
            return View();
        }
    
        public ActionResult codeverify()
        {
            return View();
        }
        [HttpPost]
        public ActionResult codeverify(int code)
        {
            int sendcode = (int)Session["code"];
            if (code == sendcode)
            {
                return RedirectToAction("NewPassword");
            }
            TempData["erro"] = "Invalid Code";
            return View();
        }
        public ActionResult NewPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPassword(string password)
        {
            var user = (tbl_Student)Session["userforgotpassword"];
            var updatestudent= db.tbl_Student.Where(x => x.Student_Gmail == user.Student_Gmail).FirstOrDefault();
            updatestudent.Student_Password = password;
            db.Entry(updatestudent).State= EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "Password Updated Successfully!";
            return RedirectToAction("LoginStudent");
        }
    }
}
