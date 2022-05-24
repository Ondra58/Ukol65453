using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool JePrvocislo(int vstup)
        {
            bool prvocislo = false;
            if (vstup == 2 || vstup == 3)
            {
                prvocislo = true;
            }
            else if (vstup % 2 == 0 && vstup != 2 || vstup == 1)
            {
                prvocislo = false;
            }
            else
            {
                prvocislo = true;
                for (int i = 3; i < Math.Sqrt(vstup) && prvocislo != false; i += 2)
                {
                    if (vstup % i == 0)
                    {
                        prvocislo = false;
                    }
                    else
                    {
                        prvocislo = true;
                    }
                }
            }
            return prvocislo;
        }
        int[] pole;
        void Prepis(TextBox textBox1, ListBox listBox1)
        {
            listBox1.Items.Clear();
            foreach (int cislo in pole)
            {
                if (JePrvocislo(cislo))
                {
                    listBox1.Items.Add(cislo);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vstup = (int)numericUpDown1.Value;
            if (JePrvocislo(vstup) == true)
            {
                label1.Text = "Číslo je prvočíslo";
            }
            else 
            {
                label1.Text = "Číslo není prvočíslo";
            }
        }
        Random rng = new Random();
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            pole = new int[(int)numericUpDown2.Value];
            for (int i = 0; i < (int)numericUpDown2.Value; i++)
            {
                int random = rng.Next(2, 16);
                pole[i] = random;
                textBox1.Text += (random + "; ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prepis(textBox1, listBox1);
        }
    }
}
