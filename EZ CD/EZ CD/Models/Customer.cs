using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Customer
    {
        public int customerId;
        public String name;
        public String phone;
        public String addr;
        public String email;
        public Sale[] purchases;
    }
}
