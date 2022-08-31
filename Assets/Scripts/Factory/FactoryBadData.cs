using System.Collections.Generic;

namespace AutomatedTestSystem
{
    public static class FactoryBadData
    {
        public static IList<T> AddBadData<T>() where T : new()
        {
            List<T> list = new List<T>();
            T[] badData = GenerateBadData<T>();
            list.AddRange(badData);
            return list;
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