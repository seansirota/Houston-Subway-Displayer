using System;
using NUnit.Framework;
using MapWriter;

namespace ProjectTester
{
    //This class contains unit tests for checking if the service properly assigns itself the correct color based on its name.
    [TestFixture]
    public class ColorTest
    {
        [Test]
        public void Pass_Invalid_Name_Expect_White_Color()
        {
            Service service = new Service("Fake Service", 67);

            Assert.AreEqual(ConsoleColor.White, service.Color);
        }

        [Test]
        public void Pass_Valid_Name_Expect_Dark_Yellow_Color()
        {
            Service service = new Service("F", 53);

            Assert.AreEqual(ConsoleColor.DarkYellow, service.Color);
        }
    }
}
