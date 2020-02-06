using System;
using System.Drawing;

namespace DataLayer.Actions
{
    public class Game
    {
        public Game()
        {
            
        }
        public Game(Level level, Guid gameId)
        {
            Field = level.field;
            ID = gameId;
        }
        public Field Field { get; set; }

        public int Score { get; set; }

        public Guid ID { get; set; }
        
        public Point PlayerPosition { get; set; }
    }
}