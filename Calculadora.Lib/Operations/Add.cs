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

        public override string ToString()
        {
            return LeftValue.ToString() + "+" + RightValue.ToString();
        }

        public override decimal Resolve() 
        {
            decimal left = LeftValue.Resolve();
            decimal right = RightValue.Resolve();

            Value = decimal.Add(left, right);
            
            return Value;
        }

    }
}
