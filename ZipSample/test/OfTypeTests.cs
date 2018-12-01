using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class OfTypeTests
    {
        [TestMethod]
        public void pick_integer_from_ArrayList()
        {
            var arrayList = new ArrayList { 2, "4", 6 };
            var actual = MyOfType<int>(arrayList).ToList();

            var expected = new List<int> { 2, 6 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<TResult> MyOfType<TResult>(ArrayList source)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is TResult result)
                {
                    yield return result;
                }
            }
        }
    }
}