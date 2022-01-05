using ImplementationLibrary;

namespace MapWriter
{
    public class Line : MapComponent
    {
        //This is the class definition of the Line object. It contains constructors, the Namer instantiator method, and completed
        //definitions of the Link methods from the MapComponent and MapMalleable classes.
        //The constructor of the object uses the Namer to validate the Name string by using a method that turns the string into an
        //enum defined within the HoustonSubway class library. If the string successfully turns into a valid enum, the ValidName field
        //becomes true, otherwise it is false and the name is set to INVALID so that debugging errors can be made easier.
        //The completed Link method for each component does four things: 1. it creates an object of the "this" type, 2. it creates an
        //object of the parameter type, 3. it links the "this" object to the parameter object, and 4. it links the parameter object
        //to "this" object. This method basically creates objects if they don't exist, then creates local and global links between
        //each other.
        public Line() { }

        public Line(string name, int id) : base(name, id)
        {
            Namer = new LineNamer();
            ValidName = Namer.AttachName(name);
            if (!ValidName)
                Name = "INVALID";
        }

        public override void NamerStart()
        {
            Namer = new LineNamer();
        }

        public override void LinkStation(Station station)
        {
            base.LinkStation(station);
            AddLine(this);
            StationLinks.Add(station.ID);
            station.LineLinks.Add(ID);
        }

        public override void LinkService(Service service)
        {
            base.LinkService(service);
            AddLine(this);
            ServiceLinks.Add(service.ID);
            service.LineLinks.Add(ID);
        }
    }
}
