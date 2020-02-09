namespace DataLayer
{
    public enum Directions
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    public interface ICommand
    {
        
    }

    public class MoveCommand : ICommand
    {
        public Directions Direction { get; private set; }

        public MoveCommand(Directions direction)
        {
            Direction = direction;
        }
    }

    public class IdleCommand : ICommand
    {
        
    }

    public class ResetCommand : ICommand
    {
        
    }
}