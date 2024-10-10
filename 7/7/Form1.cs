using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void num1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void num2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void num3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void num4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void num5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void num6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void num7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void num8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void num9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void num0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void parentesis_abrir_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void parentesis_cerrar_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }


        private void borrar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void suma_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void resta_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void multiplicacion_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void division_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void igual_Click(object sender, EventArgs e)
        {
 
            calcu_lib calculadora = new calcu_lib();

            string expresion = textBox1.Text;
            string expresionPostfija = calculadora.ConvertirInfijaAPostfija(expresion);

            double resultado = calculadora.EvaluarPostfija(expresionPostfija);
            textBox1.Text = resultado.ToString();
        }
    }
}
