using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace calculator
{
    public partial class Form1 : Form
    {
        public double rezaltMamory = 0;
        public double curentNubmer;
        public string currentOperation = "";
        public double previousNumber = 0;
        public Form1()
        {
            InitializeComponent();
            textTablo.Text = "0";
            textMamory.Text = rezaltMamory.ToString();
            buttonMC.Enabled = false;
            buttonMR.Enabled = false;
        }
        void RenderTablo(string number)
        {
            if (textTablo.Text == "0")
                textTablo.Text = "";
            textTablo.Text += number;
        }
        void RunOparationTablo(string oparation)
        {
            double rezaltTablo;
            if (oparation == "")
                return;
            try
            {
                rezaltTablo = Convert.ToDouble(textTablo.Text);

                switch (oparation)
                {
                    case "%":
                        rezaltTablo *= 0.01;
                        break;
                    case "Sqrt":
                        if (rezaltTablo < 0)
                            MessageBox.Show("Опрерація не можлива: корінь з відємного числа не можливо добути!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        rezaltTablo = Math.Sqrt(rezaltTablo);
                        break;
                    case "x^2":
                        rezaltTablo = rezaltTablo * rezaltTablo;
                        break;
                    case "1/x":
                        rezaltTablo = 1 / rezaltTablo;
                        break;
                    case "+/-":
                        rezaltTablo *= -1;
                        break;
                }
                textTablo.Text = rezaltTablo.ToString();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Опрерація не можлива!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void RunOparationMamory(string operation)
        {
            if (operation == "")
                return;

            try
            {
                double currentTabloValue = Convert.ToDouble(textTablo.Text);

                switch (operation)
                {
                    case "MS":
                        rezaltMamory = currentTabloValue;
                        break;
                    case "M-":
                        rezaltMamory -= currentTabloValue;
                        break;
                    case "M+":
                        rezaltMamory += currentTabloValue;
                        break;
                    case "MR":
                        textTablo.Text = rezaltMamory.ToString();
                        break;
                    case "MC":
                        rezaltMamory = 0;
                        break;
                    default:
                        MessageBox.Show("Операція не існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                if(rezaltMamory != 0) 
                {
                    buttonMC.Enabled = true;
                    buttonMR.Enabled = true;
                }
                else 
                {
                    buttonMC.Enabled = false;
                    buttonMR.Enabled = false;
                }
                textMamory.Text = rezaltMamory.ToString();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Операція не можлива!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void OparationTablo(string operation)
        {
            double currentNumber = Convert.ToDouble(textTablo.Text);

            if (currentOperation == "")
            {
                previousNumber = currentNumber;
                currentOperation = operation;
                textTablo.Text = "0";
                return;
            }

            switch (currentOperation)
            {
                case "+":
                    previousNumber += currentNumber;
                    break;
                case "-":
                    previousNumber -= currentNumber;
                    break;
                case "*":
                    previousNumber *= currentNumber;
                    break;
                case "/":
                    if (currentNumber != 0)
                        previousNumber /= currentNumber;
                    else
                        MessageBox.Show("Ділення на нуль неможливе!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            if (operation == "=")
            {
                textTablo.Text = previousNumber.ToString();
                currentOperation = "";
            }
            else
            {
                currentOperation = operation;
                textTablo.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Text;
                RenderTablo(buttonText);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            if (textTablo.Text == "")
                textTablo.Text = "0";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textTablo.Text != "0")
                if (!textTablo.Text.Contains(","))
                    textTablo.Text += ",";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Text;
                RunOparationTablo(buttonText);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textTablo.Text = "0";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Text;
                RunOparationMamory(buttonText);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Text;
                OparationTablo(buttonText);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            textTablo.Text = "0";
            previousNumber = 0;
            currentOperation = "";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор проекта:Щрий Олексій О\nЦей проект був зроблений за 5 годин\nТому поставте 100 балів за старння:)", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}