using UnityEngine;

namespace AutomatedTestSystem
{
    public class FactoryPrimitiveType
    {
        public static int GetIntValueAt(int index)
        {
            return IntValues[index % IntValues.Length];
        }

        public static string GetStringValueAt(int index)
        {
            return StringValues[index % StringValues.Length];
        }
        
        public static char GetCharValueAt(int index)
        {
            return CharValues[index % CharValues.Length];
        }

        public static long GetLongValueAt(int index)
        {
            return LongValues[index % LongValues.Length];
        }

        public static int GetLengthMax =>
            Mathf.Max(IntValues.Length, StringValues.Length, CharValues.Length, LongValues.Length);

        public static readonly int[] IntValues =
        {
            int.MinValue, -24, -1, 0, 1, 5, int.MaxValue
        };

        public static readonly string[] StringValues =
        {
            "", " ", "0", "a", "A", "!#€%&/()=?``", "test", null
        };
        
        public static readonly char[] CharValues =
        {
            ' ', '0', 'a', 'A', '!', '#', '€', '%', '&', '/', '(', ')', '=', '?', '`', 'Ä'
        };

        public static readonly long[] LongValues =
        {
            long.MinValue, -24, -1, 0, 1, 5, long.MaxValue
        };
    }
}