using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("player")]
    public class Player
    {
        [Column("PlayerId")]
        public int id { get; set; }

        [Required(ErrorMessage = "player name is required")]
        public string name { get; set; }
        public ICollection<Highscore> highscores { get; set; }
    }
}
