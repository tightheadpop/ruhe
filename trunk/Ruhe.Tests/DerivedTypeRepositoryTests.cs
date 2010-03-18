using System.ComponentModel;
using LiquidSyntax.ForTesting;
using NUnit.Framework;

namespace Ruhe.Tests {
    [TestFixture]
    public class DerivedTypeRepositoryTests {
        [Test]
        public void FindsAllDerivedTypesFromAssembly() {
            var controls = new DerivedTypeRepository<Foo>().GetDerivedTypes();
            controls.Should(Be.EquivalentTo(new[] {typeof(Fun), typeof(Bar), typeof(Baz)}));
        }

        [Test]
        public void FindsAllDisplayNamesSortedAlphabetically() {
            var displayNames = new DerivedTypeRepository<Foo>().GetDisplayNames();
            displayNames.Should(Be.EqualTo(new[] {"This is Bar", "This is Baz", "This is fun"}));
        }

        [Test]
        public void ConvertsDisplayNameBackToType() {
            new DerivedTypeRepository<Foo>().GetDerivedType("This is Bar").Should(Be.EqualTo(typeof(Bar)));
        }

        [Test]
        public void CreatesInstanceOfDerivedType() {
            new DerivedTypeRepository<Foo>().GetInstanceOfDerivedType("This is Bar").Should(Be.InstanceOf<Bar>());
        }

        [Test]
        public void ShouldDiscoverInterfaceImplementers() {
            new DerivedTypeRepository<IFoo>().GetDerivedTypes().Should(Have.Count.EqualTo(3));
        }

        [Test]
        public void ShouldWorkWithMultipleDerivedTypeRepositories() {
            var foos = new DerivedTypeRepository<Foo>();
            var unknowns = new DerivedTypeRepository<Unknown>();

            foos.GetDerivedTypes();
            unknowns.GetDerivedTypes().Should(Have.Count.EqualTo(1));
        }

        private interface IFoo {}

        private abstract class Foo : IFoo {}

        [DisplayName("This is fun")]
        private class Fun : Foo {}

        [DisplayName("This is Bar")]
        private class Bar : Foo {}

        [DisplayName("This is Baz")]
        private class Baz : Foo {}

        private abstract class Unknown{}
// ReSharper disable UnusedMember.Local
        private class MyFeelings : Unknown{}
// ReSharper restore UnusedMember.Local
    }
}