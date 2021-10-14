using System;
using System.Collections.Generic;
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
        private double FerstOperand;
        //private readonly double SecondOperand;
        //private readonly double Result;
        //private readonly string SignOperation;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickNumber(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Content) 
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (textBlock.Text == "0")
                        textBlock.Text = button.Content.ToString();
                    else
                        textBlock.Text += button.Content;
                    break;
                case "0":
                    if (textBlock.Text == "0")
                        break;
                    else
                        textBlock.Text += button.Content;
                    break;

            }
        }
        private void ButtonClickSign(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClickOperation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            FerstOperand = Convert.ToDouble(textBlock.Text);
            
            switch (button.Content) 
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "√x":
                case "X^2":
                case "%":
                    textBlockRes.Text += $" {textBlock.Text} {button.Content}";
                    textBlock.Text = "0";
                    break;

            }
        }
        private void ButtonClickEqls(object sender, RoutedEventArgs e)
        {


        }
        private void ButtonClickPoint(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonClickCE(object sender, RoutedEventArgs e) 
        {
            textBlock.Text = "0";
        }
        private void ButtonClickC(object sender, RoutedEventArgs e) 
        {
            textBlock.Text = "0";
            textBlockRes.Text = "";
        }
        private void ButtonClickOpenBracket(object sender, RoutedEventArgs e) { }
        private void ButtonClickCloseBracket(object sender, RoutedEventArgs e) { }
    }
}
