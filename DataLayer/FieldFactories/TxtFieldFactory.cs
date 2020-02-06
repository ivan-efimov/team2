using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DataLayer.Cells;

namespace DataLayer.FieldFactories
{
    public enum TypeIds
    {
        Empty = 0,
        Player = 1,
        Target = 2,
        Box = 3,
        Wall = 4
    }

    public class TxtFieldFactory : IFieldFactory
    {
        public Field Create(Stream inputStream)
        {
            StreamReader sr = new StreamReader(inputStream);
            string[] fieldData = sr.ReadToEnd().Replace("\r", string.Empty).Split("\n");
            int[] fieldSize = fieldData[0].Split(" ").Select(x => int.Parse(x)).ToArray();
            int height, width;
            List<ICell>[][] cells;
            (height, width) = (fieldSize[0], fieldSize[1]);
            if (fieldData.GetLength(0) != height + 1)
            {
                throw new DataException("wrong height or count of lines in file");
            }

            cells = new List<ICell>[height][];
            for (int i = 1; i <= height; i++)
            {
                if (fieldData[i].Length != width)
                {
                    throw new DataException($"wrong width or lenght of {i} line in file");
                }
                cells[i - 1] = new List<ICell>[width];
                for (int j = 0; j < width; j++)
                {
                    TypeIds cellTypeId = (TypeIds) char.GetNumericValue(fieldData[i][j]);
                    cells[i - 1][j] = new List<ICell>();
                    cells[i - 1][j].Add(CreateCellOfType(cellTypeId));
                }
            }
            return new Field(cells);
        }



        private static ICell CreateCellOfType(TypeIds cellTypeId)
        {
            switch (cellTypeId)
            {
                case TypeIds.Empty:
                {
                    return null;
                }
                case TypeIds.Box:
                {
                    return new Box();
                }
                case TypeIds.Player:
                {
                    return new Player();
                }
                case TypeIds.Target:
                {
                    return new Target();
                }
                case TypeIds.Wall:
                {
                    return new Wall();
                }
                default:
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
