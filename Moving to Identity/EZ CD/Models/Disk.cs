using EZ_CD.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Disk
    {
        public int diskId { get; set; } // The disk ID
        public double price { get; set; } // The price
        public string name { get; set; } // The name
        public DateTime date { get; set; } // Date of release
        public Artist Artist { get; set; } // The artist
        public string genre { get; set; } // The genre
        public DateTime dateAdded { get; set; } // The date that the admin added the disk to the website
        public User Admin { get; set; } // The admin who added the disk to the DB
        public string imagePath { get; set; } // The cover image url
        public ICollection<Song> songs { get; set; }
        public string featuredVideoUrl { get; set; } // the video URL
    }
}
