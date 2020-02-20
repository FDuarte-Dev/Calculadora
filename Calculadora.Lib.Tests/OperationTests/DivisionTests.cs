using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void DivTest1()
        {
            Expression exp = new Expression("dois a dividir por um");

            decimal result = exp.Resolve();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void DivTest2()
        {
            Expression exp = new Expression("vinte a dividir por cinco");

            decimal result = exp.Resolve();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void DivTest3()
        {
            Expression exp = new Expression("vinte a dividir por zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(decimal.MaxValue, result);
        }

        [TestMethod]
        public void DivTest4()
        {
            Expression exp = new Expression("um a dividir por dois");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)0.5, result);
        }

        [TestMethod]
        public void DivTest5()
        {
            Expression exp = new Expression("um ponto um a dividir por zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(decimal.MaxValue, result);
        }

        [TestMethod]
        public void DivTest6()
        {
            Expression exp = new Expression("zero ponto cinco a dividir por zero ponto cinco");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }
    }
}