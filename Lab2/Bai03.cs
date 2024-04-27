using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB2
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        string url = "";

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTinh_Click(object sender, EventArgs e)
        {
            string inputFilePath = url;

            string outputFilePath = "C:\\Users\\USER\\Desktop\\22520300-LeVietDuong\\Lab2\\output3.txt";

            using (StreamReader sr = new StreamReader(inputFilePath))
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                while (true)
                {
                    string expression = sr.ReadLine();
                    if (expression == null)
                    {
                        break;
                    }
                    double result = TinhToan.Evaluate(expression);
                    textBoxKQ.Text += expression + " = " + result.ToString() + Environment.NewLine;

                }
                sw.WriteLine(textBoxKQ.Text);
            }
        }
        private void buttonDoc_Click(object sender, EventArgs e)
        {
            string inputFilePath = "C:\\Users\\USER\\Desktop\\22520300-LeVietDuong\\Lab2\\input3.txt";
            textBoxDoc.Text = File.ReadAllText(inputFilePath);
            url = inputFilePath;
        }

        public class TinhToan
        {
            public static double Evaluate(string expression)
            {
                expression = expression.Replace(" ", "");
                return EvaluateExpression(expression);
            }
            private static double EvaluateExpression(string expression)
            {
                Stack<double> numbers = new Stack<double>();
                Stack<char> operations = new Stack<char>();
                for (int i = 0; i < expression.Length; i++)
                {
                    char c = expression[i];
                    if (c == ' ')
                        continue;

                    if (char.IsDigit(c) || c == '.')
                    {
                        string numStr = c.ToString();
                        while (i + 1 < expression.Length && (char.IsDigit(expression[i + 1]) || expression[i + 1] == '.'))
                        {
                            numStr += expression[i + 1];
                            i++;
                        }
                        double num = double.Parse(numStr, CultureInfo.InvariantCulture);
                        numbers.Push(num);
                    }
                    else if (c == '(')
                    {
                        operations.Push(c);
                    }
                    else if (c == ')')
                    {
                        while (operations.Peek() != '(')
                        {
                            EvaluateOperation(numbers, operations);
                        }
                        operations.Pop(); 
                    }
                    else
                    {
                        while (operations.Count > 0 && GetPrecedence(operations.Peek()) >= GetPrecedence(c))
                        {
                            EvaluateOperation(numbers, operations);
                        }
                        operations.Push(c);
                    }
                }

                while (operations.Count > 0)
                {
                    EvaluateOperation(numbers, operations);
                }

                return numbers.Pop();
            }

            private static void EvaluateOperation(Stack<double> numbers, Stack<char> operations)
            {
                char op = operations.Pop();
                double num2 = numbers.Pop();
                double num1 = numbers.Pop();
                double result = 0;

                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = num1 / num2;
                        break;
                }

                numbers.Push(result);
            }

            private static int GetPrecedence(char op)
            {
                if (op == '+' || op == '-')
                    return 1;
                if (op == '*' || op == '/')
                    return 2;
                return 0;
            }
        }

    

        private void Bai03_Load(object sender, EventArgs e)
        {

        }
    }
}
