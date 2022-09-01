using System;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class TypeExtensionTest : TypeExtensionData
    {
        [TestCaseSource(nameof(IsNullableTestData))]
        public void IsNullableTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }

        [TestCaseSource(nameof(IsCollectionTestData))]
        public void IsCollectionTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }

        [TestCaseSource(nameof(IsSimpleTypeTestData))]
        public void IsSimpleTypesTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }
    }
}