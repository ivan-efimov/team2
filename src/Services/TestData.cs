using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static CellDto CreateWall(Vec position, string id) =>
            new CellDto(id, position, "color1", "", 0);
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 10;
            var height = 8;
            var testCells = new[]
            {
                new CellDto("1", new Vec(2, 4), "color1", "", 0),
                new CellDto("2", new Vec(5, 4), "color1", "", 0),
                new CellDto("3", new Vec(3, 1), "color2", "", 20),
                new CellDto("4", new Vec(1, 3), "color2", "", 20),
                new CellDto("5", movingObjectPosition, "color4", "☺", 10),
            };

            var walls = new List<CellDto>();

            for (int i = 0; i < Math.Max(width, height); i++)
            {
                if (i < width)
                {
                    walls.Add(CreateWall(new Vec(i, 0), i + "- 0"));
                    walls.Add(CreateWall(new Vec(i, height-1), i + "- 0-bot"));
                }
                
                if (i > 0 && i < height)
                {
                    walls.Add(CreateWall(new Vec(0, i), "0-" + i));
                    walls.Add(CreateWall(new Vec(width-1, i), "0-right" + i));
                }
            }
            
            testCells = testCells.Concat(walls.ToArray()).ToArray();
            
            return new GameDto(testCells, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}