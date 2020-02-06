using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Actions
{
    public interface IActionChainPerformer
    {
        Field Do(Field field, IAction[] actions);
        Field Undo(Field field, IAction[] actions);
    }

    public class ActionChainPerformer :IActionChainPerformer
    {
        public Field Do(Field field, IAction[] actions)
        {
            var result = field;
            foreach (var action in actions)
            {
                var performer = CreateActionPerformer(action);
                result = performer.Do(result, action);
            }

            return result;
        }

        private IActionPerformer CreateActionPerformer(IAction action)
        {
            switch (action)
            {
                case MoveAction _:
                    return new MoveActionPerformer();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Field Undo(Field field, IAction[] actions)
        {
            var result = field;
            foreach (var action in actions.Reverse())
            {
                var performer = CreateActionPerformer(action);
                result = performer.Undo(result, action);
            }

            return result;
        }
    }

    public interface IActionPerformer
    {
        Field Do(Field field, IAction action);
        Field Undo(Field field, IAction action);
    }

    public class MoveActionPerformer : IActionPerformer
    {
        public Field Do(Field field, IAction action)
        {
            throw new NotImplementedException();
        }

        public Field Undo(Field field, IAction action)
        {
            throw new NotImplementedException();
        }
    }
}
