using EZ_CD.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Customer
    {
        public int customerId { get; set; }

        public User user { get; set; }

        public int theUserId { get; set; }

        public ICollection<SaleDetailes> purchases { get; set; }

    }
}
