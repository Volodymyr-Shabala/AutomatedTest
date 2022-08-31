using System;
using System.Collections.Generic;
using AutomatedTestSystem;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemSimpleTypeData
    {
        public static TestCaseData[] AllTypesData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            FactorySimpleType factory = new FactorySimpleType();
            IEnumerable<TypeClass> allTypes = factory.GetAllImplementedTypes();
            foreach (TypeClass type in allTypes)
            {
                TestCaseData[] value = Generic(type, factory);
                data.AddRange(value);
            }

            TestCaseData[] result = data.ToArray();
            return result;
        }

        private static TestCaseData[] Generic(TypeClass type, FactoryData factory)
        {
            if (factory.IsTypeImplemented(type))
            {
                Type[] values = factory.GetValue<Type>(type);
                return GenericData(values);
            }

            return new[] { new TestCaseData() };
        }
        
        private static TestCaseData[] GenericData<T>(IReadOnlyList<T> testValues)
        {
            IList<T> values = AutomatedTest.Populate<T>();
            int length = values.Count;
            TestCaseData[] testCaseData = new TestCaseData[length];
            for (int i = 0; i < length; i++)
            {
                T valueToTestAgainst = testValues[i];
                testCaseData[i] = new TestCaseData(values[i], new Predicate<T>(
                                    x => EqualityComparer<T>.Default.Equals(x, valueToTestAgainst)));
            }

            return testCaseData;
        }

        public static TestCaseData[] SByteData()
        {
            return GenericData(FactorySimpleType.SByteValues);
        }

        public static TestCaseData[] ByteData()
        {
            return GenericData(FactorySimpleType.ByteValues);
        }

        public static TestCaseData[] ShortData()
        {
            return GenericData(FactorySimpleType.ShortValues);
        }

        public static TestCaseData[] UShortData()
        {
            return GenericData(FactorySimpleType.UShortValues);
        }

        public static TestCaseData[] IntData()
        {
            return GenericData(FactorySimpleType.IntValues);
        }

        public static TestCaseData[] UIntData()
        {
            return GenericData(FactorySimpleType.UIntValues);
        }

        public static TestCaseData[] FloatData()
        {
            return GenericData(FactorySimpleType.FloatValues);
        }

        public static TestCaseData[] LongData()
        {
            return GenericData(FactorySimpleType.LongValues);
        }

        public static TestCaseData[] ULongData()
        {
            return GenericData(FactorySimpleType.ULongValues);
        }

        public static TestCaseData[] DoubleData()
        {
            return GenericData(FactorySimpleType.DoubleValues);
        }

        public static TestCaseData[] DecimalData()
        {
            return GenericData(FactorySimpleType.DecimalValues);
        }

        public static TestCaseData[] StringData()
        {
            return GenericData(FactorySimpleType.StringValues);
        }

        public static TestCaseData[] CharData()
        {
            return GenericData(FactorySimpleType.CharValues);
        }

        public static TestCaseData[] BoolData()
        {
            return GenericData(FactorySimpleType.BoolValues);
        }

        public static TestCaseData[] DateTimeData()
        {
            return GenericData(FactorySimpleType.DateTimeValues);
        }

        public static TestCaseData[] DateTimeOffsetData()
        {
            return GenericData(FactorySimpleType.DateTimeOffsetValues);
        }

        public static TestCaseData[] TimeSpanData()
        {
            return GenericData(FactorySimpleType.TimeSpanValues);
        }
    }
}