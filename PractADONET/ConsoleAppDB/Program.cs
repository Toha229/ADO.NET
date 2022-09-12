using ClassLibraryDBContext;
using ClassLibraryModelGame;
using System;

namespace ConsoleAppDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CompGamesContext db = new CompGamesContext())
            {
                StyleGame sg = new StyleGame
                {
                    Name = "Shooter"
                };
                StyleGame sg2 = new StyleGame
                {
                    Name = "Platformer"
                };
                Game g1 = new Game
                {
                    Name = "Geometry Dush",
                    ProductionStudio = "RobTopGames",
                    StyleGame = sg2,
                    Release = new DateTime(2015, 08, 22)
                };
                Game g2 = new Game
                {
                    Name = "Fortinayt",
                    ProductionStudio = "EpicGames",
                    StyleGame = sg,
                    Release = new DateTime(2010, 07, 22)
                };
                //db.Games.AddRange(g1, g2);
                //db.SaveChanges();
                foreach (var g in db.Games)
                {
                    Console.WriteLine($"{g.Id} {g.Name} {g.ProductionStudio} {g.StyleGame.Name} {g.Release.ToShortDateString()}");
                }



            }
        }
    }
}
