using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemComplexTypeTest : AutomatedTestSystemComplexTypeData
    {
        [TestCaseSource(nameof(Testing))]
        public void Get()
        {
            Assert.IsTrue(false);
        }
    }
}