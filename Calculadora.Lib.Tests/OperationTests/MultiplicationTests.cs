using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void MulTest1()
        {
            Expression exp = new Expression("um vezes um");

            decimal result = exp.Resolve();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MulTest2()
        {
            Expression exp = new Expression("um vezes zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MulTest3()
        {
            Expression exp = new Expression("um vezes trinta");

            decimal result = exp.Resolve();

            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void MulTest4()
        {
            Expression exp = new Expression("três vezes trinta");

            decimal result = exp.Resolve();

            Assert.AreEqual(90, result);
        }

        [TestMethod]
        public void MulTest5()
        {
            Expression exp = new Expression("zero vezes zero");

            decimal result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MulTest6()
        {
            Expression exp = new Expression("dois vezes um ponto um");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)2.2, result);
        }

        [TestMethod]
        public void MulTest7()
        {
            Expression exp = new Expression("um ponto um vezes um ponto um");

            decimal result = exp.Resolve();

            Assert.AreEqual((decimal)1.21, result);
        }
    }
}