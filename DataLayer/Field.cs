using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Cells;

namespace DataLayer
{

    public class Field
    {
        public int Width { get; }
        public int Height { get; }
        private readonly ICell[,] _cells;

        public Field(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            _cells = new ICell[Height, Width];
        }

        public Field(ICell[,] cells)
        {
            this.Height = cells.GetLength(0);
            this.Width = cells.GetLength(0);
            _cells = new ICell[Height, Width];
            cells.CopyTo(_cells, 0);
        }
        public Field(Field field)
        {
            this.Height = field.Height;
            this.Width = field.Width;
            _cells = new ICell[Height, Width];
            field._cells.CopyTo(_cells, 0);
        }

        public ICell this[int i, int j] {
            get { return _cells[i, j]; }
        }

    }
}
