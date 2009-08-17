using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LiquidSyntax;

namespace Ruhe {
    public class DerivedTypeRepository<T> where T : class {
        private static readonly Dictionary<Type, List<Type>> DerivedTypes = new Dictionary<Type, List<Type>>();

        public virtual IEnumerable<Assembly> GetAssembliesToSearch() {
            return typeof(T).Assembly.AsList();
        }

        public IEnumerable<Type> GetDerivedTypes() {
            EnsureDerivedTypesOfT();
            return DerivedTypes[typeof(T)];
        }

        private void EnsureDerivedTypesOfT() {
            if (!DerivedTypes.ContainsKey(typeof(T))) {
                AddDerivedTypesOfT();
            }
        }

        private void AddDerivedTypesOfT() {
            var typesOfT = new List<Type>();
            foreach (var assembly in GetAssembliesToSearch()) {
                foreach (var type in assembly.GetTypes()) {
                    if (!type.IsAbstract && type.IsClass && typeof(T).IsAssignableFrom(type))
                        typesOfT.Add(type);
                }
            }
            DerivedTypes.Add(typeof(T), typesOfT);
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