using DatabaseEntities.DatabaseModels;
using System.Collections.Generic;

namespace Contracts
{
    public interface IHighscoreRepository
    {
        IEnumerable<Highscore> GetAllHighscores();
        IEnumerable<Highscore> GetByField(string field, string direction);
        IEnumerable<Highscore> GetByName(string name);
        void CreateHighscore(Highscore highscore);
        void UpdateHighscore(Highscore highscore);
    }
}
