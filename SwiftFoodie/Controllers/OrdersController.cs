using SwiftFoodie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftFoodie.Controllers
{
    public class OrdersController : Controller
    {
        DBContextDataBase db = new DBContextDataBase();
        // GET: Orders
        public ActionResult pending()
        {
            var pendings = (from o in db.Orders
                            where o.Status == 1
                            join c in db.Users on o.CustomerID equals c.UserID
                            join m in db.Menu on o.MenuID equals m.MenuID
                            select new
                            {
                                OrderId = o.OrderID,
                                Customer = c.FirstName + "" + c.LastName,
                                Item = m.ItemName,
                                Address = o.Location,
                                Phone = c.Phone,
                                Date = o.OrderDate,
                            });
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
        public ActionResult current()
        {
            var current = (from o in db.Orders
                           where o.Status == 2
                           join c in db.Users on o.CustomerID equals c.UserID
                           join m in db.Menu on o.MenuID equals m.MenuID
                           select new
                           {
                               OrderId = o.OrderID,
                               Customer = c.FirstName + "" + c.LastName,
                               Item = m.ItemName,
                               Address = o.Location,
                               Phone = c.Phone,
                               Date = o.OrderDate,
                           }

                           );
            List<VmOrders> lsorders = new List<VmOrders>();
            foreach (var p in current)
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
        public ActionResult canceled()
        {
            var canceled = (from o in db.Orders
                            where o.Status == 3
                            join c in db.Users on o.CustomerID equals c.UserID
                            join m in db.Menu on o.MenuID equals m.MenuID
                            select new
                            {
                                OrderId = o.OrderID,
                                Customer = c.FirstName + "" + c.LastName,
                                Item = m.ItemName,
                                Address = o.Location,
                                Phone = c.Phone,
                                Date = o.OrderDate,
                            }

                           );
            List<VmOrders> lsorders = new List<VmOrders>();
            foreach (var p in canceled)
            {
                VmOrders o = new VmOrders();
                o.OrderId = p.OrderId;
                o.Customer = p.Customer;
                o.Item = p.Item;
                o.Address = p.Address;
                o.Phone = p.Phone;
                o.Date = p.Date;
                lsorders.Add(o);
            }
            return View(lsorders);
        }
        public ActionResult completed()
        {
            var completed = (from o in db.Orders
                             where o.Status == 4
                             join c in db.Users on o.CustomerID equals c.UserID
                             join m in db.Menu on o.MenuID equals m.MenuID
                             select new
                             {
                                 OrderId = o.OrderID,
                                 Customer = c.FirstName + "" + c.LastName,
                                 Item = m.ItemName,
                                 Address = o.Location,
                                 Phone = c.Phone,
                                 Date = o.OrderDate,
                             }

                            );
            List<VmOrders> lsorders = new List<VmOrders>();
            foreach (var p in completed)
            {
                VmOrders o = new VmOrders();
                o.OrderId = p.OrderId;
                o.Customer = p.Customer;
                o.Item = p.Item;
                o.Phone = p.Phone;
                o.Address = p.Address;
                o.Date = p.Date;
                lsorders.Add(o);
            }
            return View(lsorders);
        }

        public ActionResult cancelorder(long id)
        {
            var order = db.Orders.Find(id);
                order.Status = 3;
                db.Entry(order).State = EntityState.Modified;
                  db.SaveChanges();
            return RedirectToAction("canceled");
        }
    }
}