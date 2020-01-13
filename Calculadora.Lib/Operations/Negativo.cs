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

        public override Literal Resolve()
        {
            NegLiteral(Exp);

            return Exp;
        }

        private void NegLiteral(Literal val)
        {
            Exp.NumericValue = val.NumericValue * -1;
        }
    }
}
