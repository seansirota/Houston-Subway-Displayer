using NUnit.Framework;
using MapWriter;

namespace ProjectTester
{
    //This class contains unit tests for the Extract method from the MapComponent class. It creates a couple objects, links
    //them together, and checks if the Extract method can find one of those objects by their ID.
    [TestFixture]
    public class ExtractTest1
    {
        public void ClearLists()
        {
            MapComponent.ClearStationList();
            MapComponent.ClearServiceList();
            MapComponent.ClearLineList();
        }

        [Test]
        public void StationID_Not_Found_In_Stations_List()
        {
            ClearLists();
            Station testStation = new Station("Stokes St", 5);
            Station linkStation1 = new Station("Navigation Blvd", 1);
            Station linkStation2 = new Station("Quitman St", 2);
            Station linkStation3 = new Station("Northside Village", 3);

            testStation.LinkStation(linkStation1);
            testStation.LinkStation(linkStation2);
            testStation.LinkStation(linkStation3);

            Assert.AreSame(null, MapComponent.ExtractService(4));
        }

        [Test]
        public void StationID_Found_In_Stations_List()
        {
            ClearLists();
            Station testStation = new Station("Stokes St", 5);
            Station linkStation1 = new Station("Navigation Blvd", 1);
            Station linkStation2 = new Station("Quitman St", 2);
            Station linkStation3 = new Station("Northside Village", 3);

            testStation.LinkStation(linkStation1);
            testStation.LinkStation(linkStation2);
            testStation.LinkStation(linkStation3);

            Assert.AreSame(linkStation3, MapComponent.ExtractStation(3));
        }

        [Test]
        public void ServiceID_Not_Found_In_Stations_List()
        {
            ClearLists();
            Station testStation = new Station("Stokes St", 5);
            Service linkService1 = new Service("G", 1);
            Service linkService2 = new Service("A", 2);
            Service linkService3 = new Service("T", 3);

            testStation.LinkService(linkService1);
            testStation.LinkService(linkService2);
            testStation.LinkService(linkService3);

            Assert.AreSame(null, MapComponent.ExtractService(4));
        }

        [Test]
        public void ServiceID_Found_In_Stations_List()
        {
            ClearLists();
            Station testStation = new Station("Stokes St", 5);
            Service linkService1 = new Service("G", 1);
            Service linkService2 = new Service("A", 2);
            Service linkService3 = new Service("T", 3);

            testStation.LinkService(linkService1);
            testStation.LinkService(linkService2);
            testStation.LinkService(linkService3);

            Assert.AreSame(linkService3, MapComponent.ExtractService(3));
        }

        [Test]
        public void LineID_Not_Found_In_Stations_List()
        {
            ClearLists();
            Station testStation = new Station("Stokes St", 5);
            Line linkLine1 = new Line("Spring", 1);
            Line linkLine2 = new Line("Northern", 2);
            Line linkLine3 = new Line("Main St", 3);

            testStation.LinkLine(linkLine1);
            testStation.LinkLine(linkLine2);
            testStation.LinkLine(linkLine3);

            Assert.AreSame(null, MapComponent.ExtractLine(4));
        }

        [Test]
        public void LineID_Found_In_Stations_List()
        {
            ClearLists();
            Station testStation = new Station("Stokes St", 5);
            Line linkLine1 = new Line("Spring", 1);
            Line linkLine2 = new Line("Northern", 2);
            Line linkLine3 = new Line("Main St", 3);

            testStation.LinkLine(linkLine1);
            testStation.LinkLine(linkLine2);
            testStation.LinkLine(linkLine3);

            Assert.AreSame(linkLine3, MapComponent.ExtractLine(3));            
        }

        [Test]
        public void StationID_Not_Found_In_Services_List()
        {
            ClearLists();
            Service testService = new Service("P", 5);
            Station linkStation1 = new Station("Navigation Blvd", 1);
            Station linkStation2 = new Station("Quitman St", 2);
            Station linkStation3 = new Station("Northside Village", 3);

            testService.LinkStation(linkStation1);
            testService.LinkStation(linkStation2);
            testService.LinkStation(linkStation3);

            Assert.AreSame(null, MapComponent.ExtractStation(4));
        }

