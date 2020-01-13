using System;
using System.Collections.Generic;
using System.Text;
using Calculadora.Lib;

namespace Calculadora.Lib.Operations
{
    class Divide : Expression
    {
        Expression LeftValue;
        Expression RightValue;

        public Divide(string leftExpression, string rightExpression)
            : base(leftExpression + ":" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        public override Literal Resolve()
        {
            Literal left = LeftValue.Resolve();
            Literal right = RightValue.Resolve();

            DivideLiterals(left, right);

            return Value;
        }

        private void DivideLiterals(Literal left, Literal right)
        {
            Value.NumericValue = left.NumericValue / right.NumericValue;
        }
    }
}
