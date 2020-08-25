using EZ_CD.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;


namespace EZ_CD.Models
{
    public class Disk
    {
        public int diskId { get; set; } // The disk ID
        [DisplayName("Price")]
        public double price { get; set; } // The price
        [DisplayName("Name")]
        public string name { get; set; } // The name
        [DisplayName("Release Date")]
        public DateTime date { get; set; } // Date of release
        public Artist Artist { get; set; } // The artist
        [DisplayName("Genre")]
        public string genre { get; set; } // The genre
        [DisplayName("Date Added To The Site")]
        public DateTime dateAdded { get; set; } // The date that the admin added the disk to the website
        public User Admin { get; set; } // The admin who added the disk to the DB
        [DisplayName("Cover Image")]
        public string imagePath { get; set; } // The cover image url
        [DisplayName("Featured Video URL")]
        public string featuredVideoUrl { get; set; } // the video URL
    }
}
