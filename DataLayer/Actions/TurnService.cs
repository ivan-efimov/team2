using System.Collections.Generic;

namespace DataLayer.Actions
{
    public class TurnService
    {
        private readonly IActionChainPerformer _actionChainPerformer;

        public TurnService(IActionChainPerformer actionChainPerformer)
        {
            _actionChainPerformer = actionChainPerformer;
        }
        public TurnResult MakeTurn(IAction playerAction, Game game)
        {
            var actionChain = CreateActionChain(playerAction);
            if (!ValidateChain(actionChain))
            {
                return TurnResult.Invalid;
            }

            game.Field = this._actionChainPerformer.Do(game.Field, actionChain);

            if (IsLevelSolved(game))
            {
                return TurnResult.GameSolved;
            }

            return TurnResult.GameInProgress;
        }

        private bool IsLevelSolved(Game game)
        {
            // TODO
            return false;
        }

        private IAction[] CreateActionChain(Field field, IAction playerAction)
        {
            var actionChain = new List<IAction>();
            actionChain.Add();
            return new IAction[0];
        }

        private bool ValidateChain(IAction[] actionChain)
        {
            // TODO Make last-action-based solution
            return true;
        }
    }
}