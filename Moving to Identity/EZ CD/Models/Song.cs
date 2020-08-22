using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Song
    {
        public int songId { get; set; }
        public string name { get; set; }
        public Disk disk{ get; set; }
        public int DiskId { get; set; }
        public string length { get; set; }
    }
}
