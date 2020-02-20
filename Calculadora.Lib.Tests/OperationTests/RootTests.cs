using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class RootTests
    {
        [TestMethod]
        public void RootTest1()
        {
            Expression exp = new Expression("raiz quadrada de um");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void RootTest2()
        {
            Expression exp = new Expression("raiz quadrada de zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void RootTest3()
        {
            Expression exp = new Expression("raiz quadrada de vinte e cinco");

            decimal result = exp.Resolve();

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void RootTest4()
        {
            Expression exp = new Expression("raiz quadrada de dois ponto dois");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)1.4832396974191325897422794881601, result);
        }
    }
}
