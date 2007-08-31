using System;
using System.Collections;
using System.Reflection;

namespace Ruhe.Common {
	public class Reflector {
		private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;

		private Reflector() {}

		public static void SetPropertyValue(object obj, string propertyName, object propertyValue) {
			PropertyInfo property = GetProperty(obj, propertyName);
			object value = propertyValue;
			if (property.PropertyType.IsEnum) {
				value = ConvertToEnum(value, property.PropertyType);
			}
			property.SetValue(obj, value, null);
		}

		public static object ConvertToEnum(object value, Type enumerationType) {
			if (value.GetType().IsInstanceOfType(enumerationType))
				return value;

			object enumerationValue = null;
			if (value is string) {
				enumerationValue = Enum.Parse(enumerationType, (string) value, true);
			}
			else if (value is int) {
				enumerationValue = Enum.Parse(enumerationType, Enum.GetName(enumerationType, value), true);
			}
			return enumerationValue;
		}

		public static bool ImplementsInterface(Type implementingType, Type interfaceType) {
			return implementingType.GetInterface(interfaceType.FullName) != null;
		}

		public static object GetPropertyValue(object obj, string propertyName) {
			PropertyInfo property = GetProperty(obj, propertyName);
			return property.GetValue(obj, null);
		}

		public static object GetPropertyValue(object obj, string propertyName, BindingFlags flags) {
			PropertyInfo property = GetProperty(obj, propertyName, flags);
			return property.GetValue(obj, null);
		}

		public static object GetFieldValue(object obj, string fieldName) {
			return GetField(obj, fieldName).GetValue(obj);
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

		public static bool FieldExists(object obj, string fieldName) {
			return GetField(obj, fieldName) != null;
		}

		public static bool FieldExists(Type domainObjectType, string fieldName) {
			return GetField(domainObjectType, fieldName) != null;
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

		public static Type GetFieldType(object obj, string fieldName) {
			return GetField(obj, fieldName).FieldType;
		}

		public static bool PropertyExists(object obj, string propertyName) {
			return GetProperty(obj, propertyName) != null;
		}

		public static Type GetPropertyType(object obj, string propertyName) {
			return GetProperty(obj, propertyName).PropertyType;
		}

		public static PropertyInfo[] GetProperties(object obj) {
			return obj.GetType().GetProperties(Flags);
		}

		public static FieldInfo[] GetFields(object obj) {
			return obj.GetType().GetFields(Flags);
		}

		public static FieldInfo[] GetFields(Type type) {
			return type.GetFields(Flags);
		}

		public static PropertyInfo GetProperty(object obj, string propertyName) {
			return GetProperty(obj, propertyName, Flags);
		}

		public static PropertyInfo GetProperty(object obj, string propertyName, BindingFlags bindingFlags) {
			return obj.GetType().GetProperty(propertyName, bindingFlags);
		}

		public static Type GetCrossAssemblyType(string assemblyName, string fullName) {
			return GetCrossAssemblyType(assemblyName, fullName, false);
		}

		public static Type GetCrossAssemblyType(string assemblyName, string fullName, bool throwExceptionOnFailure) {
			Assembly assembly = Assembly.Load(assemblyName);
			return assembly.GetType(fullName, throwExceptionOnFailure, true);
		}

		public static bool HasAttribute(PropertyInfo property, Type attributeType) {
			return property.GetCustomAttributes(attributeType, true).Length > 0;
		}

		public static bool IsIList(PropertyInfo property) {
			return (property.PropertyType == typeof(IList));
		}

		public static object InvokeMethod(object obj, string methodName) {
			return InvokeMethod(obj, methodName, null);
		}

		public static object InvokeMethod(object obj, string methodName, object[] parameters) {
			MethodInfo method = obj.GetType().GetMethod(methodName, Flags);
			return method.Invoke(obj, parameters);
		}
	}
}