using EZ_CD.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class CartItem
    {
            public int cartItemId { get; set; }
            public User User { get; set; } // The User that the DISK is on his cart
            public Disk Disk { get; set; } // The Disk
        
    }
}
