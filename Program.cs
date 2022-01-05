//This is a program that parses information based on a transit map, creates objects from stations, services, and lines, links those
//objects together, and finally displays them to the user.

using System;

namespace MapWriter
{
    //This is the program class containing the main method.
    class Program
    {
        //The main method containing only the surface level operations; including the user interface.
        static void Main(string[] args)
        {
            bool programActive = true;
            Implementation implementation = new Implementation();

            implementation.StartUp();

            Console.WriteLine("Welcome to the MapWriter program. This program has multiple functions including:");
            Console.WriteLine("Parsing a list of station names.");
            Console.WriteLine("Creating stations, lines, and services from all the station names.");
            Console.WriteLine("Displaying a list of station names for each service.");
            Console.WriteLine("Simulating a subway train display station-by-station.");           

            //Program loop that continues running while the user keeps using the program. The user is given three choices.
            //If he choses choice 1, the user is asked to enter a service name, and the program lists all the stations within that
            //within that service in order along with their transfer connections.
            //If he choses choice 2, the user is asked to enter a service name, and the program gives the user information on each
            //stop as if they were traveling inside a train traveling on this service.
            //If he choses choice 3, the program exits the loops and ends.
            while (programActive)
            {
                bool parseSuccessful;
                Console.WriteLine("\nPlease choose one of the following options by entering the correct number preceding the option.");
                Console.WriteLine("1: Display list of stations in a service.");
                Console.WriteLine("2: Simulate subway train display.");
                Console.WriteLine("3: Exit program.");
                parseSuccessful = int.TryParse(Console.ReadLine(), out int userInput);
                if (parseSuccessful && userInput <= 3 && userInput > 0)
                {
                    string serviceInput;

                    switch (userInput)
                    {
                        case 1:                                                   
                            Console.WriteLine("\nPlease enter a service to display its stations.");
                            serviceInput = Console.ReadLine();

                            implementation.ReadStations(serviceInput);
                            break;
                        case 2:
                            Console.WriteLine("\nPlease enter a service to simulate train display.");
                            serviceInput = Console.ReadLine();

                            implementation.SimulateTrainDisplay(serviceInput);
                            break;
                        case 3:
                            Console.WriteLine("\nExiting program...");
                            programActive = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect option. Please choose one of the options below.");
                }
            }
        }
    }
}
