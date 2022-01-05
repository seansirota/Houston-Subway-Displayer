using NUnit.Framework;
using MapWriter;

namespace ProjectTester
{
    //This class contains unit tests for name validation functionality of the Namer object.
    [TestFixture]
    class INamerTest
    {
        [Test]
        public void Check_Station_Name_With_INameChecker()
        {
            string name = "Eastex/Union";
            int id = 23;
            Station station = new Station(name, id);

            Assert.IsTrue(station.ValidName);
        }

        [Test]
        public void Check_Line_Name_With_INameChecker()
        {
            string name = "North Fwy";
            int id = 12;
            Line line = new Line(name, id);

            Assert.IsTrue(line.ValidName);
        }

        [Test]
        public void Check_Service_Name_With_INameChecker()
        {
            string name = "G";
            int id = 5;
            Service service = new Service(name, id);

            Assert.IsTrue(service.ValidName);
        }
    }
}