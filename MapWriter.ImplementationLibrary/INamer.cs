namespace ImplementationLibrary
{
    //An interface containing the definition of the AttachName method used to validate the Name field of a component by
    //referencing the enum's naming convention.
    public interface INamer
    {
        public bool AttachName(string name);
    }
}
