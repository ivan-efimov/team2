using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DataLayer.Game;
using thegame.Models;

namespace thegame
{
    public class GameToDto
    {
        public static GameDto Convert(ITurnGame game, Guid gameId)
        {
            var cellDtos = game.Field.GetAllCells()
                .Where(tup => tup.Item2.Count != 0)
                .SelectMany(tup => tup.Item2
                    .Select((cell, index) => new CellDto(
                        MakeId(cell.Name, tup.Item1, index),
                        new Vec(tup.Item1),
                        cell.Name,
                        "",
                        index)))
                .ToArray();

            
            return new GameDto(cellDtos,
                true,
                false,
                game.Field.Width,
                game.Field.Height,
                gameId,
                game.LastState == TurnResult.GameSolved,
                game.Score);

        }

        public static string MakeId(string name, Point p, int zIndex)
        {
            return name + "_" + p.X.ToString() + "_" + p.Y.ToString() + "_" + zIndex.ToString();
        }
    }
}