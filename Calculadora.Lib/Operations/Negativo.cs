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

        public override double Resolve()
        {
            double exp = Exp.Resolve();

            Value = exp * -1;

            return Value;
        }
    }
}
