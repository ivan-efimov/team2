using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataLayer.Actions;
using DataLayer.LevelFactories;

namespace DataLayer.GameService
{
    public interface IGameStorage
    {
        Game GetGameById(Guid gameId);
    }

    public class GameStorage : IGameStorage
    {
        private readonly Dictionary<Guid, Game> _games = new Dictionary<Guid, Game>();
        private readonly Dictionary<string, Level> _levels;
        private readonly string _defaultLevelId ;

        public GameStorage(ILevelFactory levelFactory)
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            if (files.Length == 0)
            {
                throw new FileNotFoundException("No level files in level directory");
            }
            _defaultLevelId = "Level1.txt";
            _levels = files.Select(filename => levelFactory
                    .Create(new FileInfo(Path.Join(Directory.GetCurrentDirectory(), filename))))
                .ToDictionary(level => level.id);
        }

        public Game GetGameById(Guid gameId)
        {
            if (!_games.TryGetValue(gameId, out var result))
            {
                result = new Game(_levels[_defaultLevelId], gameId);
                _games[gameId] = result;
            }

            return result;
        }
    }
}