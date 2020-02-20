using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class SubtractionTests
    {
        [TestMethod]
        public void MinusTest1()
        {
            Expression exp = new Expression("um menos um");

            decimal result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MinusTest2()
        {
            Expression exp = new Expression("três menos um menos dois");

            decimal result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MinusTest3()
        {
            Expression exp = new Expression("trinta menos dez menos dez menos um");

            decimal result = exp.Resolve();

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void MinusTest4()
        {
            Expression exp = new Expression("um ponto um menos um");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)0.1, result);
        }

        [TestMethod]
        public void MinusTest5()
        {
            Expression exp = new Expression("dois ponto um menos um ponto um");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }
    }
}