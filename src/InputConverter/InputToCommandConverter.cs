using System.ComponentModel;
using DataLayer;
using thegame.Models;

namespace thegame.InputConverter
{
    public enum SupportedKeys { W = 87, A = 65, S = 83, D = 68, R = 82 }
    public interface IInputToCommandConverter
    {
        ICommand Convert(UserInputForMovesPost userInput);
    }
    
    public class InputToCommandConverter : IInputToCommandConverter
    {
        public ICommand Convert(UserInputForMovesPost userInput)
        {
            switch ((SupportedKeys) userInput.KeyPressed)
            {
                case SupportedKeys.S:
                    return new MoveCommand(Directions.Down);
                case SupportedKeys.A:
                    return new MoveCommand(Directions.Left);
                case SupportedKeys.W:
                    return new MoveCommand( Directions.Up);
                case SupportedKeys.D:
                    return new MoveCommand(Directions.Right);
                case SupportedKeys.R:
                    return new ResetCommand();
                default:
                    return new IdleCommand();
            }
        }
    }
}