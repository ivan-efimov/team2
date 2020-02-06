using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Actions;
using DataLayer.Cells;
using DataLayer.Helpers;
using thegame.Models;

namespace thegame.Converters
{
    public static class MapConverter
    {
        public static GameDto GameToGameDto(Game game)
        {
            List<CellDto> cellDtos = new List<CellDto>();

            for (int row = 0; row < game.Field.Height; row++)
            {
                for (int col = 0; col < game.Field.Width; col++)
                {
                    foreach (var cell in game.Field._cells[row][col] )
                    {
                        int zIndex = GetZIndexByCellType(cell);
                        CellDto cellDto = new CellDto(
                            $"{col}_{row}_{cell.GetType()}",
                            new Vec(col, row),
                            cell.GetType().ToString(),
                            string.Empty,
                            zIndex
                            );
                        cellDtos.Add(cellDto);
                    }
                }
            }
            return new GameDto(cellDtos.ToArray(),
                true,
                false,
                game.Field.Width,
                game.Field.Height,
                Guid.Empty,
                GameHelper.IsGameSolved(game), 
                game.Score);

        }

        private static int GetZIndexByCellType(ICell cell)
        {
            Type cellType = cell.GetType();
            if (cellType == typeof(Box))
            {
                return 2;
            }
            else if (cellType == typeof(Wall))
            {
                return 2;
            }
            else if (cellType == typeof(Player))
            {
                return 1;
            }
            else if (cellType == typeof(Target))
            {
                return 0;
            }
            else return 0;
        }
    }
}
