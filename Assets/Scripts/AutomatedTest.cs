using System;
using System.Collections.Generic;
using System.Reflection;
using AutomatedTestSystemTests;
using UnityEngine;

namespace AutomatedTestSystem
{
    public class AutomatedTest
    {
        public static T Populate<T>()
        {
            if (typeof(T).IsSimpleType())
            {
                return PopulateSimpleTypeField<T>();
            }

            // object returnObject = objectType;
            // object returnObject = new object();
            // return Populate(returnObject, typeof(T));
            return default;
        }

        private static T PopulateSimpleTypeField<T>()
        {
            string stringValue = FactoryPrimitiveType.GetStringValueAt(3);
            return stringValue is T value ? value : default;

            if (typeof(T) == typeof(string))
            {
                
            }
        }

        private static object Populate(object objectToPopulate, Type type)
        {
            if (type.IsSimpleType())
            {
                AssignField(objectToPopulate, type.GetProperties()[0], type);
            }

            return objectToPopulate;

            PropertyInfo[] fieldInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in fieldInfos)
            {
                Type fieldType = propertyInfo.PropertyType;
                if (IsTypeSupported(fieldType))
                {
                    objectToPopulate = AssignField(objectToPopulate, propertyInfo, fieldType);
                    Debug.Log("Supported type");
                }
                else if (fieldType.IsPrimitive)
                {
                    Debug.Log("Primitive");
                }
                else if (fieldType == typeof(List<>) && fieldType.IsGenericType)
                {
                    Debug.LogError("List encountered");
                }
                else
                {
                    object fieldObject = Activator.CreateInstance(fieldType);
                    propertyInfo.SetValue(objectToPopulate, Populate(fieldObject, fieldType));
                }
            }

            return objectToPopulate;
        }

        private static object AssignField(object testObject, PropertyInfo propertyInfo, Type type)
        {
            if (type == typeof(int))
            {
                propertyInfo.SetValue(testObject, FactoryPrimitiveType.IntValues[2]);
            }

            if (type == typeof(long))
            {
                propertyInfo.SetValue(testObject, FactoryPrimitiveType.LongValues[2]);
            }

            if (type == typeof(string))
            {
                propertyInfo.SetValue(testObject, FactoryPrimitiveType.StringValues[2]);
            }

            if (type == typeof(char))
            {
                propertyInfo.SetValue(testObject, FactoryPrimitiveType.CharValues[2]);
            }

            return testObject;
        }

        // I think this can be removed
        private static bool IsTypeSupported(Type type)
        {
            if (type == typeof(int))
            {
                return true;
            }

            if (type == typeof(long))
            {
                return true;
            }

            if (type == typeof(string))
            {
                return true;
            }

            return false;
        }
    }
}