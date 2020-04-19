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
        public Guid id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "player name is required")]
        public string name { get; set; }
        public int order_number { get; set; } = 0;
        public ICollection<Highscore> highscores { get; set; }
    }
}
