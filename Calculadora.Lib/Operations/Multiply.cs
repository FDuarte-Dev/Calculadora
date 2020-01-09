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
            : base(leftExpression + "+" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        internal override Literal Resolve()
        {
            Literal left = LeftValue.Resolve();
            Literal right = RightValue.Resolve();

            Value = MultiplyLiterals(left, right);

            return Value;
        }

        private Literal MultiplyLiterals(Literal left, Literal right)
        {
            throw new NotImplementedException();
        }
    }
}
