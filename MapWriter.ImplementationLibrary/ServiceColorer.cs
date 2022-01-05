using System;
using HoustonSubway;

namespace ImplementationLibrary
{
    //This class has the GetColor method which matches a service name to its correct ConsoleColor.
    public class ServiceColorer
    {
        public static ConsoleColor GetColor(string name)
        {
            ServiceEnums.ServiceName enumVal;
            try
            {
                enumVal = (ServiceEnums.ServiceName) Enum.Parse(typeof(ServiceEnums.ServiceName), name);
            }
            catch (Exception)
            {
                enumVal = ServiceEnums.ServiceName._;
            }

            return ServiceEnums.ServiceColor(enumVal);
        }
    }
}
