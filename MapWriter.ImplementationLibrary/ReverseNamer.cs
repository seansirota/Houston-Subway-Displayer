using System;

//This is the parent class of all Compiler classes. It contains the returnString which is the result of the parsing and is
//passed back up as a return value. It also has an abstract ParseAndTransform and ParseEnum method which the child Compiler
//classes implement for each component-specific enum list.
//The EnumToString method is defined here which does the parsing work, and passes the result on to the ParseAndTransform method.
namespace ImplementationLibrary
{
    public abstract class ReverseNamer : IComponentCompiler
    {
        protected string returnString;

        public abstract void ParseAndTransform();

        protected string EnumToString(object enumVal)
        {
            try
            {
                returnString = ParseEnum(enumVal);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return returnString;
        }

        protected abstract string ParseEnum(object enumVal);
    }
}