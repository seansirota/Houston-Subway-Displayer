using NUnit.Framework;
using ImplementationLibrary;

namespace ProjectTester
{
    //This class contains unit tests for the AttachName method for line strings to see if they are valid.
    [TestFixture]
    class LineNamerTest
    {
        [Test]
        public void Null_Passed_To_LineNameChecker()
        {
            string name = null;
            INamer nameChecker = new LineNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Empty_String_Passed_To_LineNameChecker()
        {
            string name = "";
            INamer nameChecker = new LineNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Empty_Space_Passed_To_LineNameChecker()
        {
            string name = " ";
            INamer nameChecker = new LineNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Real_Line_Passed_To_LineNameChecker_1()
        {
            string name = "Spring";
            INamer nameChecker = new LineNamer();

            Assert.IsTrue(nameChecker.AttachName(name));
        }

        [Test]
        public void Real_Line_Passed_To_LineNameChecker_2()
        {
            string name = "North_Fwy";
            INamer nameChecker = new LineNamer();

            Assert.IsTrue(nameChecker.AttachName(name));
        }
    }
}