using System;
using System.Collections.Generic;
using System.Text;
using Calculadora.Lib;

namespace Calculadora.Lib.Operations
{
    class Negativo : Expression
    {
        Literal Exp;

        public Negativo(string leftExpression)
            : base("-" + leftExpression)
        {
            Exp = new Literal(leftExpression);
        }

        public override string ToString()
        {
            return "-" + Exp.ToString();
        }

        public override decimal Resolve()
        {
            decimal exp = Exp.Resolve();

            Value = decimal.Negate(exp);

            return Value;
        }
    }
}
