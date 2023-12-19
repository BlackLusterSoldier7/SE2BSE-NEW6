using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BasicMathTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }


        [TestMethod] 
        public void Test_AddMethod()
        {
            BasicMaths bm = new BasicMaths();
            double res = bm.Add(10, 10);
            Assert.AreEqual(res, 20); 


        }



        [TestMethod] 
        public void Test_SubtractMethod()
        {
            BasicMaths bm = new BasicMaths();
            double res = bm.Subtract(50, 25);
            Assert.AreEqual(res, 25); 
        }

        [TestMethod]
        public void Test_DivideMethod()
        {
            BasicMaths bm = new BasicMaths();
            double res = bm.divide(10, 5);
            Assert.AreEqual(res, 2);
        }

        [TestMethod] 
        public void Test_MultiplyMethod()
        {
            BasicMaths bm = new BasicMaths();
            double res = bm.Multiply(10, 10);
            Assert.AreEqual(res, 100); 
        }




    }
}
