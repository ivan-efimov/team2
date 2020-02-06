using System;
using System.Drawing;
using DataLayer.Cells;

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

        public Point PlayerPosition
        {
            get
            {
                for (int i = 0; i < Field.Height; i++)
                {
                    for (int j = 0; j < Field.Width; j++)
                    {
                        foreach (var cell in Field._cells[i][j])
                        {
                            if (cell is Player)
                                return new Point(i, j);
                        }
                    }
                }
//TODO: change to nullable
                return new Point(0, 0);
            }
        }
    }
}