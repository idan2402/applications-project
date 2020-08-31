using EZ_CD.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Sale
    {
        public int saleId { get; set; } // The id of the sale
        public User User{ get; set; } // The user that made the purchase
        [DisplayName("Date")]
        public DateTime date { get; set; } // The time the purchase was made
    }
}
