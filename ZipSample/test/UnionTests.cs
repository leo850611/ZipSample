using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void Union_integers()
        {
            var first = new List<int> { 1, 3, 3, 5 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 1, 3, 5, 7, 9 };

            var actual = MyUnion(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Union_girls()
        {
            var first = new List<Girl>
            {
                new Girl(){Name = "lulu", Age = 25},
                new Girl(){Name = "lily", Age = 18},
            };
            var second = new List<Girl>
            {
                new Girl(){Name = "leo", Age = 18},
                new Girl(){Name = "lulu", Age = 25},
            };

            var expected = new List<Girl>
            {
                new Girl(){Name = "lulu", Age = 25},
                new Girl(){Name = "lily", Age = 18},
                new Girl(){Name = "leo", Age = 18},
            };

            var actual = MyGirlUnion(first, second, new MyComparer()).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<T> MyGirlUnion<T>(IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            var hashSet = new HashSet<T>(comparer);
            var firstEnumerator = first.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                if (hashSet.Add(firstEnumerator.Current))
                {
                    yield return firstEnumerator.Current;
                }
            }

            var secondEnumerator = second.GetEnumerator();
            while (secondEnumerator.MoveNext())
            {
                if (hashSet.Add(secondEnumerator.Current))
                {
                    yield return secondEnumerator.Current;
                }
            }
        }

        private IEnumerable<int> MyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            return MyGirlUnion(first, second, EqualityComparer<int>.Default);
        }
    }

    public class MyComparer : IEqualityComparer<Girl>
    {
        public bool Equals(Girl x, Girl y)
        {
            return x.Name == y.Name && x.Age == y.Age;
        }

        public int GetHashCode(Girl obj)
        {
            return Tuple.Create(obj.Name, obj.Age).GetHashCode();
            //return new {obj.Name, obj.Age}.GetHashCode();
        }
    }
}