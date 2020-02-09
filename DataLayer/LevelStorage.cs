using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataLayer.Game.LevelFactory;
using DataLayer.Game.Levels;

namespace DataLayer
{
    public interface ILevelStorage
    {
        ILevel GetLevelByName(string name);
        string[] GetLevels();
    }

    class LevelStorage : ILevelStorage
    {
        private readonly Dictionary<string, ILevel> _levels;
        public LevelStorage(string levelDirectory, string searchPattern, ILevelFactory levelFactory)
        {
            var files = Directory.GetFiles(levelDirectory, searchPattern);
            _levels = new Dictionary<string, ILevel>();
            foreach (var file in files)
            {
                try
                {
                    var level = levelFactory.Create(Path.Join(levelDirectory, file));
                    _levels.Add(level.Name, level);
                }
                catch (Exception e)
                {
                    
                }
            }
            _levels = files
                .Select(filename => levelFactory.Create(Path.Join(levelDirectory, filename)))
                .ToDictionary(level => level.Name);
        }
        public ILevel GetLevelByName(string name)
        {
            if (_levels.TryGetValue(name, out var result)) return result;
            throw new ArgumentException();
        }

        public string[] GetLevels()
        {
            return _levels
                .Select(level => level.Key)
                .ToArray();
        }
    }
}