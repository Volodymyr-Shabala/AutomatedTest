using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemComplexTypeTest : AutomatedTestSystemComplexTypeData
    {
        [TestCaseSource(nameof(Testing))]
        public void PopulateArray()
        {
            Assert.IsTrue(false);
        }
        
        [TestCaseSource(nameof(Testing))]
        public void PopulateList()
        {
            Assert.IsTrue(false);
        }
        
        [TestCaseSource(nameof(Testing))]
        public void PopulateDictionary()
        {
            Assert.IsTrue(false);
        }
        
        [TestCaseSource(nameof(Testing))]
        public void PopulateICollection()
        {
            Assert.IsTrue(false);
        }
    }
}