using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {
        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }

    [WebMethod]
    public string EvaluarExpresion(string expresion)
    {
        try
        {
            double resultado = EvaluarInfijo(expresion);
            return resultado.ToString();
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    private double EvaluarInfijo(string expresion)
    {
        var posfija = ConvertirInfijaAPostfija(expresion);
        return EvaluarPostfija(posfija);
    }

    private string ConvertirInfijaAPostfija(string expresion)
    {
        Stack<string> pilaOperadores = new Stack<string>();
        StringBuilder salida = new StringBuilder();

        for (int i = 0; i < expresion.Length; i++)
        {
            char c = expresion[i];

            if (char.IsDigit(c))
            {
                while (i < expresion.Length && char.IsDigit(expresion[i]))
                {
                    salida.Append(expresion[i]);
                    i++;
                }
                salida.Append(' '); 
                i--; 
            }
            else if (c == '(')
            {
                pilaOperadores.Push(c.ToString());
            }
            else if (c == ')')
            {
                while (pilaOperadores.Count > 0 && pilaOperadores.Peek() != "(")
                {
                    salida.Append(pilaOperadores.Pop());
                    salida.Append(' '); 
                }
                if (pilaOperadores.Count > 0)
                {
                    pilaOperadores.Pop(); 
                }
            }
            else if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                while (pilaOperadores.Count > 0 && Precedencia(pilaOperadores.Peek()) >= Precedencia(c.ToString()))
                {
                    salida.Append(pilaOperadores.Pop());
                    salida.Append(' ');
                }
                pilaOperadores.Push(c.ToString());
            }
        }

 
        while (pilaOperadores.Count > 0)
        {
            salida.Append(pilaOperadores.Pop());
            salida.Append(' '); 
        }

        return salida.ToString().Trim(); 
    }


    private double EvaluarPostfija(string expresionPostfija)
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


    private int Precedencia(string operador)
    {
        if (operador == "+" || operador == "-")
            return 1;
        if (operador == "*" || operador == "/")
            return 2;
        return 0;
    }
}
