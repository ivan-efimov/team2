namespace DataLayer.Actions
{
    public interface ITurnService
    {
        TurnResult MakeTurn(IAction playerAction, ref Game game);
    }
}