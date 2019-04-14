using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftFoodie.Models
{
    public class VmOrders
    {
        public long OrderId { get; set; }
        public string Customer { get; set; }
          public string Item { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public long ResturantID { get; set; }
    }
}