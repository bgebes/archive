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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            sakla();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int saat;
            saat = Convert.ToInt32(textBox1.Text);
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 10 && DateTime.Now.Second == 00) //50 Dakika
            {
                Form2 yeni = new Form2();
                yeni.Show();               
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 20 && DateTime.Now.Second == 00) //40 Dakika
            {
               Form5 yeni = new Form5();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 30 && DateTime.Now.Second == 00) //30 Dakika
            {
                Form6 yeni = new Form6();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 40 && DateTime.Now.Second == 00)  //20 Dakika
            {
                Form7 yeni = new Form7(); 
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 45 && DateTime.Now.Second == 00) //15 Dakika
            {
                Form8 yeni = new Form8();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 50 && DateTime.Now.Second == 00) //10 Dakika
            {
                Form9 yeni = new Form9();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 55 && DateTime.Now.Second == 00) //5 Dakika
            {
                Form10 yeni = new Form10();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Hour == saat && DateTime.Now.Minute == 56 && DateTime.Now.Second == 00)  //4 Dakika
            {
                Form11 yeni = new Form11();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 57 && DateTime.Now.Second == 00) //3 Dakika
            {
                Form12 yeni = new Form12();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 58 && DateTime.Now.Second == 00) //2 Dakika
            {
                Form13 yeni = new Form13();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat && DateTime.Now.Minute == 59 && DateTime.Now.Second == 00) //1 Dakika
            {
                Form14 yeni = new Form14();
                yeni.Show();
            }
            if (DateTime.Now.Hour == saat + 1 && DateTime.Now.Minute == 00 && DateTime.Now.Second == 00) //KatılımSonlandı
            {
                Form15 yeni = new Form15();
                yeni.Show();             
                Form16 sonuc = new Form16();
                sonuc.Show();
                this.Hide();
                timer1.Stop(); 
            }
        }
        private void sakla() 
        {
            this.Hide();
        }
        private void Form20_Load(object sender, EventArgs e)
        {

        }
    }
}
