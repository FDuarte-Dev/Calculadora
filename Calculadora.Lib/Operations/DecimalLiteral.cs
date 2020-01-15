using System;
using System.Collections.Generic;
using System.Text;
using Calculadora.Lib;

namespace Calculadora.Lib.Operations
{
    class DecimalLiteral : Expression
    {
        Expression LeftValue;
        Expression RightValue;

        public DecimalLiteral(string leftExpression, string rightExpression)
            : base(leftExpression + "ponto" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        public override double Resolve()
        {
            double left = LeftValue.Resolve();
            double right = RightValue.Resolve();

            Value = Createdouble((int)left, (int)right);

            return Value;
        }

        private double Createdouble(int leftValue, int rightValue)
        {
            int dummy;
            while (rightValue > 0)
            {
                dummy = rightValue;

                if (rightValue >= 10)
                {
                    Math.DivRem(rightValue, 10, out dummy);
                }

                Value += dummy;
                Value /= 10;
                rightValue /= 10;
            }
            Value += leftValue;

            return Value;
        }
    }
}

