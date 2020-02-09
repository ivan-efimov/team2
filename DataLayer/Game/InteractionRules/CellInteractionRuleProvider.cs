using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Game.InteractionRules
{
    public interface ICellInteractionRuleProvider
    {
        ICellInteractionRule GetRule(Type actorType, Type targetType);
    }

    public class CellInteractionRuleProvider : ICellInteractionRuleProvider
    {
        private readonly Dictionary<Tuple<Type, Type>, ICellInteractionRule> _rules;
        public CellInteractionRuleProvider(IEnumerable<ICellInteractionRule> rules)
        {
            _rules = rules.ToDictionary(rule => new Tuple<Type, Type>(rule.ActorType, rule.TargetType));
        }
        public ICellInteractionRule GetRule(Type actorType, Type targetType)
        {
            if (_rules.TryGetValue(new Tuple<Type, Type>(actorType, targetType), out var result))
                return result;
            throw new ArgumentException();
        }
    }
}