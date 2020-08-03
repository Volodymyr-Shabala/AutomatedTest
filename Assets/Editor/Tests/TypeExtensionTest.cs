using System;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class TypeExtensionTest
    {
        [TestCaseSource(nameof(TypeExtensionsData))]
        public void TypeExtensionsTest(Type type, Predicate<Type> validator)
        {
            Assert.IsTrue(validator(type));
        }

        public static TestCaseData[] TypeExtensionsData()
        {
            Predicate<Type> validator = x => x.IsSimpleType();
            return new[]
            {
                new TestCaseData(typeof(string), validator).SetDescription("String is a simple type"),
                new TestCaseData(typeof(char), validator).SetDescription("Char is a simple type"),
                new TestCaseData(typeof(bool), validator).SetDescription("Bool is a simple type"),
                new TestCaseData(typeof(byte), validator).SetDescription("Byte is a simple type"),
                new TestCaseData(typeof(short), validator).SetDescription("Short is a simple type"),
                new TestCaseData(typeof(int), validator).SetDescription("Int is a simple type"),
                new TestCaseData(typeof(long), validator).SetDescription("Long is a simple type"),
                new TestCaseData(typeof(float), validator).SetDescription("Float is a simple type"),
                new TestCaseData(typeof(double), validator).SetDescription("Double is a simple type"),
                new TestCaseData(typeof(Guid), validator).SetDescription("Guid is a simple type"),
                new TestCaseData(typeof(decimal), validator).SetDescription("Decimal is a simple type"),
                new TestCaseData(typeof(sbyte), validator).SetDescription("SByte is a simple type"),
                new TestCaseData(typeof(ushort), validator).SetDescription("UShort is a simple type"),
                new TestCaseData(typeof(uint), validator).SetDescription("UInt is a simple type"),
                new TestCaseData(typeof(ulong), validator).SetDescription("ULong is a simple type"),
                new TestCaseData(typeof(DateTime), validator).SetDescription("DateTime is a simple type"),
                new TestCaseData(typeof(DateTimeOffset), validator).
                    SetDescription("DateTimeOffset is a simple type"),
                new TestCaseData(typeof(TimeSpan), validator).SetDescription("TimeSpan is a simple type"),
                new TestCaseData(typeof(char?), validator).SetDescription("Nullable char is a simple type"),
                new TestCaseData(typeof(Guid?), validator).SetDescription("Nullable Guid is a simple type"),
                new TestCaseData(typeof(bool?), validator).SetDescription("Nullable bool is a simple type"),
                new TestCaseData(typeof(byte?), validator).SetDescription("Nullable byte is a simple type"),
                new TestCaseData(typeof(short?), validator).SetDescription("Nullable short is a simple type"),
                new TestCaseData(typeof(int?), validator).SetDescription("Nullable int is a simple type"),
                new TestCaseData(typeof(long?), validator).SetDescription("Nullable long is a simple type"),
                new TestCaseData(typeof(float?), validator).SetDescription("Nullable float is a simple type"),
                new TestCaseData(typeof(double?), validator).
                    SetDescription("Nullable double is a simple type"),
                new TestCaseData(typeof(decimal?), validator).
                    SetDescription("Nullable decimal is a simple type"),
                new TestCaseData(typeof(sbyte?), validator).SetDescription("Nullable sbyte is a simple type"),
                new TestCaseData(typeof(ushort?), validator).
                    SetDescription("Nullable ushort is a simple type"),
                new TestCaseData(typeof(uint?), validator).SetDescription("Nullable uint is a simple type"),
                new TestCaseData(typeof(ulong?), validator).SetDescription("Nullable ulong is a simple type"),
                new TestCaseData(typeof(DateTime?), validator).
                    SetDescription("Nullable DateTime is a simple type"),
                new TestCaseData(typeof(DateTimeOffset?), validator).
                    SetDescription("Nullable DateTimeOffset is a simple type"),
                new TestCaseData(typeof(TimeSpan?), validator).
                    SetDescription("Nullable TimeSpan is a simple type"),
                new TestCaseData(typeof(TestEnum), new Predicate<Type>(x => !validator(x))).
                    SetDescription("Enum is not a simple type"),
                new TestCaseData(typeof(TestStruct), new Predicate<Type>(x => !validator(x))).
                    SetDescription("Struct is not a simple type"),
                new TestCaseData(typeof(TestClass), new Predicate<Type>(x => !validator(x))).
                    SetDescription("Class is not a simple type"),
                new TestCaseData(typeof(TestEnum?), new Predicate<Type>(x => !validator(x))).
                    SetDescription("Nullable Enum is not a simple type"),
                new TestCaseData(typeof(TestStruct?), new Predicate<Type>(x => !validator(x))).
                    SetDescription("Nullable Struct is not a simple type")
            };
        }

        struct TestStruct
        {
        }

        class TestClass
        {
            public string Prop1;
            public int Prop2;
        }

        enum TestEnum { TheValue }
    }
}