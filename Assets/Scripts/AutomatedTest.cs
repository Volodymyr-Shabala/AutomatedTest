using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutomatedTestSystemTests;
using UnityEngine;

namespace AutomatedTestSystem
{
    public class AutomatedTest
    {
        public static object Populate(Type type)
        {
            if (type.IsSimpleType())
            {
                object simpleTypeResult = GetPopulatedArrayOfSimpleType(type);
                return simpleTypeResult;
            }
            
            if (type.GetInterface("ICollection") != null)
            {
                // var collectionResult = PopulateCollection(type, ref objectToPopulate);
                // return collectionResult;
            }
            
            if (type.IsClass())
            {
                object populatedClass = PopulateClass(type);
                return populatedClass;
            }

            return default;
        }
        
        private static object PopulateCollection(Type type)
        {
            // IList<T> collection = new List<T>();
            //
            // var underLyingType = typeof(T);
            // var baseType = typeof(T).BaseType;
            // if (typeof(T).IsGenericType)
            // {
            //     var generic = typeof(T).GetGenericTypeDefinition();
            // }
            //
            // var declaringType = typeof(T).DeclaringType;
            // var t = typeof(T).GetGenericArguments(); // Works for generic type like List, Dictionary. Can loop them
            // var underLyingSystemType = typeof(T).UnderlyingSystemType;
            // var underLyingSystemTypeUnderlying = typeof(T).UnderlyingSystemType.UnderlyingSystemType;
            //
            // return collection;
            return default;
        }
        
        private static object PopulateClass(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields();
            int length = fieldInfos.Length;
            List<object[]> values = new List<object[]>(length);
            for (int i = 0; i < length; i++)
            {
                object fieldValues = Populate(fieldInfos[i].FieldType);
                object[] fieldValueIEnumerable = (fieldValues as IEnumerable).Cast<object>().ToArray();
                values.Add(fieldValueIEnumerable);
            }

            // TODO V: Put into Utils class/function
            int biggestLength = values[0].Length;
            for (int i = 0; i < length - 1; i++)
            {
                int nextArrayLength = values[i + 1].Length;
                biggestLength = Mathf.Max(biggestLength, nextArrayLength);
            }
            
            object[] classArray = new object[biggestLength];
            for (int i = 0; i < biggestLength; i++)
            {
                object classValue = CreateObject(type);
                for (int j = 0; j < length; j++)
                {
                    object[] array = values[j];
                    object value = array.Length > i ? array[i] : null;
                    fieldInfos[j].SetValue(classValue, value);
                }

                classArray[i] = classValue;
            }

            return classArray;
        }
        
        /// <summary>
        /// Returns an array with elements of provided type
        /// </summary>
        /// <param name="type"></param> Type of the array to be returned
        /// <returns> Returns an array with elements of provided type </returns>
        private static object GetPopulatedArrayOfSimpleType(Type type)
        {
            FactoryData factoryData = new FactoryData();
            if (factoryData.IsTypeImplemented(type))
            {
                object foundType = factoryData.GetValue(type);
                return foundType;
            }

            return default;
        }

        public static object CreateObject(Type type)
        {
            if (type == typeof(string))
            {
                return typeof(string);
            }

            if (type.BaseType == typeof(Array))
            {
                return typeof(Array);
            }

            object result = Activator.CreateInstance(type);
            return result;
        }
    }
}