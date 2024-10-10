using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class calcu_lib
    {
        private Stack<string> operadores = new Stack<string>();
        private Stack<double> operandos = new Stack<double>();

        public string ConvertirInfijaAPostfija(string expresion)
        {
            Stack<string> pilaOperadores = new Stack<string>();
            StringBuilder salida = new StringBuilder();

            for (int i = 0; i < expresion.Length; i++)
            {
                char c = expresion[i];

                if (char.IsDigit(c))
                {
                    salida.Append(c);
                }

                else if (c == '(')
                {
                    pilaOperadores.Push(c.ToString());
                }

                else if (c == ')')
                {
                    while (pilaOperadores.Peek() != "(")
                    {
                        salida.Append(pilaOperadores.Pop());
                    }
                    pilaOperadores.Pop();
                }

                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    while (pilaOperadores.Count > 0 && Precedencia(pilaOperadores.Peek()) >= Precedencia(c.ToString()))
                    {
                        salida.Append(pilaOperadores.Pop());
                    }
                    pilaOperadores.Push(c.ToString());
                }
            }


            while (pilaOperadores.Count > 0)
            {
                salida.Append(pilaOperadores.Pop());
            }

            return salida.ToString();
        }

        private int Precedencia(string operador)
        {
            if (operador == "+" || operador == "-")
                return 1;
            if (operador == "*" || operador == "/")
                return 2;
            return 0;
        }

        public double EvaluarPostfija(string expresionPostfija)
        {
            Stack<double> pilaOperandos = new Stack<double>();

            for (int i = 0; i < expresionPostfija.Length; i++)
            {
                char c = expresionPostfija[i];

                if (char.IsDigit(c))
                {
                    pilaOperandos.Push(double.Parse(c.ToString()));
                }

                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    double b = pilaOperandos.Pop();
                    double a = pilaOperandos.Pop();
                    switch (c)
                    {
                        case '+': pilaOperandos.Push(a + b); break;
                        case '-': pilaOperandos.Push(a - b); break;
                        case '*': pilaOperandos.Push(a * b); break;
                        case '/': pilaOperandos.Push(a / b); break;
                    }
                }
            }

            return pilaOperandos.Pop();
        }
    }
}