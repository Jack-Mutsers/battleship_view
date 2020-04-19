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

        public void UpdateHighscore(Highscore highscore)
        {
            Update(highscore);
        }
    }
}
