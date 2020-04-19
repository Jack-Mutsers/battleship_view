﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("highscore")]
    public class Highscore
    {
        public int id { get; set; }

        public int session_id { get; set; }

        public int shots { get; set; }

        public int accuracy { get; set; }
        
        public int hit_streak { get; set; }

        public int boats_sunk { get; set; }
        
        [ForeignKey(nameof(Player))]
        public Guid PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
