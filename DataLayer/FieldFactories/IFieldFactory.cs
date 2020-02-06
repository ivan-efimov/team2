using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLayer
{
    public interface IFieldFactory
    {
        Field Create(Stream inputStream);
    }
}
