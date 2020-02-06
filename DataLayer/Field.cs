using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DataLayer.Cells;

namespace DataLayer
{

    public class Field
    {
        public int Width { get; }
        public int Height { get; }
        public List<ICell>[][] _cells;

        public Field(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            _cells = new List<ICell>[Height][];
            for (int i = 0; i < Height; i++)
            {
                _cells[i] = new List<ICell>[Width];
                for (int j = 0; j < Width; j++)
                {
                    _cells[i][j] = new List<ICell>();
                }
            }
        }
    

        public Field(List<ICell>[][] cells)
        {
            this.Height = cells.Length;
            this.Width = cells[0].Length;
            _cells = new List<ICell>[Height][];
            for (int i = 0; i < Height; i++)
            {
                _cells[i] = new List<ICell>[Width];
                for (int j = 0; j < Width; j++)
                {
                    _cells[i][j] = new List<ICell>(cells[i][j]);
                }
            }
        }
        public Field(Field field)
        {
            this.Height = field.Height;
            this.Width = field.Width;
            _cells = new List<ICell>[Height][];
            for (int i = 0; i < Height; i++)
            {
                _cells[i] = new List<ICell>[Width];
                for (int j = 0; j < Width; j++)
                {
                    _cells[i][j] = new List<ICell>(field._cells[i][j]);
                }
            }
            field._cells.CopyTo(_cells, 0);
        }

        public List<ICell> this[int i, int j] {
            get { return _cells[i][j]; }
        }

        public List<ICell> At(Point p)
        {
            return _cells[p.X][p.Y];
        }

    }
}
