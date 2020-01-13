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

        public override Literal Resolve()
        {
            Literal left = LeftValue.Resolve();
            Literal right = RightValue.Resolve();

            MultiplyLiterals(left, right);

            return Value;
        }

        private void MultiplyLiterals(Literal left, Literal right)
        {
            Value.NumericValue = left.NumericValue * right.NumericValue;
        }
    }
}
