using GameStore_WPF.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore_WPF.Contexts
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=Resources\\Data\\games.db");
            base.OnConfiguring(builder);
        }
    }
}