using Calculadora.Lib.Operations;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculadora.Lib
{
    public class Expression
    {
        private static Dictionary<Regex, Operations> regices;
        private Dictionary<Regex, Operations> Regices 
        {
            get
            {
                if(regices == null) 
                {
                    regices = new Dictionary<Regex, Operations>()
                    {
                        { new Regex(@"(.+)( mais )(.+)"), Operations.Add },
                        { new Regex(@"(.+?)( menos )(.+)"), Operations.Minus },
                        { new Regex(@"(.+)( menos )(.+)"), Operations.MinusNeg },
                        { new Regex(@"(.+)( a dividir por )(.+)"), Operations.Divide },
                        { new Regex(@"(.+)( vezes )(.+)"), Operations.Multiply },
                        { new Regex(@"(.+)( por cento de )(.+)"), Operations.Percent },
                        { new Regex(@"(.+)( elevado a )(.+)"), Operations.Power },
                        { new Regex(@"(raiz quadrada de )(.+)"), Operations.Root },
                        { new Regex(@"(.*?)(menos )(.+)"), Operations.Negative },
                        { new Regex(@"(.+)( ponto | vírgula )(.+)"), Operations.Decimal },
                        { new Regex(@"(.+)( e )(.+)"), Operations.And },
                        { new Regex(@"(.+)"), Operations.Literal }
                    };
                }

                return regices;
            }
        }

        private enum Operations 
        {
            Expression      = 0,
            Add             = 1,
            Minus           = 2,
            MinusNeg        = 3,
            Divide          = 4,
            Multiply        = 5,
            Percent         = 6,
            Power           = 7,
            Root            = 8,
            Negative        = 9,
            Decimal         = 10, 
            And             = 11,
            Literal         = 12
        }

        private Expression operation;
        public string Text;
        public decimal Value { get; internal set; }

        public Expression(string text)
        {
            this.Text = text;
        }

        public override string ToString()
        {
            return operation.ToString();
        }

        public virtual decimal Resolve()
        {
            Match match;

            foreach(Regex reg in Regices.Keys) 
            {
                if((Regices[reg] == Operations.Minus) 
                    &&
                    !(Text.Contains("menos menos") ||
                      Text.Contains("mais menos") ||
                      Text.Contains("a dividir por menos") ||
                      Text.Contains("vezes menos")))
                {
                    continue;
                }

                match = reg.Match(Text);
                if (match.Success)
                {
                    if ((Regices[reg] == Operations.Minus || 
                         Regices[reg] == Operations.MinusNeg) 
                         &&
                        (match.Groups[1].Value.EndsWith("mais") ||
                         match.Groups[1].Value.EndsWith("a dividir por") ||
                         match.Groups[1].Value.EndsWith("vezes")))
                    { 
                            continue;
                    }

                    operation = ResolveOperation(Regices[reg], match.Groups);
                    break;
                }
            }

            Value = operation.Resolve();

            return Value;
        }

        private Expression ResolveOperation(Operations operation, GroupCollection groups)
        {
            switch (operation)
            {
                case Operations.Add:
                case Operations.And:
                    return new Add(groups[1].Value, groups[3].Value);
                case Operations.Minus:
                case Operations.MinusNeg:
                    return new Subtract(groups[1].Value, groups[3].Value);
                case Operations.Divide:
                    return new Divide(groups[1].Value, groups[3].Value);
                case Operations.Multiply:
                    return new Multiply(groups[1].Value, groups[3].Value);
                case Operations.Percent:
                    return new Percent(groups[1].Value, groups[3].Value);
                case Operations.Power:
                    return new Potencia(groups[1].Value, groups[3].Value);
                case Operations.Root:
                    return new Raiz(groups[2].Value);
                case Operations.Negative:
                    return new Negativo(groups[3].Value);
                case Operations.Decimal:
                    return new DecimalLiteral(groups[1].Value, groups[3].Value);
                case Operations.Literal:
                    return new Literal(groups[1].Value);
                default:
                    return new Expression(groups[0].Value);

            }
        }
    }
}