        [Test]
        public void StationID_Found_In_Services_List()
        {
            ClearLists();
            Service testService = new Service("P", 5);
            Station linkStation1 = new Station("Navigation Blvd", 1);
            Station linkStation2 = new Station("Quitman St", 2);
            Station linkStation3 = new Station("Northside Village", 3);

            testService.LinkStation(linkStation1);
            testService.LinkStation(linkStation2);
            testService.LinkStation(linkStation3);

            Assert.AreSame(linkStation3, MapComponent.ExtractStation(3));

        }

        [Test]
        public void ServiceID_Not_Found_In_Services_List()
        {
            ClearLists();
            Service testService = new Service("P", 5);
            Service linkService1 = new Service("G", 1);
            Service linkService2 = new Service("A", 2);
            Service linkService3 = new Service("T", 3);

            testService.LinkService(linkService1);
            testService.LinkService(linkService2);
            testService.LinkService(linkService3);

            Assert.AreSame(null, MapComponent.ExtractService(4));
        }

        [Test]
        public void ServiceID_Found_In_Services_List()
        {
            ClearLists();
            Service testService = new Service("P", 5);
            Service linkService1 = new Service("G", 1);
            Service linkService2 = new Service("A", 2);
            Service linkService3 = new Service("T", 3);

            testService.LinkService(linkService1);
            testService.LinkService(linkService2);
            testService.LinkService(linkService3);

            Assert.AreSame(linkService3, MapComponent.ExtractService(3));
        }

        [Test]
        public void LineID_Not_Found_In_Services_List()
        {
            ClearLists();
            Service testService = new Service("P", 5);
            Line linkLine1 = new Line("Spring", 1);
            Line linkLine2 = new Line("Northern", 2);
            Line linkLine3 = new Line("Main St", 3);

            testService.LinkLine(linkLine1);
            testService.LinkLine(linkLine2);
            testService.LinkLine(linkLine3);

            Assert.AreSame(null, MapComponent.ExtractLine(4));
        }

        [Test]
        public void LineID_Found_In_Services_List()
        {
            ClearLists();
            Service testService = new Service("P", 5);
            Line linkLine1 = new Line("Spring", 1);
            Line linkLine2 = new Line("Northern", 2);
            Line linkLine3 = new Line("Main St", 3);

            testService.LinkLine(linkLine1);
            testService.LinkLine(linkLine2);
            testService.LinkLine(linkLine3);

            Assert.AreSame(linkLine3, MapComponent.ExtractLine(3));
        }

        [Test]
        public void StationID_Not_Found_In_Lines_List()
        {
            ClearLists();
            Line testLine = new Line("Tomball", 5);
            Station linkStation1 = new Station("Navigation Blvd", 1);
            Station linkStation2 = new Station("Quitman St", 2);
            Station linkStation3 = new Station("Northside Village", 3);

            testLine.LinkStation(linkStation1);
            testLine.LinkStation(linkStation2);
            testLine.LinkStation(linkStation3);

            Assert.AreSame(null, MapComponent.ExtractStation(4));
        }

        [Test]
        public void StationID_Found_In_Lines_List()
        {
            ClearLists();
            Line testLine = new Line("Tomball", 5);
            Station linkStation1 = new Station("Navigation Blvd", 1);
            Station linkStation2 = new Station("Quitman St", 2);
            Station linkStation3 = new Station("Northside Village", 3);

            testLine.LinkStation(linkStation1);
            testLine.LinkStation(linkStation2);
            testLine.LinkStation(linkStation3);

            Assert.AreSame(linkStation3, MapComponent.ExtractStation(3));
        }

        [Test]
        public void ServiceID_Not_Found_In_Lines_List()
        {
            ClearLists();
            Line testLine = new Line("Tomball", 5);
            Service linkService1 = new Service("G", 1);
            Service linkService2 = new Service("A", 2);
            Service linkService3 = new Service("T", 3);

            testLine.LinkService(linkService1);
            testLine.LinkService(linkService2);
            testLine.LinkService(linkService3);

            Assert.AreSame(null, MapComponent.ExtractService(4));
        }

        [Test]
        public void ServiceID_Found_In_Lines_List()
        {
            ClearLists();
            Line testLine = new Line("Tomball", 5);
            Service linkService1 = new Service("G", 1);
            Service linkService2 = new Service("A", 2);
            Service linkService3 = new Service("T", 3);

            testLine.LinkService(linkService1);
            testLine.LinkService(linkService2);
            testLine.LinkService(linkService3);

            Assert.AreSame(linkService3, MapComponent.ExtractService(3));
        }
    }
}
