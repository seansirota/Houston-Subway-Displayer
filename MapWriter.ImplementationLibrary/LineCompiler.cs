using System;
using System.Collections.Generic;
using HoustonSubway;

namespace ImplementationLibrary
{
    //This class contains methods for creating valid Line strings from all Line enums.
    public class LineCompiler : ReverseNamer
    {
        public readonly List<string> LineList = new List<string>();

        //This is the main parsing method. It loops through an array of Line enums and converts them into valid Name strings
        //beforing adding them to string list.
        public override void ParseAndTransform()
        {
            LineEnums.LineName[] lineArray = (LineEnums.LineName[]) Enum.GetValues(typeof(LineEnums.LineName));
            foreach (LineEnums.LineName lineEnum in lineArray)
            {
                LineList.Add(EnumToString(lineEnum));
            }
        }

        //This is an overload of the ParseAndTransform method used during unit testing. It has similar functionality, but it returns
        //a count of all empty strings that didn't parse correctly due to an invalid name.
        public int ParseAndTransform(bool testFlag)
        {
            int emptyCount = 0;
            LineEnums.LineName[] lineArray = (LineEnums.LineName[])Enum.GetValues(typeof(LineEnums.LineName));
            foreach (LineEnums.LineName lineEnum in lineArray)
            {
                string lineName = EnumToString(lineEnum);
                LineList.Add(lineName);
                Console.WriteLine(lineName);
                if (lineName == string.Empty)
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
                case LineEnums.LineName._:
                    return string.Empty;
                default:
                    return enumVal.ToString().Replace('_', ' ');
            }
        }
    }
}
