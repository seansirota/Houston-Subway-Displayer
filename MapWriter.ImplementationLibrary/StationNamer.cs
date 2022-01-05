using System;
using HoustonSubway;

namespace ImplementationLibrary
{
    //This class contains an AttachName method which takes a name string parameter, transforms and parses the string so that it
    //can be formatted to match one of the enums of the component type, and finally return true if a match exists and false if not.
    public class StationNamer : INamer
    {
        public bool AttachName(string name)
        {
            StationEnums.StationName enumVal;

            if (String.IsNullOrWhiteSpace(name))
                return false;
            
            try
            {
                switch (name)
                {
                    case "11 St":
                        enumVal = StationEnums.StationName._11_St;
                        break;
                    case "12 St":
                        enumVal = StationEnums.StationName._12_St;
                        break;
                    case "78 St":
                        enumVal = StationEnums.StationName._78_St;
                        break;
                    case "":
                        enumVal = StationEnums.StationName._;
                        break;
                    default:
                        name = name.Replace(' ', '_');
                        name = name.Replace('/', '_');
                        name = name.Replace('&', '_');
                        name = name.Replace('\'', '_');
                        name = name.Replace('-', '_');
                        name = name.Replace("___", "_");
                        name = name.Trim('_');
                        enumVal = (StationEnums.StationName)Enum.Parse(typeof(StationEnums.StationName), name);
                        break;
                }                
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
