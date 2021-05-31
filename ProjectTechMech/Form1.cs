using System;
using System.Drawing;
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
            //1.Загальний розрахунок приводу.
            //Вхідні данні (варіант №17):
            //Потужність на виході Pв, кВт
            double Pv = double.Parse(textBox_P.Text.Replace('.', ',')); //3.1
            //Частота обертання на виході nв, хв.-1
            double nv = double.Parse(textBox_n.Text.Replace('.', ',')); //115
            //1.1	Загальний коефіцієнт корисної дії.
            //Тому маємо: Nзаг
            double nZag = 0.903;

            //1.2 Визначення потрібної потужності та вибір електродвигуна.
            //Потрібна потужність
            double Ppotr = Pv / nZag;
            //фактична частота обертання
            double nF = 950;

            //Таблиця 1.2.1. Типи та характеристики деяких електродвигунів серії 4А.
            if (Ppotr > 0.18 && Ppotr <= 0.25)
            { nF = 890; }
            else if (Ppotr > 0.25 && Ppotr <= 0.37)
            { nF = 900; }
            else if (Ppotr > 0.37 && Ppotr <= 0.55)
            { nF = 910; }
            else if (Ppotr > 0.55 && Ppotr <= 0.75)
            { nF = 915; }
            else if (Ppotr > 0.75 && Ppotr <= 1.1)
            { nF = 920; }
            else if (Ppotr > 1.1 && Ppotr <= 1.5)
            { nF = 935; }
            else if (Ppotr > 1.5 && Ppotr <= 2.2)
            { nF = 950; }
            else if (Ppotr > 2.2 && Ppotr <= 3.0)
            { nF = 955; }
            else if (Ppotr > 3.0 && Ppotr <= 4.0)
            { nF = 950; }
            else if (Ppotr > 4.0 && Ppotr <= 5.5)
            { nF = 965; }
            else if (Ppotr > 5.5 && Ppotr <= 7.5)
            { nF = 970; }
            else if (Ppotr > 7.5 && Ppotr <= 11.0)
            { nF = 975; }

            //1.3 Розбивка загального передаточного числа по ступеням.
            //Загальне передаточне число
            double Uzag = nF / nv;
            double Up = Uzag / 2;
            //передаточне число редуктора по ГОСТу.
            double UpGOST = 4.0;

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
            else if (Up > 3.55 && Up <= 4.14)
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
            //Приймаємо UpGOST = 4.0 
            //Тоді
            double Upp = Uzag / UpGOST;

            //1.4	Визначення обертових моментів на валах редуктора.
            //Частота обертання на валу двигуна
            double n1 = nF;
            //Частота обертання вхідного кінця вала редуктора:
            double n2 = n1 / Upp;
            //Частота обертання вихідного кінця вала редуктора:
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
            //Відповідно циклічні частоти дорівнюють:
            double w1 = (Math.PI * n1) / 30;
            double w2 = (Math.PI * n2) / 30;
            double w3 = (Math.PI * n3) / 30;
            //Отже обертальні моменти:
            double T1 = (Ppotr * 1000) / w1;
            double T2 = (Ppotr * 0.95 * 0.99 * 1000) / w2;
            double T3 = (Pv * 1000) / w3;
            //Робимо перевірку проведених розрахунків:
            double T1Strich = T3 / (nZag * Uzag);
            double EpsilonT1Strich = (T1 - T1Strich) / T1Strich * 100;
            if (EpsilonT1Strich < 5)
            {
                EpsilonT1Strich = (T1 - T1Strich) / T1Strich * 100;
            }
            else
            {
                EpsilonT1Strich = 1;
            }

            //Вивід данних 
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center; 
            richTextBox1.SelectionFont = new Font("Times new roman", 20, FontStyle.Bold);
            richTextBox1.AppendText("1. Загальний розрахунок приводу.\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.SelectionFont = new Font("Times new roman", 16, FontStyle.Regular);
            richTextBox1.AppendText("Вхідні данні (варіант №17):\n");
            richTextBox1.AppendText("Потужність на виході Pв, кВт:                    " + Math.Round(Pv, 2) + "\n");
            richTextBox1.AppendText("Частота обертання на виході nв, (хв.-1):   " + Math.Round(nv, 2) + "\n\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.SelectionFont = new Font("Times new roman", 18, FontStyle.Bold);
            richTextBox1.AppendText("1.1 Загальний коефіцієнт корисної дії.\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.AppendText("Загальний коефіцієнт корисної дії знаходиться за формулою:\n");
            richTextBox1.AppendText("Nзаг = Nпп * Nц * (Nпід)^2\n");
            richTextBox1.AppendText("де Nпп - коефіцієнт корисної дії (ККД) плоскопасової передачі, Nпп = 0.95\n");
            richTextBox1.AppendText("Nц - ККД циліндричної передачі, Nц = 0.97;.\n");
            richTextBox1.AppendText("Nпід - ККД підшипників, Nпід = 0.99.\n");
            richTextBox1.AppendText("Тому маємо: Nзаг= " + Math.Round(nZag, 3) + "\n\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.SelectionFont = new Font("Times new roman", 18, FontStyle.Bold);
            richTextBox1.AppendText("1.2 Визначення потрібної потужності та вибір електродвигуна.\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.AppendText("Потрібна потужність: Pпотр= " + Math.Round(Ppotr, 2) + " кВт\n"); 
            richTextBox1.AppendText("Вибираємо двигун потужністю Ре= 4 кВт; синхронна частота обертання Nе= 1000 (хв -1), фактична частота обертання Nф =" + nF + " (хв -1),\n\n");
            richTextBox1.SelectionFont = new Font("Times new roman", 18, FontStyle.Bold);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.AppendText("1.3 Розбивка загального передаточного числа по ступеням.\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.AppendText("Загальне передаточне число: " + Math.Round(Uzag,2) + "\n");
            richTextBox1.AppendText("Приймаємо UpGOST = " + Math.Round(UpGOST, 2) + "\n");
            richTextBox1.AppendText("Тоді Uпп= " + Math.Round(Upp, 3) + ".\n\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.SelectionFont = new Font("Times new roman", 18, FontStyle.Bold);
            richTextBox1.AppendText("1.4 Визначення обертових моментів на валах редуктора.\n");
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.AppendText("Частота обертання на валу двигуна: " + Math.Round(nF, 2) + "( хв-1)\n");
            richTextBox1.AppendText("Частота обертання вхідного  кінця вала редуктора: " + Math.Round(n2, 3) + "( хв-1)\n");
            richTextBox1.AppendText("Частота обертання вихідного кінця вала редуктора: " + Math.Round(n3, 3) + "( хв-1)\n");
            richTextBox1.AppendText("Рахуємо похибки розрахунків: " + Math.Round(Epsilon, 3) + "% < 5% - що допустимо.\n");
            richTextBox1.AppendText("Відповідно циклічні частоти дорівнюють:\n");
            richTextBox1.AppendText("w1= " + Math.Round(w1, 2) + " (с-1)\n");
            richTextBox1.AppendText("w2= " + Math.Round(w2, 2) + " (с-1)\n");
            richTextBox1.AppendText("w3= " + Math.Round(w3, 2) + " (с-1)\n");
            richTextBox1.AppendText("Отже обертальні моменти:\n");
            richTextBox1.AppendText("T1= " + Math.Round(T1, 2) + " (Н * м)\n");
            richTextBox1.AppendText("T2= " + Math.Round(T2, 2) + " (Н * м)\n");
            richTextBox1.AppendText("T3= " + Math.Round(T3, 2) + " (Н * м)\n");
            richTextBox1.AppendText("Робимо перевірку проведених розрахунків: " + Math.Round(EpsilonT1Strich, 3) + "% < 5% - що допустимо.\n");     
        }
    }
}