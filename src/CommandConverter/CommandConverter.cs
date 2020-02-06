using System.ComponentModel;
using DataLayer.Commands;

namespace thegame
{
    public enum DirectionsKeys { W = 87, A = 65, S = 83, D = 68 }
    
    public static class CommandConverter
    {
        public static ICommand GetCommand(DirectionsKeys key)
            => new MoveCommand(GetDirection(key));

        public static DirectionsKeys GetDirectionKeyByCode
            (int keycode) => (DirectionsKeys) keycode;
        
        private static Directions GetDirection(DirectionsKeys key)
        {
            switch (key)
            {
                case DirectionsKeys.S:
                    return Directions.Down;
                case DirectionsKeys.A:
                    return Directions.Left;
                case DirectionsKeys.W:
                    return Directions.Up;
                case DirectionsKeys.D:
                    return Directions.Right;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}