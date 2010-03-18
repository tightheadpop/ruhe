using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LiquidSyntax;

namespace Ruhe {
    public class DerivedTypeRepository<T> where T : class {
        private static List<Type> derivedTypes;
        private static readonly object lockable = new object();

        public virtual IEnumerable<Assembly> GetAssembliesToSearch() {
            return typeof(T).Assembly.AsList();
        }

        public IEnumerable<Type> GetDerivedTypes() {
            EnsureDerivedTypesOfT();
            return derivedTypes;
        }

        private void EnsureDerivedTypesOfT() {
            if (derivedTypes == null)
                lock (lockable)
                    if (derivedTypes == null)
                        AddDerivedTypesOfT();
        }

        private void AddDerivedTypesOfT() {
            derivedTypes = new List<Type>();
            foreach (var assembly in GetAssembliesToSearch()) {
                foreach (var type in assembly.GetTypes()) {
                    if (!type.IsAbstract && type.IsClass && typeof(T).IsAssignableFrom(type))
                        derivedTypes.Add(type);
                }
            }
        }

        public IEnumerable<string> GetDisplayNames() {
            return GetDerivedTypes().ToList().ConvertAll(input => input.GetDisplayName()).Sorted();
        }

        public Type GetDerivedType(string displayName) {
            return (from type in GetDerivedTypes()
                    where type.GetDisplayName() == displayName
                    select type).FirstOrDefault();
        }

        public T GetInstanceOfDerivedType(string displayName) {
            return (T) Activator.CreateInstance(GetDerivedType(displayName));
        }
    }
}