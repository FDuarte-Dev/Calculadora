namespace Calculadora.Lib
{
    internal class Literal : Expression
    {
        public Literal(string text)
            : base(text)
        {
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}