using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class SaleItem
    {
        public int saleItemId { get; set; }
        public Disk Disk { get; set; } // The Disk
        public Sale Sale { get; set; } // The Sale it is related to
    }
}
