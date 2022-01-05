using System.Collections.Generic;

namespace MapWriter
{
    //This class is a child class of the Implementation class because it does all the instantiation and linking work of the program,
    //and inherits the indexor int values so that it can create all objects with unique ids.
    public class LinkAllObjects : Implementation
    {
        //This method is what I used to create "station blocks", which is an instantiated station object automatically linked to
        //a service and line. This allows for a more organized way of instantiating stations and doing multiple tasks at once.
        public static void TripleInitiate(string stationName, string serviceName, string lineName)
        {
            Station station = new Station();
            station.NamerStart();

            if (MapComponent.ExtractStation(stationName, serviceName).Name == string.Empty)
            {
                station = new Station(stationName, ++_stationIndexer);
                Service service = MapComponent.ExtractService(serviceName);
                Line line = MapComponent.ExtractLine(lineName);

                if (service != null)
                    station.LinkService(service);
                else
                {
                    service = new Service();
                    service.NamerStart();
                    station.LinkService(new Service(serviceName, ++_serviceIndexer));
                }

                if (line != null)
                    station.LinkLine(line);
                else
                {
                    line = new Line();
                    line.NamerStart();
                    station.LinkLine(new Line(lineName, ++_lineIndexer));
                }                                                   
            }       
        }

        //This is an overload of the TripleInitiate method that also takes a list of service strings. This method links a newly
        //created station to other connecting stations of the same name on top of its regular functionality.
        public static void TripleInitiate(string stationName, string serviceName1, string lineName, List<string> serviceList)
        {
            TripleInitiate(stationName, serviceName1, lineName);
            foreach (string s in serviceList)
                MapComponent.ExtractStation(stationName, s).LinkStation(MapComponent.ExtractStation(stationName, serviceName1));
        }

