using System.IO;
using DataLayer.LevelFactories;
using NUnit.Framework;

namespace NUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            FileInfo fileInfo = new FileInfo("Level1.txt");
            Assert.AreNotEqual(null, new TxtLevelFactory().Create(fileInfo));
        }
    }
}