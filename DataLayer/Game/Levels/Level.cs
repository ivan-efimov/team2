using DataLayer.Game.Field;

namespace DataLayer.Game.Levels
{
    public interface ILevel
    {
        GameField Field { get; }
        string Name { get; }
    }

    public class Level : ILevel
    {
        public Level(GameField field, string name)
        {
            Field = field;
            Name = name;
        }
        public GameField Field { get; }
        public string Name { get; }
    }
}