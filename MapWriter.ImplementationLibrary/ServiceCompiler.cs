using System;
using HoustonSubway;
using System.Collections.Generic;

namespace ImplementationLibrary
{
    //This class contains methods for creating valid Service strings from all Service enums.
    public class ServiceCompiler : ReverseNamer
    {
        public readonly List<string> ServiceList = new List<string>();

        //This is the main parsing method. It loops through an array of Service enums and converts them into valid Name strings
        //beforing adding them to string list.
        public override void ParseAndTransform()
        {
            ServiceEnums.ServiceName[] serviceArray = (ServiceEnums.ServiceName[]) Enum.GetValues(typeof(ServiceEnums.ServiceName));
            foreach (ServiceEnums.ServiceName serviceEnum in serviceArray)
            {
                ServiceList.Add(EnumToString(serviceEnum));
            }
        }

        //This is an overload of the ParseAndTransform method used during unit testing. It has similar functionality, but it returns
        //a count of all empty strings that didn't parse correctly due to an invalid name.
        public int ParseAndTransform(bool testFlag)
        {
            int emptyCount = 0;
            ServiceEnums.ServiceName[] serviceArray = (ServiceEnums.ServiceName[])Enum.GetValues(typeof(ServiceEnums.ServiceName));
            foreach (ServiceEnums.ServiceName serviceEnum in serviceArray)
            {
                string serviceName = EnumToString(serviceEnum);
                ServiceList.Add(serviceName);
                Console.WriteLine(serviceName);
                if (serviceName == string.Empty)
                    emptyCount++;
            }

            return emptyCount;
        }

        //This method looks through all exceptions when converting an enum to a string by just converted all underscores to
        //blank spaces. It returns the string value of a correctly parsed enum.
        protected override string ParseEnum(object enumVal)
        {
            switch (enumVal)
            {
                case ServiceEnums.ServiceName._:
                    return string.Empty;
                default:
                    return enumVal.ToString();
            }
        }
    }
}
