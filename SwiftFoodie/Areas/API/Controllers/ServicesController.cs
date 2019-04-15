using SwiftFoodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.Areas.API.Controllers
{
    public class ServicesController : Controller
    {
        DBContextDataBase db = new DBContextDataBase();
        public JsonResult CustomerLogin(Users user)
        {
            try
            {
               var users= db.Users.Where(u=>u.UserName==user.UserName && u.Password==user.Password && u.IsActive==true && u.Role==2).FirstOrDefault();
                if (users !=null)
                {
                    return Json(new { msg = "found" ,response = users }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { msg = "notfound" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg= "exception", response=ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RegisterCustomer(Users user)
        {
            try
            {
                var users = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password ).FirstOrDefault();
                if (users == null)
                {
                    users.IsActive = true;
                    user.Role = 2;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Json(new { msg = "success", response = users }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { msg = "exists" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = "exception", response = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult RiderLogin(Users user)
        {
            try
            {
                var users = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password && u.IsActive == true && u.Role == 3).FirstOrDefault();
                if (users != null)
                {
                    return Json(new { msg = "found", response = users }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { msg = "notfound" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { msg = "exception", response = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}