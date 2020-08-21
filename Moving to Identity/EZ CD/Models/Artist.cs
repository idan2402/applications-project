using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Artist
    {
        public string name{ get; set; }
        public int artistId { get; set; }
        public ICollection<Disk> disks { get; set; }
        public DateTime birthday { get; set; }
        public string genre { get; set; }
        public string country { get; set; }
    }
}
