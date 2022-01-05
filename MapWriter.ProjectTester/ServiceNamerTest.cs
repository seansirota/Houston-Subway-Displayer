using NUnit.Framework;
using ImplementationLibrary;

namespace ProjectTester
{
    //This class contains unit tests for the AttachName method for service strings to see if they are valid.
    [TestFixture]
    class ServiceNamerTest
    {
        [Test]
        public void Null_Passed_To_LineNameChecker()
        {
            string name = null;
            INamer nameChecker = new ServiceNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Empty_String_Passed_To_LineNameChecker()
        {
            string name = "";
            INamer nameChecker = new ServiceNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Empty_Space_Passed_To_LineNameChecker()
        {
            string name = " ";
            INamer nameChecker = new ServiceNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Real_Service_Passed_To_LineNameChecker_1()
        {
            string name = "D";
            INamer nameChecker = new ServiceNamer();

            Assert.IsTrue(nameChecker.AttachName(name));
        }
    }
}
