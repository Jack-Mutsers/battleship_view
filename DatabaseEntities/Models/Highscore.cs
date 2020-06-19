using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseEntities.DatabaseModels
{
    [Table("highscore")]
    public class Highscore
    {
        public int id { get; set; }

        public int session_id { get; set; }

        public int shots { get; set; }

        [Column("accuracy")]
        public int hits { get; set; }
        
        public int hit_streak { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
