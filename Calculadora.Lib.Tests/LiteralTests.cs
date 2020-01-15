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

            double result = a.Resolve();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void LiteralIntTest2()
        {
            Literal a = new Literal("onze");

            double result = a.Resolve();

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void LiteralIntTest3()
        {
            Literal a = new Literal("mil");

            double result = a.Resolve();

            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void LiteralIntTest4()
        {
            Literal a = new Literal("cinco mil");

            double result = a.Resolve();

            Assert.AreEqual(5000, result);
        }

        [TestMethod]
        public void LiteraldoubleTest1()
        {
            Literal a = new Literal("dois ponto dois");

            double result = a.Resolve();

            Assert.AreEqual(2.2, result);
        }

        [TestMethod]
        public void LiteraldoubleTest2()
        {
            Literal a = new Literal("dois vírgula dois");

            double result = a.Resolve();

            Assert.AreEqual(2.2, result);
        }

        [TestMethod]
        public void LiteraldoubleTest3()
        {
            Literal a = new Literal("mil vírgula onze");

            double result = a.Resolve();

            Assert.AreEqual(1000.11, result);
        }
    }
}
