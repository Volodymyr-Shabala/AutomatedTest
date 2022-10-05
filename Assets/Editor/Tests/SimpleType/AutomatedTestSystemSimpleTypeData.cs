using System;
using System.Collections;
using System.Collections.Generic;
using AutomatedTestSystem;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemSimpleTypeData
    {
        public static IEnumerable<TestCaseData> SimpleClassTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Type type = typeof(TestClass);
            object result = AutomatedTest.Populate(type);
            Predicate<object> validator = x => x != null;
            IEnumerable array = result as IEnumerable;
            foreach (object element in array)
            {
                data.Add(new TestCaseData(element, validator).SetDescription("Checking for not null"));
            }
            
            return data;
        }
        
        public static IEnumerable<TestCaseData> PopulateSimpleTypeTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            FactoryData factoryData = new FactoryData();
            IEnumerable<Type> allTypes = factoryData.GetAllImplementedTypes();
            foreach (Type type in allTypes)
            {
                object result = AutomatedTest.Populate(type);
                Predicate<object> validator = x => x.GetType() == type.MakeArrayType();
                data.Add(new TestCaseData(result, validator).SetDescription("Checking against correct type"));
            }

            return data;
        }

        public static IEnumerable<TestCaseData> CreateObjectTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            FactoryData factoryData = new FactoryData();
            IEnumerable<Type> allTypes = factoryData.GetAllImplementedTypes();
            foreach (Type type in allTypes)
            {
                object result = AutomatedTest.CreateObject(type);
                Predicate<object> validator = x => x.GetType() == result.GetType();
                data.Add(new TestCaseData(result, validator).SetDescription("Checking against correct type"));
            }

            const int firstValue = 0;
            const byte secondValue = 0;
            Predicate<object> reversedValidator = x => x.GetType() != secondValue.GetType();
            data.Add(new TestCaseData(firstValue, reversedValidator).SetDescription("Checking against incorrect type"));

            return data;
        }
    }
}