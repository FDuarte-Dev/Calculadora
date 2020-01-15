using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora.Lib;
using System;

namespace Calculadora.Lib.Tests
{
    [TestClass]
    public class OperationTests
    {
        #region Addition
        [TestMethod]
        public void AddTest1() 
        {
            Expression exp = new Expression("um mais um");

            double result = exp.Resolve();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void AddTest2()
        {
            Expression exp = new Expression("um mais um mais um");

            double result = exp.Resolve();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddTest3()
        {
            Expression exp = new Expression("um mais um mais um mais trinta");

            double result = exp.Resolve();

            Assert.AreEqual(33, result);
        }

        [TestMethod]
        public void AddTest4()
        {
            Expression exp = new Expression("um mais um ponto um");

            double result = exp.Resolve();

            Assert.AreEqual(2.1, result);
        }

        [TestMethod]
        public void AddTest5()
        {
            Expression exp = new Expression("um ponto um mais um ponto um");

            double result = exp.Resolve();

            Assert.AreEqual(2.2, result);
        }
        #endregion

        #region Subtraction
        [TestMethod]
        public void MinusTest1()
        {
            Expression exp = new Expression("um menos um");

            double result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MinusTest2()
        {
            Expression exp = new Expression("três menos um menos dois");

            double result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MinusTest3()
        {
            Expression exp = new Expression("trinta menos dez menos dez menos um");

            double result = exp.Resolve();

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void MinusTest4()
        {
            Expression exp = new Expression("um ponto um menos um");

            double result = exp.Resolve();

            Assert.AreEqual(0.1, result);
        }

        [TestMethod]
        public void MinusTest5()
        {
            Expression exp = new Expression("dois ponto um menos um ponto um");

            double result = exp.Resolve();

            Assert.AreEqual(1, result);
        }
        #endregion

        #region Multiplication
        [TestMethod]
        public void MulTest1()
        {
            Expression exp = new Expression("um vezes um");

            double result = exp.Resolve();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MulTest2()
        {
            Expression exp = new Expression("um vezes zero");

            double result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MulTest3()
        {
            Expression exp = new Expression("um vezes trinta");

            double result = exp.Resolve();

            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void MulTest4()
        {
            Expression exp = new Expression("três vezes trinta");

            double result = exp.Resolve();

            Assert.AreEqual(90, result);
        }

        [TestMethod]
        public void MulTest5()
        {
            Expression exp = new Expression("zero vezes zero");

            double result = exp.Resolve();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MulTest6()
        {
            Expression exp = new Expression("dois vezes um ponto um");

            double result = exp.Resolve();

            Assert.AreEqual(2.2, result);
        }

        [TestMethod]
        public void MulTest7()
        {
            Expression exp = new Expression("um ponto um vezes um ponto um");

            double result = exp.Resolve();

            Assert.AreEqual(1.21, result);
        }
        #endregion

        #region Division
        [TestMethod]
        public void DivTest1()
        {
            Expression exp = new Expression("dois a dividir por um");

            double result = exp.Resolve();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void DivTest2()
        {
            Expression exp = new Expression("vinte a dividir por cinco");

            double result = exp.Resolve();

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void DivTest3()
        {
            Expression exp = new Expression("vinte a dividir por zero");

            double result = exp.Resolve();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void DivTest4()
        {
            Expression exp = new Expression("um a dividir por dois");

            double result = exp.Resolve();

            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void DivTest5()
        {
            Expression exp = new Expression("um a dividir por zero");

            double result = exp.Resolve();

            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void DivTest6()
        {
            Expression exp = new Expression("zero ponto cinco a dividir por zero ponto cinco");

            double result = exp.Resolve();

            Assert.AreEqual(1, result);
        }
        #endregion

        #region And
        [TestMethod]
        public void AndTest1()
        {
            Expression exp = new Expression("vinte e cinco");

            double result = exp.Resolve();

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void AndTest2()
        {
            Expression exp = new Expression("vinte e cinco ponto dois");

            double result = exp.Resolve();

            Assert.AreEqual(25.2, result);
        }

        [TestMethod]
        public void AndTest3()
        {
            Expression exp = new Expression("vinte e cinco ponto vinte e cinco");

            double result = exp.Resolve();

            Assert.AreEqual(25.25, result);
        }
        #endregion

        #region Negative
        [TestMethod]
        public void NegTest1()
        {
            Expression exp = new Expression("menos dois");

            double result = exp.Resolve();

            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void NegTest2()
        {
            Expression exp = new Expression("dois menos menos dois");

            double result = exp.Resolve();

            Assert.AreEqual(4, result);
        }
        #endregion

        #region Various Operations
        #endregion
    }
}
