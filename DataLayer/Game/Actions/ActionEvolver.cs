using System;
using System.Drawing;
using DataLayer.Game.Field;
using DataLayer.Game.InteractionRules;

namespace DataLayer.Game.Actions
{
    public interface IActionEvolver
    {
        IAction GetNext(IAction previousAction, Func<Point, ICell> getCellByPosition);
    }

    public class ActionEvolver : IActionEvolver
    {
        private readonly ICellInteractionRuleProvider _cellInteractionRuleProvider;

        public ActionEvolver(ICellInteractionRuleProvider cellInteractionRuleProvider)
        {
            _cellInteractionRuleProvider = cellInteractionRuleProvider;
        }
        public IAction GetNext(IAction previousAction, Func<Point, ICell> getCellByPosition)
        {
            switch (previousAction)
            {
                case ICellInteraction interaction:
                    var rule = _cellInteractionRuleProvider.GetRule(
                        getCellByPosition(previousAction.ActorPoint)?.GetType(),
                        getCellByPosition(interaction.TargetPoint)?.GetType());
                    return rule.NextAction(previousAction);
                case IControl _:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(previousAction));
            }
        }
    }
}