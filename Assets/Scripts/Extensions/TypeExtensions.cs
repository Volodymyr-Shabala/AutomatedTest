using System;
using System.Collections.Generic;

namespace AutomatedTestSystemTests
{
    public static class TypeExtensions
    {
        private const string collectionName = "ICollection";
        private static readonly IList<Type> customDefinedSimpleTypes = new List<Type>
        {
            typeof(string),
            typeof(decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan)
        };

        public static bool IsSimpleType(this Type type)
        {
            bool isPrimitive = type.IsPrimitive;
            bool isCustomDefined = customDefinedSimpleTypes.Contains(type);
            bool isNotAnObject = Convert.GetTypeCode(type) != TypeCode.Object;
            bool result = isPrimitive || isCustomDefined || isNotAnObject;
            if (result)
            {
                return true;
            }

            // V: Nullables are not simple type. Have to check if they are nullable, then get underlying type and check it if it is simple.
            if (IsNullable(type))
            {
                result = HandleNullable(type);
                return result;
            }

            return false;
        }

        public static bool IsClass(this Type type)
        {
            bool result = Convert.GetTypeCode(type) == TypeCode.Object;
            return result;
        }

        private static bool HandleNullable(Type type)
        {
            Type[] genericTypeArguments = type.GenericTypeArguments;
            foreach (Type genericTypeArgument in genericTypeArguments)
            {
                bool simpleType = genericTypeArgument.IsSimpleType();
                if (simpleType)
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool IsNullable(this Type type)
        {
            bool result = Nullable.GetUnderlyingType(type) != null;
            return result;
        }

        public static Type GetNullableType(this Type type)
        {
            // Use Nullable.GetUnderlyingType() to remove the Nullable<T> wrapper if type is already nullable.
            type = Nullable.GetUnderlyingType(type) ?? type; // avoid type becoming null
            return type.IsValueType ? typeof(Nullable<>).MakeGenericType(type) : type;
        }

        public static bool IsCollection(this Type type)
        {
            bool result = type.GetInterface(collectionName) != null;
            return result;
        }
        
        public static Type GetSimpleTypeFromCollection(this Type type)
        {
            // if (type.IsCollection())
            // {
                Type elementType = type.GetElementType();
                if (elementType.IsSimpleType())
                {
                    return elementType;
                }
            // }

            return type;
        }
    }
}