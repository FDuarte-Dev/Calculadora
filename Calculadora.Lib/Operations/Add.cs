using System;
using System.Collections.Generic;
using System.Text;
using Calculadora.Lib;

namespace Calculadora.Lib.Operations
{
    class Add : Expression
    {
        Expression LeftValue;
        Expression RightValue;

        public Add(string leftExpression, string rightExpression)
            : base(leftExpression + "+" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        public override Literal Resolve() 
        {
            Literal left = LeftValue.Resolve();
            Literal right = RightValue.Resolve();

            AddLiterals(left.Value, right.Value);
            
            return Value;
        }

        private void AddLiterals(Literal left, Literal right)
        {
            Value.NumericValue = left.NumericValue + right.NumericValue;
        }
    }
}
