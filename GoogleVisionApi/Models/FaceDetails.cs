using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Models
{
    public class FaceDetails
    {
        public string Anger { get; set; }
        public string Joy { get; set; }
        public string Sorrow { get; set; }
        public string Surprise { get; set; }
        public string ImagePath { get; set; }


    }
}
