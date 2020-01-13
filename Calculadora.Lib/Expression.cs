using Calculadora.Lib.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculadora.Lib
{
    public class Expression
    {
        public string Text;
        public Literal Value { get; internal set; }

        public Expression(string text)
        {
            this.Text = text;
            this.Value = new Literal("zero");
        }


        public virtual Literal Resolve()
        {
            Expression operation = null;

            Regex reg;
            Match match;

            //TODOFD - somewhere in here you have to work the negatives
            //TODOFD - Also the percentages

            #region Soma
            reg = new Regex(@"(.+)(mais)(.+)");
            match = reg.Match(Text);
            if (match.Success) 
            {
                operation = new Add(match.Groups[1].Value, match.Groups[3].Value);
            }
            #endregion

            #region Subtracção
            reg = new Regex(@"(.+?)(menos)(.+)");
            match = reg.Match(Text);
            if (match.Success)
            {
                operation = new Subtract(match.Groups[1].Value, match.Groups[3].Value);
            }
            #endregion

            #region Divisão
            reg = new Regex(@"(.+)(a dividir por)(.+)");
            match = reg.Match(Text);
            if (match.Success)
            {
                operation = new Divide(match.Groups[1].Value, match.Groups[3].Value);
            }
            #endregion

            #region Multiplicação
            reg = new Regex(@"(.+)(vezes)(.+)");
            match = reg.Match(Text);
            if (match.Success)
            {
                operation = new Multiply(match.Groups[1].Value, match.Groups[3].Value);
            }
            #endregion

            #region Negativo
            reg = new Regex(@"(.*)(menos)(.+)");
            match = reg.Match(Text);
            if (match.Success)
            {
                operation = new Negativo(match.Groups[3].Value);
            }
            #endregion

            #region e
            //In portuguese the word 'e' is used to form numbers, works as an addition
            reg = new Regex(@"(.+)(e)(.+)");
            match = reg.Match(Text);
            if (match.Success)
            {
                operation = new Add(match.Groups[1].Value, match.Groups[3].Value);
            }
            #endregion

            Value = operation.Resolve();

            return Value;
        }
    }
}
