using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using DataLayer.Cells;

namespace DataLayer.FieldFactories
{
    enum TypeIds
    {
        Empty = 0,
        Player = 1,
        Target = 2,
        Box = 3,
        Wall = 4
    }

    class TxtFieldFactory : IFieldFactory
    {
        public Field Create(Stream inputStream)
        {
            StreamReader sr = new StreamReader(inputStream);
            string[] fieldData = sr.ReadToEnd().Split("\n");
            int height = fieldData.GetLength(0);
            int width = fieldData[0].Length;
            ICell[,] cells = new ICell[height,width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    TypeIds cellTypeId = (TypeIds) char.GetNumericValue(fieldData[i][j]);
                    cells[i,j] = CreateCellOfType(cellTypeId);
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
