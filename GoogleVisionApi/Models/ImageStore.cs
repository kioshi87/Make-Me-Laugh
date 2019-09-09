using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Models
{
    public class ImageStore
    {
        [Key]
        public int ImageStoreId { get; set; }
        public string ImageBase64String { get; set; }
        public DateTime? CreateDate { get; set; }
        public PlayerModel PlayerId { get; set; }
    }
}
