using Entities.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Highscore> Highscores { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
