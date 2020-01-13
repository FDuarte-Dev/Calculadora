using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Lib
{
    public class Calculadora
    {
        public string Resolve(string text) 
        {
            Expression expression = TextToExpression(text);

            expression.Resolve();

            return ExpressionToText(expression);
        }

        public static Expression TextToExpression(string text)
        {
            return new Expression(text);
        }


        public static string ExpressionToText(Expression expression)
        {
            return expression.Value.ToString();
        }
    }
}
