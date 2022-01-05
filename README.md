# Houston-Subway-Displayer
MapWriter is a program that takes data about a subway map, parses and transforms into station, service, and line components that the program can read, and then uses these components to display information about the map to the user of this program.

This project is split into four layers. There is the main layer, "MapWriter", which has all executive tasks and interacts with the user. Then there's the intermediary layer, "Implementation Libraries", which interacts with MapWriter to receieve queries and then completes them by reaching into the enum lists of the last layer, and performs parsing and transformation of this data. There's the data layer, "Houston Subway", which contains enums of all stations, services, and lines which are used to validate the names of objects of those types and as a repository of all stations, services, and lines in the system. There is also the fourth layer, "Project Tester", which is used for unit testing certain methods and functionalities. The first three layers work together to work with the data and complete tasks by separating the most interfacing part from the data storage part. This allows for new maps to be implemented fairly easily since you would mainly have to add a new data storage layer containing all station, service, and line enums and the rest of the project would be able to work with the new data.

The program gives the player 3 choices. The first choice displays all stations within a service in order and displays in the color of the service. Services that connect to each station are also displayed in their respective colors. The second choice simulates the inner display inside a train rolling stock that gives information on things like: the current station, the next station, the last station, and the current line. It does all this with a 4 second delay to make it realistic. It also displays transfer connections to other services at each station as well, if applicable. The third choice exits the program.

For this project, I used my fantasy Houston Subway map which I designed myself and thought it was a good example for this project as an exercise. If you are interested to see my work, follow the links below:

PNG: https://drive.google.com/file/d/1xAmlYb9nDbLvds9pLWzttIWpBLTFYx9s/view?usp=sharing

PDF: https://drive.google.com/file/d/1yWJqSygGTUmTiGJUQzZU_-lV-QzoQYK5/view?usp=sharing
