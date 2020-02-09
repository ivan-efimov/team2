using System.Drawing;

namespace DataLayer.Game.Actions
{
    public interface IControl
    {
        
    }
    
    public interface ICellInteraction
    {
        Point TargetPoint { get; set; }
    }

    public interface IPerformable
    {
        
    }

    public class SuccessAction : IAction, IControl
    {
        public Point ActorPoint { get; set; }
    }
    
    public class FailAction : IAction, IControl
    {
        public Point ActorPoint { get; set; }
    }

    public class MoveAction : IAction, ICellInteraction, IPerformable
    {
        public Point ActorPoint { get; set; }
        public Point TargetPoint { get; set; }
    }
}