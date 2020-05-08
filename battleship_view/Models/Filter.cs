using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_view.Models
{
    public class Filter
    {
        public string field { get; set; }
        public string direction { get; set; }
        public List<Highscore> highscores { get; set; }
        public string search { get; set; }
    }
}
