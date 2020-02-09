using System;
using System.Collections.Generic;
using DataLayer.Game;

namespace DataLayer
{
    public interface IGameStorage
    {
        ITurnGame GetGameById(Guid gameId);
    }
    
    public class GameStorage : IGameStorage
    {
        private readonly Func<ITurnGame> _makeNewGame;
        private readonly Dictionary<Guid, ITurnGame> _games = new Dictionary<Guid, ITurnGame>();
        public GameStorage(Func<ITurnGame> makeNewGame)
        {
            _makeNewGame = makeNewGame;
        }
        public ITurnGame GetGameById(Guid gameId)
        {
            if (_games.TryGetValue(gameId, out var result)) return result;
            result = _makeNewGame();
            _games[gameId] = result;

            return result;
        }
    }
}