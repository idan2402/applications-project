using EZ_CD.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Admin
    {
        public int adminId { get; set; }
        public User theUser { get; set; }
        public Admin whoAdded { get; set; }
        public DateTime dateAdded { get; set; }
    }
}
