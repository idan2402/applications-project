using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Sale
    {
        public int saleId { get; set; }
        public Customer customer { get; set; }
        public ICollection<SaleDetailes> disksSalesDetailes { get; set; }
        public DateTime date { get; set; }
    }
}
