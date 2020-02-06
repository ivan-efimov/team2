using System.ComponentModel;
using DataLayer.Commands;

namespace thegame
{
    public enum SupportedKeys { W = 87, A = 65, S = 83, D = 68 }
    
    public static class CommandConverter
    {   
        public static ICommand GetCommand(int key)
        {
            switch ((SupportedKeys) key)
            {
                case SupportedKeys.S:
                    return new MoveCommand(Directions.Down);
                case SupportedKeys.A:
                    return new MoveCommand(Directions.Left);
                case SupportedKeys.W:
                    return new MoveCommand( Directions.Up);
                case SupportedKeys.D:
                    return new MoveCommand(Directions.Right);
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}