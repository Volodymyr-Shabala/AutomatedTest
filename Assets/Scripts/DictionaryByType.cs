using System;
using System.Collections;
using System.Collections.Generic;

namespace AutomatedTestSystem
{
    // TODO V: Decide if I should throw away a dictionary? It is hard to get it to work with generics
    public class DictionaryByType : IEnumerable<KeyValuePair<Type, object>>
    {
        private readonly Dictionary<Type, object> innerDictionary = new Dictionary<Type, object>();

        public void Add<T>(Type type, T value)
        {
            innerDictionary[type] = value;
        }

        // public bool Remove<T>()
        // {
        //     Type type = typeof(T);
        //     bool result = innerDictionary.Remove(type);
        //     return result;
        // }

        public bool ContainsKey(Type type)
        {
            bool result = innerDictionary.ContainsKey(type);
            return result;
        }

        public object Get(Type type)
        {
            object retrievedValue = innerDictionary[type];
            object result = Convert.ChangeType(retrievedValue, type);
            return result;
        }

        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}