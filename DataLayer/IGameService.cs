using System;
using System.Drawing;
using DataLayer.Game;
using DataLayer.Game.Actions;
using DataLayer.Game.Field;
using DataLayer.Game.InteractionRules;
using DataLayer.Game.Levels;

namespace DataLayer
{
    public interface IGameService
    {
        Tuple<ITurnGame, TurnResult> PerformCommand(Guid gameId, ICommand command);
    }

    public class GameService : IGameService
    {
        private readonly IGameStorage _gameStorage;

        public GameService(IGameStorage gameStorage)
        {
            _gameStorage = gameStorage;
        }

        public Tuple<ITurnGame, TurnResult> PerformCommand(Guid gameId, ICommand command)
        {
            var game = _gameStorage.GetGameById(gameId);
            TurnResult result;
            switch (command)
            {
                case MoveCommand moveCommand:
                    return PerformMoveCommand(game, moveCommand);
                case IdleCommand idleCommand:
                    return new Tuple<ITurnGame, TurnResult>(game, game.LastState);
                case ResetCommand resetCommand:
                    game.Reset();
                    return new Tuple<ITurnGame, TurnResult>(game, game.LastState);
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), "Unknown command");
            }
        }

        private Tuple<ITurnGame, TurnResult> PerformMoveCommand(ITurnGame turnGame, MoveCommand command)
        {
            switch (turnGame)
            {
                case IPlayerGame playerGame:
                {
                    var action = new MoveAction()
                    {
                        ActorPoint = playerGame.PlayerPosition,
                        TargetPoint = playerGame.PlayerPosition
                            .Add(GetDirectionVector(command))
                    };
            
                    return new Tuple<ITurnGame, TurnResult>(turnGame, turnGame.MakeTurn(action));
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(turnGame));
            }
        }
        
        private static Point GetDirectionVector(MoveCommand command)
        {
            switch (command.Direction)
            {
                case Directions.Left:
                    return new Point(0, -1);
                case Directions.Right:
                    return new Point(0, 1);
                case Directions.Up:
                    return new Point(-1, 0);
                case Directions.Down:
                    return new Point(1, 0);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}