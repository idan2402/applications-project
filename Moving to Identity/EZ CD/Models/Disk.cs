using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Disk
    {
        public int diskId { get; set; }
        public double price { get; set; }

        public string name { get; set; }

        public DateTime date { get; set; }

        public Artist artist { get; set; }
        public int ArtistId { get; set; }
        public ICollection<Song> songs { get; set; }

        public string genre { get; set; }

        public DateTime dateAdded { get; set; } // The date that the admin added the disk to the website

        public Admin admin { get; set; } // The admin who added the disk to the DB

        public string imagePath { get; set; }
        public string videoUrl { get; set; }
        public ICollection<SaleDetailes> disksSalesDetailes { get; set; } // all the orders that contains the disk

    }
}
