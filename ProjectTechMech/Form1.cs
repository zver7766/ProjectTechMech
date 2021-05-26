using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTechMech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Pv = double.Parse(textBox_P.Text);
            double nv = double.Parse(textBox_n.Text);

            textBox3.Text = Pv.ToString();
            textBox3.Text = nv.ToString();


            double nZag = 0.903;
            double Ppotr = Pv / nZag;

            double nF = 950;


            double Uzag = nF / nv;
            double Up = Uzag / 3;

            double UpGOST = 1.0;

            //Таблиця 1.3.1. Номінальні передаточні числа.
            if (Up > 1 && Up <= 1.12)
            { UpGOST = 1.12; }
            else if (Up > 1.12 && Up <= 1.25)
            { UpGOST = 1.25; }
            else if (Up > 1.25 && Up <= 1.4)
            { UpGOST = 1.4; }
            else if (Up > 1.4 && Up <= 1.6)
            { UpGOST = 1.6; }
            else if (Up > 1.6 && Up <= 1.8)
            { UpGOST = 1.8; }
            else if (Up > 1.8 && Up <= 2.0)
            { UpGOST = 2.0; }
            else if (Up > 2.0 && Up <= 2.24)
            { UpGOST = 2.24; }
            else if (Up > 2.24 && Up <= 2.5)
            { UpGOST = 2.5; }
            else if (Up > 2.5 && Up <= 2.8)
            { UpGOST = 2.8; }
            else if (Up > 2.8 && Up <= 3.15)
            { UpGOST = 3.15; }
            else if (Up > 3.15 && Up <= 3.55)
            { UpGOST = 3.55; }
            else if (Up > 3.55 && Up <= 4.0)
            { UpGOST = 4.00; }
            else if (Up > 4.00 && Up <= 4.5)
            { UpGOST = 4.5; }
            else if (Up > 4.5 && Up <= 5.0)
            { UpGOST = 5.0; }
            else if (Up > 5.0 && Up <= 5.6)
            { UpGOST = 5.6; }
            else if (Up > 5.6 && Up <= 6.3)
            { UpGOST = 6.3; }
            else if (Up > 6.3 && Up <= 7.1)
            { UpGOST = 7.1; }
            else if (Up > 7.1 && Up <= 8.0)
            { UpGOST = 8.0; }
            else if (Up > 8.0 && Up <= 9.0)
            { UpGOST = 9.0; }
            else if (Up > 9.0 && Up <= 10.0)
            { UpGOST = 10.0; }
            else if (Up > 10.0 && Up <= 11.2)
            { UpGOST = 11.2; }
            else if (Up > 11.2 && Up <= 12.5)
            { UpGOST = 12.5; }

            double Upp = Uzag / UpGOST;

            //два

            double n1 = nF;
            double n2 = n1 / Upp;
            double n3 = n2 / UpGOST;

            //Рахуємо похибки розрахунків:
            double Epsilon = (n3 - nv) / nv * 100;
            if (Epsilon < 5)
            {
                Epsilon = (n3 - nv) / nv * 100;
            }
            else
            {
                Epsilon = 1;
            }

            double w1 = (Math.PI * n1) / 30;
            double w2 = (Math.PI * n2) / 30;
            double w3 = (Math.PI * n3) / 30;

            double T1 = (Ppotr * 1000) / w1;
            double T2 = (Ppotr * 0.95 * 0.99 * 1000) / w2;
            double T3 = (Pv * 1000) / w3;

            //Вивід данних 
            /*
            НУЖНА ПОМОЩЬ Я ЗАБУВ ЯК ВИВОДИТИ ТЕКСТ
            */
            richTextBox1.Text = ("1.Загальний розрахунок приводу.");


        }
    }
}