using Calculadora.Lib.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculadora.Lib
{
    public class Expression
    {
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
            Regex reg;
            Match match;

            //TODOFD - UGLY 

            reg = new Regex(@"(.+)( mais )(.+)");
            match = reg.Match(Text);
            if (match.Success)
            {
                operation = new Add(match.Groups[1].Value, match.Groups[3].Value);
            }
            else 
            {
                reg = Text.Contains("menos menos") ||
                      Text.Contains("mais menos") ||
                      Text.Contains("a dividir por menos") ||
                      Text.Contains("vezes menos") ?
                    new Regex(@"(.+?)( menos )(.+)") :
                    new Regex(@"(.+)( menos )(.+)");
                match = reg.Match(Text);
                if (match.Success &&
                    !match.Groups[1].Value.EndsWith("mais") &&
                    !match.Groups[1].Value.EndsWith("a dividir por") &&
                    !match.Groups[1].Value.EndsWith("vezes"))
                {
                    operation = new Subtract(match.Groups[1].Value, match.Groups[3].Value);
                }
                else 
                {
                    reg = new Regex(@"(.+)( a dividir por )(.+)");
                    match = reg.Match(Text);
                    if (match.Success)
                    {
                        operation = new Divide(match.Groups[1].Value, match.Groups[3].Value);
                    }
                    else 
                    {
                        reg = new Regex(@"(.+)( vezes )(.+)");
                        match = reg.Match(Text);
                        if (match.Success)
                        {
                            operation = new Multiply(match.Groups[1].Value, match.Groups[3].Value);
                        }
                        else 
                        {
                            reg = new Regex(@"(.+)( por cento de )(.+)");
                            match = reg.Match(Text);
                            if (match.Success)
                            {
                                operation = new Percent(match.Groups[1].Value, match.Groups[3].Value);
                            }
                            else
                            {
                                reg = new Regex(@"(.+)( elevado a )(.+)");
                                match = reg.Match(Text);
                                if (match.Success) 
                                {
                                    operation = new Potencia(match.Groups[1].Value, match.Groups[3].Value);
                                }
                                else
                                {
                                    reg = new Regex(@"(raiz quadrada de )(.+)");
                                    match = reg.Match(Text);
                                    if (match.Success)
                                    {
                                        operation = new Raiz(match.Groups[2].Value);
                                    }
                                    else
                                    {
                                        reg = new Regex(@"(.*?)(menos )(.+)");
                                        match = reg.Match(Text);
                                        if (match.Success)
                                        {
                                            operation = new Negativo(match.Groups[3].Value);
                                        }
                                        else
                                        {
                                            reg = new Regex(@"(.+)( ponto | vírgula )(.+)");
                                            match = reg.Match(Text);
                                            if (match.Success)
                                            {
                                                operation = new DecimalLiteral(match.Groups[1].Value, match.Groups[3].Value);
                                            }
                                            else
                                            {
                                                //In portuguese the word 'e' is used to form numbers, works as an addition
                                                reg = new Regex(@"(.+)( e )(.+)");
                                                match = reg.Match(Text);
                                                if (match.Success)
                                                {
                                                    operation = new Add(match.Groups[1].Value, match.Groups[3].Value);
                                                }
                                                else
                                                {
                                                    reg = new Regex(@"(.+)");
                                                    match = reg.Match(Text);
                                                    if (match.Success)
                                                    {
                                                        operation = new Literal(match.Groups[1].Value);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Value = operation.Resolve();

            return Value;
        }
    }
}
