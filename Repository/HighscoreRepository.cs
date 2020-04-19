using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class HighscoreRepository : RepositoryBase<Highscore>, IHighscoreRepository
    {
        public HighscoreRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateHighscore(Highscore highscore)
        {
            Create(highscore);
        }

        public IEnumerable<Highscore> GetAllHighscores()
        {
            return FindAll().Include(pl => pl.Player).ToList();
        }

        public IEnumerable<Highscore> GetByField(string field, string direction)
        {
            IEnumerable<Highscore> highscores = null;
            if (direction == "asc")
            {
                switch (field)
                {
                    case "shots":
                        highscores = FindAll().OrderBy(pl => pl.shots).Include(pl => pl.Player).ToList();
                        break;
                    case "accuracy":
                        highscores = FindAll().OrderBy(pl => pl.accuracy).Include(pl => pl.Player).ToList();
                        break;
                    case "hit_streak":
                        highscores = FindAll().OrderBy(pl => pl.hit_streak).Include(pl => pl.Player).ToList();
                        break;
                    case "boats_sunk":
                        highscores = FindAll().OrderBy(pl => pl.boats_sunk).Include(pl => pl.Player).ToList();
                        break;
                }
            }
            else
            {
                switch (field)
                {
                    case "shots":
                        highscores = FindAll().OrderByDescending(pl => pl.shots).Include(pl => pl.Player).ToList();
                        break;
                    case "accuracy":
                        highscores = FindAll().OrderByDescending(pl => pl.accuracy).Include(pl => pl.Player).ToList();
                        break;
                    case "hit_streak":
                        highscores = FindAll().OrderByDescending(pl => pl.hit_streak).Include(pl => pl.Player).ToList();
                        break;
                    case "boats_sunk":
                        highscores = FindAll().OrderByDescending(pl => pl.boats_sunk).Include(pl => pl.Player).ToList();
                        break;
                }
            }

            return highscores;
        }

        public IEnumerable<Highscore> GetByName(string name)
        {
            return FindAll().Include(pl => pl.Player).Where(pl => pl.Player.name.IndexOf(name, StringComparison.OrdinalIgnoreCase) != -1).ToList();
        }

        public void UpdateHighscore(Highscore highscore)
        {
            Update(highscore);
        }
    }
}
