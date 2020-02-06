using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Actions;
using DataLayer.Cells;

namespace DataLayer.Helpers
{
    public static class GameHelper
    {
        public static bool IsGameSolved(Game game)
        {
            for (int i = 0; i < game.Field.Height; i++)
            {
                for (int j = 0; j < game.Field.Width; j++)
                {
                    if (game.Field._cells[i][j].FirstOrDefault(x => x is Target) != null)
                    {
                        if (game.Field._cells[i][j].FirstOrDefault(x => x is Box) == null)
                            return false;
                    }
                }
            }

            return true;
        }
    }
}
