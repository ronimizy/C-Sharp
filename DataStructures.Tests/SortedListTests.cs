using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DataStructures.Tests
{
    [TestFixture]
    public class SortedListTests
    {
        [Test]
        public void Add_AddMultipleValues_SortingCorrectly(
            [Random(0, 1000, 100, Distinct = true)]
            int count)
        {
            var values = GetValues(count);
            var list = new SortedList<int>();

            foreach (var value in values)
            {
                list.Add(value);
            }

            CollectionAssert.AreEqual(values.OrderBy(i => i), list);
        }

        [Test]
        public void Add_AddAnExistingValue_ArgumentException()
        {
            int[] values = { 1, 2, 3 };
            var value = values[0];

            var list = new SortedList<int>();

            foreach (var i in values)
            {
                list.Add(i);
            }

            Assert.Throws<ArgumentException>(() => list.Add(value));
        }

        [Test]
        public void Contains_PositiveArrayAdded_NegativeNumberAsked_FalseReturned(
            [Random(0, 200, 10, Distinct = true)]
            int count)
        {
            var values = GetValues(count);
            const int value = -1;

            var list = new SortedList<int>();

            foreach (var i in values)
            {
                list.Add(i);
            }

            Assert.IsFalse(list.Contains(value));
        }

        [Test]
        public void Contains_PositiveArrayAdded_ContainingValueAsked_TrueReturned(
            [Random(0, 200, 10, Distinct = true)]
            int count)
        {
            var values = GetValues(count);
            var value = values[TestContext.CurrentContext.Random.Next(count - 1)];

            var list = new SortedList<int>();

            foreach (var i in values)
            {
                list.Add(i);
            }

            Assert.IsTrue(list.Contains(value));
        }

        private static List<int> GetValues(int count)
            => Enumerable
                .Range(0, count)
                .Select(_ => TestContext.CurrentContext.Random.Next(1_000_000))
                .Distinct()
                .ToList();
    }
}