using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBoxUtils textBoxUtils;


        public MainWindow()
        {
            InitializeComponent();

            textBoxUtils = new TextBoxUtils(CalculationBox);
        }

        //Digit Event-Handler
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("0");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("1");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("3");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("4");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("5");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("6");
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("7");
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("8");
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("9");
        }

        //Special Buttons Event-Handler
        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText(".");
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.WriteResult();
        }

        //Operators Event-Handler
        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("+");
        }

        private void SubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("-");
        }

        private void MultiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("*");
        }

        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.AddText("/");
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.RemoveCharacter();
        }

        private void ClearAllButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUtils.ClearAll();
        }
    }
}
