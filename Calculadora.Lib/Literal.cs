using System;
using System.Text.RegularExpressions;

namespace Calculadora.Lib
{
    public class Literal : Expression
    {
        public float NumericValue;

        public Literal(string text)
            : base(text)
        {
        }

        public override string ToString()
        {
            return NumericValue.ToString();
        }

        #region Private Methods
        private void KeywordMatch(MatchCollection matches)
        {
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "zero":
                        NumericValue = 0;
                        break;
                    case "um":
                        NumericValue = 1;
                        break;
                    case "dois":
                        NumericValue = 2;
                        break;
                    case "três":
                        NumericValue = 3;
                        break;
                    case "quatro":
                        NumericValue = 4;
                        break;
                    case "cinco":
                        NumericValue = 5;
                        break;
                    case "seis":
                        NumericValue = 6;
                        break;
                    case "sete":
                        NumericValue = 7;
                        break;
                    case "oito":
                        NumericValue = 8;
                        break;
                    case "nove":
                        NumericValue = 9;
                        break;
                    case "dez":
                        NumericValue = 10;
                        break;
                    case "onze":
                        NumericValue = 11;
                        break;
                    case "doze":
                        NumericValue = 12;
                        break;
                    case "treze":
                        NumericValue = 13;
                        break;
                    case "catorze":
                        NumericValue = 14;
                        break;
                    case "quinze":
                        NumericValue = 15;
                        break;
                    case "dezasseis":
                        NumericValue = 16;
                        break;
                    case "dezassete":
                        NumericValue = 17;
                        break;
                    case "dezoito":
                        NumericValue = 18;
                        break;
                    case "dezanove":
                        NumericValue = 19;
                        break;
                    case "vinte":
                        NumericValue = 20;
                        break;
                    case "trinta":
                        NumericValue = 30;
                        break;
                    case "quarenta":
                        NumericValue = 40;
                        break;
                    case "cinquenta":
                        NumericValue = 50;
                        break;
                    case "sessenta":
                        NumericValue = 60;
                        break;
                    case "setenta":
                        NumericValue = 70;
                        break;
                    case "oitenta":
                        NumericValue = 80;
                        break;
                    case "noventa":
                        NumericValue = 90;
                        break;
                    case "cem":
                    case "cento":
                        NumericValue = 100;
                        break;
                    case "duzentos":
                        NumericValue = 200;
                        break;
                    case "trezentos":
                        NumericValue = 300;
                        break;
                    case "quatrocentos":
                        NumericValue = 400;
                        break;
                    case "quinhentos":
                        NumericValue = 500;
                        break;
                    case "seiscentos":
                        NumericValue = 600;
                        break;
                    case "setecentos":
                        NumericValue = 700;
                        break;
                    case "oitocentos":
                        NumericValue = 800;
                        break;
                    case "novencentos":
                        NumericValue = 900;
                        break;
                    case "mil":
                        NumericValue = (int)NumericValue == 0 ? 10 ^ 3 : (int)NumericValue * (10 ^ 3);
                        break;
                    case "milhão":
                        NumericValue = 10 ^ 6;
                        break;
                    case "milhões":
                        NumericValue = (int)NumericValue == 0 ? 10 ^ 6 : (int)NumericValue * (10 ^ 6);
                        break;
                    case "bilião":
                        NumericValue = 10 ^ 12;
                        break;
                    case "bilões":
                        NumericValue = (int)NumericValue == 0 ? 10 ^ 12 : (int)NumericValue * (10 ^ 12);
                        break;
                    case "trilião":
                        NumericValue = 10 ^ 24;
                        break;
                    case "triliões":
                        NumericValue = (int)NumericValue == 0 ? 10 ^ 24 : (int)NumericValue * (10 ^ 24);
                        break;
                    case "quadrilião":
                        NumericValue = 10 ^ 48;
                        break;
                    case "quadriliões":
                        NumericValue = (int)NumericValue == 0 ? 10 ^ 48 : (int)NumericValue * (10 ^ 48);
                        break;
                    default:
                        throw new NotSupportedException("Keyword not recognised");
                }
            }
        }

        private void ComputeInt()
        {
            NumericValue = 0;

            Regex reg = new Regex(@"(\w+)");
            MatchCollection matches = reg.Matches(Text);

            KeywordMatch(matches);
        }

        private void ComputeFloat(string[] text)
        {
            NumericValue = 0;

            int leftValue = 0;
            int rightValue = 0;
            
            Regex reg = new Regex(@"(\w+)");
            
            MatchCollection matches = reg.Matches(text[1]);
            KeywordMatch(matches);
            rightValue = (int)NumericValue;
            NumericValue = 0;

            matches = reg.Matches(text[0]);
            KeywordMatch(matches);
            leftValue = (int)NumericValue;

            NumericValue = CreateFloat(leftValue, rightValue);

        }

        private float CreateFloat(int leftValue, int rightValue)
        {
            int dummy = rightValue;
            while(rightValue > 0) 
            {
                dummy = rightValue % 10;
                Value.NumericValue = Value.NumericValue + dummy;
                Value.NumericValue = Value.NumericValue / 10;
                rightValue = rightValue / 10;
            }
            Value.NumericValue = Value.NumericValue + leftValue;

            return Value.NumericValue;
        }
        #endregion

        #region Public Methods
        public override Literal Resolve() 
        {
            ComputeValue();
            return this;
        }

        public void ComputeValue() 
        {
            if (Text.Contains("ponto") ||
                Text.Contains("vírgula"))
            {
                ComputeFloat(Text.Split(new string[] { "ponto", "vírgula"}, 
                                         StringSplitOptions.RemoveEmptyEntries ));
            }
            else
            {
                NumericValue = 0;
                ComputeInt();
            }
        }
        #endregion
    }
}