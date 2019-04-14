using SwiftFoodie.App_Start;
using SwiftFoodie.Models;
using SwiftFoodie.Models.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.Controllers
{
  //  [SessionExpire , IsRestaurant]

    public class HomeController : Controller
    {
        DBContextDataBase db = new DBContextDataBase();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            long ResId = Convert.ToInt64(Session["RestaurantID"]);
            var pendings = (from o in db.Orders
                            where o.Status == 1 && o.ResturantID== ResId
                            join c in db.Users on o.CustomerID equals c.UserID
                            join m in db.Menu on o.MenuID equals m.MenuID orderby o.OrderID descending
                            select new
                            {
                                OrderId = o.OrderID,
                                Customer = c.FirstName + "" + c.LastName,
                                Item = m.ItemName,
                                Address = o.Location,
                                Phone = c.Phone,
                                Date = o.OrderDate,
                            }).Take(10);
            List<VmOrders> lsorders = new List<VmOrders>();
            foreach (var p in pendings)
            {
                VmOrders o = new VmOrders();
                o.OrderId = p.OrderId;
                o.Customer = p.Customer;
                o.Address = p.Address;
                o.Item = p.Item;
                o.Phone = p.Phone;
                o.Date = p.Date;
                lsorders.Add(o);
            }
            return View(lsorders);
        }

       
    }
}