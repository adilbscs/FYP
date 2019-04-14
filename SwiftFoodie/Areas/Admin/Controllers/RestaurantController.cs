using SwiftFoodie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.Areas.Admin.Controllers
{
    public class RestaurantController : Controller
    {
        DBContextDataBase db = new DBContextDataBase();
        // GET: Admin/Restaurant
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult SaveRestaurant(Restaurants restaurants)
        {
            if (restaurants.RestaurantID == 0)
            {
                restaurants.IsActive = true;
                db.Restaurants.Add(restaurants);
               
            }
            else
            {
                db.Entry(restaurants).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("all");
        }
        public ActionResult All()
        {
            var Rest = db.Restaurants.ToList();
            return View(Rest);
        }
        public ActionResult Edit(long id)
        {
            var res = db.Restaurants.Find(id);
            if (res !=null)
            {
                return View(res);
            }
            else
            {
                return RedirectToAction("");
            }

        }
        public ActionResult DeleteConfirm(long id)
        {
            var res = db.Restaurants.Find(id);
            if (res != null)
            {
                return View(res);
            }
            else
            {
                return RedirectToAction("");
            }

        }
        public ActionResult Delete(long id)
        {
            Restaurants res = db.Restaurants.Find(id);
            if (res != null)
            {
                res.IsActive = false;
                db.Entry(res).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("all");
        }
        public ActionResult dlist()
        {
            var Rest = db.Restaurants.Where(r => r.IsActive == false).ToList();
            return View(Rest);
        }
        public ActionResult alist()
        {
            var Rest = db.Restaurants.Where(r => r.IsActive == true).ToList();
            return View(Rest);
        }
        public ActionResult doactive(long id)
        {
            Restaurants res = db.Restaurants.Find(id);
            if (res != null)
            {
                res.IsActive = true;
                db.Entry(res).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("dlist");
        }
    }
}