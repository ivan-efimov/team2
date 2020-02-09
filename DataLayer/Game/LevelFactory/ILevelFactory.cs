using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using DataLayer.Game.Field;
using DataLayer.Game.Levels;

namespace DataLayer.Game.LevelFactory
{
    public interface ILevelFactory
    {
        ILevel Create(string filename);
    }

    public class TxtLevelFactory : ILevelFactory
    {
        private readonly ICellFactory _cellFactory;

        public TxtLevelFactory(ICellFactory cellFactory)
        {
            _cellFactory = cellFactory;
        }
        public ILevel Create(string filename)
        {
            try
            {
                TextReader reader = File.OpenText(filename);
                var headerData = reader.ReadLine().Split(",");
                var height = int.Parse(headerData[0]);
                var width = int.Parse(headerData[1]);
                var name = headerData[2];
                var fieldData = new List<ICell>[height, width];
                for (int i = 0; i < height; i++)
                {
                    var row = reader.ReadLine();
                    for (int j = 0; j < width; j++)
                    {
                        // fieldData[i, j] = row[j]
                        //     .Split(",")
                        //     .Where(cellName => _cellFactory.CreateByCodeChar(cellName) != null)
                        //     .Select(cellName => _cellFactory.CreateByCodeChar(cellName))
                        //     .ToList();
                        fieldData[i, j] = new List<ICell>();
                        var cell = _cellFactory.CreateByCodeChar(row[j].ToString());
                        if (cell != null)
                            fieldData[i, j].Add(cell);
                    }
                }

                return new Level(new GameField(fieldData), name);
            }
            catch (Exception e)
            {
                throw new Exception("invalid file format", e);
            }
        }
    }
}