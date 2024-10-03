using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2._3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3.Tests
{
    [TestClass]
    public class GCDAlgorithmsTest
    {
        [TestMethod]
        public void FindGCDSteinTest()
        {
            int u = 298467352;
            int v = 569484;
            int expected = 4;

            int actual = GCDAlgorithms.FindGCDStein(u, v, out _);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindGCDEuclidTest()
        {
            int u = 298467352;
            int v = 569484;
            int expected = 4;

            int actual = GCDAlgorithms.FindGCDEuclid(u, v, out _);

            Assert.AreEqual(expected, actual);
        }
    }
}