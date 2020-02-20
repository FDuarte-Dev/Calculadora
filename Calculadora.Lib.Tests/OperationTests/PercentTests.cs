using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class PercentTests
    {
        [TestMethod]
        public void PercentTest1()
        {
            Expression exp = new Expression("cinquenta por cento de dez");

            decimal result = exp.Resolve();

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void PercentTest2()
        {
            Expression exp = new Expression("cem por cento de dez");

            decimal result = exp.Resolve();

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void PercentTest3()
        {
            Expression exp = new Expression("cento e cinquenta por cento de dez");

            decimal result = exp.Resolve();

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void PercentTest4()
        {
            Expression exp = new Expression("duzentos por cento de zero vírgula cinco");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void PercentTest5()
        {
            Expression exp = new Expression("vinte e sete por cento de trinta");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)8.1, result);
        }
    }
}
