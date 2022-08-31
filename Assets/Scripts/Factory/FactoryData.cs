using System;
using System.Collections.Generic;

namespace AutomatedTestSystem
{
    public class FactoryData
    {
        private readonly DictionaryByType implementedTypes = new DictionaryByType();

        protected FactoryData()
        {
            implementedTypes.Add(typeof(sbyte[]), new sbyte[] { sbyte.MinValue, -24, -1, 0, 1, 5, sbyte.MaxValue });
            implementedTypes.Add(typeof(byte[]), new byte[] { byte.MinValue, 1, 3, 25, byte.MaxValue });
            implementedTypes.Add(typeof(short[]), new short[] { short.MinValue, -24, -1, -0, 1, 5, short.MaxValue });
            implementedTypes.Add(typeof(ushort[]), new ushort[] { ushort.MinValue, 1, 3, 25, ushort.MaxValue });
            implementedTypes.Add(typeof(int[]), new int[] { int.MinValue, -24, -1, 0, 1, 5, int.MaxValue });
            implementedTypes.Add(typeof(uint[]), new uint[] { uint.MinValue, 1, 3, 25, uint.MaxValue });
            implementedTypes.Add(typeof(float[]), new float[] { float.MaxValue, -24, -24.0994f, -1, -1.9847362f, 0, 0.0000f, 1, 1.45678f, 5.11111f, float.MaxValue });
            implementedTypes.Add(typeof(long[]), new long[] { long.MinValue, -24, -1, 0, 1, 5, long.MaxValue });
            implementedTypes.Add(typeof(ulong[]), new ulong[] { ulong.MinValue, 1, 3, 25, ulong.MaxValue });
            implementedTypes.Add(typeof(double[]), new double[] { double.MaxValue, -24, -24.0994f, -1, -1.9847362f, 0, 0.000000000f, 1, 1.45678f, 5.11111111111111f, double.MaxValue });
            implementedTypes.Add(typeof(decimal[]), new decimal[] { decimal.MaxValue, -24.02994m, -1.98343447362m, 0.00000000000000m, 1.43535678m, 5.111111111111111m, decimal.MaxValue });
            implementedTypes.Add(typeof(string[]), new string[] { string.Empty, " ", "0", "a", "A", "!#€%&/()=?``", "test", null });
            implementedTypes.Add(typeof(char[]), new char[] { char.MinValue, '0', 'a', 'A', '!', '#', '€', '%', '&', '/', '(', ')', '=', '?', '`', 'Ä', char.MaxValue });
            implementedTypes.Add(typeof(bool[]), new bool[] { true, false });
            implementedTypes.Add(typeof(DateTime[]), new DateTime[] { DateTime.MinValue, DateTime.Now, DateTime.Today, new DateTime(), DateTime.MaxValue });
            implementedTypes.Add(typeof(DateTimeOffset[]), new DateTimeOffset[] { DateTimeOffset.MinValue, DateTimeOffset.Now, DateTimeOffset.UtcNow, new DateTimeOffset(), DateTimeOffset.MaxValue });
            implementedTypes.Add(typeof(TimeSpan[]), new TimeSpan[] { TimeSpan.MinValue, TimeSpan.Zero, new TimeSpan(), TimeSpan.MaxValue });
        }

        public T[] GetValue<T>(TypeClass typeClass)
        {
            List<T> sorted = new List<T>();
            object value = implementedTypes.Get(typeClass);
            if (value is IEnumerable<T> enumerable)
            {
                sorted.AddRange(enumerable);
            }

            T[] result = sorted.ToArray();
            return result;
        }

        public bool IsTypeImplemented(TypeClass typeClass)
        {
            bool result = implementedTypes.ContainsKey(typeClass);
            return result;
        }

        public IEnumerable<TypeClass> GetAllImplementedTypes()
        {
            IEnumerator<KeyValuePair<TypeClass, object>> enumerator = implementedTypes.GetEnumerator();
            List<TypeClass> result = new List<TypeClass>();
            while (enumerator.MoveNext())
            {
                TypeClass key = enumerator.Current.Key;
                result.Add(key);
            }
            
            enumerator.Dispose();
            
            return result;
        }
    }
}