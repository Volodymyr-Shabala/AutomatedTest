using System;

namespace AutomatedTestSystem
{
    /*Skipped types:
     * Guid
     */
    // V: Not used anymore
    public class FactorySimpleType
    {
        public static readonly sbyte[] SByteValues =
        {
            sbyte.MinValue, -24, -1, 0, 1, 5, sbyte.MaxValue
        };

        public static readonly byte[] ByteValues =
        {
            byte.MinValue, 1, 3, 25, byte.MaxValue
        };

        public static readonly short[] ShortValues =
        {
            short.MinValue, -24, -1, -0, 1, 5, short.MaxValue
        };

        public static readonly ushort[] UShortValues =
        {
            ushort.MinValue, 1, 3, 25, ushort.MaxValue
        };

        public static readonly int[] IntValues =
        {
            int.MinValue, -24, -1, 0, 1, 5, int.MaxValue
        };

        public static readonly uint[] UIntValues =
        {
            uint.MinValue, 1, 3, 25, uint.MaxValue
        };

        public static readonly float[] FloatValues =
        {
            float.MaxValue, -24, -24.0994f, -1, -1.9847362f, 0, 0.0000f, 1, 1.45678f, 5.11111f, float.MaxValue
        };

        public static readonly long[] LongValues =
        {
            long.MinValue, -24, -1, 0, 1, 5, long.MaxValue
        };

        public static readonly ulong[] ULongValues =
        {
            ulong.MinValue, 1, 3, 25, ulong.MaxValue
        };

        public static readonly double[] DoubleValues =
        {
            double.MaxValue, -24, -24.0994f, -1, -1.9847362f, 0, 0.000000000f, 1, 1.45678f, 5.11111111111111f, double.MaxValue
        };

        public static readonly decimal[] DecimalValues =
        {
            decimal.MaxValue, -24.02994m, -1.98343447362m, 0.00000000000000m, 1.43535678m, 5.111111111111111m, decimal.MaxValue
        };

        public static readonly string[] StringValues =
        {
            string.Empty, " ", "0", "a", "A", "!#€%&/()=?``", "test", null
        };

        public static readonly char[] CharValues =
        {
            char.MinValue, '0', 'a', 'A', '!', '#', '€', '%', '&', '/', '(', ')', '=', '?', '`', 'Ä', char.MaxValue
        };

        public static readonly bool[] BoolValues =
        {
            true, false
        };

        public static readonly DateTime[] DateTimeValues =
        {
            DateTime.MinValue, DateTime.Now, DateTime.Today, new DateTime(), DateTime.MaxValue
        };

        public static readonly DateTimeOffset[] DateTimeOffsetValues =
        {
            DateTimeOffset.MinValue, DateTimeOffset.Now, DateTimeOffset.UtcNow, new DateTimeOffset(), DateTimeOffset.MaxValue
        };

        public static readonly TimeSpan[] TimeSpanValues =
        {
            TimeSpan.MinValue, TimeSpan.Zero, new TimeSpan(), TimeSpan.MaxValue
        };
    }
}