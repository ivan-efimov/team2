using DataLayer.Game.Actions;
using DataLayer.Game.Field;

namespace DataLayer.Game.Performers
{
    public interface IActionPerformer
    {
        IGameField Do(IGameField field, IAction action);
        IGameField Undo(IGameField filed, IAction action);
    }
}