using ClassLibraryModelGame;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClassLibraryDBContext
{
    public class CompGamesContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComputerGames;Integrated Security=True;");

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<StyleGame> StyleGames { get; set; }
    }
}
