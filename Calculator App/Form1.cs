using System;
using System.Windows.Forms;

namespace Calculator_App
{
    public partial class Form1 : Form
    {
        string currentInput = "";
        double result = 0;
        string operation = "";
        bool operationPending = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Evaluate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            currentInput = "";
            result = 0;
            operation = "";
            operationPending = false;
            textBox1.Text = "0";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SetOperation("+");
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            SetOperation("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            SetOperation("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            SetOperation("/");
        }

        private void button0_Click(object sender, EventArgs e) { AppendNumber("0"); }
        private void button1_Click(object sender, EventArgs e) { AppendNumber("1"); }
        private void button2_Click(object sender, EventArgs e) { AppendNumber("2"); }
        private void button3_Click(object sender, EventArgs e) { AppendNumber("3"); }
        private void button4_Click(object sender, EventArgs e) { AppendNumber("4"); }
        private void button5_Click(object sender, EventArgs e) { AppendNumber("5"); }
        private void button6_Click(object sender, EventArgs e) { AppendNumber("6"); }
        private void button7_Click(object sender, EventArgs e) { AppendNumber("7"); }
        private void button8_Click(object sender, EventArgs e) { AppendNumber("8"); }
        private void button9_Click(object sender, EventArgs e) { AppendNumber("9"); }

        private void AppendNumber(string digit)
        {
            currentInput += digit;
            textBox1.Text = currentInput;
        }

        private void SetOperation(string op)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                if (operationPending)
                {
                    Evaluate();
                }
                else
                {
                    result = double.Parse(currentInput);
                }
            }

            operation = op;
            currentInput = "";
            operationPending = true;
        }

        private void Evaluate()
        {
            if (operationPending && !string.IsNullOrEmpty(currentInput))
            {
                double secondNumber = double.Parse(currentInput);

                switch (operation)
                {
                    case "+": result += secondNumber; break;
                    case "-": result -= secondNumber; break;
                    case "*": result *= secondNumber; break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result /= secondNumber;
                        }
                        else
                        {
                            textBox1.Text = "Error";
                            currentInput = "";
                            operationPending = false;
                            return;
                        }
                        break;
                }

                textBox1.Text = result.ToString();
                currentInput = "";
                operationPending = false;
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double number = double.Parse(currentInput);
                number = number / 100; 
                currentInput = number.ToString();
                textBox1.Text = currentInput;
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                textBox1.Text = currentInput.Length > 0 ? currentInput : "0";
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!currentInput.Contains(".")) 
            {
                if (string.IsNullOrEmpty(currentInput))
                    currentInput = "0."; 
                else
                    currentInput += ".";

                textBox1.Text = currentInput;
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double number = double.Parse(currentInput);
                if (number >= 0)
                {
                    number = Math.Sqrt(number);
                    currentInput = number.ToString();
                    textBox1.Text = currentInput;
                }
                else
                {
                    textBox1.Text = "Error"; 
                    currentInput = "";
                }
            }
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double number = double.Parse(currentInput);
                number = Math.Pow(number, 2);
                currentInput = number.ToString();
                textBox1.Text = currentInput;
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                if (currentInput.StartsWith("-"))
                    currentInput = currentInput.Substring(1);
                else
                    currentInput = "-" + currentInput;

                textBox1.Text = currentInput;
            }
        }
    }
}
