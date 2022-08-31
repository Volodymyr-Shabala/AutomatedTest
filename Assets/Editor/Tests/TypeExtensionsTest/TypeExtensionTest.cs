using System;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class TypeExtensionTest : TypeExtensionData
    {
        [TestCaseSource(nameof(IsSimpleTypeTestData))]
        public void IsSimpleTypeTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }

        [TestCaseSource(nameof(IsNullableTestData))]
        public void IsNullableTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }

        [TestCaseSource(nameof(GetNullableTypeData))]
        public void GetNullableTypeTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }
        
        [TestCaseSource(nameof(IsCollectionData))]
        public void IsCollectionTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }

        [TestCaseSource(nameof(GetSimpleTypeFromCollectionData))]
        public void GetSimpleTypeFromCollectionTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }
    }
}