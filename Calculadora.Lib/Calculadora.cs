namespace Calculadora.Lib
{
    public class Calculadora
    {
        public static string Init(string text) 
        {
            if (string.IsNullOrEmpty(text))
                return text;

            Expression expression = TextToExpression(text.ToLowerInvariant());

            expression.Resolve();

            return ExpressionToText(expression);
        }

        public static Expression TextToExpression(string text)
        {
            return new Expression(text);
        }


        public static string ExpressionToText(Expression expression)
        {
            return expression.ToString() + " = " + expression.Value.ToString();
        }
    }
}
