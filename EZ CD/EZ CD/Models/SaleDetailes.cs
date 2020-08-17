using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class SaleDetailes
    {
        public Disk disk { get; set; }
        public int diskId { get; set; }
        public int saleId { get; set; }
        public Sale sale { get; set; }
    }
}
