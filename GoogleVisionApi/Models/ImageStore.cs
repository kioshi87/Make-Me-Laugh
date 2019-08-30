using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Models
{
    public class ImageStore
    {
        public int ImageStoreId { get; set; }
        public string ImageBase64String { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
