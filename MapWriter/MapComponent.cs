using System.Collections.Generic;
using ImplementationLibrary;

namespace MapWriter
{
    //This is the component class which is an abstract version of any of the three map components: stations, services, and lines.
    //It contains all the fields and methods that the three components share and their partial and/or full definitions.
    public abstract class MapComponent
    {
        //These are all the fields shared by every component. Name and ID fields are most used for finding and adding stations.
        public int ID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public bool ValidName { get; set; } = false;
        public List<int> ServiceLinks { get; set; } = new List<int>();
        public List<int> StationLinks { get; set; } = new List<int>();
        public INamer Namer { get; set; }

        //These three static object lists store all objects every created by component type. There are methods created to add
        //new objects to these lists, and to look through the list to find a specific object by ID or by Name.
        private readonly static List<Station> _stations = new List<Station>();
        private readonly static List<Service> _services = new List<Service>();
        private readonly static List<Line> _lines = new List<Line>();
        
        public MapComponent() { }

        public MapComponent(string name, int id)
        {
            Name = name;
            ID = id;
        }

        //This is an abstract definition of the NamerStart method which creates an instance of the Namer field which is used for
        //validation of the names of these objects. Each child class has its own definition of the NamerStart method to valid the
        //name of a specific component type.
        public abstract void NamerStart();

        //The Link methods are partially defined at the MapComponent level in order to use the private object list fields and add
        //objects into them.
        public virtual void LinkStation(Station station)
        {
            AddStation(station);
        }

        public virtual void LinkService(Service service)
        {
            AddService(service);
        }

        //The Add methods create an instance of a specific component if it doesn't exist already, and adds it to the correct
        //object list.
        public static void AddStation(Station station)
        {
            if (!_stations.Exists(x => x.ID == station.ID))
                _stations.Add(station);
        }

        public static void AddService(Service service)
        {
            if (!_services.Exists(x => x.ID == service.ID))
                _services.Add(service);
        }

        public static void AddLine(Line line)
        {
            if (!_lines.Exists(x => x.ID == line.ID))
                _lines.Add(line);
        }

        //The Extract methods go into the object list fields and search them for a specific object. Every Extract method of
        //every object type has two overloads: one that searches by ID, and one that serches by Name.
        public static Station ExtractStation(int stationID)
        {
            Station station;

            try
            {
                station = _stations.Find(x => x.ID.Equals(stationID));
            }
            catch (System.Exception)
            {
                return null;
            }

            return station;
        }

        public static Station ExtractStation(string stationName, string serviceName)
        {
            Station station;

            try
            {
                foreach (Station s in _stations.FindAll(x => x.Name.Equals(stationName)))
                {
                    Service serviceMatch = _services.Find(x => x.Name.Equals(serviceName));
                    if (serviceMatch.ID == s.ServiceLinks.Find(x => x.Equals(serviceMatch.ID)))
                    {
                        station = s;
                        return station;
                    }

                    station = new Station();
                }
            }
            catch (System.Exception)
            {
                return new Station();
            }

            return new Station();
        }

        public static Service ExtractService(int serviceID)
        {
            Service service;

            try
            {
                service = _services.Find(x => x.ID.Equals(serviceID));
            }
            catch (System.Exception)
            {
                return null;
            }

            return service;
        }

        public static Service ExtractService(string serviceName)
        {
            Service service;

            try
            {
                service = _services.Find(x => x.Name.Equals(serviceName));
            }
            catch (System.Exception)
            {
                return null;
            }

            return service;
        }

        public static Line ExtractLine(int lineID)
        {
            Line line;

            try
            {
                line = _lines.Find(x => x.ID.Equals(lineID));
            }
            catch (System.Exception)
            {
                return null;
            }

            return line;
        }

        public static Line ExtractLine(string lineName)
        {
            Line line;

            try
            {
                line = _lines.Find(x => x.Name.Equals(lineName));
            }
            catch (System.Exception)
            {
                return null;
            }

            return line;
        }

        //The Clear methods are used to delete all objects within each object list. It was only used during unit testing.
        public static void ClearStationList()
        {
            _stations.Clear();
        }

        public static void ClearServiceList()
        {
            _services.Clear();
        }

        public static void ClearLineList()
        {
            _lines.Clear();
        }
    }
}
