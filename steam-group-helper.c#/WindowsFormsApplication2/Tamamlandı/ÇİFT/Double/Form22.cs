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
    public partial class Form22 : Form
    {
        public static TextBox tt;
        public static TextBox cb;
        public static int sayı = 0;
        public int sa;
        public Form22()
        {
            InitializeComponent();
            tt = textBox1;
            cb = textBox2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Başlıyoruz", "Giriş!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.OK)
            {
                timer1.Start();
                this.Hide();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 9 && DateTime.Now.Second == 00) //TT50
            {
                sayı = sayı + 1;
                Form2 yeni = new Form2();
                yeni.Show(); 
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 10 && DateTime.Now.Second == 00) //CB50
            {
                sayı = sayı + 2;
                Form2 yeni = new Form2();
                yeni.Show();          
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 19 && DateTime.Now.Second == 00) //TT40
            {
                sayı = sayı + 1;
                Form5 yeni = new Form5();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 20 && DateTime.Now.Second == 00)  //CB40
            {
                sayı = sayı + 2;
                Form5 yeni = new Form5();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 29 && DateTime.Now.Second == 00) //TT30
            {
                sayı = sayı + 1;
                Form6 yeni = new Form6();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 30 && DateTime.Now.Second == 00) //CB30
            {
                sayı = sayı + 2;
                Form6 yeni = new Form6();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 39 && DateTime.Now.Second == 00) //TT20
            {
                sayı = sayı + 1;
                Form7 yeni = new Form7();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 40 && DateTime.Now.Second == 00)  //CB20
            {
                sayı = sayı + 2;
                Form7 yeni = new Form7();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 44 && DateTime.Now.Second == 00) //TT15
            {
                sayı = sayı + 1;
                Form8 yeni = new Form8();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 45 && DateTime.Now.Second == 00) //CB15
            {
                sayı = sayı + 2;
                Form8 yeni = new Form8();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 49 && DateTime.Now.Second == 00) //TT10
            {
                sayı = sayı + 1;
                Form9 yeni = new Form9();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 50 && DateTime.Now.Second == 00) //CB10
            {
                sayı = sayı + 2;
                Form9 yeni = new Form9();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 54 && DateTime.Now.Second == 00) //TT5
            {
                sayı = sayı + 1;
                Form10 yeni = new Form10();
                yeni.Show();             
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 55 && DateTime.Now.Second == 00) //CB5
            {
                sayı = sayı + 2;
                Form10 yeni = new Form10();
                yeni.Show();                
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 55 && DateTime.Now.Second == 00) //TT4
            {
                sayı = sayı + 1;
                Form11 yeni = new Form11();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 56 && DateTime.Now.Second == 00) //CB4
            {
                sayı = sayı + 2;
                Form11 yeni = new Form11();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 56 && DateTime.Now.Second == 00) //TT3
            {
                sayı = sayı + 1;
                Form12 yeni = new Form12();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 57 && DateTime.Now.Second == 00) //CB3
            {
                sayı = sayı + 2;
                Form12 yeni = new Form12();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 57 && DateTime.Now.Second == 00) //TT2
            {
                sayı = sayı + 1;
                Form13 yeni = new Form13();
                yeni.Show();           
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 58 && DateTime.Now.Second == 00) //CB2
            {
                sayı = sayı + 2;
                Form13 yeni = new Form13();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 58 && DateTime.Now.Second == 00) //TT1
            {
                sayı = sayı + 1;
                Form14 yeni = new Form14();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa && DateTime.Now.Minute == 59 && DateTime.Now.Second == 00) //CB1
            {
                sayı = sayı + 2;
                Form14 yeni = new Form14();
                yeni.Show();
            }
            if (DateTime.Now.Hour == sa + 1 && DateTime.Now.Minute == 00 && DateTime.Now.Second == 00) //TT0
            {
                sayı = sayı + 1;
                Form15 yeni = new Form15();
                yeni.Show();
                Form16 sonuç = new Form16();
                sonuç.Show();
            }
            if (DateTime.Now.Hour == sa + 1 && DateTime.Now.Minute == 01 && DateTime.Now.Second == 00) //CB0
            {
                sayı = sayı + 2;
                Form15 yeni = new Form15();
                yeni.Show();
                Form16 sonuç = new Form16();
                sonuç.Show();                                         
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.ReadOnly = true;
            }
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.ReadOnly = true;
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
        }
        private void Form22_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button1.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form23 yeni = new Form23();
            yeni.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form24 katılımcılar = new Form24();
            katılımcılar.Show();
            this.Hide();
        }
        private void saat_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }
        private void Form22_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.Hour.ToString();
            sa = Convert.ToInt32(label3.Text);

        }
    }   
}
