using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Globalization;

namespace Calculator
{
    public static class Calculation
    {
        public static double Calculate(string inputTerm)
        {
            double result = 0;

            var addends = SubTermsMultiplication(SubTermsExtractor(inputTerm));

            for(int i = 0; i < addends.Count; i++)
            {
                result += Convert.ToDouble(addends[i], CultureInfo.InvariantCulture);
            }

            return result;
        }

        public static List<string> SubTermsMultiplication(List<string> subterms)
        {
            string subTerm = "";

            for (int i = 0; i < subterms.Count; i++)
            {
                subTerm = subterms[i];

                // Checks if an element of subterms is already prepared for the addition process in the Calculate() method.
                bool isReady = double.TryParse(subTerm, out _);
                if (isReady)
                    continue;

                subterms[i] = Convert.ToString(CalculateMultiplicationAndDivisionFromString(subTerm), CultureInfo.InvariantCulture);
            }

            return subterms;
        }

        public static double CalculateMultiplicationAndDivisionFromString(string term)
        {
            double termResult = 0;
            bool isMultiplicativeOperator = false;
            string termFactor = "";
            char mathOperator = ' ';

            for (int i = 0; i < term.Length; i++)
            {
                isMultiplicativeOperator = (term[i] == '/' || term[i] == '*');
                if (isMultiplicativeOperator)
                {
                    if (termResult == 0)
                    {
                        termResult = Convert.ToDouble(termFactor, CultureInfo.InvariantCulture);
                        termFactor = "";
                    }
                    else
                    {
                        termResult = HandleMultiplicativeOperations(termResult, mathOperator, Convert.ToDouble(termFactor, CultureInfo.InvariantCulture));

                        termFactor = "";
                    }
                    mathOperator = term[i];
                }
                else
                {
                    termFactor += term[i];
                }
            }
            termResult = HandleMultiplicativeOperations(termResult, mathOperator, Convert.ToDouble(termFactor, CultureInfo.InvariantCulture));

            return termResult;
        }

        public static double HandleMultiplicativeOperations(double result, char mathOperator, double termFactor)
        {
            if (mathOperator == '/')
            {
                result /= termFactor;
            }
            if (mathOperator == '*')
            {
                result *= termFactor;
            }

            return result;
        }

        public static List<string> SubTermsExtractor(string inputText)
        {
            var subterms = new List<string>();

            string part = "";

            // Adds terms to the list while keeping multiplication and division grouped together.
            // This ensures that multiplication and division are processed with higher priority before addition and subtraction.
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsDigit(inputText[i]))
                {
                    part += inputText[i];
                }
                else
                {
                    switch (inputText[i])
                    {
                        case '.':
                            part += ".";
                            break;

                        case '+':
                        case '-':
                            bool isNewTerm = inputText[i - 1] != '*' && inputText[i - 1] != '/';

                            // This if-statement ensures that numbers with explicit positive or negative signs  
                            // are correctly treated as divisors and factors.
                            if (isNewTerm)
                            {
                                subterms.Add(part);
                                part = inputText[i].ToString();
                            }
                            else
                            {
                                part += inputText[i];
                            }
                            break;

                        case '*':
                            part += "*";
                            break;

                        case '/':
                            part += '/';
                            break;

                        default:
                            continue;

                    }
                }
            }
            subterms.Add(part);
            return subterms;
        }
    }
}
