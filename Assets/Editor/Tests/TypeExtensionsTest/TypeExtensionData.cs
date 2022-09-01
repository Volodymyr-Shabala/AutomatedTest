using System;
using System.Collections.Generic;
using AutomatedTestSystem;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class TypeExtensionData
    {
        public static IEnumerable<TestCaseData> IsNullableTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => x.IsNullable();
            FactoryData factoryData = new FactoryData();
            IEnumerable<Type> allTypes = factoryData.GetAllImplementedTypes();
            foreach (Type type in allTypes)
            {
                if (type == typeof(string))
                {
                    continue;
                }

                Type nullableType = type.GetNullableType();
                data.Add(new TestCaseData(nullableType, validator).SetDescription("Checking against nullable type"));
            }
            
            Predicate<Type> reverseValidator = x => x.IsNullable() == false;
            data.Add(new TestCaseData(typeof(int), reverseValidator).SetDescription("Checking against incorrect type"));
            return data;
        }

        public static IEnumerable<TestCaseData> IsCollectionTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => x.IsCollection() == false;
            FactoryData factoryData = new FactoryData();
            IEnumerable<Type> allTypes = factoryData.GetAllImplementedTypes();
            foreach (Type type in allTypes)
            {
                data.Add(new TestCaseData(type, validator).SetDescription("Checking against non collection data"));
            }

            Predicate<Type> reverseValidator = x => x.IsCollection();
            data.Add(new TestCaseData(typeof(int[]), reverseValidator).SetDescription("Checking against collection data"));
            data.Add(new TestCaseData(typeof(string[]), reverseValidator).SetDescription("Checking against collection data"));

            return data;
        }

        public static IEnumerable<TestCaseData> IsSimpleTypeTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => x.IsSimpleType();
            FactoryData factoryData = new FactoryData();
            IEnumerable<Type> allTypes = factoryData.GetAllImplementedTypes();
            foreach (Type type in allTypes)
            {
                data.Add(new TestCaseData(type, validator).SetDescription("Checking against simple type"));
            }

            Predicate<Type> reverseValidator = x => validator(x) == false;
            Type[] incorrectTypes = {
                typeof(int[]), typeof(string[]), typeof(TestEnum), typeof(TestStruct), typeof(TestClass),
                typeof(TestEnum?), typeof(TestStruct?)
            };

            foreach (Type incorrectType in incorrectTypes)
            {
                data.Add(new TestCaseData(incorrectType, reverseValidator).SetDescription("Checking against collection type"));
            }

            return data;
        }
    }
}