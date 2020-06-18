using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class HighscoreRecords
    {
        public int shots { get; set; } = 0;
        public int hits { get; set; } = 0;
        public int highestHitStreak { get; set; } = 0;
        public int currenctHitStreak { get; set; } = 0;

    }
}
