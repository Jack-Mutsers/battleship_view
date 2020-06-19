using DatabaseEntities.DatabaseModels;

namespace DatabaseEntities.DataTransferObjects
{
    public class HighscoresForUpdateDto
    {
        public int Id { get; set; }

        public Player player { get; set; }

        public int session_id { get; set; }

        public int shots { get; set; }

        public int hits { get; set; }

        public int hit_streak { get; set; }
    }
}
