using System.Collections.Generic;
using System.Linq;
using DataLayer.Helpers;

namespace DataLayer.Actions
{
    public class TurnService : ITurnService
    {
        private readonly IActionChainPerformer _actionChainPerformer;
        private readonly IActionFactory _actionFactory;

        public TurnService(IActionChainPerformer actionChainPerformer, IActionFactory actionFactory)
        {
            _actionChainPerformer = actionChainPerformer;
            _actionFactory = actionFactory;
        }
        public TurnResult MakeTurn(IAction playerAction, ref Game game)
        {
            var actionChain = CreateActionChain(game.Field, playerAction);
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
            return GameHelper.IsGameSolved(game);
        }

        private IAction[] CreateActionChain(Field field, IAction playerAction)
        {
            var actionChain = new List<IAction>();
            actionChain.Add(_actionFactory.CreateNext(field, playerAction));
            while (!(actionChain.Last() is FailAction || actionChain.Last() is SuccessAction))
            {
                actionChain.Add(_actionFactory.CreateNext(field, actionChain.Last()));
            }
            return new IAction[0];
        }

        private bool ValidateChain(IAction[] actionChain)
        {
            return !(actionChain.Last() is FailAction);
        }
    }
}