using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_CD.Models
{
    public class Song
    {
        public int songId { get; set; } // The song Id
        public string name { get; set; } // The name of the song
        public Disk Disk{ get; set; } // The disk this song is related to
        public string length { get; set; } // The length (00:00 format)
        public string imagePath { get; set; } // The cover image url
        public string videoUrl { get; set; } // the video URL
    }
}
