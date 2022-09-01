using System;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemSimpleTypeTest : AutomatedTestSystemSimpleTypeData
    {
        [TestCaseSource(nameof(SimpleClassTestData))]
        public void SimpleClassTest(object value, Predicate<object> validator)
        {
            Assert.IsTrue(validator(value));
        }
        
        [TestCaseSource(nameof(PopulateSimpleTypeTestData))]
        public void PopulateSimpleTypeTest(object value, Predicate<object> validator)
        {
            Assert.IsTrue(validator(value));
        }
        
        [TestCaseSource(nameof(CreateObjectTestData))]
        public void CreateObjectTest(object value, Predicate<object> validator)
        {
            Assert.IsTrue(validator(value));
        }
    }
}