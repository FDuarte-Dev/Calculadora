using System;
using System.Text.RegularExpressions;

namespace Calculadora.Lib
{
    public class Literal : Expression
    {
        public Literal(string text)
            : base(text)
        {
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        #region Private Methods
        private void KeywordMatch(MatchCollection matches)
        {
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "zero":
                        Value = 0;
                        break;
                    case "um":
                        Value = 1;
                        break;
                    case "dois":
                        Value = 2;
                        break;
                    case "três":
                        Value = 3;
                        break;
                    case "quatro":
                        Value = 4;
                        break;
                    case "cinco":
                        Value = 5;
                        break;
                    case "seis":
                        Value = 6;
                        break;
                    case "sete":
                        Value = 7;
                        break;
                    case "oito":
                        Value = 8;
                        break;
                    case "nove":
                        Value = 9;
                        break;
                    case "dez":
                        Value = 10;
                        break;
                    case "onze":
                        Value = 11;
                        break;
                    case "doze":
                        Value = 12;
                        break;
                    case "treze":
                        Value = 13;
                        break;
                    case "catorze":
                        Value = 14;
                        break;
                    case "quinze":
                        Value = 15;
                        break;
                    case "dezasseis":
                        Value = 16;
                        break;
                    case "dezassete":
                        Value = 17;
                        break;
                    case "dezoito":
                        Value = 18;
                        break;
                    case "dezanove":
                        Value = 19;
                        break;
                    case "vinte":
                        Value = 20;
                        break;
                    case "trinta":
                        Value = 30;
                        break;
                    case "quarenta":
                        Value = 40;
                        break;
                    case "cinquenta":
                        Value = 50;
                        break;
                    case "sessenta":
                        Value = 60;
                        break;
                    case "setenta":
                        Value = 70;
                        break;
                    case "oitenta":
                        Value = 80;
                        break;
                    case "noventa":
                        Value = 90;
                        break;
                    case "cem":
                    case "cento":
                        Value = 100;
                        break;
                    case "duzentos":
                        Value = 200;
                        break;
                    case "trezentos":
                        Value = 300;
                        break;
                    case "quatrocentos":
                        Value = 400;
                        break;
                    case "quinhentos":
                        Value = 500;
                        break;
                    case "seiscentos":
                        Value = 600;
                        break;
                    case "setecentos":
                        Value = 700;
                        break;
                    case "oitocentos":
                        Value = 800;
                        break;
                    case "novencentos":
                        Value = 900;
                        break;
                    case "mil":
                        Value = (int)Value == 0 ? 1000 : (int)Value * 1000;
                        break;
                    case "milhão":
                        Value = 10 ^ 6;
                        break;
                    case "milhões":
                        Value = (int)Value == 0 ? 1000000 : (int)Value * 1000000;
                        break;
                    case "bilião":
                        Value = 10 ^ 12;
                        break;
                    case "bilões":
                        Value = (int)Value == 0 ? 1000000000000 : (int)Value * 1000000000000;
                        break;
                    default:
                        throw new NotSupportedException("Keyword not recognised: " + match.Value);
                }
            }
        }

        private void ComputeInt()
        {
            Value = 0;

            Regex reg = new Regex(@"(\w+)");
            MatchCollection matches = reg.Matches(Text);

            KeywordMatch(matches);
        }

        private void Computedecimal(string[] text)
        {
            Value = 0;

            int leftValue = 0;
            int rightValue = 0;
            
            Regex reg = new Regex(@"(\w+)");
            
            MatchCollection matches = reg.Matches(text[1]);
            KeywordMatch(matches);
            rightValue = (int)Value;
            Value = 0;

            matches = reg.Matches(text[0]);
            KeywordMatch(matches);
            leftValue = (int)Value;
            Value = 0;

            Value = Createdecimal(leftValue, rightValue);

        }

        private decimal Createdecimal(int leftValue, int rightValue)
        {
            int dummy;
            while(rightValue > 0) 
            {
                dummy = rightValue;

                if (rightValue >= 10) 
                {
                    Math.DivRem(rightValue, 10, out dummy);
                }

                Value += dummy;
                Value /= 10;
                rightValue /= 10;
            }
            Value += leftValue;

            return Value;
        }
        #endregion

        #region Public Methods
        public override decimal Resolve() 
        {
            ComputeValue();
            return Value;
        }

        public void ComputeValue() 
        {
            if (Text.Contains("ponto") ||
                Text.Contains("vírgula"))
            {
                Computedecimal(Text.Split(new string[] { "ponto", "vírgula"}, 
                                         StringSplitOptions.RemoveEmptyEntries ));
            }
            else
            {
                Value = 0;
                ComputeInt();
            }
        }
        #endregion
    }
}