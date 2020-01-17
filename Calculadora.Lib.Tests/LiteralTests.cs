using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora.Lib;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class LiteralTests
    {

        [TestMethod]
        public void LiteralIntTest1()
        {
            Literal a = new Literal("dois");

            decimal result = a.Resolve();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void LiteralIntTest2()
        {
            Literal a = new Literal("onze");

            decimal result = a.Resolve();

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void LiteralIntTest3()
        {
            Literal a = new Literal("mil");

            decimal result = a.Resolve();

            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void LiteralIntTest4()
        {
            Literal a = new Literal("cinco mil");

            decimal result = a.Resolve();

            Assert.AreEqual(5000, result);
        }

        [TestMethod]
        public void LiteraldecimalTest1()
        {
            Literal a = new Literal("dois ponto dois");

            decimal result = a.Resolve();

            Assert.AreEqual((decimal)2.2, result);
        }

        [TestMethod]
        public void LiteraldecimalTest2()
        {
            Literal a = new Literal("dois vírgula dois");

            decimal result = a.Resolve();

            Assert.AreEqual((decimal)2.2, result);
        }

        [TestMethod]
        public void LiteraldecimalTest3()
        {
            Literal a = new Literal("mil vírgula onze");

            decimal result = a.Resolve();

            Assert.AreEqual((decimal)1000.11, result);
        }
    }
}
