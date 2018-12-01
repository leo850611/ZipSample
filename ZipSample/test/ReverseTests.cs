using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void reverse_string()
        {
            var source = new string[] { "Apple", "Banana", "Cat" };

            var actual = MyReverse(source).ToList();
            var expected = new List<string> { "Cat", "Banana", "Apple" };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<string> MyReverse(IEnumerable<string> source)
        {
            var enumerator = source.GetEnumerator();

            Stack myStack = new Stack();
            while (enumerator.MoveNext())
            {
                myStack.Push(enumerator.Current);
            }

            while (myStack.Count>0)
            {
                yield return (string) myStack.Pop();
            }
        }
    }
}