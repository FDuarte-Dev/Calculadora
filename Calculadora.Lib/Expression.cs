using Calculadora.Lib.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculadora.Lib
{
    class Expression
    {
        public string Text;
        public Literal Value { get; internal set; }

        public Expression(string text)
        {
            this.Text = text;
            this.Value = new Literal("zero");
        }


        internal virtual Literal Resolve()
        {
            Expression operation = null;

            Regex reg;
            Match match;

            #region Soma
            reg = new Regex(@"(.+)(mais)(.+)");
            match = reg.Match(Text);
            if (match.Success) 
            {
                operation = new Add(match.Groups[1].Value, match.Groups[3].Value);
            }
            #endregion

            #region Subtracção
            //TODOFD - wont work on cases like: dois menos menos dois
            reg = new Regex(@"(.+)(menos)(.+)");
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

            Value = operation.Resolve();

            return Value;
        }
    }
}
