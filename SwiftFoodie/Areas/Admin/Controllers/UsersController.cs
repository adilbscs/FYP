using SwiftFoodie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        DBContextDataBase db = new DBContextDataBase();
        

        public ActionResult All()
        {
            var user = db.Users.ToList();
            return View(user);
        }
        public ActionResult details(long id)
        {
            var Users = db.Users.Find(id);
            if (Users != null)
            {
                return View(Users);
            }
            else
            {
                return RedirectToAction("");
            }

        }

        public ActionResult DeleteConfirm(long id)
        {
            var Users = db.Users.Find(id);
            if (Users != null)
            {
                return View(Users);
            }
            else
            {
                return RedirectToAction("");
            }

        }
        public ActionResult Delete(long id)
        {
            Users Users = db.Users.Find(id);
            if (Users != null)
            {
                Users.IsActive = false;
                db.Entry(Users).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("all");
        }
        public ActionResult dlist()
        {
            var Users = db.Users.Where(r => r.IsActive == false).ToList();
            return View(Users);
        }
        public ActionResult alist()
        {
            var Users = db.Users.Where(r => r.IsActive == true).ToList();
            return View(Users);
        }
        public ActionResult doactive(long id)
        {
            Users Users = db.Users.Find(id);
            if (Users != null)
            {
                Users.IsActive = true;
                db.Entry(Users).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("dlist");
        }
    }
}