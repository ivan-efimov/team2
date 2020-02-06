using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataLayer.FieldFactories;

namespace DataLayer.LevelFactories
{
    public class TxtLevelFactory : ILevelFactory
    {
        public Level Create(FileInfo inputFile)
        {
            Field field = new TxtFieldFactory().Create(new FileStream(inputFile.Name, FileMode.Open));
            return new Level(inputFile.Name, field);
        }
    }
}
