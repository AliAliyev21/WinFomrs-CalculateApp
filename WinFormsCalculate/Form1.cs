using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Tapışırıq 2
//Sadə kalkulyator düzəldin
//Operatorlar: +, -, *, /.
//Rəqəmlər üçün buttonlar , nəticə üçün label işlədin

namespace WinFormsCalculate
{
    public partial class Form1 : Form
    {
        private decimal currentNumber = 0;
        private decimal result = 0;
        private string currentOperator = "";

        public Form1()
        {
            InitializeComponent();

            resulttxtb.Text = "0";

            ButtonsNum();

            ButtonsOperator();

            btnclear.Click += btnclear_Click_1;
        }


        private void ButtonsNum()
        {
            foreach (var button in new[] { btnzero, btnone, btntwo, btnthree, btnfour, btnfive, btnsix, btnseven, btneigh, btnnine })
            {
                button.Click += NumberButtonClick;
            }
        }

        private void ButtonsOperator()
        {
            foreach (var button in new[] { btnsum, btnsubt, btnmult, btndiv })
            {
                button.Click += OperatorButtonClick;
            }
        }

        private void NumberButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            
            if (resulttxtb.Text == "0")
            {
                resulttxtb.Text = button.Text;
            }
            else
            {
                resulttxtb.Text += button.Text;
            }
        }

        private void OperatorButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resulttxtb.Text))
            {
                currentNumber = decimal.Parse(resulttxtb.Text);
                currentOperator = ((Button)sender).Text;
                resulttxtb.Text = "";
            }
        }

        private void btnequal_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resulttxtb.Text))
            {
                decimal secondNumber = decimal.Parse(resulttxtb.Text);

                switch (currentOperator)
                {
                    case "+":
                        result = currentNumber + secondNumber;
                        break;
                    case "-":
                        result = currentNumber - secondNumber;
                        break;
                    case "*":
                        result = currentNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Division by zero is not allowed");
                            resulttxtb.Text = "";
                            return;
                        }
                        result = currentNumber / secondNumber;
                        break;
                }

                resulttxtb.Text = result.ToString();
            }
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            resulttxtb.Text = "0";
            currentNumber = 0;
            result = 0;
            currentOperator = "";
        }

        private void pointbtn_Click_1(object sender, EventArgs e)
        {
            if (!resulttxtb.Text.Contains("."))
            {
                resulttxtb.Text += ".";
            }

        }

        private void btnfix_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resulttxtb.Text) && resulttxtb.Text.Length > 1)
            {
                resulttxtb.Text = resulttxtb.Text.Substring(0, resulttxtb.Text.Length - 1);
            }
            else if (!string.IsNullOrEmpty(resulttxtb.Text))
            {
                resulttxtb.Text = "0";
            }
        }

        private void btnpercentage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resulttxtb.Text))
            {
                decimal number = decimal.Parse(resulttxtb.Text);
                decimal percentage = number / 100;
                resulttxtb.Text = percentage.ToString();
            }
        }
        
        private void btnsquareroot_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resulttxtb.Text))
            {
                double number = double.Parse(resulttxtb.Text);
                double cubeRoot = Math.Pow(number, 1.0 / 3.0);
                resulttxtb.Text = cubeRoot.ToString();
            }
        }

        private void btncube_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resulttxtb.Text))
            {
                double number = double.Parse(resulttxtb.Text);
                double cube = Math.Pow(number, 3);
                resulttxtb.Text = cube.ToString();
            }
        }
      
        private void btnsquare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resulttxtb.Text))
            {
                double number = double.Parse(resulttxtb.Text);
                double square = Math.Pow(number, 2);
                resulttxtb.Text = square.ToString();
            }
        }
    }
}
