using System;
using System.Collections.Generic;
using System.Text;
using Calculadora.Lib;

namespace Calculadora.Lib.Operations
{
    class Multiply : Expression
    {
        Expression LeftValue;
        Expression RightValue;

        public Multiply(string leftExpression, string rightExpression)
            : base(leftExpression + "x" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        public override double Resolve()
        {
            double left = LeftValue.Resolve();
            double right = RightValue.Resolve();

            Value = left * right;

            return Value;
        }
    }
}
