using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
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
                    foreach (var cell in game.Field._cells[row][col])
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
                game.ID,
                GameHelper.IsGameSolved(game),
                game.Score);

        }

        public static Game GameDtoToGame(GameDto gameDto)
        {
            Game game = new Game();
            game.Score = gameDto.Score;
            game.ID = gameDto.Id;
            game.Field = new Field(gameDto.Height, gameDto.Width);
            foreach (var cellDto in gameDto.Cells)
            {
                int row, col;
                
                (row, col) = (cellDto.Pos.Y, cellDto.Pos.X);
                game.Field[row, col].Add(CreateCellByType(cellDto.Type));
            }
            return game;
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

        private static ICell CreateCellByType(string type)
        {
            if (type == typeof(Box).ToString())
            {
                return  new Box();
            }
            else if (type == typeof(Player).ToString())
            {
                return new Player();
            }
            else if (type == typeof(Wall).ToString())
            {
                return new Wall();
            }
            else if (type == typeof(Target).ToString())
            { 

                return new Target();
            }
            else return null;
        }

    }
}