        //This is a really long method that is used solely to create all station blocks for all the services.
        public static void CreateComponents()
        {
            //Initiating all Green service stations.
            //A Service.
            TripleInitiate("Altamira", "A", "Bellaire Blvd");
            TripleInitiate("Syrott Rd", "A", "Bellaire Blvd");
            TripleInitiate("Cook Rd", "A", "Bellaire Blvd");
            TripleInitiate("Hong Kong City Mall", "A", "Bellaire Blvd");
            TripleInitiate("Chinatown", "A", "Bellaire Blvd");
            TripleInitiate("Gessner Rd", "A", "Bellaire Blvd");
            TripleInitiate("PlazAmericas", "A", "Bellaire Blvd");
            TripleInitiate("Hillcroft Av", "A", "Bellaire Blvd");
            TripleInitiate("Alder Dr", "A", "Bellaire Blvd");
            TripleInitiate("Rice Av", "A", "Bellaire Blvd");
            TripleInitiate("Bellaire", "A", "Bellaire Blvd");
            TripleInitiate("Stella Link Rd", "A", "Bellaire Blvd");
            TripleInitiate("Buffalo Spwy", "A", "Bellaire Blvd");
            TripleInitiate("Greenbriar Dr", "A", "Bellaire Blvd");
            TripleInitiate("RU - Texas Medical Ctr", "A", "Main St");            
            TripleInitiate("Blodgett St", "A", "Main St");
            TripleInitiate("CBD", "A", "Main St");
            TripleInitiate("Skyline District", "A", "Main St");                                   
            TripleInitiate("Stokes St", "A", "Main St");            
            TripleInitiate("Northside", "A", "North Fwy");
            TripleInitiate("Mitchell Rd", "A", "North Fwy");
            TripleInitiate("Mt Houston Rd", "A", "North Fwy");
            TripleInitiate("West Rd", "A", "North Fwy");
            TripleInitiate("Greater Greenspoint", "A", "North Fwy");
            TripleInitiate("Greenspoint Mall", "A", "North Fwy");
            TripleInitiate("Rankin Rd", "A", "North Fwy");
            TripleInitiate("Airtex Dr", "A", "North Fwy");
            TripleInitiate("Forest Blvd", "A", "North Fwy");
            TripleInitiate("Paramount North", "A", "North Fwy");

            //B Service.
            TripleInitiate("West Oaks Mall", "B", "Westheimer Rd");
            TripleInitiate("Eldridge Pkwy", "B", "Westheimer Rd");
            TripleInitiate("Dairy Ashford Rd", "B", "Westheimer Rd");
            TripleInitiate("Houston Center Blvd", "B", "Westheimer Rd");
            TripleInitiate("Wilcrest Dr", "B", "Westheimer Rd");
            TripleInitiate("Gessner Rd", "B", "Westheimer Rd");
            TripleInitiate("Mid-West", "B", "Westheimer Rd");
            TripleInitiate("Stony Brook Dr", "B", "Westheimer Rd");
            TripleInitiate("Briarhurst Dr", "B", "Westheimer Rd");
            TripleInitiate("Bering Dr", "B", "Westheimer Rd");
            TripleInitiate("Uptown", "B", "Westheimer Rd");
            TripleInitiate("Kettering Dr", "B", "Westheimer Rd");
            TripleInitiate("Weslayan St", "B", "Westheimer Rd");
            TripleInitiate("Buffalo Spwy", "B", "Westheimer Rd");
            TripleInitiate("Kirby Dr", "B", "Westheimer Rd");
            TripleInitiate("Dunlavy St", "B", "Westheimer Rd");
            TripleInitiate("Montrose Blvd", "B", "Westheimer Rd");            
            TripleInitiate("CBD", "B", "Main St", new List<string> { "A" });
            TripleInitiate("Skyline District", "B", "Main St", new List<string> { "A" });
            TripleInitiate("Stokes St", "B", "Main St", new List<string> { "A" });
            TripleInitiate("North Fwy", "B", "Cypresswood");
            TripleInitiate("Beall St", "B", "Cypresswood");
            TripleInitiate("Victory Dr", "B", "Cypresswood");
            TripleInitiate("Gulfbank Rd", "B", "Cypresswood");
            TripleInitiate("Killough Dr", "B", "Cypresswood");
            TripleInitiate("Frick Rd", "B", "Cypresswood");
            TripleInitiate("Greenfield Village", "B", "Cypresswood");
            TripleInitiate("Northcliffe Village", "B", "Cypresswood");
            TripleInitiate("Cypress Creek Dr", "B", "Cypresswood");
            TripleInitiate("Cypresswood", "B", "Cypresswood");

            //K Service.
            TripleInitiate("NRG Stadium", "K", "Stadium");
            TripleInitiate("Fannin St", "K", "Stadium");
            TripleInitiate("RU - Texas Medical Ctr", "K", "Main St", new List<string> { "A" });
            TripleInitiate("Museum District", "K", "Main St");
            TripleInitiate("Blodgett St", "K", "Main St", new List<string> { "A" });
            TripleInitiate("Tuam St", "K", "Main St");
            TripleInitiate("CBD", "K", "Main St", new List<string> { "A", "B" });
            TripleInitiate("Skyline District", "K", "Main St", new List<string> { "A", "B" });
            TripleInitiate("UHD", "K", "Main St");
            TripleInitiate("Quitman St", "K", "Main St");
            TripleInitiate("Northside Village", "K", "Main St");
            TripleInitiate("Stokes St", "K", "Main St", new List<string> { "A", "B" });
            TripleInitiate("Berry Rd", "K", "Main St");
            TripleInitiate("Northside", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Mitchell Rd", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Mt Houston Rd", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("West Rd", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Greater Greenspoint", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Greenspoint Mall", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Rankin Rd", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Airtex Dr", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Forest Blvd", "K", "North Fwy", new List<string> { "A" });
            TripleInitiate("Paramount North", "K", "North Fwy", new List<string> { "A" });

            //Initiating all Orange service stations.
            //C Service.
            TripleInitiate("First Colony Mall", "C", "Sugarland");
            TripleInitiate("Englewood", "C", "Sugarland");
            TripleInitiate("Dulles Av", "C", "Sugarland");
            TripleInitiate("Independence Blvd", "C", "Sugarland");
            TripleInitiate("Staffordshire Rd", "C", "Sugarland");
            TripleInitiate("Lexington Blvd", "C", "Sugarland");
            TripleInitiate("Missouri City", "C", "Sugarland");
            TripleInitiate("Cravens Rd", "C", "Sugarland");
            TripleInitiate("Fondren Meadow Dr", "C", "Sugarland");
            TripleInitiate("Brays Oaks", "C", "Bellfort Av");
            TripleInitiate("NRG Stadium", "C", "Bellfort Av", new List<string> { "K" });
            TripleInitiate("Texas Medical Ctr", "C", "Bellfort Av");
            TripleInitiate("Toyota Ctr", "C", "Crawford St");
            TripleInitiate("Minute Maid Park", "C", "Crawford St");
            TripleInitiate("Hardy/Union", "C", "Northern");
            TripleInitiate("North Fwy", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Beall St", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Victory Dr", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Gulfbank Rd", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Killough Dr", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Frick Rd", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Greenfield Village", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Northcliffe Village", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Cypress Creek Dr", "C", "Cypresswood", new List<string> { "B" });
            TripleInitiate("Cypresswood", "C", "Cypresswood", new List<string> { "B" });

            //F Service.
            TripleInitiate("Pheasant Cove", "F", "Westpark Tlwy");
            TripleInitiate("Houston Center Blvd", "F", "Westpark Tlwy");
            TripleInitiate("Rogerdale Rd", "F", "Westpark Tlwy");
            TripleInitiate("Gessner Rd", "F", "Westpark Tlwy");
            TripleInitiate("Mahatma Gandhi District", "F", "Westpark Tlwy");
            TripleInitiate("Larchmont", "F", "Southwest Fwy");
            TripleInitiate("Blodgett St", "F", "Southwest Fwy", new List<string> { "A", "K" });
            TripleInitiate("Toyota Ctr", "F", "Crawford St", new List<string> { "C" });
            TripleInitiate("Minute Maid Park", "F", "Crawford St", new List<string> { "C" });
            TripleInitiate("Eastex/Lyons", "F", "Market St");
            TripleInitiate("Greens Bayou", "F", "Market St");
            TripleInitiate("Freeport St", "F", "Interbay");
            TripleInitiate("Marwood", "F", "Interbay");
            TripleInitiate("Channelview", "F", "Interbay");
            TripleInitiate("Bayou Dr", "F", "Interbay");
            TripleInitiate("Bayway Dr", "F", "Interbay");
            TripleInitiate("Baker Rd", "F", "Interbay");
            TripleInitiate("Town Ctr", "F", "Interbay");
            TripleInitiate("Chaparral Dr", "F", "Interbay");
            TripleInitiate("Bramor", "F", "Interbay");

            //N Service.
            TripleInitiate("Brays Oaks", "N", "Bellfort Av", new List<string> { "C" });
            TripleInitiate("Mullins Dr", "N", "Bellfort Av");
            TripleInitiate("Willowbend Blvd", "N", "Bellfort Av");
            TripleInitiate("Stella Link Rd", "N", "Bellfort Av");
            TripleInitiate("South Main", "N", "Bellfort Av");
            TripleInitiate("NRG Stadium", "N", "Bellfort Av", new List<string> { "C", "K" });
            TripleInitiate("Fannin St", "N", "Bellfort Av", new List<string> { "K" });
            TripleInitiate("Texas Medical Ctr", "N", "Bellfort Av", new List<string> { "C" });
            TripleInitiate("Southmore Blvd", "N", "Bellfort Av");
            TripleInitiate("Elgin St", "N", "Crawford St");
            TripleInitiate("Hadley St", "N", "Crawford St");
            TripleInitiate("Toyota Ctr", "N", "Crawford St", new List<string> { "C", "F" });
            TripleInitiate("Minute Maid Park", "N", "Crawford St", new List<string> { "C", "F" });
            TripleInitiate("Eastex/Lyons", "N", "Market St", new List<string> { "F" });
            TripleInitiate("Lockwood Dr", "N", "Market St");
            TripleInitiate("Wayside Dr", "N", "Market St");
            TripleInitiate("Gellhorn Dr", "N", "Market St");
            TripleInitiate("Mercury Dr", "N", "Market St");
            TripleInitiate("Greens Bayou", "N", "Market St", new List<string> { "F" });
            TripleInitiate("Orleans St", "N", "New Forest");
            TripleInitiate("Woodforest Blvd", "N", "New Forest");
            TripleInitiate("SJC North", "N", "New Forest");

            //R Service.
            TripleInitiate("Mahatma Gandhi District", "R", "Westpark Tlwy", new List<string> { "F" });
            TripleInitiate("Hillcroft Av", "R", "Westpark Tlwy");
            TripleInitiate("Fountain View Dr", "R", "Southwest Fwy");
            TripleInitiate("Larchmont", "R", "Southwest Fwy", new List<string> { "F" });
            TripleInitiate("Newcastle Dr", "R", "Southwest Fwy");
            TripleInitiate("Edloe St", "R", "Southwest Fwy");
            TripleInitiate("Kirby Dr", "R", "Southwest Fwy");
            TripleInitiate("Mandell St", "R", "Southwest Fwy");
            TripleInitiate("Blodgett St", "R", "Southwest Fwy", new List<string> { "A", "F", "K" });
            TripleInitiate("Elgin St", "R", "Crawford St", new List<string> { "N" });
            TripleInitiate("Hadley St", "R", "Crawford St", new List<string> { "N" });
            TripleInitiate("Toyota Ctr", "R", "Crawford St", new List<string> { "C", "F", "N" });
            TripleInitiate("Minute Maid Park", "R", "Crawford St", new List<string> { "C", "F", "N" });
            TripleInitiate("Quitman St", "R", "Northern");
            TripleInitiate("Cavalcade St", "R", "Northern");
            TripleInitiate("Hardy/Union", "R", "Northern", new List<string> { "C" });
            TripleInitiate("Berry Rd", "R", "Northern");
            TripleInitiate("Little York Rd", "R", "Northern");
            TripleInitiate("Aldine Gardens", "R", "Northern");
            TripleInitiate("Aldine Bender Rd", "R", "Northern");
            TripleInitiate("Greenbranch", "R", "Northern");
            TripleInitiate("Imperial Green", "R", "Northern");
            TripleInitiate("GBI Airport A & B", "R", "Airport");
            TripleInitiate("GBI Airport D & E", "R", "Airport");

            //Initiating all Blue service stations.
            //D Service.
            TripleInitiate("Spring Branch West", "D", "Spring");
            TripleInitiate("Spring Valley Village", "D", "Spring");
            TripleInitiate("Bingle Rd", "D", "Spring");
            TripleInitiate("Wirt Rd", "D", "Spring");
            TripleInitiate("Northwest Houston CHCP", "D", "Spring");
            TripleInitiate("Rice Military", "D", "Spring");
            TripleInitiate("Skyline District", "D", "Spring", new List<string> { "A", "B", "K" });
            TripleInitiate("Minute Maid Park", "D", "Spring", new List<string> { "C", "F", "N", "R" });
            TripleInitiate("BBVA Stadium", "D", "Spring");
            TripleInitiate("Harrisburg", "D", "Spring");
            TripleInitiate("Findlay St", "D", "Broadway St");
            TripleInitiate("Bellfort Av", "D", "Broadway St");
            TripleInitiate("WPH Airport", "D", "Broadway St");
            TripleInitiate("Airport Blvd", "D", "Broadway St");
            TripleInitiate("Almeda Mall", "D", "NASA");
            TripleInitiate("Southbelt", "D", "NASA");
            TripleInitiate("Clearlake Medical Ctr", "D", "NASA");
            TripleInitiate("NASA", "D", "NASA");

            //H Service.
            TripleInitiate("Spring Branch West", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Spring Valley Village", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Bingle Rd", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Wirt Rd", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Northwest Houston CHCP", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Rice Military", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Skyline District", "H", "Spring", new List<string> { "A", "B", "D", "K" });
            TripleInitiate("Minute Maid Park", "H", "Spring", new List<string> { "C", "D", "F", "N", "R" });
            TripleInitiate("BBVA Stadium", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Harrisburg", "H", "Spring", new List<string> { "D" });
            TripleInitiate("Oak Park", "H", "Pasadena");
            TripleInitiate("Center St", "H", "Pasadena");
            TripleInitiate("La Porte", "H", "Pasadena");
            TripleInitiate("East La Porte", "H", "Baytown");
            TripleInitiate("Morgan's Point", "H", "Baytown");
            TripleInitiate("Pelly", "H", "Baytown");
            TripleInitiate("Baytown", "H", "Baytown");
            TripleInitiate("Park St", "H", "Baytown");
            TripleInitiate("Town Ctr", "H", "Baytown");
            TripleInitiate("Baytown Village", "H", "Baytown");
            TripleInitiate("San Jacinto Mall", "H", "Baytown");

            //S Service.
            TripleInitiate("Northwest Houston CHCP", "S", "Spring", new List<string> { "D", "H" });
            TripleInitiate("12 St", "S", "Spring");
            TripleInitiate("Hempstead Rd", "S", "Spring");
            TripleInitiate("Memorial Park", "S", "Spring");
            TripleInitiate("Rice Military", "S", "Spring", new List<string> { "D", "H" });
            TripleInitiate("Heights Blvd", "S", "Spring");
            TripleInitiate("Sawyer St", "S", "Spring");
            TripleInitiate("Houston Station", "S", "Spring");
            TripleInitiate("Skyline District", "S", "Spring", new List<string> { "A", "B", "D", "H", "K" });
            TripleInitiate("Minute Maid Park", "S", "Spring", new List<string> { "C", "D", "F", "H", "N", "R" });
            TripleInitiate("BBVA Stadium", "S", "Spring", new List<string> { "D", "H" });
            TripleInitiate("Sampson St", "S", "Spring");
            TripleInitiate("Eastwood St", "S", "Spring");
            TripleInitiate("Latham St", "S", "Spring");
            TripleInitiate("Greater East End", "S", "Spring");
            TripleInitiate("78 St", "S", "Spring");
            TripleInitiate("Harrisburg", "S", "Spring", new List<string> { "D", "H" });
            TripleInitiate("Allen Genoa Rd", "S", "Pasadena");
            TripleInitiate("Oak Park", "S", "Pasadena", new List<string> { "H" });
            TripleInitiate("Macroplaza Mall", "S", "Pasadena");
            TripleInitiate("Strawberry Rd", "S", "Pasadena");
            TripleInitiate("Preston Av", "S", "Pasadena");
            TripleInitiate("Red Bluff Rd", "S", "Pasadena");
            TripleInitiate("Center St", "S", "Pasadena", new List<string> { "H" });
            TripleInitiate("Filmore Ln", "S", "Pasadena");
            TripleInitiate("H St", "S", "Pasadena");
            TripleInitiate("Myrtle Creek Dr", "S", "Pasadena");
            TripleInitiate("Fleetwood Dr", "S", "Pasadena");
            TripleInitiate("Bay Area Blvd", "S", "Pasadena");
            TripleInitiate("La Porte", "S", "Pasadena", new List<string> { "H" });

            //Initiating all Yellow service stations.
            //E Service.
            TripleInitiate("Kohrville", "E", "Tomball");
            TripleInitiate("Cypresswood Dr", "E", "Tomball");
            TripleInitiate("Willowbrook Mall", "E", "Tomball");
            TripleInitiate("Sam Houston Race Park", "E", "Tomball");
            TripleInitiate("Willowood", "E", "Tomball");
            TripleInitiate("Breen Dr", "E", "Tomball");
            TripleInitiate("Alabonson Rd", "E", "Tomball");
            TripleInitiate("Greater Inwood", "E", "Tomball");
            TripleInitiate("Pinemont Dr", "E", "Tomball");
            TripleInitiate("Watonga Blvd", "E", "Tomball");
            TripleInitiate("Ella Blvd", "E", "Shepherd Dr");
            TripleInitiate("Shady Acres", "E", "Shepherd Dr");
            TripleInitiate("11 St", "E", "Shepherd Dr");
            TripleInitiate("Rice Military", "E", "Shepherd Dr", new List<string> { "D", "H", "S" });
            TripleInitiate("CBD", "E", "Shepherd Dr", new List<string> { "A", "B", "K" });
            TripleInitiate("Toyota Ctr", "E", "Shepherd Dr", new List<string> { "C", "F", "N", "R" });
            TripleInitiate("East Downtown", "E", "Shepherd Dr");
            TripleInitiate("Southeast Houston", "E", "Pearland");
            TripleInitiate("WPH Airport", "E", "South Pasadena", new List<string> { "D" });
            TripleInitiate("South Houston", "E", "South Pasadena");
            TripleInitiate("Westside Terrace", "E", "South Pasadena");
            TripleInitiate("Burke Rd", "E", "South Pasadena");
            TripleInitiate("Golden Acres", "E", "South Pasadena");
            TripleInitiate("Red Bluff Rd", "E", "South Pasadena");
            TripleInitiate("SJC Central", "E", "South Pasadena");
            TripleInitiate("East Blvd", "E", "South Pasadena");
            TripleInitiate("La Porte", "E", "Pasadena", new List<string> { "H", "S" });

            //Q Service.
            TripleInitiate("Energy Corridor", "Q", "Katy Fwy");
            TripleInitiate("Eldridge Pkwy", "Q", "Katy Fwy");
            TripleInitiate("Tully St", "Q", "Katy Fwy");
            TripleInitiate("Wilcrest Dr", "Q", "Katy Fwy");
            TripleInitiate("Memorial City Mall", "Q", "Katy Fwy");
            TripleInitiate("Hedwig Village", "Q", "Katy Fwy");
            TripleInitiate("Voss Rd", "Q", "Katy Fwy");
            TripleInitiate("Spring Branch East", "Q", "Katy Fwy");
            TripleInitiate("Memorial Park", "Q", "Katy Fwy", new List<string> { "S" });
            TripleInitiate("Rice Military", "Q", "Shepherd Dr", new List<string> { "D", "E", "H", "S" });
            TripleInitiate("Kirby Dr", "Q", "Shepherd Dr");
            TripleInitiate("Waugh Dr", "Q", "Shepherd Dr");
            TripleInitiate("Genesee St", "Q", "Shepherd Dr");
            TripleInitiate("CBD", "Q", "Shepherd Dr", new List<string> { "A", "B", "E", "K" });
            TripleInitiate("Toyota Ctr", "Q", "Shepherd Dr", new List<string> { "C", "E", "F", "N", "R" });
            TripleInitiate("East Downtown", "Q", "Shepherd Dr", new List<string> { "E" });
            TripleInitiate("Scott St", "Q", "Pearland");
            TripleInitiate("University of Houston", "Q", "Pearland");
            TripleInitiate("Griggs Rd", "Q", "Pearland");
            TripleInitiate("Dixie Dr", "Q", "Pearland");
            TripleInitiate("Southeast Houston", "Q", "Pearland", new List<string> { "E" });
            TripleInitiate("Greater Hobby Area", "Q", "Pearland");
            TripleInitiate("Schurmier Rd", "Q", "Pearland");
            TripleInitiate("McHard Rd", "Q", "Pearland");
            TripleInitiate("Pearland", "Q", "Pearland");

            //T Service.
            TripleInitiate("Rice Military", "T", "Shepherd Dr", new List<string> { "D", "E", "H", "Q", "S" });
            TripleInitiate("Kirby Dr", "T", "Shepherd Dr", new List<string> { "Q" });
            TripleInitiate("Waugh Dr", "T", "Shepherd Dr", new List<string> { "Q" });
            TripleInitiate("Genesee St", "T", "Shepherd Dr", new List<string> { "Q" });
            TripleInitiate("CBD", "T", "Shepherd Dr", new List<string> { "A", "B", "E", "K", "Q" });
            TripleInitiate("Toyota Ctr", "T", "Shepherd Dr", new List<string> { "C", "E", "F", "N", "Q", "R" });
            TripleInitiate("East Downtown", "T", "Shepherd Dr", new List<string> { "E", "Q" });
            TripleInitiate("Scott St", "T", "Pearland", new List<string> { "Q" });
            TripleInitiate("University of Houston", "T", "Pearland", new List<string> { "Q" });
            TripleInitiate("Griggs Rd", "T", "Pearland", new List<string> { "Q" });
            TripleInitiate("Dixie Dr", "T", "Pearland", new List<string> { "Q" });
            TripleInitiate("Southeast Houston", "T", "Pearland", new List<string> { "E", "Q" });
            TripleInitiate("Kopman Dr", "T", "South Pasadena");
            TripleInitiate("Telephone Rd", "T", "South Pasadena");
            TripleInitiate("WPH Airport", "T", "South Pasadena", new List<string> { "D", "E" });
            TripleInitiate("Edgebrook Dr", "T", "NASA");
            TripleInitiate("Almeda Mall", "T", "NASA", new List<string> { "D" });
            TripleInitiate("Fuqua St", "T", "NASA");
            TripleInitiate("Southbelt", "T", "NASA", new List<string> { "D" });
            TripleInitiate("Dixie Farm Rd", "T", "NASA");
            TripleInitiate("El Dorado Blvd", "T", "NASA");
            TripleInitiate("Baybrook Mall", "T", "NASA");
            TripleInitiate("Clearlake Medical Ctr", "T", "NASA", new List<string> { "D" });
            TripleInitiate("Egret Bay Blvd", "T", "NASA");
            TripleInitiate("NASA", "T", "NASA", new List<string> { "D" });

            //Initiating all Purple service stations.
            //G Service.
            TripleInitiate("First Colony Mall", "G", "Southwest Fwy", new List<string> { "C" });
            TripleInitiate("Sugar Land Office Park", "G", "Southwest Fwy");
            TripleInitiate("Sugar Creek Blvd", "G", "Southwest Fwy");
            TripleInitiate("Kirkwood Rd", "G", "Southwest Fwy");
            TripleInitiate("Bellfort Av", "G", "Southwest Fwy");
            TripleInitiate("Westwood", "G", "Southwest Fwy");
            TripleInitiate("Beechnut St", "G", "Southwest Fwy");
            TripleInitiate("PlazAmericas", "G", "Southwest Fwy", new List<string> { "A" });
            TripleInitiate("Hillcroft Av", "G", "Southwest Fwy");
            TripleInitiate("Larchmont", "G", "Southwest Fwy", new List<string> { "F", "R" });
            TripleInitiate("Blodgett St", "G", "Southwest Fwy", new List<string> { "F", "R" });
            TripleInitiate("East Downtown", "G", "Eastern", new List<string> { "E", "Q", "T" });
            TripleInitiate("BBVA Stadium", "G", "Eastern", new List<string> { "D", "H", "S" });
            TripleInitiate("Eastex/Lyons", "G", "Eastern", new List<string> { "F", "N" });
            TripleInitiate("Eastex/Union", "G", "Eastern");
            TripleInitiate("Eastex/Jenson", "G", "Eastern");
            TripleInitiate("Lauder Rd", "G", "Eastern");
            TripleInitiate("Aldine Bender Rd", "G", "Eastern");
            TripleInitiate("Bender/Greens", "G", "Eastern");
            TripleInitiate("Rankin Rd", "G", "Eastern");
            TripleInitiate("GBI Airport D & E", "G", "Airport", new List<string> { "R" });
            TripleInitiate("GBI Airport A & B", "G", "Airport", new List<string> { "R" });

            //J Service.
            TripleInitiate("Brookside Village", "J", "Cullen Blvd");
            TripleInitiate("McHard Rd", "J", "Cullen Blvd");
            TripleInitiate("Brunswick Lakes", "J", "Cullen Blvd");
            TripleInitiate("Crestmont Park", "J", "Cullen Blvd");
            TripleInitiate("Airport Blvd", "J", "Cullen Blvd");
            TripleInitiate("Bellfort Av", "J", "Cullen Blvd");
            TripleInitiate("Yellowstone Blvd", "J", "Cullen Blvd");
            TripleInitiate("MacGregor Park", "J", "Cullen Blvd");
            TripleInitiate("University of Houston", "J", "Cullen Blvd");
            TripleInitiate("TSU", "J", "Cullen Blvd");
            TripleInitiate("East Downtown", "J", "Eastern", new List<string> { "E", "G", "Q", "T" });
            TripleInitiate("BBVA Stadium", "J", "Eastern", new List<string> { "D", "G", "H", "S" });
            TripleInitiate("Eastex/Lyons", "J", "Eastern", new List<string> { "F", "G", "N" });
            TripleInitiate("Eastex/Union", "J", "Eastern", new List<string> { "G" });
            TripleInitiate("Eastex/Jenson", "J", "Eastern", new List<string> { "G" });
            TripleInitiate("Lauder Rd", "J", "Eastern", new List<string> { "G" });
            TripleInitiate("Oak Village Dr", "J", "Lake Houston");
            TripleInitiate("Humble Park", "J", "Lake Houston");
            TripleInitiate("Will Clayton Pkwy", "J", "Lake Houston");
            TripleInitiate("Timber Forest Dr", "J", "Lake Houston");
            TripleInitiate("Atascocita", "J", "Lake Houston");

            //M Service.
            TripleInitiate("Pearland Town Ctr", "M", "South Fwy");
            TripleInitiate("McHard Rd", "M", "South Fwy");
            TripleInitiate("Almeda Genoa Rd", "M", "South Fwy");
            TripleInitiate("AVEVA Stadium", "M", "South Fwy");
            TripleInitiate("Sunnyside", "M", "South Fwy");
            TripleInitiate("Holmes Rd", "M", "South Fwy");
            TripleInitiate("Holcombe Blvd", "M", "South Fwy");
            TripleInitiate("Southmore Blvd", "M", "South Fwy");
            TripleInitiate("Emancipation Park", "M", "Eastern");
            TripleInitiate("Hadley St", "M", "Eastern");
            TripleInitiate("East Downtown", "M", "Eastern", new List<string> { "E", "G", "J", "Q", "T" });
            TripleInitiate("BBVA Stadium", "M", "Eastern", new List<string> { "D", "G", "H", "J", "S" });
            TripleInitiate("Navigation Blvd", "M", "Eastern");
            TripleInitiate("Eastex/Lyons", "M", "Eastern", new List<string> { "F", "G", "J", "N" });
            TripleInitiate("Collingsworth St", "M", "Eastern");
            TripleInitiate("Eastex/Union", "M", "Eastern", new List<string> { "G", "J" });
            TripleInitiate("Eastex/Jenson", "M", "Eastern", new List<string> { "G", "J" });
            TripleInitiate("Little York Rd", "M", "Eastern");
            TripleInitiate("Mt Houston", "M", "Eastern");
            TripleInitiate("Lauder Rd", "M", "Eastern", new List<string> { "G", "J" });
            TripleInitiate("Aldine Bender Rd", "M", "Eastern", new List<string> { "G" });
            TripleInitiate("Bender/Greens", "M", "Eastern", new List<string> { "G" });
            TripleInitiate("Rankin Rd", "M", "Eastern", new List<string> { "G" });
            TripleInitiate("GBI Airport D & E", "M", "Airport", new List<string> { "G", "R" });
            TripleInitiate("GBI Airport A & B", "M", "Airport", new List<string> { "G", "R" });

            //Initiating all Cyan service stations.
            //L Service.
            TripleInitiate("Crossroads", "L", "Northwest Fwy");
            TripleInitiate("Eldridge Pkwy", "L", "Northwest Fwy");
            TripleInitiate("Jones Rd", "L", "Northwest Fwy");
            TripleInitiate("Senate Av", "L", "Northwest Fwy");
            TripleInitiate("Gessner Rd", "L", "Northwest Fwy");
            TripleInitiate("Fairbanks", "L", "Northwest Fwy");
            TripleInitiate("Pinemont Dr", "L", "Northwest Fwy");
            TripleInitiate("Antoine Dr", "L", "Northwest Fwy");
            TripleInitiate("Ella Blvd", "L", "Northwest Fwy", new List<string> { "E" });
            TripleInitiate("Yale St", "L", "Atascocita");
            TripleInitiate("Stokes St", "L", "Atascocita", new List<string> { "A", "B", "K" });
            TripleInitiate("Hardy/Union", "L", "Atascocita", new List<string> { "C", "R" });
            TripleInitiate("Eastex/Union", "L", "Atascocita", new List<string> { "G", "J", "M" });
            TripleInitiate("Crosstimbers St", "L", "Atascocita");
            TripleInitiate("Homestead/Wayside", "L", "Atascocita");
            TripleInitiate("Little York Rd", "L", "Atascocita");
            TripleInitiate("Mt Houston Rd", "L", "Atascocita");
            TripleInitiate("Water Works Blvd", "L", "Atascocita");
            TripleInitiate("Lakeshore", "L", "Atascocita");
            TripleInitiate("Harmaston", "L", "Atascocita");
            TripleInitiate("Atascocita", "L", "Atascocita", new List<string> { "J" });

            //Initiating all Brown service stations.
            //P Service.
            TripleInitiate("Spring Valley Village", "P", "Suburban", new List<string> { "D", "H" });
            TripleInitiate("Hedwig Village", "P", "Suburban", new List<string> { "Q" });
            TripleInitiate("Piney Point Village", "P", "Suburban");
            TripleInitiate("Mid-West", "P", "Suburban", new List<string> { "B" });
            TripleInitiate("Mahatma Gandhi District", "P", "Suburban", new List<string> { "F", "R" });
            TripleInitiate("PlazAmericas", "P", "Suburban", new List<string> { "A", "G" });
            TripleInitiate("Bissonet St", "P", "Suburban");
            TripleInitiate("Brays Oaks", "P", "Suburban", new List<string> { "C", "N" });
            TripleInitiate("Fondren Gardens", "P", "Suburban");
            TripleInitiate("Post Oak Rd", "P", "Suburban");
            TripleInitiate("Central Southwest", "P", "Suburban");
            TripleInitiate("AVEVA Stadium", "P", "Suburban", new List<string> { "M" });
            TripleInitiate("Crestmont Park", "P", "Suburban", new List<string> { "J" });
            TripleInitiate("Minnetex", "P", "Suburban");
            TripleInitiate("Greater Hobby Area", "P", "Suburban", new List<string> { "Q" });
            TripleInitiate("Monroe Blvd", "P", "Suburban");
            TripleInitiate("Almeda Mall", "P", "Suburban", new List<string> { "D", "T" });
            TripleInitiate("Fairmont Pkwy", "P", "Suburban");
            TripleInitiate("Westside Terrace", "P", "Suburban", new List<string> { "E" });
            TripleInitiate("Pasadena", "P", "Suburban");
            TripleInitiate("Oak Park", "P", "Suburban", new List<string> { "H", "S" });
            TripleInitiate("Greens Bayou", "P", "Suburban", new List<string> { "F", "N" });
        }
    }
}
