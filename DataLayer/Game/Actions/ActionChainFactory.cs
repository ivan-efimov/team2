using System;
using System.Collections.Generic;
using System.Drawing;
using DataLayer.Game.Field;

namespace DataLayer.Game.Actions
{
    public interface IActionChainFactory
    {
        IAction[] Create(IAction initialAction, Func<Point, ICell> getCellByPosition);
    }

    public class ActionChainFactory : IActionChainFactory
    {
        private readonly IActionEvolver _actionEvolver;

        public ActionChainFactory(IActionEvolver actionEvolver)
        {
            _actionEvolver = actionEvolver;
        }

        public IAction[] Create(IAction initialAction, Func<Point, ICell> getCellByPosition)
        {
            var actionChain = new List<IAction>();
            var lastAction = initialAction;
            while (lastAction != null)
            {
                actionChain.Add(lastAction);
                lastAction = _actionEvolver.GetNext(lastAction, getCellByPosition);
            }

            return actionChain.ToArray();
        }
    }
}