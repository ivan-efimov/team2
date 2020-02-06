using System;
using System.Collections.Generic;
using DataLayer.Actions;

namespace DataLayer.GameService
{
    public interface IGameStorage
    {
        Game GetGameById(Guid gameId);
    }

    public class GameStorage : IGameStorage
    {
        private readonly Dictionary<Guid, Game> _games;

        public Game GetGameById(Guid gameId)
        {
            if (!_games.TryGetValue(gameId, out var result))
            {
                result = new Game();
                _games[gameId] = result;
            }

            return result;
        }
    }
}