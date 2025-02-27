using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;
using System.Diagnostics;

namespace Calculator
{
    public class TextBoxUtils
    {
        private TextBox CalculationBox {  get; set; }

        public TextBoxUtils(TextBox texbox)
        {
            CalculationBox = texbox;
        }

        public void AddText(string inputText)
        {
            CalculationBox.Text = CalculationBox.Text + inputText;
        }

        public void RemoveCharacter()
        {
            //Removes the last character
            if(CalculationBox.Text != "")
            {
                CalculationBox.Text = CalculationBox.Text.Remove(CalculationBox.Text.Length - 1);
            }
        }

        public void ClearAll()
        {
            CalculationBox.Clear();
        }

        public void WriteResult()
        {
            CalculationBox.Text = Convert.ToString(Calculation.Calculate(CalculationBox.Text), CultureInfo.InvariantCulture);
        }
    }
}
