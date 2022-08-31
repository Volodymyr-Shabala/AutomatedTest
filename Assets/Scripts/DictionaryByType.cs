using System;
using System.Collections;
using System.Collections.Generic;

namespace AutomatedTestSystem
{
    // TODO V: Decide if I should throw away a dictionary? It is hard to get it to work with generics
    public class DictionaryByType : IEnumerable<KeyValuePair<TypeClass, object>>
    {
        private readonly Dictionary<TypeClass, object> innerDictionary = new Dictionary<TypeClass, object>();

        public void Add<T>(Type type, T value)
        {
            TypeClass myClass = new TypeClass(type);
            innerDictionary[myClass] = value;
        }

        // public bool Remove<T>()
        // {
        //     Type type = typeof(T);
        //     bool result = innerDictionary.Remove(type);
        //     return result;
        // }

        public bool ContainsKey(TypeClass typeClass)
        {
            bool result = innerDictionary.ContainsKey(typeClass);
            return result;
        }

        public object Get(TypeClass typeClass)
        {
            object retrievedValue = innerDictionary[typeClass];
            object result = Convert.ChangeType(retrievedValue, typeClass.type);
            return result;
        }

        public IEnumerator<KeyValuePair<TypeClass, object>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}