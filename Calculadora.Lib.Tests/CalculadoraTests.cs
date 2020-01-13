using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora.Lib;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class CalculadoraTests
    {

        [TestMethod]
        public void TextToExpressionTest1()
        {
            string expression = "um";

            Expression result = Calculadora.TextToExpression(expression);

        }
    }
}
