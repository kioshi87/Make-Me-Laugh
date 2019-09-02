using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Models
{
    public class PlayerModel
    {
        public string Player { get; set; }
        public string Score { get; set; }
        public string PreferredJokeCategory { get; set; } // Set to joke API categories:  Programming, Miscellaneous, Dark and Any
        public string FunniestJoke { get; set; } // refers to Joke Id from joke API
        public string FunniestPictures { get; set; } // Create a picture class and DB or save pictures directly to player DB and set ID string?
        public string ContentFlagSettings { get; set; } // Should each flag be a public bool?  Nsfw = true, Political = false, etc.
    }
}
