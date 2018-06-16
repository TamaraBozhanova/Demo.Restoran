using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public double a;
        public double b;
        public char c;

        private void button4_Click(object sender, EventArgs e)
        {if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "5";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "8";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") textBox1.Clear();
            textBox1.Text += "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                c = '+';
                textBox1.Clear();
            }
            catch (Exception)
            {

            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                c = '-';
                textBox1.Clear();
            }
            catch(Exception)
            {

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                c = '*';
                textBox1.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                c = '/';
                textBox1.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                b = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
                switch (c)
                {
                    case '+':
                        textBox1.Text = Convert.ToString(a + b);
                        break;
                    case '-':
                        textBox1.Text = Convert.ToString(a - b);
                        break;
                    case '*':
                        textBox1.Text = Convert.ToString(a * b);
                        break;
                    case '/':
                        textBox1.Text = Convert.ToString(a / b);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            a = 0;
            b = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[0] == '-')
            {
                textBox1.Text = textBox1.Text.Remove(0, 1);
            }
            else
            {
                textBox1.Text = '-' + textBox1.Text;
            }            
        }
    }
}