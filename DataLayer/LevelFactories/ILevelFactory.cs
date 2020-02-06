using System.IO;

namespace DataLayer.LevelFactories
{
    public interface ILevelFactory
    {
        public Level Create(FileInfo inputFile);
    }
}