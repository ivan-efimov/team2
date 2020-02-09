using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DataLayer.Game.Actions;
using DataLayer.Game.Field;
using DataLayer.Game.Levels;
using DataLayer.Game.Performers;

namespace DataLayer.Game
{
    using CellsDump = List<Tuple<Point, List<ICell>>>;
    public interface IPlayerGame
    {
        Point PlayerPosition { get; }
    }
    public interface ITurnGame
    {
        TurnResult MakeTurn(IAction initialAction);
        TurnResult LastState { get; }
        int Score { get; }

        IGameField Field { get; }
        void Reset();
    }

    public class SokobanGame : ITurnGame, IPlayerGame
    {
        private TurnResult _lastState;
        private readonly ILevel _level;
        private readonly IActionChainFactory _actionChainFactory;
        private readonly Func<CellsDump, bool> _checkGameOver;
        private IGameField _gameField;
        private int _turnsCount;

        public SokobanGame(ILevel level, IActionChainFactory actionChainFactory, Func<CellsDump, bool> checkGameOver)
        {
            _level = level;
            _actionChainFactory = actionChainFactory;
            _checkGameOver = checkGameOver;
            _gameField = new GameField(level.Field);
            _turnsCount = 0;
            _lastState = TurnResult.GameInProgress;
        }
        public TurnResult MakeTurn(IAction initialAction)
        {
            var actionChain = _actionChainFactory.Create(initialAction, p => _gameField[p].TopCell);

            if (!ValidateChain(actionChain))
                return TurnResult.Invalid;

            _turnsCount++;
            
            // TODO
            var moveActionPerformer = new MoveActionPerformer();
            foreach (var action in actionChain.Reverse())
            {
                if (action is MoveAction moveAction)
                {
                    _gameField = moveActionPerformer.Do(_gameField, moveAction);
                }
            }

            _lastState = _checkGameOver(_gameField.GetAllCells()) ? TurnResult.GameSolved : TurnResult.GameInProgress;
            return _lastState;
        }

        public TurnResult LastState => _lastState;

        public int Score => _turnsCount;
        public IGameField Field => _gameField;
        public void Reset()
        {
            _lastState = TurnResult.GameInProgress;
            _turnsCount = 0;
            _gameField = new GameField(_level.Field);
        }

        public Point PlayerPosition => _gameField.FindByType<PlayerCell>();

        private bool ValidateChain(IAction[] actionChain)
        {
            // Empty action chain is valid
            return actionChain.Length == 0 || actionChain.Last() is SuccessAction;
        }
    }
}