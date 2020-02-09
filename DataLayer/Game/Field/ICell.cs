namespace DataLayer.Game.Field
{
    public interface ICell
    {
        string Name { get; }
        string CodeChar { get; }
    }

    public interface ISolid
    {
        
    }

    public interface IMovable
    {
        
    }

    public class PlayerCell : ICell
    {
        public string Name => "player";
        public string CodeChar => "@";
    }

    public class WallCell : ICell, ISolid
    {
        public string Name => "brick_wall";
        public string CodeChar => "X";
    }

    public class BoxCell : ICell, ISolid, IMovable
    {
        public string Name => "basic_box";
        public string CodeChar => "*";
    }
    
    public class TargetCell : ICell
    {
        public string Name => "target";
        public string CodeChar => ".";
    }
}