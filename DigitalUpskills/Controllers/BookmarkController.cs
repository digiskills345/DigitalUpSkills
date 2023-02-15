using DigitalUpskills.Models;
using DigitalUpskills.Utills;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalUpskills.Controllers
{
    public class BookmarkController : Controller
    {
        Model1 db = new Model1();
        // GET: Bookmark

        public ActionResult DisplayBookmark(int? id)
        {
            if (id != null)
            {
                var Bookmark = db.tbl_Bookmark.Where(x => x.Student_Fid == CurrentUser.CurrentStudent.Student_Id && x.Student_Fid == id).ToList();
                return View(Bookmark);
            }
            var bookmark = db.tbl_Bookmark.Where(x => x.Student_Fid == CurrentUser.CurrentStudent.Student_Id).ToList();
            return View(bookmark);
        }

        public ActionResult bookmark(int id)
        {
            if (CurrentUser.CurrentStudent == null)
            {
                return RedirectToAction("LoginStudent", "StudentLoginSystem");
            }

            if (db.tbl_Bookmark.Any(x => x.Course_Fid == id && x.Student_Fid == CurrentUser.CurrentStudent.Student_Id))
            {
                tbl_Bookmark bookmark = db.tbl_Bookmark.Where(x => x.Course_Fid == id && x.Student_Fid == CurrentUser.CurrentStudent.Student_Id).FirstOrDefault();
                db.tbl_Bookmark.Remove(bookmark);
                db.SaveChanges();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    tbl_Bookmark Bookmark = new tbl_Bookmark();
                    Bookmark.Course_Fid = id;
                    Bookmark.Student_Fid = CurrentUser.CurrentStudent.Student_Id;
                    db.tbl_Bookmark.Add(Bookmark);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Courses", "Home");
        }
    }
}