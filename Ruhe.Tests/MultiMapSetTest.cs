using System;
using System.Collections.Generic;
using LiquidSyntax.ForTesting;
using NUnit.Framework;

namespace Ruhe.Tests {
    [TestFixture]
    public class MultiMapSetTest {
        [Test]
        public void ShouldAcceptSameKeyMoreThanOnceYouStupidFramework() {
            var set = new MultiMapSet<int, int> {{1, 1}, {1, 1}};

            set[1].Should(Be.EquivalentTo(new[] {1}));
        }

        [Test]
        public void ShouldAcceptMultipleValuesForAGivenKey() {
            var set = new MultiMapSet<int, int> {{1, 1}, {1, 11}};

            set[1].Should(Be.EquivalentTo(new[] {1, 11}));
        }

        [Test]
        public void ShouldAcceptMultipleKeys() {
            var set = new MultiMapSet<int, int> {{1, 1}, {2, 11}};

            set.Keys.Should(Be.EquivalentTo(new[] {1, 2}));
        }

        [Test]
        public void ShouldProvideCollectionOfSetsOfValues() {
            var set = new MultiMapSet<int, int> {{1, 1}, {2, 45726}, {1, 11}, {3, 6}};

            set.Values.Should(Be.EquivalentTo(new[] {
                new HashSet<int> {1, 11},
                new HashSet<int> {45726},
                new HashSet<int> {6}
            }));
        }

        [Test]
        public void ShouldBeAbleToTellYouIfItContainsKey() {
            var set = new MultiMapSet<int, int> {{1, 1}, {2, 4}};

            set.ContainsKey(1).Should(Be.True);
            set.ContainsKey(3).Should(Be.False);
        }

        [Test]
        public void ShouldBeEnumerableCollectionOfKeyValuePairs() {
            var set = new MultiMapSet<int, string> {{1, "a"}, {2, "b"}};
            foreach (var mapPair in set) {
                mapPair.Should(Be.InstanceOf<KeyValuePair<int, HashSet<string>>>());
            }
        }

        [Test]
        public void ShouldRemoveEntryBasedOnKey() {
            var set = new MultiMapSet<string, int> {{"foo", 42}};
            set.Remove("foo").Should(Be.True);
            set.Should(Be.Empty);
        }

        [Test]
        public void RemovingNonExistentKeyShouldReturnFalse() {
            var set = new MultiMapSet<string, int> {{"foo", 42}};
            set.Remove("42").Should(Be.False);
            set.ShouldNot(Be.Empty);
        }
    }
}