using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string addr { get; set; }
        public string email { get; set; }
        public ICollection<Sale> purchases { get; set; }
    }
}
