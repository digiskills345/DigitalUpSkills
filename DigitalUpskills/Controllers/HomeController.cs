using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
       
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult CoursesByTeacher(int id)
        {
            var course=db.tbl_Course.Where(x => x.Instructor_Fid == id && x.Is_Approved==true).ToList();
            return View(course);
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

        public ActionResult Courses(int? id,string Search)
        {
            SearchCourses data = new SearchCourses();

            if (Search != null)
            {
                var course = db.tbl_Course.Where(c => c.Is_Approved == true && c.Course_Name.StartsWith(Search)).ToList();
                data.Courses = course;
                return View(data);
            }
            else
            {
                var course = db.tbl_Course.Where(x => x.Is_Approved == true).ToList();
                data.Courses = course;
              
                if (id != null)
                {
                    ViewData["catid"] = id;
                    //ViewBag.catid = id;
                }
                ViewBag.Message = "Your application description page.";
                return View(data);
            }
        }

        public ActionResult Lectures(int? id)

        {
            if (id != null)
            {
                ViewData["lecid"] = id;
                //ViewBag.catid = id;
            }
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Slides(int? id)

        {
            if (id != null)
            {
                ViewData["sid"] = id;
                //ViewBag.catid = id;
            }

            ViewBag.Message = "Your application description page.";
            return View();
        }

   
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(tbl_Message Message)
        {

            if (ModelState.IsValid)
            {
                db.tbl_Message.Add(Message);
                db.SaveChanges();
                ViewBag.msg = "<script> alert('MESSAGE SENT!') </script>";

            }
            return View();
        }


        public ActionResult LoginInstructor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginInstructor(tbl_Instructor instructor)
        {
        //    TempData["Data"] = "Welcome to knowledge world!";
            if (instructor.Instructor_Name == null || instructor.Instructor_PhoneNo == null || instructor.Instructor_Address == null)
            {
                tbl_Instructor inst = db.tbl_Instructor.Where(x => x.Instructor_Gmail == instructor.Instructor_Gmail && x.Instructor_Password == instructor.Instructor_Password).FirstOrDefault();
                if (inst != null)
                {
                    CurrentUser.Currentinstructor = inst;
                    return RedirectToAction("InstructorDashboard","InstructorControls");
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
            return View("CreateCourse");
    }
        public ActionResult SignupInstructor()
        {
            return View();
        }
        public ActionResult ForgotInstructor()
        {
            return View();
        }
        public ActionResult Instructor(int? id)
        {
            if (id != null)
            {
                ViewData["catid"] = id;
            }
            return View();

        }

        public ActionResult InstructorLogout()
        {
            CurrentUser.Currentinstructor = null;
            return RedirectToAction("IndexUser", "Home");
        }

    }
}