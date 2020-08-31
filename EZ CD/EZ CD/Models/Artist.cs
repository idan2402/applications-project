using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Artist
    {
        
        public int artistId { get; set; } // The artist ID
        [DisplayName("Name")]
        public string name{ get; set; } // The artist name
        [DisplayName("Birthday")]
        public DateTime birthday { get; set; } // His birthday
        [DisplayName("Genre")]
        public string genre { get; set; } // The genre
        [DisplayName("Country")]
        public string country { get; set; } // The country of origin
    }
}
