using System;
using System.Drawing;
using DataLayer.Commands;
using DataLayer.GameService;

namespace DataLayer.Actions
{
    public interface IGameService
    {
        Game PerformCommand(Guid gameId, ICommand command);
    }
    public class GameService : IGameService
    {
        private readonly IGameStorage _gameStorage;
        private readonly ITurnService _turnService;

        public GameService(IGameStorage gameStorage, ITurnService turnService)
        {
            _gameStorage = gameStorage;
            _turnService = turnService;
        }
        public Game PerformCommand(Guid gameId, ICommand command)
        {
            var game = _gameStorage.GetGameById(gameId);
            switch (command)
            {
                case MoveCommand moveCommand:
                    return PerformMoveCommand(game, moveCommand);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Game PerformMoveCommand(Game game, MoveCommand command)
        {
            var action = new MoveAction()
            {
                ActionPoint = game.PlayerPosition,
                DestinationPoint = new Point(
                    game.PlayerPosition.X + GetVector(command).X,
                    game.PlayerPosition.Y + GetVector(command).Y),
            };
            var turnResults = _turnService.MakeTurn(action, ref game);
            return game;
        }

        private static Point GetVector(MoveCommand command)
        {
            switch (command.Direction)
            {
                case Directions.Up:
                    return new Point(0, -1);
                case Directions.Down:
                    return new Point(0, 1);
                case Directions.Left:
                    return new Point(-1, 0);
                case Directions.Right:
                    return new Point(1, 0);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}