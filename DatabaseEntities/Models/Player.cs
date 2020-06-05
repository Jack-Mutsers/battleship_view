using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseEntities.DatabaseModels
{
    [Table("player")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "player name is required")]
        public string name { get; set; }
        public ICollection<Highscore> highscores { get; set; }
    }
}
