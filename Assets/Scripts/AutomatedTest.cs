using System;
using System.Reflection;
using AutomatedTestSystemTests;

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
            object result = CreateObject(type);
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                object field = Populate(fieldInfo.FieldType);
                fieldInfo.SetValue(result, field);
            }

            return result;
        }
        
        private static object GetPopulatedArrayOfSimpleType(Type type)
        {
            FactoryData factoryData = new FactoryData();
            // TODO V: This one returns array of the type, but I need only a simple type. Need to think about how to handle it
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