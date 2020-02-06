using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Level
    {
        public readonly string id;
        public Field field;

        public Level(string id, Field field)
        {
            this.id = id;
            this.field = field;
        }
    }
}
