using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IHighscoreRepository
    {
        IEnumerable<Highscore> GetAllHighscores();
        void CreateHighscore(Highscore highscore);
        void UpdateHighscore(Highscore highscore);
    }
}
