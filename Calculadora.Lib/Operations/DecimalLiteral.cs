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
            : base(leftExpression + "vírgula" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        public override string ToString()
        {
            return LeftValue.ToString() + "," + RightValue.ToString();
        }

        public override decimal Resolve()
        {
            decimal left = LeftValue.Resolve();
            decimal right = RightValue.Resolve();

            Value = Createdecimal((int)left, (int)right);

            return Value;
        }

        private decimal Createdecimal(int leftValue, int rightValue)
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

