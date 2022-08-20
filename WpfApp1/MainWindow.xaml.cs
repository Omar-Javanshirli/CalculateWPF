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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string numberOrOperand = (string)((Button)e.OriginalSource).Content;

            if (numberOrOperand == "C")
            {
                TextLabel.Text = string.Empty;
            }
            else if (numberOrOperand == "=")
            {
                string value = new DataTable().Compute(TextLabel.Text, null).ToString();
                TextLabel.Text = value;
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
