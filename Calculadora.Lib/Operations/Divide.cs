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
            : base(leftExpression + "+" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        internal override Literal Resolve()
        {
            Literal left = LeftValue.Resolve();
            Literal right = RightValue.Resolve();

            Value = DivideLiterals(left, right);

            return Value;
        }

        private Literal DivideLiterals(Literal left, Literal right)
        {
            throw new NotImplementedException();
        }
    }
}
