using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class AndTests
    {
        [TestMethod]
        public void AndTest1()
        {
            Expression exp = new Expression("vinte e cinco");

            decimal result = exp.Resolve();

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void AndTest2()
        {
            Expression exp = new Expression("vinte e cinco ponto dois");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)25.2, result);
        }

        [TestMethod]
        public void AndTest3()
        {
            Expression exp = new Expression("vinte e cinco ponto vinte e cinco");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)25.25, result);
        }
    }
}
