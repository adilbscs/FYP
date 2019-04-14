using SwiftFoodie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        DBContextDataBase db = new DBContextDataBase();

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult List()
        {
            long ResId = Convert.ToInt64(Session["RestaurantID"]);

            var menus = db.Menu.Where(m => m.Status == true && m.ResturantID== ResId).ToList();
            return View(menus);
        }
        public ActionResult IList()
        {
            long ResId = Convert.ToInt64(Session["RestaurantID"]);

            var menus = db.Menu.Where(m => m.Status == false && m.ResturantID == ResId).ToList();
            return View(menus);
        }
        public ActionResult Save(Menu objMenu)
        {
            if (objMenu != null)
            {
                if (objMenu.MenuID == 0)
                {
                    long ResId = Convert.ToInt64(Session["RestaurantID"]);

                    objMenu.ResturantID = ResId;
                    objMenu.Status = true;
                    db.Menu.Add(objMenu);

                }
                else
                {
                    db.Entry(objMenu).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("add");
            }
        }
        public ActionResult Active(long id)
        {
            var objMenu = db.Menu.Find(id);
            if (objMenu != null)
            {
                objMenu.Status = true;
                db.Entry(objMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("add");
            }
        }
        public ActionResult IActive(long id)
        {
            var objMenu = db.Menu.Find(id);
            if (objMenu != null)
            {
                objMenu.Status = false;
                db.Entry(objMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ilist");
            }
            else
            {
                return RedirectToAction("add");
            }
        }
    }
}