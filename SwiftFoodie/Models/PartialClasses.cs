using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SwiftFoodie.Models
{
  
        public partial class Users
        {
            [NotMapped]
            public bool RememberMe { get; set; }

        }
}