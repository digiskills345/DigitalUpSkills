using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalUpskills.Models;
using DigitalUpskills.Utills;

namespace DigitalUpskills.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult IndexUser()
        {
            string s = (string)TempData.Peek("Data");
            return View();
        }
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
                    return RedirectToAction("Courses");

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
            return View("IndexUser");
        }

        public ActionResult Logout()
        {
            if (CurrentUser.CurrentStudent != null)
            {
                db.SaveChanges();
                return RedirectToAction("IndexUser");
            }
            return RedirectToAction("LoginStudent");
        }
            
        public ActionResult SignupStudent()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        } 
        public ActionResult CourseCategory()
            
        {
          
            return View();
        } 
        public ActionResult Courses(int? id)
        {
            if (id != null)
            {
                ViewData["catid"] = id;
                //ViewBag.catid = id;
            }

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LoginAdmin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(string Email, string Password)
        {

            int v = db.tbl_Admin.Where(x => x.Admin_Gmail == Email && x.Admin_Password == Password).Count();
            if (v > 0)
            {
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.loginerror = "Incorrect Email or Passsword";
                return View();
            }

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LoginInstructor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginInstructor(tbl_Instructor instructor)
        {
            TempData["Data"] = "Welcome to knowledge world!";
            if (instructor.Instructor_Name == null || instructor.Instructor_PhoneNo == null || instructor.Instructor_Address == null)
            {
                tbl_Instructor inst = db.tbl_Instructor.Where(x => x.Instructor_Gmail == instructor.Instructor_Gmail && x.Instructor_Password == instructor.Instructor_Password).FirstOrDefault();
                if (inst != null)
                {
                    CurrentUser.Currentinstructor = inst;
                    return RedirectToAction("Index");
                    //if (Session["cart"] != null)
                    //{
                    //    return RedirectToAction("DisplayCart", "Cart");
                    //}
                    //return RedirectToAction("Instructor");

                }
                else
                {
                    ViewBag.msg = "<script> alert('Invalid Email & Password'</script>)";
                }
            }
             
            if (ModelState.IsValid)
            {
                db.tbl_Instructor.Add(instructor);
                db.SaveChanges();
                ViewBag.msg = "<script> alert('Account is created Successfully'</script>)";
            }
            return View();
      
    }
        public ActionResult SignupInstructor()
        {
            return View();
        }
        public ActionResult ForgotInstructor()
        {
            return View();
        }
        public ActionResult Instructor()
        {
            return View();

        }
    }
}