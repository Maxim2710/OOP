using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._2.Tests
{
    [TestClass()]
    public class GCDAlgorithmsTests
    {
        [TestMethod]
        public void FindGCDEuclidTest1()
        {
            int a = 7396, b = 1978, c = 1204;
            int expected = 86;
            int actual = GCDAlgorithms.FindGCDEuclid(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclidTest2()
        {
            int a = 7396, b = 1978, c = 1204, d = 430;
            int expected = 86;
            int actual = GCDAlgorithms.FindGCDEuclid(a, b, c, d);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclidTest3()
        {
            int a = 7396, b = 1978, c = 1204, d = 430, e = 258;
            int expected = 86;
            int actual = GCDAlgorithms.FindGCDEuclid(a, b, c, d, e);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclidParamsTest()
        {
            int[] numbers = { 7396, 1978, 1204, 430, 258 };
            int expected = 86;

            int actual = GCDAlgorithms.FindGCDEuclid(numbers);

            Assert.AreEqual(expected, actual);
        }

    }
}