using System.IO;

namespace DataLayer.LevelFactories
{
    public interface ILevelFactory
    {
        Level Create(FileInfo inputFile);
    }
}