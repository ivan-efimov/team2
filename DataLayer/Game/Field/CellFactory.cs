using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Game.Field
{
    public interface ICellFactory
    {
        ICell CreateByCodeChar(string cellName);
    }

    public class CellFactory : ICellFactory
    {
        private readonly Dictionary<string, ICell> _cells;
        
        public CellFactory(IEnumerable<ICell> cells)
        {
            _cells = cells.ToDictionary(cell => cell.CodeChar);
            _cells[" "] = null;
        }

        public ICell CreateByCodeChar(string cellName)
        {
            if (_cells.TryGetValue(cellName, out var result))
            {
                return result;
            }
            else
            {
                throw new Exception("Unregistered cell name");
            }
        }
    }
}