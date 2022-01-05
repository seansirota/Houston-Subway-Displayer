using NUnit.Framework;
using ImplementationLibrary;

namespace ProjectTester
{
    //This class contains unit tests for the ParseAndTransform method and checks to see if any of the parsed strings are invalid.
    [TestFixture]
    public class CompilerTest
    {
        [Test]
        public void Compile_All_Stations_Check_For_Empty_Strings()
        {
            StationCompiler stationCompiler = new StationCompiler();
            int emptyCount = stationCompiler.ParseAndTransform(true);

            Assert.IsTrue(emptyCount == 1);
        }

        [Test]
        public void Compile_All_Services_Check_For_Empty_Strings()
        {
            ServiceCompiler serviceCompiler = new ServiceCompiler();
            int emptyCount = serviceCompiler.ParseAndTransform(true);

            Assert.IsTrue(emptyCount == 1);
        }

        [Test]
        public void Compile_All_Lines_Check_For_Empty_Strings()
        {
            LineCompiler lineCompiler = new LineCompiler();
            int emptyCount = lineCompiler.ParseAndTransform(true);

            Assert.IsTrue(emptyCount == 1);
        }
    }
}
