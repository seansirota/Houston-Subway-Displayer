using System;
using System.Collections.Generic;
using HoustonSubway;

namespace ImplementationLibrary
{
    //This class contains methods for creating valid Station strings from all Station enums.
    public class StationCompiler : ReverseNamer
    {
        public readonly List<string> StationList = new List<string>();

        //This is the main parsing method. It loops through an array of Station enums and converts them into valid Name strings
        //beforing adding them to string list.
        public override void ParseAndTransform()
        {
            StationEnums.StationName[] stationArray = (StationEnums.StationName[]) Enum.GetValues(typeof(StationEnums.StationName));
            foreach (StationEnums.StationName stationEnum in stationArray)
            {
                StationList.Add(EnumToString(stationEnum));
            }
        }

        //This is an overload of the ParseAndTransform method used during unit testing. It has similar functionality, but it returns
        //a count of all empty strings that didn't parse correctly due to an invalid name.
        public int ParseAndTransform(bool testFlag)
        {
            int emptyCount = 0;
            StationEnums.StationName[] stationArray = (StationEnums.StationName[])Enum.GetValues(typeof(StationEnums.StationName));
            foreach (StationEnums.StationName stationEnum in stationArray)
            {
                string stationName = EnumToString(stationEnum);
                StationList.Add(stationName);
                Console.WriteLine(stationName);
                if (stationName == string.Empty)
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
                case StationEnums.StationName.RU_Texas_Medical_Ctr:
                    return "RU - Texas Medical Ctr";
                case StationEnums.StationName.Mid_West:
                    return "Mid-West";
                case StationEnums.StationName.Hardy_Union:
                    return "Hardy/Union";
                case StationEnums.StationName.GBI_Airport_A_B:
                    return "GBI Airport A & B";
                case StationEnums.StationName.GBI_Airport_D_E:
                    return "GBI Airport D & E";
                case StationEnums.StationName.Eastex_Lyons:
                    return "Eastex/Lyons";
                case StationEnums.StationName.Eastex_Union:
                    return "Eastex/Union";
                case StationEnums.StationName.Eastex_Jenson:
                    return "Eastex/Jenson";
                case StationEnums.StationName.Bender_Greens:
                    return "Bender/Greens";
                case StationEnums.StationName.Long_Point_Silber:
                    return "Long Point/Silber";
                case StationEnums.StationName._11_St:
                    return "11 St";
                case StationEnums.StationName._12_St:
                    return "12 St";
                case StationEnums.StationName._78_St:
                    return "78 St";
                case StationEnums.StationName.Homestead_Wayside:
                    return "Homestead/Wayside";
                case StationEnums.StationName.Morgan_s_Point:
                    return "Morgan's Point";
                case StationEnums.StationName._:
                    return string.Empty;
                default:
                    return enumVal.ToString().Replace('_', ' ');
            }
        }
    }
}
