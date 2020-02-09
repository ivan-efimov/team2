using System;
using DataLayer.Game.Actions;
using DataLayer.Game.Field;

namespace DataLayer.Game.Performers
{
    public class MoveActionPerformer : IActionPerformer
    {
        public IGameField Do(IGameField field, IAction action)
        {
            if (action is MoveAction moveAction)
            {
                return field.MoveTop(moveAction.ActorPoint, moveAction.TargetPoint);
            }
            else
            {
                throw new ArgumentException("must be MoveAction", nameof(action));
            }
        }

        public IGameField Undo(IGameField field, IAction action)
        {
            throw new System.NotImplementedException();
        }
    }
}