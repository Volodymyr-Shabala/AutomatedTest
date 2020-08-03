using AutomatedTestSystem;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemTest
    {
        [Test]
        public void StringArrayTest()
        {
            string stringValue = AutomatedTest.Populate<string>();
            Assert.IsTrue(stringValue.Length > 0);
        }
    }
}