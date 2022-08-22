using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        double sum = 0;
        double substraction = 0;
        double multiplication = 0;
        double division = 0;
        bool NegativNumber = false;
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement element in MainGrid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
        }

        private void CaLculate(string text, char operand)
        {
            dynamic leftSide = 0;
            dynamic rightSide = 0;
            var result = text.Split(operand);
            leftSide = double.Parse(result[0]);
            rightSide = double.Parse(result[1]);
            if (operand == '+')
            {
                sum = leftSide + rightSide;
                TextLabel.Text = sum.ToString();

            }
            else if (operand == '-')
            {
                substraction = rightSide - leftSide;

            }
            else if (operand == '*')
            {
                multiplication = rightSide * leftSide;
                TextLabel.Text = multiplication.ToString();

            }
            else if (operand == '/')
            {
                try
                {
                    division = rightSide / leftSide;
                    TextLabel.Text = (division.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string numberOrOperand = (string)((Button)e.OriginalSource).Content;

            if (numberOrOperand == "C")
            {
                TextLabel.Text = string.Empty;
            }
            else if (numberOrOperand == "=")
            {
                //string value = new DataTable().Compute(TextLabel.Text, null).ToString();
                //TextLabel.Text = value;
                foreach (var item in TextLabel.Text)
                {
                    if (item == '+')
                    {
                        CaLculate(TextLabel.Text, item);
                        break;
                    }
                    else if (item == '-')
                    {
                        if (TextLabel.Text[0] == '-')
                            continue;
                        CaLculate(TextLabel.Text, item);
                        break;
                    }
                    else if (item == '*')
                    {
                        CaLculate(TextLabel.Text, item);
                        break;
                    }
                    else if (item == '/')
                    {
                        CaLculate(TextLabel.Text.ToString(), item);
                        break;
                    }
                }
            }
            else if (numberOrOperand == "⇦")
            {
                if (TextLabel.Text.Length == 0)
                {
                    TextLabel.Text = String.Empty;
                }
                else
                {
                    TextLabel.Text = TextLabel.Text.Remove(TextLabel.Text.Length - 1);
                }
            }
            else if (numberOrOperand == "±")
            {
                var number = double.Parse(TextLabel.Text);
                if (NegativNumber == false)
                {
                    TextLabel.Text = String.Empty;
                    TextLabel.Text = "-";
                    TextLabel.Text += number.ToString();
                    NegativNumber = true;
                }
                else
                {
                    number *= -1;
                    TextLabel.Text = String.Empty;
                    TextLabel.Text = number.ToString();
                    NegativNumber = false;
                }
            }
            else if (TextLabel.Text.Length < 20)
                Operation(numberOrOperand);
        }

        private void Operation(string operand)
        {
            string[] operands = { "%", "+", "-", "*", "/", "√", "," };
            if (TextLabel.Text.Length != 0 && (operand == "%" || operand == "+" || operand == "-" ||
              operand == "*" || operand == "/" || operand == "√" || operand == ","))
            {
                string lastCharOfTextLabel = TextLabel.Text[TextLabel.Text.Length - 1].ToString();
                int sum = 0;
                foreach (var item in operands)
                {
                    if (item == lastCharOfTextLabel)
                        sum += 1;
                }
                if (sum != 1)
                    TextLabel.Text += operand;
            }
            else
                TextLabel.Text += operand;
        }
    }
}
