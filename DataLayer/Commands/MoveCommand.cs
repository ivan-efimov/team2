namespace DataLayer.Commands
{
    public enum Directions { Up, Down,Left, Right }

    public class MoveCommand : ICommand
    {
        public Directions Direction { get; private set; }

        public MoveCommand(Directions direction)
        {
            Direction = direction;
        }
    }
}