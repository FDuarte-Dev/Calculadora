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

        public override double Resolve()
        {
            double left = LeftValue.Resolve();
            double right = RightValue.Resolve();

            if (right == 0)
            {
                Value = double.NaN;
            }
            else
            {
                Value = left / right;
            }

            return Value;
        }
    }
}
