using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1.GCDTests
{
    [TestClass]
    public class GCDAlgorithmsTest
    {
        [TestMethod]
        public void FindGCDEuclidTest()
        {
            int a = 2806;
            int b = 345;
            int expected = 23;

            int result = GCDAlgorithms.FindGCDEuclid(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}