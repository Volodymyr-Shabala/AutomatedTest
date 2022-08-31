using System;
using NUnit.Framework;

namespace AutomatedTestSystemTests
{
    public class AutomatedTestSystemSimpleTypeTest : AutomatedTestSystemSimpleTypeData
    {
        [TestCaseSource(nameof(AllTypesData))]
        public void AllTypesTest(sbyte value, Predicate<sbyte> validator)
        {
            Assert.IsTrue(validator(value));
        }
        
        [TestCaseSource(nameof(SByteData))]
        public void SByteTest(sbyte value, Predicate<sbyte> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(ByteData))]
        public void ByteTest(byte value, Predicate<byte> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(ShortData))]
        public void ShortTest(short value, Predicate<short> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(UShortData))]
        public void UShortTest(ushort value, Predicate<ushort> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(IntData))]
        public void IntTest(int value, Predicate<int> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(UIntData))]
        public void UIntTest(uint value, Predicate<uint> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(FloatData))]
        public void FloatTest(float value, Predicate<float> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(LongData))]
        public void LongTest(long value, Predicate<long> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(ULongData))]
        public void ULongTest(ulong value, Predicate<ulong> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(DoubleData))]
        public void DoubleTest(double value, Predicate<double> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(DecimalData))]
        public void DecimalTest(decimal value, Predicate<decimal> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(StringData))]
        public void StringTest(string value, Predicate<string> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(CharData))]
        public void CharTest(char value, Predicate<char> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(BoolData))]
        public void BoolTest(bool value, Predicate<bool> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(DateTimeData))]
        public void DateTimeTest(DateTime value, Predicate<DateTime> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(DateTimeOffsetData))]
        public void DateTimeOffsetTest(DateTimeOffset value, Predicate<DateTimeOffset> validator)
        {
            Assert.IsTrue(validator(value));
        }

        [TestCaseSource(nameof(TimeSpanData))]
        public void TimeSpanTest(TimeSpan value, Predicate<TimeSpan> validator)
        {
            Assert.IsTrue(validator(value));
        }
    }
}