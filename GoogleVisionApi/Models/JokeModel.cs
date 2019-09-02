using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Models
{
    public class JokeModel
    {
        public string Category { get; set; }
        public bool Type { get; set; }
        public string Joke { get; set; }
        public string Setup { get; set; }
        public string Deliver { get; set; }
        public string Nsfw { get; set; }
        public string Religious { get; set; }
        public string Political { get; set; }
        public string Id { get; set; }
    }
}
