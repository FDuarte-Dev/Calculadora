using System;

namespace Calculadora.Lib.Operations
{
    class Raiz : Expression
    {
        Expression Exp;

        public Raiz(string expression)
            : base("v" + expression)
        {
            Exp = new Expression(expression);
        }

        public override string ToString()
        {
            return "v" + Exp.ToString();
        }

        public override decimal Resolve()
        {
            decimal expression = Exp.Resolve();

            Value = Convert.ToDecimal(Math.Sqrt((double)expression));

            return Value;
        }
    }
}