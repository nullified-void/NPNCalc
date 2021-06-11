using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NPNcalc
{
    public class NPNCalc
    {
        public double Resolve(string expression)
        {
            int operators = 0;
            int operands = 0;
            Stack<double> stack = new Stack<double>();
            while (expression.Contains("  "))
            {
                expression = expression.Replace("  ", " ");
            }
            if (!Regex.IsMatch(expression, @"^[0-9+-/* ]+$"))
            {
                throw new Exception("incorrect symbols in expression");
            }
            string[] split = expression.Split(' ');
            foreach (string str in split)
            {
                if (Regex.IsMatch(str, @"^[0-9]+$"))
                {
                    operands++;
                }
                else
                {
                    operators++;
                }
            }

            if (operands != operators + 1)
            {
                throw new Exception("incorrect expression");
            }
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                string number = string.Empty;
                if (char.IsDigit(expression[i]))
                {
                    while (expression[i] != ' ')
                    {
                        number += expression[i];
                        i--;
                        if (i == -1)
                        {
                            break;
                        }
                    }
                    stack.Push(int.Parse(new string(number.Reverse().ToArray())));

                }
                if (IsOperator(expression[i]))
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    stack.Push(Calculate(a, b, expression[i]));
                }
            }
            return stack.Peek();

        }

        private double Calculate(double a, double b, char op)
        {
            if (IsOperator(op))
            {
                switch (op)
                {
                    case '+':
                        return a + b;
                    case '-':
                        return a - b;
                    case '*':
                        return a * b;
                    case '/':
                        return a / b;
                }
            }
            else
            {
                throw new Exception("incorrect operator: " + op);
            }
            return 0;
        }
        private bool IsOperator(char с)
        {
            if (("+-/*".IndexOf(с) != -1))
                return true;
            return false;
        }
    }
}
