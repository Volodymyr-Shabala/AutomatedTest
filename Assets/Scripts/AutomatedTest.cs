using System;
using System.Collections.Generic;
using System.Reflection;
using AutomatedTestSystemTests;

namespace AutomatedTestSystem
{
    public class AutomatedTest
    {
        public static IList<T> Populate<T>()
        {
            Type type = typeof(T);
            object objectToPopulate = CreateObject<T>();
            if (type.GetInterface("ICollection") != null)
            {
                return PopulateCollection<T>(ref objectToPopulate);
            }
            
            if (type.IsSimpleType())
            {
                return PopulateSimpleType<T>(objectToPopulate);
            }
            
            return new List<T>();

            // Go through an array one by one
            // int index = 0;
            // bool shouldContinue = true;
            // while (shouldContinue)
            // {
            //     shouldContinue = GetElementOfType<T>(ref objectToPopulate, index);
            //     listToPopulate.Add(objectToPopulate);
            //     index++;
            // }
            //
            // return listToPopulate;
        }
        
        private static IList<T> PopulateCollection<T>(ref object objectToPopulate)
        {
            IList<T> collection = new List<T>();

            var underLyingType = typeof(T);
            var baseType = typeof(T).BaseType;
            if (typeof(T).IsGenericType)
            {
                var generic = typeof(T).GetGenericTypeDefinition();
            }

            var declaringType = typeof(T).DeclaringType;
            var t = typeof(T).GetGenericArguments(); // Works for generic type like List, Dictionary. Can loop them
            var underLyingSystemType = typeof(T).UnderlyingSystemType;
            var underLyingSystemTypeUnderlying = typeof(T).UnderlyingSystemType.UnderlyingSystemType;

            return collection;
        }

        private static object CreateObject<T>()
        {
            if (typeof(T) == typeof(string))
            {
                return typeof(string);
            }

            if (typeof(T).BaseType == typeof(Array))
            {
                return typeof(Array);
            }

            return Activator.CreateInstance<T>();
        }

    #region SimpleType

        private static bool GetElementOfType<T>(ref object objectToPopulate, int index)
        {
            FieldInfo[] fieldInfos = typeof(FactorySimpleType).GetFields();
            Type type = typeof(T).MakeArrayType();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (type == fieldInfo.FieldType)
                {
                    T[] objectArray = (T[]) fieldInfo.GetValue(objectToPopulate);
                    objectToPopulate = objectArray[index];
                    return objectArray.Length - 1 > index;
                }
            }

            return false;
        }

        // V: This version should be faster if I get only a simple type to populate
        private static IList<T> PopulateSimpleType<T>(object objectToPopulate)
        {
            FieldInfo[] fieldInfos = typeof(FactorySimpleType).GetFields();
            Type type = typeof(T).MakeArrayType();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (fieldInfo.FieldType == type && fieldInfo.FieldType.IsArray)
                {
                    return (IList<T>) fieldInfo.GetValue(objectToPopulate);
                }
            }

            return default;
        }

    #endregion

        /*
         * Activator for strings:
         * var oType = oVal.GetType();
         * if (oType == typeof(string)) return oVal as string;
         * else return Activator.CreateInstance(oType, oVal);
         *
         * For int:
         * TypeConverter tc = TypeDescriptor.GetConverter(someType);
         * object obj = tc.ConvertFromString(s);
         */
    }
}