using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Artist
    {
        public int artistId;
        public Disk[] Disks;
        public int BirthYear, BirthMonth, BirthDay;
        public String Genre;
        public String Country;
    }
}
