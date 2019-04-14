using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwiftFoodie.Models
{
    public partial class Orders
    {
        [Key]
        public long OrderID { get; set; }
        public long CustomerID { get; set; }
        public string Location { get; set; }
        public DateTime OrderDate { get; set; }
        public long MenuID { get; set; }
        public long ResturantID { get; set; }

        public int Status
        {
            get; set;
        }
    }
    
}