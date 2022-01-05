using NUnit.Framework;
using ImplementationLibrary;

namespace ProjectTester
{
    //This class contains unit tests for the AttachName method for station strings to see if they are valid.
    [TestFixture]
    class StationNamerTest
    {
        [Test]
        public void Null_Passed_To_StationNameChecker()
        {
            string name = null;
            INamer nameChecker = new StationNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Empty_String_Passed_To_StationNameChecker()
        {
            string name = "";
            INamer nameChecker = new StationNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Empty_Space_Passed_To_StationNameChecker()
        {
            string name = " ";
            INamer nameChecker = new StationNamer();

            Assert.IsFalse(nameChecker.AttachName(name));
        }

        [Test]
        public void Real_Station_Passed_To_StationNameChecker_1()
        {
            string name = "Griggs Rd";
            INamer nameChecker = new StationNamer();

            Assert.IsTrue(nameChecker.AttachName(name));
        }

        [Test]
        public void Real_Station_Passed_To_StationNameChecker_2()
        {
            string name = "RU - Texas Medical Ctr";
            INamer nameChecker = new StationNamer();

            Assert.IsTrue(nameChecker.AttachName(name));
        }

        [Test]
        public void Real_Station_Passed_To_StationNameChecker_3()
        {
            string name = "Eastex/Jenson";
            INamer nameChecker = new StationNamer();

            Assert.IsTrue(nameChecker.AttachName(name));
        }

        [Test]
        public void Real_Station_Passed_To_StationNameChecker_4()
        {
            string name = "GBI Airport A & B";
            INamer nameChecker = new StationNamer();

            Assert.IsTrue(nameChecker.AttachName(name));
        }
    }
}
