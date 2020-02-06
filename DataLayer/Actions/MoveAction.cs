using System.Drawing;

namespace DataLayer.Actions
{
    public class MoveAction : IAction
    {
        public Point ActionPoint { get; set; }

        public Point DestinationPoint { get; set; }

        public Point Direction => new Point(DestinationPoint.X - ActionPoint.X,
            DestinationPoint.Y - ActionPoint.Y);
    }
}