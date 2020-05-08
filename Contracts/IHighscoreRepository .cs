using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

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
