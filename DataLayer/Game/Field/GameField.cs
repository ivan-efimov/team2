using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DataLayer.Game.Field;

namespace DataLayer.Game.Field
{
    public interface IGameField
    {
        int Height { get; }
        int Width { get; }

        List<Tuple<Point, List<ICell>>> GetAllCells();

        IGameField MoveTop(Point from, Point to);
        Point FindByType<TType>();
        
        FieldElement this[Point p] { get; }
        FieldElement this[int i, int j] { get; }
    }

    public class FieldElement
    {
        private List<ICell> _cells;
        
        public FieldElement()
        {
            _cells = new List<ICell>();
        }

        public FieldElement(FieldElement fieldElement)
        {
            _cells = fieldElement._cells.ToList();
        }

        public FieldElement(List<ICell> cells)
        {
            _cells = cells.ToList();
        }

        public List<ICell> GetCells()
        {
            return _cells.ToList();
        }

        public ICell TopCell => _cells.LastOrDefault();

        public void AddCell(ICell cell)
        {
            if (cell != null)
                _cells.Add(cell);
        }

        public void Pop()
        {
            if (_cells.Count > 0)
                _cells = _cells
                    .Take(_cells.Count - 1)
                    .ToList();
        }
    }

    public class GameField : IGameField
    {
        private readonly FieldElement[,] _fieldElements;

        public GameField(GameField gameField)
        {
            Height = gameField.Height;
            Width = gameField.Width;
            
            _fieldElements = new FieldElement[Height, Width];
            
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    _fieldElements[i, j] = new FieldElement(gameField[i, j]);
                }
            }
        }
        public GameField(int height, int width)
        {
            Height = height;
            Width = width;
            
            _fieldElements = new FieldElement[Height, Width];
            
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    _fieldElements[i, j] = new FieldElement();
                }
            }
        }

        public GameField(List<ICell>[,] cellLists)
        {
            Height = cellLists.GetLength(0);
            Width = cellLists.GetLength(1);
            
            _fieldElements = new FieldElement[Height, Width];
            
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    _fieldElements[i, j] = new FieldElement(cellLists[i, j]);
                }
            }
        }

        public int Height { get; }
        public int Width { get; }
        public List<Tuple<Point, List<ICell>>> GetAllCells()
        {
            var result = new List<Tuple<Point, List<ICell>>>();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    result.Add(new Tuple<Point, List<ICell>>(
                        new Point(i, j),
                        _fieldElements[i, j].GetCells()));
                }
            }

            return result;
        }

        public IGameField MoveTop(Point from, Point to)
        {
            var field = new GameField(this);
            field[to].AddCell(field[from].TopCell);
            field[from].Pop();
            return field;
        }

        public FieldElement this[Point p] => _fieldElements[p.X, p.Y];
        public FieldElement this[int i, int j] => _fieldElements[i, j];

        public Point FindByType<TType>()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_fieldElements[i, j].TopCell is TType)
                        return new Point(i, j);
                }
            }

            return new Point();
        }
    }
}