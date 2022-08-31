using System;
using System.Collections.Generic;
using System.Reflection;
using AutomatedTestSystem;
using NUnit.Framework;
using Type = System.Type;

namespace AutomatedTestSystemTests
{
    public class TypeExtensionData
    {
        public static TestCaseData[] IsSimpleTypeTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => x.IsSimpleType();
            FieldInfo[] fieldInfos = typeof(FactorySimpleType).GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Type type = fieldInfo.FieldType;
                Type nullableType;
                Type simpleType = type;
                if (type.IsCollection())
                {
                    Type elementType = type.GetElementType();
                    if (elementType == typeof(string))
                    {
                        continue;
                    }

                    nullableType = elementType.GetNullableType();
                    if (elementType.IsSimpleType())
                    {
                        simpleType = elementType;
                    }
                }
                else
                {
                    if (type == typeof(string))
                    {
                        continue;
                    }

                    nullableType = type.GetNullableType();
                    if (type.IsSimpleType())
                    {
                        simpleType = type;
                    }
                }

                data.Add(new TestCaseData(nullableType, validator));
                data.Add(new TestCaseData(simpleType, validator));
            }
            
            Predicate<Type> reverseValidator = x => validator(x) == false;
            data.Add(new TestCaseData(typeof(TestEnum), reverseValidator));
            data.Add(new TestCaseData(typeof(TestStruct), reverseValidator));
            data.Add(new TestCaseData(typeof(TestClass), reverseValidator));
            data.Add(new TestCaseData(typeof(TestEnum?), reverseValidator));
            data.Add(new TestCaseData(typeof(TestStruct?), reverseValidator));

            TestCaseData[] result = data.ToArray();
            return result;
        }

        public static TestCaseData[] IsNullableTestData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => x.IsNullable();
            FieldInfo[] fieldInfos = typeof(FactorySimpleType).GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Type type = fieldInfo.FieldType;
                Type nullableType;
                if (type.IsCollection())
                {
                    Type elementType = type.GetElementType();
                    if (elementType == typeof(string))
                    {
                        continue;
                    }

                    nullableType = elementType.GetNullableType();
                }
                else
                {
                    if (type == typeof(string))
                    {
                        continue;
                    }

                    nullableType = type.GetNullableType();
                }

                data.Add(new TestCaseData(nullableType, validator));
            }

            TestCaseData[] result = data.ToArray();
            return result;
        }

        public static TestCaseData[] GetNullableTypeData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => Nullable.GetUnderlyingType(x) != null;
            FieldInfo[] fieldInfos = typeof(FactorySimpleType).GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Type type = fieldInfo.FieldType;
                Type nullableType;
                if (type.IsCollection())
                {
                    Type elementType = type.GetElementType();
                    if (elementType == typeof(string))
                    {
                        continue;
                    }

                    nullableType = elementType.GetNullableType();
                }
                else
                {
                    if (type == typeof(string))
                    {
                        continue;
                    }

                    nullableType = type.GetNullableType();
                }

                data.Add(new TestCaseData(nullableType, validator));
            }

            TestCaseData[] result = data.ToArray();
            return result;
        }
        
        public static TestCaseData[] IsCollectionData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => x.IsCollection();
            FieldInfo[] fieldInfos = typeof(FactorySimpleType).GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Type type = fieldInfo.FieldType;
                data.Add(new TestCaseData(type, validator));
            }

            Predicate<Type> reverseValidator = x => validator(x) == false;
            data.Add(new TestCaseData(typeof(int), reverseValidator));
            data.Add(new TestCaseData(typeof(string), reverseValidator));

            TestCaseData[] result = data.ToArray();
            return result;
        }

        public static TestCaseData[] GetSimpleTypeFromCollectionData()
        {
            List<TestCaseData> data = new List<TestCaseData>();
            Predicate<Type> validator = x => x.IsSimpleType();
            FieldInfo[] fieldInfos = typeof(FactorySimpleType).GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Type type = fieldInfo.FieldType;
                Type simpleType = type.GetSimpleTypeFromCollection();
                data.Add(new TestCaseData(simpleType, validator));
            }

            Predicate<Type> reverseValidator = x => validator(x) == false;
            data.Add(new TestCaseData(typeof(int[]), reverseValidator));
            data.Add(new TestCaseData(typeof(string[]), reverseValidator));

            TestCaseData[] result = data.ToArray();
            return result;
        }
    }

    struct TestStruct
    {
        public int testValue;
    }

    class TestClass
    {
        public string Prop1;
        public int Prop2;
    }

    enum TestEnum { TheValue }
}