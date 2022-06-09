using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public static RadioButton teamtürkman;
        public static RadioButton cobeprospectus;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            teamtürkman = radioButton1;
            cobeprospectus = radioButton2;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 yeni = new Form4();
            yeni.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 yeni = new Form15();
            yeni.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form16 sonuç = new Form16();
            sonuç.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form18 yeni = new Form18();
            yeni.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form17 yeni = new Form17();
            yeni.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true || radioButton2.Checked==true)
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                }
        }
    }
}