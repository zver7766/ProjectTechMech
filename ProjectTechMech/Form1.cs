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

            if (Up > 1)
            { UpGOST = 1.12; }
            else if (Up > 1.12)
            { UpGOST = 1.25; }
            else if (Up > 1.25)
            { UpGOST = 1.4; }
            else if (Up > 1.4)
            { UpGOST = 1.6; }
            else if (Up > 1.6)
            { UpGOST = 1.8; }
            else if (Up > 1.8)
            { UpGOST = 2.0; }
            else if (Up > 2.0)
            { UpGOST = 2.24; }
            else if (Up > 2.24)
            { UpGOST = 2.5; }
            else if (Up > 2.5)
            { UpGOST = 2.8; }
            else if (Up > 2.8)
            { UpGOST = 3.15; }
            else if (Up > 3.15)
            { UpGOST = 3.55; }
            else if (Up > 3.55)
            { UpGOST = 4.00; }
            else if (Up > 4.00)
            { UpGOST = 4.5; }
            else if (Up > 4.5)
            { UpGOST = 5.0; }
            else if (Up > 5.0)
            { UpGOST = 5.6; }
            else if (Up > 5.6)
            { UpGOST = 6.3; }
            else if (Up > 6.3)
            { UpGOST = 7.1; }
            else if (Up > 7.1)
            { UpGOST = 8.0; }
            else if (Up > 8.0)
            { UpGOST = 9.0; }
            else if (Up > 9.0)
            { UpGOST = 10.0; }
            else if (Up > 10.0)
            { UpGOST = 11.2; }
            else if (Up > 11.2)
            { UpGOST = 12.5; }



            double Upp = Uzag / UpGOST;

            textBox3.Text = Upp.ToString();

            double n1 = nF;
            double n2 = n1 / Upp;
            double n3 = n2 / UpGOST;

            //похибка ага

            double w1 = (Math.PI * n1) / 30;
            double w2 = (Math.PI * n2) / 30;
            double w3 = (Math.PI * n3) / 30;

            double T1 = (Ppotr * 1000) / w1;
            double T2 = (Ppotr * 0.95 * 0.99 * 1000) / w2;
            double T3 = (Pv * 1000) / w3;
        }
    }
}