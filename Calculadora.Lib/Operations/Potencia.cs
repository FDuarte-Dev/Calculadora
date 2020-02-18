using System;

namespace Calculadora.Lib.Operations
{
    class Potencia : Expression
    {
        Expression LeftValue;
        Expression RightValue;

        public Potencia(string leftExpression, string rightExpression)
            : base(leftExpression + "^" + rightExpression)
        {
            LeftValue = new Expression(leftExpression);
            RightValue = new Expression(rightExpression);
        }

        public override string ToString()
        {
            return LeftValue.ToString() + "^" + RightValue.ToString();
        }

        public override decimal Resolve()
        {
            decimal left = LeftValue.Resolve();
            decimal right = RightValue.Resolve();

            Value = Convert.ToDecimal(Math.Pow((double)left, (double)right));

            return Value;
        }
    }
}