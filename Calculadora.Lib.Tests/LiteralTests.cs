using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora.Lib;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class LiteralTests
    {

        [TestMethod]
        public void TextToExpressionTest1()
        {
            Literal a = new Literal("dois");

            //TODOFD - recursion
            a.Resolve();

            Assert.AreEqual((float)2, a.NumericValue);
        }
    }
}
