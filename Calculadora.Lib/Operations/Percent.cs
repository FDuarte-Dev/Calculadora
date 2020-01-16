using System;
using System.Collections.Generic;
using System.Text;
using Calculadora.Lib;

namespace Calculadora.Lib.Operations
{
    class Percent : Expression
    {
        Expression LeftValue;
        Expression RightValue;

        public Percent(string leftExpression, string rightExpression)
            : base(leftExpression + "%" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        public override double Resolve()
        {
            double left = LeftValue.Resolve();
            double right = RightValue.Resolve();

            Value = left / 100 *  right;

            return Value;
        }
    }
}