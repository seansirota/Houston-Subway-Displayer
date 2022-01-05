using System;
using HoustonSubway;

namespace ImplementationLibrary
{
    //This class contains an AttachName method which takes a name string parameter, transforms and parses the string so that it
    //can be formatted to match one of the enums of the component type, and finally return true if a match exists and false if not.
    public class LineNamer : INamer
    {
        public bool AttachName(string name)
        {
            LineEnums.LineName enumVal;

            if (String.IsNullOrWhiteSpace(name))
                return false;

            name = name.Replace(' ', '_');

            try
            {
                enumVal = (LineEnums.LineName)Enum.Parse(typeof(LineEnums.LineName), name);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
