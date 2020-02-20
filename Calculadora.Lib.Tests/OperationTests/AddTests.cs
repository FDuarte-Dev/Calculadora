using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void AddTest1()
        {
            Expression exp = new Expression("um mais um");

            decimal result = exp.Resolve();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void AddTest2()
        {
            Expression exp = new Expression("um mais um mais um");

            decimal result = exp.Resolve();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddTest3()
        {
            Expression exp = new Expression("um mais um mais um mais trinta");

            decimal result = exp.Resolve();

            Assert.AreEqual(33, result);
        }

        [TestMethod]
        public void AddTest4()
        {
            Expression exp = new Expression("um mais um ponto um");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)2.1, result);
        }

        [TestMethod]
        public void AddTest5()
        {
            Expression exp = new Expression("um ponto um mais um ponto um");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)2.2, result);
        }
    }
}
