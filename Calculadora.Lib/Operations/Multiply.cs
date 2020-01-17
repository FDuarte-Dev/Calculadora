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

        public override string ToString()
        {
            return LeftValue.ToString() + "x" + RightValue.ToString();
        }

        public override decimal Resolve()
        {
            decimal left = LeftValue.Resolve();
            decimal right = RightValue.Resolve();

            Value = decimal.Multiply(left, right);

            return Value;
        }
    }
}
