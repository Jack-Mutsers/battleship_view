using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class HighscoresForUpdateDto
    {
        public int Id { get; set; }

        public Player player { get; set; }

        public int session_id { get; set; }

        public int shots { get; set; }

        public int accuracy { get; set; }

        public int hit_streak { get; set; }

        public int boats_sunk { get; set; }
    }
}
