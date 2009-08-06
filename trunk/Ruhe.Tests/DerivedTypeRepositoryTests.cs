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

        private abstract class Foo {}

        [DisplayName("This is fun")]
        private class Fun : Foo {}

        [DisplayName("This is Bar")]
        private class Bar : Foo {}

        [DisplayName("This is Baz")]
        private class Baz : Foo {}
    }
}