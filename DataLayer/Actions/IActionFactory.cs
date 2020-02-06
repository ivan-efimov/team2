using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using DataLayer.Cells;

namespace DataLayer.Actions
{
    public class ActionFactory
    {
        IAction CreateNext(ICell actorCell, ICell targetCell, IAction previousAction)
        {
            if (previousAction is MoveAction action)
            {
                
                
            }

            return new FailAction();
        }

        private IAction ProcessMoveAction(ICell actorCell, ICell targetCell, MoveAction previousAction)
        {
            switch (actorCell)
            {
                case Player player when targetCell is ISolid:
                    return new MoveAction()
                    {
                        ActionPoint = previousAction.DestinationPoint,
                        DestinationPoint = new Point(previousAction.DestinationPoint.X + previousAction.Direction.X,
                            previousAction.DestinationPoint.Y + previousAction.Direction.Y)
                    };
                case Wall wall:
                    return new FailAction();
                case Box box when targetCell is ISolid:
                    return new FailAction();
                default:
                    return new SuccessAction();
            }
        }
    }
}
