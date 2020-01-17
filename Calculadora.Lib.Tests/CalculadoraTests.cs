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

            string result = Calculadora.Resolve(expression);

            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void CalculadoraTest2()
        {
            string expression = "um mais um";

            string result = Calculadora.Resolve(expression);

            Assert.AreEqual("1+1", result);
        }

        [TestMethod]
        public void CalculadoraTest3()
        {
            string expression = "dois mais três menos vinte";

            string result = Calculadora.Resolve(expression);

            Assert.AreEqual("2+3-20", result);
        }

        [TestMethod]
        public void CalculadoraTest4()
        {
            string expression = "dois vírgula um";

            string result = Calculadora.Resolve(expression);

            Assert.AreEqual("2,1", result);
        }

        [TestMethod]
        public void CalculadoraTest5()
        {
            string expression = "cinquenta por cento de cem";

            string result = Calculadora.Resolve(expression);

            Assert.AreEqual("50%100", result);
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

            string result = Calculadora.Resolve(expression);

            Assert.AreEqual("-1+1-1+1-1+1-1+1-1+1", result);
        }
    }
}
