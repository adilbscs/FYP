using SwiftFoodie.Models;
using SwiftFoodie.Models.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoLogin(Users users)
        {
            string Action = "login";
            string Response = IsValidUser(users);
            if (Response=="Admin")
            {
                return RedirectToAction("dashboard", "home", new { Area = "Admin" });
            }
            else if (Response == "Resturant")
            {
                return RedirectToAction("dashboard", "home");
            }
            else
            {
                ViewBag.loginError = "notfound";
                return RedirectToAction("", "Login");
            }
        }

        private string IsValidUser(Users user)
        {
            string msg = "not found";
            DBContextDataBase db = new DBContextDataBase();
            //string password = EncryptDecrypt.Encrypt(user.Password, true);
            


            var obj = db.Users.Where(u=>u.UserName==user.UserName && u.Password == user.Password && u.IsActive==true && u.Role==1).FirstOrDefault();
            if (obj != null)
            {
                Session["FirstName"] = obj.FirstName;
                Session["LastName"] = obj.LastName;
                Session["username"] = obj.UserName;
                Session["Password"] = user.Password;
                Session["Email"] = obj.Email;
                Session["UserID"] = obj.UserID.ToString();
                Session["Role"] = obj.Role;
                if (obj.Role == 1)
                {
                    Session["RoleName"] = msg = "Admin";

                }
                Session["Phone"] = obj.Phone;
                
            }
            else
            {
               var  objRes = db.Restaurants.Where(u => u.UserName == user.UserName && u.Password == user.Password && u.IsActive == true).FirstOrDefault();
                if (objRes !=null)
                {
                    Session["RestaurantName"] = objRes.RestaurantName;
                    Session["OwnerName"] = objRes.OwnerName;
                    Session["username"] = objRes.UserName;
                    Session["Password"] = user.Password;
                    Session["RestaurantID"] = objRes.RestaurantID.ToString();
                    Session["RoleName"] = msg = "Resturant";
                    Session["Phone"] = objRes.PhoneNumber;
                }
            }


            //if (user.RememberMe == true)
            //{

            //    HttpCookie cookie = new HttpCookie("SF");
            //    cookie.Values.Add("UserName", obj.UserName);
            //    cookie.Expires = DateTime.Now.AddDays(15);
            //    Response.Cookies.Add(cookie);
            //}
            //else
            //{
            //    HttpCookie myCookie = new HttpCookie("SF");
            //    myCookie.Expires = DateTime.Now.AddDays(-1d);
            //    Response.Cookies.Add(myCookie);
            //}
           return msg;
            //return "Admin";
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("","login");

        }
    }
}