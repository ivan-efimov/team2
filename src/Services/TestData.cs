using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 22;
            var height = 11;
            var testCells = new[]
            {
                new CellDto("6", movingObjectPosition, "player", "", 10),
            };
            return new GameDto(testCells, true, false, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}