using DigitalUpskills.Models;
using DigitalUpskills.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class StudentLoginSystemController : Controller
    {
        Model1 db = new Model1();

        // GET: StudentLoginSystem
        public ActionResult LoginStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginStudent(tbl_Student student)
        {
            TempData["Data"] = "Welcome to knowledge world!";
            if (student.Student_Name == null || student.Student_PhoneNo == null || student.Student_Address == null)
            {
                tbl_Student stu = db.tbl_Student.Where(x => x.Student_Gmail == student.Student_Gmail && x.Student_Password == student.Student_Password).FirstOrDefault();
                if (stu != null)
                {
                    CurrentUser.CurrentStudent = stu;
                    if (Session["cart"] != null)
                    {
                        return RedirectToAction("DisplayCart", "Cart");
                    }
                    return RedirectToAction("Courses","Home");
                }
                else
                {
                    ViewBag.msg = "<script> alert('Invalid Email & Password'</script>)";
                }
            }
            if (ModelState.IsValid)
            {
                db.tbl_Student.Add(student);
                db.SaveChanges();
                ViewBag.msg = "<script> alert( 'Account Is Created Successfully' </script>)";
            }
            return View("IndexUser","Home");
        }

        public ActionResult SignupStudent()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult StudentLogout()
        {
            CurrentUser.CurrentStudent = null;
            return RedirectToAction("IndexUser", "Home");
        }

        
    }
}