using System.Collections.Generic;

namespace AutomatedTestSystem
{
    public static class FactoryBadData
    {
        public static void AddBadData<T>(ref IList<T> list, bool allowBadData) where T : new()
        {
            if (allowBadData)
            {
                T[] badData = GenerateBadData<T>();
                int length = badData.Length;
                for (int i = 0; i < length; i++)
                {
                    list.Add(badData[i]);
                }
            }
        }

        private static T[] GenerateBadData<T>() where T : new()
        {
            return new[]
            {
                new T(), default
            };
        }
    }
}