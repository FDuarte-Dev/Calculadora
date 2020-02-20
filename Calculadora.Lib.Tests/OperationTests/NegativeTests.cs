using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class NegativeTests
    {
        [TestMethod]
        public void NegTest1()
        {
            Expression exp = new Expression("menos dois");

            decimal result = exp.Resolve();

            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void NegTest2()
        {
            Expression exp = new Expression("menos dois ponto dois");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)-2.2, result);
        }

        [TestMethod]
        public void NegTest3()
        {
            Expression exp = new Expression("menos zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(0, result);
        }
    }
}
