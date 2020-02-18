using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora.Lib;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class CalculadoraTests
    {

        [TestMethod]
        public void CalculadoraTest1()
        {
            string expression = "um";

            string result = Calculadora.Init(expression);

            Assert.AreEqual("1 = 1", result);
        }

        [TestMethod]
        public void CalculadoraTest2()
        {
            string expression = "um mais um";

            string result = Calculadora.Init(expression);

            Assert.AreEqual("1+1 = 2", result);
        }

        [TestMethod]
        public void CalculadoraTest3()
        {
            string expression = "dois mais três menos vinte";

            string result = Calculadora.Init(expression);

            Assert.AreEqual("2+3-20 = -15", result);
        }

        [TestMethod]
        public void CalculadoraTest4()
        {
            string expression = "dois vírgula um";

            string result = Calculadora.Init(expression);

            Assert.AreEqual("2,1 = 2,1", result);
        }

        [TestMethod]
        public void CalculadoraTest5()
        {
            string expression = "cinquenta por cento de cem";

            string result = Calculadora.Init(expression);

            Assert.AreEqual("50%100 = 50,0", result);
        }

        [TestMethod]
        public void CalculadoraTest6()
        {
            string expression = "menos um " +
                                "mais um " +
                                "menos um " +
                                "mais um " +
                                "menos um " +
                                "mais um " +
                                "menos um " +
                                "mais um " +
                                "menos um " +
                                "mais um";

            string result = Calculadora.Init(expression);

            Assert.AreEqual("-1+1-1+1-1+1-1+1-1+1 = 0", result);
        }
    }
}
