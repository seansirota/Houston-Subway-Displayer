using ImplementationLibrary;
using System;

namespace MapWriter
{
    //This is the class definition of the Service object. It contains constructors, the Namer instantiator method, and completed
    //definitions of the Link methods from the MapComponent and MapMalleable classes.
    //The constructor of the object uses the Namer to validate the Name string by using a method that turns the string into an
    //enum defined within the HoustonSubway class library. If the string successfully turns into a valid enum, the ValidName field
    //becomes true, otherwise it is false and the name is set to INVALID so that debugging errors can be made easier.
    //The completed Link method for each component does four things: 1. it creates an object of the "this" type, 2. it creates an
    //object of the parameter type, 3. it links the "this" object to the parameter object, and 4. it links the parameter object
    //to "this" object. This method basically creates objects if they don't exist, then creates local and global links between
    //each other.
    //The Service class also has a ServiceColor method used to give the object a color specific to the service name. This color
    //is used for the console display when showing transfer connections to other services and to display the service color of each
    //station for choice 1.
    public class Service : MapMalleable
    {
        public ConsoleColor Color { get; set; }

        public Service() { }

        public Service(string name, int id) : base(name, id)
        {
            Namer = new ServiceNamer();
            ValidName = Namer.AttachName(name);
            Color = ServiceColor();
            if (!ValidName)
                Name = "INVALID";
        }

        public override void NamerStart()
        {
            Namer = new ServiceNamer();
        }

        public override void LinkStation(Station station)
        {
            base.LinkStation(station);
            AddService(this);
            StationLinks.Add(station.ID);
            station.ServiceLinks.Add(ID);
        }

        public override void LinkService(Service service)
        {
            base.LinkService(service);
            AddService(this);
            ServiceLinks.Add(service.ID);
            service.ServiceLinks.Add(ID);
        }

        public override void LinkLine(Line line)
        {
            base.LinkLine(line);
            AddService(this);
            LineLinks.Add(line.ID);
            line.ServiceLinks.Add(ID);
        }

        private ConsoleColor ServiceColor()
        {
            return ServiceColorer.GetColor(Name);
        }
    }
}
