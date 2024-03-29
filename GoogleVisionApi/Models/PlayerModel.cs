﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Models
{
    public class PlayerModel
    {
        public PlayerModel()
        {
            Score = 10;
        }

        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string GameStartTimeStamp { get; set; }
        public bool Win { get; set; }
        public int Score { get; set; }
        public string FunniestPictures { get; set; } // Create a picture class and DB or save pictures directly to player DB and set ID string?

        public List<ImageStore> ImageList { get; set; }

        //public ImageStore ImageStoreId { get; set; }
    }
}
