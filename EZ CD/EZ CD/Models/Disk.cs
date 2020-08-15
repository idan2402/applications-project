using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Disk
    {
        public int Id;

        public int Price;

        public String Name;

        public Song[] Songs;

        public String Genre;
    }
}
