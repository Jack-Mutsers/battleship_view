﻿using DatabaseEntities.DatabaseModels;

namespace DatabaseEntities.DataTransferObjects
{
    public class HighscoresForCreationDto
    {
        public Player player { get; set; }

        public int session_id { get; set; }

        public int shots { get; set; }

        public int accuracy { get; set; }

        public int hit_streak { get; set; }

        public int boats_sunk { get; set; }
    }
}