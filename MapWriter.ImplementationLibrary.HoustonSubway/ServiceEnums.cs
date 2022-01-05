using System;
using System.Collections.Generic;

namespace HoustonSubway
{
    //This class contains the ServiceName enum which contains the enums for all valid Houston Subway services.
    //It also contains the ServiceColor method definition, which assigns a ConsoleColor to each service.
    public class ServiceEnums
    {
        public enum ServiceName
        {
            _,
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            J,
            K,
            L,
            M,
            N,
            P,
            Q,
            R,
            S,
            T
        }

        public static ConsoleColor ServiceColor(ServiceName service)
        {
            List<ServiceName> greenList = new List<ServiceName> { ServiceName.A, ServiceName.B, ServiceName.K };
            List<ServiceName> blueList = new List<ServiceName> { ServiceName.D, ServiceName.H, ServiceName.S };
            List<ServiceName> yellowList = new List<ServiceName> { ServiceName.E, ServiceName.Q, ServiceName.T };
            List<ServiceName> orangeList = new List<ServiceName> { ServiceName.C, ServiceName.F, ServiceName.N, ServiceName.R };
            List<ServiceName> purpleList = new List<ServiceName> { ServiceName.G, ServiceName.J, ServiceName.M };
            List<ServiceName> cyanList = new List<ServiceName> { ServiceName.L };
            List<ServiceName> brownList = new List<ServiceName> { ServiceName.P };

            if (greenList.Contains(service))
                return ConsoleColor.Green;
            else if (blueList.Contains(service))
                return ConsoleColor.Blue;
            else if (yellowList.Contains(service))
                return ConsoleColor.Yellow;
            else if (orangeList.Contains(service))
                return ConsoleColor.DarkYellow;
            else if (purpleList.Contains(service))
                return ConsoleColor.DarkMagenta;
            else if (cyanList.Contains(service))
                return ConsoleColor.Cyan;
            else if (brownList.Contains(service))
                return ConsoleColor.DarkRed;
            else
                return ConsoleColor.White;
        }
    }
}
