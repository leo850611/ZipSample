using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ZipSample.test
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        [TestFixture]
        public class UnitTest1
        {
            [TestCase(106, "2", true)]
            [TestCase(106, "11", true)]
            [TestCase(106, "0", false)]
            [TestCase(106, "12", false)]
            [TestCase(106, "99", true)]
            [TestCase(107, "2a", true)]
            [TestCase(107, "2b", true)]
            [TestCase(107, "14", true)]
            [TestCase(107, "1", true)]
            [TestCase(107, "2", false)]
            [TestCase(107, "12", false)]
            [TestCase(107, "99", true)]
            [TestCase(107, "abc", false)]
            public void valid_list(int year, string content, bool expected)
            {
                var medical = new Medical(year, content);
                Assert.AreEqual(expected, medical.IsValid());
            }
        }
    }

    public class Medical
    {
        protected internal int _year;
        private string _content;

        public Medical(int year, string content)
        {
            _content = content;
            _year = year;
        }

        public bool IsValid()
        {
            int con = -1;
            var isNumbel = Int32.TryParse(_content, out con);
            if (_year == 106)
            {
                if ((con >= 1 && con <= 11) || con == 99)
                {
                    return true;
                }
            }

            if (_year == 107)
            {
                if (isNumbel)
                {
                    if (con == 2 || con == 12)
                    {
                        return false;
                    }

                    if ((con >= 1 && con <= 14) || con == 99)
                    {
                        return true;
                    }
                }

                if (_content == "2a" || _content == "2b")
                {
                    return true;
                }
            }

            return false;
        }
    }
}