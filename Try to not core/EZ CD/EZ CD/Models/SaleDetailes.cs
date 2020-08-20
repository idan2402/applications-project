using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class SaleDetailes
    {
        [Key]
        public int SaleDetailesId { get; set; }
        public Disk disk { get; set; }
        public int diskId { get; set; }
        public int saleId { get; set; }
        public Sale sale { get; set; }
    }
}
