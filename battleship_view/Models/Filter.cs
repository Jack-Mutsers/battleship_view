using DatabaseEntities.DatabaseModels;
using System.Collections.Generic;

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
