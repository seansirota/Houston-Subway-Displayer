using NUnit.Framework;
using MapWriter;

namespace ProjectTester
{
    //This class contains unit tests for Link method to see two objects are really linked together by checking both of their
    //local link lists containing ids of objects they are linked to.
    [TestFixture]
    class LinkerTest
    {
        [Test]
        public void Link_Station_To_Station()
        {
            Station baseStation = new Station("Anything", 23);
            Station attachStation = new Station("Everything", 15);

            baseStation.LinkStation(attachStation);

            Assert.AreEqual(15, baseStation.StationLinks[0]);
            Assert.AreEqual(23, attachStation.StationLinks[0]);
        }

        [Test]
        public void Link_Station_To_Service()
        {
            Station baseStation = new Station("Anything", 23);
            Service attachService = new Service("Everything", 15);

            baseStation.LinkService(attachService);

            Assert.AreEqual(15, baseStation.ServiceLinks[0]);
            Assert.AreEqual(23, attachService.StationLinks[0]);
        }

        [Test]
        public void Link_Station_To_Line()
        {
            Station baseStation = new Station("Anything", 23);
            Line attachLine = new Line("Everything", 15);

            baseStation.LinkLine(attachLine);

            Assert.AreEqual(15, baseStation.LineLinks[0]);
            Assert.AreEqual(23, attachLine.StationLinks[0]);
        }

        [Test]
        public void Link_Service_To_Station()
        {
            Service baseService = new Service("Anything", 23);
            Station attachStation = new Station("Everything", 15);

            baseService.LinkStation(attachStation);

            Assert.AreEqual(15, baseService.StationLinks[0]);
            Assert.AreEqual(23, attachStation.ServiceLinks[0]);
        }

        [Test]
        public void Link_Service_To_Service()
        {
            Service baseService = new Service("Anything", 23);
            Service attachService = new Service("Everything", 15);

            baseService.LinkService(attachService);

            Assert.AreEqual(15, baseService.ServiceLinks[0]);
            Assert.AreEqual(23, attachService.ServiceLinks[0]);
        }

        [Test]
        public void Link_Service_To_Line()
        {
            Service baseService = new Service("Anything", 23);
            Line attachLine = new Line("Everything", 15);

            baseService.LinkLine(attachLine);

            Assert.AreEqual(15, baseService.LineLinks[0]);
            Assert.AreEqual(23, attachLine.ServiceLinks[0]);
        }

        [Test]
        public void Link_Line_To_Station()
        {
            Line baseLine = new Line("Anything", 23);
            Station attachStation = new Station("Everything", 15);

            baseLine.LinkStation(attachStation);

            Assert.AreEqual(15, baseLine.StationLinks[0]);
            Assert.AreEqual(23, attachStation.LineLinks[0]);
        }

        [Test]
        public void Link_Line_To_Service()
        {
            Line baseLine = new Line("Anything", 23);
            Service attachService = new Service("Everything", 15);

            baseLine.LinkService(attachService);

            Assert.AreEqual(15, baseLine.ServiceLinks[0]);
            Assert.AreEqual(23, attachService.LineLinks[0]);
        }
    }
}