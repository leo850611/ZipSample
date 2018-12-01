using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class IntersectTests
    {
        [TestMethod]
        public void intersect_integers()
        {
            var first = new List<int> { 1, 3, 3, 5 };
            var second = new List<int> { 5, 5, 3, 3, 7, 9 };

            var expected = new List<int> { 3, 5 };

            var actual = MyIntersect(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<int> MyIntersect(IEnumerable<int> first, IEnumerable<int> second)
        {
            throw new System.NotImplementedException();
        }
    }
}