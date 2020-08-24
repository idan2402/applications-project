using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Artist
    {
        public int artistId { get; set; } // The artist ID
        public string name{ get; set; } // The artist name
        public DateTime birthday { get; set; } // His birthday
        public string genre { get; set; } // The genre
        public string country { get; set; } // The country of origin
    }
}
