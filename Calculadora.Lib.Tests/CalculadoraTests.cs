using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class CalculadoraTests
    {
        [ClassInitialize]
        public void ClassInitializa() 
        {
        }

        [TestMethod]
        public void TextToExpressionTest1()
        {
            string expression = expressionPairs[0].key;

            Expression result = Calculadora.TextToExpression(expression);

            Assert.AreEqual(expressionPairs[0].value, result);
        }
    }
}
