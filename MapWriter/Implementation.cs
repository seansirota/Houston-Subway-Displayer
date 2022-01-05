using ImplementationLibrary;
using System;
using System.Linq;

namespace MapWriter
{
    //This class provides important methods that executes the user chooses from the main method. It also contains int values used
    //for creating unique ids for each object.
    public class Implementation
    {
        protected static int _stationIndexer = 0;
        protected static int _serviceIndexer = 0;
        protected static int _lineIndexer = 0;

        //The method that executes before the user chooses any option. It parses all station, service, and line enums into strings,
        //and then instantiates objects from all those strings with unique ids.
        public void StartUp()
        {
            StationCompiler stationCompiler = new StationCompiler();
            ServiceCompiler serviceCompiler = new ServiceCompiler();
            LineCompiler lineCompiler = new LineCompiler();

            CompileComponents(stationCompiler);
            CompileComponents(serviceCompiler);
            CompileComponents(lineCompiler);

            LinkAllObjects.CreateComponents();
        }

        //This method executes the function of choice 1. It parses through a list of station ids linked to a service, displays each
        //station name, and then displays connecting services to that station by checking the service links of each station linked
        //to the current station being looped through for a user-specified service.
        public void ReadStations(string serviceName)
        {
            Service service = MapComponent.ExtractService(serviceName);

            if (service != null)
            {
                Console.WriteLine("\nStations on {0} service:", service.Name);

                foreach (int stationID in service.StationLinks)
                {
                    Station station = MapComponent.ExtractStation(stationID);

                    Console.ForegroundColor = MapComponent.ExtractService(station.ServiceLinks[0]).Color;
                    Console.Write(station.Name + " ");

                    foreach (int id in station.StationLinks)
                    {
                        Station connectedStation = MapComponent.ExtractStation(id);
                        Service connectedService = MapComponent.ExtractService(connectedStation.ServiceLinks[0]);

                        Console.BackgroundColor = connectedService.Color;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(connectedService.Name);
                        Console.ResetColor();
                        Console.Write(" ");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\nInvalid name for service.");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        //This method executes the second choice from the main method. It has similar logic to the first method, however, it
        //displays multiple messages that give information like current station, next station and current line. There is also a
        //time delay between each message so it is more like a real train display.
        public void SimulateTrainDisplay(string serviceName)
        {
            Service service = MapComponent.ExtractService(serviceName);
            int lastStationIndex = service.StationLinks.Count;
            int milliseconds = 4000;

            if (service != null)
            {
                Console.WriteLine("\nSimulating display on {0} service:", service.Name);
                System.Threading.Thread.Sleep(milliseconds);

                for (int i = 0; i < lastStationIndex; i++)
                {
                    Station currentStation = MapComponent.ExtractStation(service.StationLinks[i]);                
                    Station lastStation = MapComponent.ExtractStation(service.StationLinks[lastStationIndex - 1]);
                    Line currentLine = MapComponent.ExtractLine(currentStation.LineLinks[0]);

                    Console.WriteLine("This stop is {0}.", currentStation.Name);
                    System.Threading.Thread.Sleep(milliseconds);
                    Console.WriteLine("This is the {0} bound {1} train.", lastStation.Name, service.Name);
                    System.Threading.Thread.Sleep(milliseconds);

                    if (currentStation != lastStation) {
                        Station nextStation = MapComponent.ExtractStation(service.StationLinks[i + 1]);
                        Console.WriteLine("Running via {0}. Next stop is {1}.", currentLine.Name, nextStation.Name);
                    }
                    else
                        Console.WriteLine("This is the last stop.");

                    if (currentStation.StationLinks != null && currentStation.StationLinks.Any())
                    {
                        int lastStationConnectionIndex = currentStation.StationLinks.Count;

                        System.Threading.Thread.Sleep(milliseconds);
                        Console.Write("Transfers available to the ");
                        for (int j = 0; j < lastStationConnectionIndex; j++)
                        {
                            Station connectedStation = MapComponent.ExtractStation(currentStation.StationLinks[j]);
                            Service connectedService = MapComponent.ExtractService(connectedStation.ServiceLinks[0]);

                            Console.BackgroundColor = connectedService.Color;
                            Console.ForegroundColor = ConsoleColor.Black;
                            if (j < lastStationConnectionIndex - 1 && currentStation.StationLinks.Count != 2)
                            {
                                Console.Write(connectedService.Name);
                                Console.ResetColor();
                                Console.Write(", ");                                
                            }                                                                
                            else if (j < lastStationConnectionIndex - 1 && currentStation.StationLinks.Count == 2)
                            {
                                Console.Write(connectedService.Name);
                                Console.ResetColor();
                                Console.Write(" ");
                            }
                            else if (j == lastStationConnectionIndex - 1 && currentStation.StationLinks.Count != 1)
                            {
                                Console.ResetColor();
                                Console.Write("and ");
                                Console.BackgroundColor = connectedService.Color;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(connectedService.Name);
                                Console.ResetColor();
                                Console.Write(" services.\n");
                            }                                
                            else
                            {
                                Console.Write(connectedService.Name);
                                Console.ResetColor();
                                Console.Write(" service.\n");
                            }                                                            
                        }
                    }
                    System.Threading.Thread.Sleep(milliseconds);
                }
            }
            else
            {
                Console.WriteLine("\nInvalid name for service.");
            }
        }

        //This method parses the strings created from the enums for each object, and then transforms them so that they can be used
        //as valid names for all the different stations, services, and links.
        public void CompileComponents(IComponentCompiler compiler)
        {
            compiler.ParseAndTransform();
        }

        //These next three methods are all left unused within the program's functionality. They were originally used to create
        //objects of each type without any links, and then I would've had to link all objects together after. Once I thought of
        //using the TripleInitiate method which instantiates a station object that is automatically linked to a service, line, and
        //other connecting stations, I dropped the ___Initiator idea since it was more tedious and requires more unnecessary code.
        public void StationInitiator(StationCompiler compiler)
        {
            foreach (string component in compiler.StationList)
            {
                Station station = new Station(component, ++_stationIndexer);
                MapComponent.AddStation(station);
            }
        }

        public void ServiceInitiator(ServiceCompiler compiler)
        {
            foreach (string component in compiler.ServiceList)
            {
                Service service = new Service(component, ++_serviceIndexer);
                MapComponent.AddService(service);
            }
        }

        public void LineInitiator(LineCompiler compiler)
        {
            foreach (string component in compiler.LineList)
            {
                Line line = new Line(component, ++_lineIndexer);
                MapComponent.AddLine(line);
            }
        }     
    }
}
