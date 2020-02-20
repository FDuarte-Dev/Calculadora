using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class PowerTests
    {
        [TestMethod]
        public void PowerTest1()
        {
            Expression exp = new Expression("um elevado a um");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void PowerTest2()
        {
            Expression exp = new Expression("um elevado a zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void PowerTest3()
        {
            Expression exp = new Expression("zero elevado a um");

            decimal result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void PowerTest4()
        {
            Expression exp = new Expression("dois elevado a dez");

            decimal result = exp.Resolve();

            Assert.AreEqual(1024, result);
        }

        [TestMethod]
        public void PowerTest5()
        {
            Expression exp = new Expression("zero elevado a zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void PowerTest6()
        {
            Expression exp = new Expression("dois elevado a um ponto um");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)2.1435469250725863284260126500467, result);
        }

        [TestMethod]
        public void PowerTest7()
        {
            Expression exp = new Expression("um ponto um elevado a um ponto um");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)1.1105342410545757282895080395066, result);
        }
    }
}
