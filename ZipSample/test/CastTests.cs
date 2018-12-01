using ExpectedObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class CastTests
    {
        [TestMethod]
        public void cast_integers()
        {
            var arrayList = new ArrayList { 2, 6 };
            var actual = MyCast(arrayList).ToList();

            var expected = new List<int> { 2, 6 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void cast_integers_with_cast_failed()
        {
            var arrayList = new ArrayList { 2, "4", 6 };
            Action action = () => MyCast(arrayList).ToList();
            action.Should().Throw<InvalidCastException>();
        }

        private IEnumerable<int> MyCast(IEnumerable arrayList)
        {
            var enumerator = arrayList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is int)
                {

                    yield return (int)enumerator.Current;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }
    }
}