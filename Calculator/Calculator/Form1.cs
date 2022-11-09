using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public string BoxForAction; // Хранение действия
        public string BoxForAction2 = "%"; // Хранение действия 2
        public string BoxForNumberOne;  //Хранение 1-го числа
        public string BoxForNumberTwo;  // Хранение 2-го числа
        public bool Stop;  // Очистка всего для ввода 2-го числа
        public Form1()
        {
            InitializeComponent();

        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            if (Stop)  // Очистка всего для ввода 2-го числа
            {
                Stop = false;
                richTextBoxMain.Text = "";
            }
            Button button = (Button)sender; // Текст который находится на кнопке(sender)
            richTextBoxMain.Text += button.Text;    // Передача данных в richTextBox
            BoxForNumberTwo = richTextBoxMain.Text;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button button = (Button)(sender);
            BoxForAction = button.Text; // Данные о действии 
            BoxForNumberOne = richTextBoxMain.Text; // Данные о первом числе
            Stop = true;   // Очистка всего для ввода 2-го числа


        }
        private void btnEqually_Click(object sender, EventArgs e)
        {
            double One = Convert.ToDouble(BoxForNumberOne);
            double Two = Convert.ToDouble(BoxForNumberTwo);
            double result = 0;

            //Типо кейсы
            if (BoxForAction == "+")
            {
                result = One + Two;
            }
            else if (BoxForAction == "-")
            {
                result = One - Two;
            }
            else if (BoxForAction == "/")
            {
                result = One / Two;
            }
            else if (BoxForAction == "*")
            {
                result = One * Two;
            }
            
            richTextBoxMain.Text = result.ToString(); // Вывод результата

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Text = "";  // Очистка всех действий
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Text += ",";    // Добавление десятичного разделителя(,)
        }
        private void btnClearOne_Click(object sender, EventArgs e)
        {
            //Удаление последнего введенного символа
            richTextBoxMain.Text = richTextBoxMain.Text.Remove(richTextBoxMain.Text.Length - 1); 
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            double One = Convert.ToDouble(BoxForNumberOne);
            double Two = Convert.ToDouble(BoxForNumberTwo);
            double result = 0;
            if (BoxForAction2 == "%") // Костыль для процента 
            {
                // Типо кейсы
                if (BoxForAction == "+")
                {
                    result = One + (Two * One) / 100;
                }
                else if (BoxForAction == "-")
                {
                    result = One - (Two * One) / 100;
                }
                else if (BoxForAction == "/")
                {
                    result = One / (Two / 100);
                }
                else if (BoxForAction == "*")
                {
                    result = One * (Two / 100);
                }
            }
            richTextBoxMain.Text = result.ToString(); // Вывод результата
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            double One = Convert.ToDouble(richTextBoxMain.Text);
            double result = 0;

            result = Math.Sqrt(One);
            richTextBoxMain.Text = result.ToString(); // Вывод результата
        }
    }

}
