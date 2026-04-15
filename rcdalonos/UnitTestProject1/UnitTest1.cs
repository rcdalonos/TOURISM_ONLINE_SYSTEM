using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{

    class Calculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    [TestClass]
    public class CalcUnitTest1
    {

        [TestMethod]
        public void TestAdd()
        {
            Calculator calc = new Calculator();
            int num1 = 1, num2 = 2;
            var result = calc.Add(num1, num2);
            //result = 4;
            Assert.AreEqual(num1 + num2, result);
        }

    }
}
