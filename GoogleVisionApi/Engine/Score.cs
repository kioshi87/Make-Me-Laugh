using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Engine
{
    public class Score
    {
        public int ScoreTally(bool laughResult)
        {
            int score = 10;
            laughResult = false;

            if (laughResult == true)
            {
                score--;
            }

            return score;
        }
    }
}



