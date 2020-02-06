using System.Drawing;
using System.Linq;
using System.Text;
using DataLayer.Cells;

namespace DataLayer.Actions
{
    public interface IActionFactory
    {
        IAction CreateNext(ICell actorCell, ICell targetCell, IAction previousAction)
        {
            if (previousAction is MoveAction action)
            {
                if (cell is Box)
                {
                    return new MoveAction()
                    {
                        ActionPoint = action.DestinationPoint,
                        DestinationPoint = new Point(action.DestinationPoint.X + action.Direction.X,
                            action.DestinationPoint.Y + action.Direction.Y)
                    };
                }
                if (cell is Wall)
                {
                    return new FailAction();
                }
            }

            return new FailAction();
        }
    }
}
