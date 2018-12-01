using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void concat_integers()
        {
            var first = new int[] {1, 3, 5};
            var second = new int[] {2, 4, 6};

            var actual = MyConcat(first, second).ToArray();

            var expected = new int[] {1, 3, 5, 2, 4, 6};
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void concat_string()
        {
            var first = new [] {"1", "3", "5"};
            var second = new [] {"2", "4", "6"};

            var actual = MyConcat(first, second).ToArray();

            var expected = new [] { "1", "3", "5" , "2", "4", "6" };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<TSource> MyConcat<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                yield return firstEnumerator.Current;
            }
            while (secondEnumerator.MoveNext())
            {
                yield return secondEnumerator.Current;
            }
        }
    }
}