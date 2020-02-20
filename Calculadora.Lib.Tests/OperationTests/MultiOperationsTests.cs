using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class MultiOperationsTests
    {
        [TestMethod]
        public void SubtractNegativeTest1()
        {
            Expression exp = new Expression("dois menos menos dois");

            decimal result = exp.Resolve();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void AddMultiplicationTest1()
        {
            Expression exp = new Expression("um mais dois vezes três");

            decimal result = exp.Resolve();

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void SubtractNegativeMultiplicationTest1()
        {
            Expression exp = new Expression("dois menos quatro vezes menos um");

            decimal result = exp.Resolve();

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void AddSubtractionForPercentTest1()
        {
            Expression exp = new Expression("duzentos e trinta mais quarenta e três menos vinte e cinco por cento de oito");

            decimal result = exp.Resolve();

            Assert.AreEqual(271, result);
        }
    }
}
