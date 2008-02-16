using System;
using System.Reflection;

namespace Ruhe.Common {
    /// <summary>
    /// Function bucket providing quick access to System.Reflection actions
    /// </summary>
    public class Reflector {
        private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;

        private Reflector() {}

        /// <summary>
        /// Converts input to specified Enum value
        /// </summary>
        /// <param name="value">input to convert</param>
        /// <param name="enumerationType">the enumeration defining the desired value</param>
        /// <returns>a single value defined in given enumeration</returns>
        public static object ConvertToEnum(object value, Type enumerationType) {
            if (value.GetType().IsInstanceOfType(enumerationType))
                return value;

            object enumerationValue = null;
            if (value is string) {
                enumerationValue = Enum.Parse(enumerationType, (string) value, true);
            } else if (value is int) {
                enumerationValue = Enum.Parse(enumerationType, Enum.GetName(enumerationType, value), true);
            }
            return enumerationValue;
        }

        public static T ConvertToEnum<T>(string value) where T : struct {
            return (T) Enum.Parse(typeof(T), value);
        }

        public static T ConvertToEnum<T>(object value) where T : struct {
            return ConvertToEnum<T>(Convert.ToString(value));
        }

        public static bool FieldExists(object obj, string fieldName) {
            return GetField(obj, fieldName) != null;
        }

        public static bool FieldExists(Type domainObjectType, string fieldName) {
            return GetField(domainObjectType, fieldName) != null;
        }

        public static Type GetCrossAssemblyType(string assemblyName, string fullName) {
            return GetCrossAssemblyType(assemblyName, fullName, false);
        }

        public static Type GetCrossAssemblyType(string assemblyName, string fullName, bool throwExceptionOnFailure) {
            Assembly assembly = Assembly.Load(assemblyName);
            return assembly.GetType(fullName, throwExceptionOnFailure, true);
        }

        private static FieldInfo GetField(Type domainObjectType, string fieldName) {
            FieldInfo field = null;
            Type type = domainObjectType;
            while (field == null) {
                field = type.GetField(fieldName, Flags);
                if (type.BaseType.Name == "Object") {
                    break;
                }
                type = type.BaseType;
            }
            return field;
        }

        private static FieldInfo GetField(object obj, string fieldName) {
            return GetField(obj.GetType(), fieldName);
        }

        public static FieldInfo[] GetFields(object obj) {
            return obj.GetType().GetFields(Flags);
        }

        public static FieldInfo[] GetFields(Type type) {
            return type.GetFields(Flags);
        }

        public static Type GetFieldType(object obj, string fieldName) {
            return GetField(obj, fieldName).FieldType;
        }

        /// <summary>
        /// Gets the value of a field from a given object
        /// </summary>
        /// <param name="obj">the object to examine</param>
        /// <param name="fieldName">the field to query</param>
        /// <returns>the value of <c>fieldName</c> on <c>obj</c></returns>
        public static object GetFieldValue(object obj, string fieldName) {
            return GetField(obj, fieldName).GetValue(obj);
        }

        public static PropertyInfo[] GetProperties(object obj) {
            return obj.GetType().GetProperties(Flags);
        }

        public static PropertyInfo GetProperty(object obj, string propertyName) {
            return GetProperty(obj, propertyName, Flags);
        }

        public static PropertyInfo GetProperty(object obj, string propertyName, BindingFlags bindingFlags) {
            return obj.GetType().GetProperty(propertyName, bindingFlags);
        }

        public static Type GetPropertyType(object obj, string propertyName) {
            return GetProperty(obj, propertyName).PropertyType;
        }

        /// <summary>
        /// Gets the value of a property from a given object
        /// </summary>
        /// <param name="obj">the object to examine</param>
        /// <param name="propertyName">the property to query</param>
        /// <returns>the value of <c>propertyName</c> on <c>obj</c></returns>
        public static object GetPropertyValue(object obj, string propertyName) {
            PropertyInfo property = GetProperty(obj, propertyName);
            return property.GetValue(obj, null);
        }

        /// <summary>
        /// Gets the value of a property from a given object
        /// </summary>
        /// <param name="obj">the object to examine</param>
        /// <param name="propertyName">the property to query</param>
        /// <param name="flags">BindingFlags to use in finding the property</param>
        /// <returns>the value of <c>propertyName</c> on <c>obj</c></returns>
        public static object GetPropertyValue(object obj, string propertyName, BindingFlags flags) {
            PropertyInfo property = GetProperty(obj, propertyName, flags);
            return property.GetValue(obj, null);
        }

        public static bool HasAttribute(PropertyInfo property, Type attributeType) {
            return property.GetCustomAttributes(attributeType, true).Length > 0;
        }

        /// <summary>
        /// Determines if a given Type implements a specified interface
        /// </summary>
        /// <param name="implementingType">the Type to examine</param>
        /// <param name="interfaceType">the interface that it might implement</param>
        /// <returns>true if <c>implementingType</c> implements <c>interfaceType</c></returns>
        public static bool ImplementsInterface(Type implementingType, Type interfaceType) {
            return implementingType.GetInterface(interfaceType.FullName) != null;
        }

        public static object InvokeMethod(object obj, string methodName) {
            return InvokeMethod(obj, methodName, null);
        }

        public static object InvokeMethod(object obj, string methodName, object[] parameters) {
            MethodInfo method = obj.GetType().GetMethod(methodName, Flags);
            return method.Invoke(obj, parameters);
        }

        public static bool PropertyExists(object obj, string propertyName) {
            return GetProperty(obj, propertyName) != null;
        }

        public static void SetFieldValue(object obj, string fieldName, object fieldValue) {
            try {
                FieldInfo field = GetField(obj, fieldName);
                object value = fieldValue;
                if (field.FieldType.IsEnum) {
                    value = ConvertToEnum(value, field.FieldType);
                }
                field.SetValue(obj, value);
            }
            catch (Exception ex) {
                throw new ApplicationException(
                    String.Format("field {0} of object {1} cannot be set with value {2}", fieldName, obj.GetType(), fieldValue), ex);
            }
        }

        /// <summary>
        /// Sets a property's value on an object
        /// </summary>
        /// <param name="obj">the object to operate on</param>
        /// <param name="propertyName">the property to set</param>
        /// <param name="propertyValue">the value to assign to the property</param>
        public static void SetPropertyValue(object obj, string propertyName, object propertyValue) {
            PropertyInfo property = GetProperty(obj, propertyName);
            object value = propertyValue;
            if (property.PropertyType.IsEnum) {
                value = ConvertToEnum(value, property.PropertyType);
            }
            property.SetValue(obj, value, null);
        }
    }
}