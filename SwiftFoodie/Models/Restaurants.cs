using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwiftFoodie.Models
{
    public partial class Restaurants
    {
        [Key]
        public long RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string CompleteAddress { get; set; }
        public bool IsActive { get; set; }
    }
}