using System.Collections.Generic;

namespace MapWriter
{
    //This is a child of the MapComponent class. It contains the LineLinks field here because no line objects should be able
    //to link to another line since it makes no sense. This is why only Station and Service objects get this capability.
    //Even then, service linking to lines was never used in the program outside of unit testing so it may make more sense to
    //just reserve this ability to the Station object only.
    public abstract class MapMalleable : MapComponent
    {
        public List<int> LineLinks { get; set; } = new List<int>();

        public MapMalleable() { }
        
        public MapMalleable(string name, int id) : base(name, id)
        {

        }

        public virtual void LinkLine(Line line)
        {
            AddLine(line);
        }

    }
}
