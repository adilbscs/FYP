using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwiftFoodie.Models
{
    public partial class Menu
    {
        [Key]
        public long MenuID { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public long ItemPrice { get; set; }
        public long ResturantID { get; set; }
        public bool Status { get; set; }

    }
}