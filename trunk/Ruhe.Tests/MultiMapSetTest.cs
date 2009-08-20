using System.Collections.Generic;
using LiquidSyntax.ForTesting;
using NUnit.Framework;

namespace Ruhe.Tests {
    [TestFixture]
    public class MultiMapSetTest {
        [Test]
        public void ShouldAcceptSameKeyMoreThanOnceYouStupidFramework() {
            var set = new MultiMapSet<int, int>();
            set.Add(1, 1);
            set.Add(1, 1);

            set[1].Should(Be.EquivalentTo(new[] {1}));
        }

        [Test]
        public void ShouldAcceptMultipleValuesForAGivenKey() {
            var set = new MultiMapSet<int, int>();
            set.Add(1, 1);
            set.Add(1, 11);

            set[1].Should(Be.EquivalentTo(new[] {1, 11}));
        }

        [Test]
        public void ShouldAcceptMultipleKeys() {
            var set = new MultiMapSet<int, int>();
            set.Add(1, 1);
            set.Add(2, 11);

            set.Keys.Should(Be.EquivalentTo(new[] {1, 2}));
        }

        [Test]
        public void ShouldProvideCollectionOfSetsOfValues() {
            var set = new MultiMapSet<int, int>();
            set.Add(1, 1);
            set.Add(2, 45726);
            set.Add(1, 11);
            set.Add(3, 6);

            set.Values.Should(Be.EquivalentTo(new[] {
                new HashSet<int> {1, 11}, 
                new HashSet<int> {45726}, 
                new HashSet<int> {6}
            }));
        }

        [Test]
        public void ShouldBeAbleToTellYouIfItContainsKey() {
            var set = new MultiMapSet<int, int>();
            set.Add(1, 1);
            set.Add(2, 4);

            set.ContainsKey(1).Should(Be.True);
            set.ContainsKey(3).Should(Be.False);
        }
    }
}