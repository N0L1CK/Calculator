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
        
        private double firstOperand;
        private double secondOperand;
        private string sighn;
        private bool mathRes;
        private bool havePoint;
    
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
                    if (textBlock.Text == "0" || mathRes)
                    {
                        textBlock.Text = button.Content.ToString();
                        mathRes = false;
                    }
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
            if (textBlock.Text != "0" ) 
            {
                if (Convert.ToDouble(textBlock.Text) > 0)
                {
                    textSign.Text = "-";
                    
                }
                else
                {
                    textSign.Text = "";

                }
            }
        }

        private void ButtonClickOperation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (textSign.Text == "-")
            {
                firstOperand = Convert.ToDouble(textBlock.Text) * -1;
            }
            else
                firstOperand = Convert.ToDouble(textBlock.Text);



            mathRes = true;
            havePoint = false;
            textBlock.Text = "0";
            textSign.Text = "";
            switch (button.Content) 
            {
                case "+":
                case "-":
                case "*":
                case "/":    
                case "%":
                    sighn = button.Content.ToString();
                    break;

            }
        }
        private void ButtonClickEqls(object sender, RoutedEventArgs e)
        {
            textSign.Text = "";
            if (textSign.Text == "-")
            {
                secondOperand = Convert.ToDouble(textBlock.Text) * -1;
            }
            else
                secondOperand = Convert.ToDouble(textBlock.Text);
            mathRes = true;
            
            switch (sighn)
            {
                case "+": 
                    textBlock.Text = SignRelise(firstOperand + secondOperand);
                    break;
                case "-":
                    textBlock.Text = SignRelise(firstOperand - secondOperand);
                    break;
                case "*":
                    textBlock.Text = SignRelise(firstOperand * secondOperand);
                    break;
                case "/":
                    if (firstOperand != 0 && secondOperand != 0)
                    {
                        textBlock.Text = SignRelise(firstOperand * secondOperand);
                        break;
                    }
                    else
                        textBlock.Text = "0";
                    break;
                case "%":
                    break;
            }
            firstOperand = 0;
            secondOperand = 0;

        }
        private void ButtonClickPoint(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (textBlock.Text == "0")
            {
                textBlock.Text += button.Content.ToString();
                havePoint = true;
            }
            else if (!havePoint) 
            {
                textBlock.Text += button.Content.ToString();
                havePoint = true;
            }
        }
        private void ButtonClickC(object sender, RoutedEventArgs e) 
        {
            textBlock.Text = "0";
            textSign.Text = "";
            havePoint = false;

        }
        private void ButtonClickMath(object sender, RoutedEventArgs e)
        {
            havePoint = false;
            mathRes = true;
            Button button = (Button)sender;
            if (button.Content.ToString() == "X^2")
            {
                firstOperand = Convert.ToDouble(textBlock.Text);
                textBlock.Text = Convert.ToString(Math.Pow(firstOperand, 2));
            }
            if (button.Content.ToString() == "√x") 
            {
                firstOperand = Convert.ToDouble(textBlock.Text);
                textBlock.Text = Convert.ToString(Math.Sqrt(firstOperand));
            }
        }
        private string SignRelise(double digit) 
        {
            if (digit < 0)
            {
                textSign.Text = "-";
                return (digit * -1).ToString();
            }
            else
                return digit.ToString();
        }
    }
}
