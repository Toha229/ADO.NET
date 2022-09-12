using System;

namespace ClassLibraryModelGame
{
    public class StyleGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ProductionStudio { get; set; }
        public DateTime Release { get; set; }
        public Nullable<int> StyleGameId { get; set; }
        public virtual StyleGame StyleGame { get; set; }
    }
}
