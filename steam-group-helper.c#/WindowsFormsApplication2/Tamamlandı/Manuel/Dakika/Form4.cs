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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                  button2.Enabled = true;
            }
            if (checkBox2.Checked==true)
            {
                button1.Enabled = true;
            }
            if (checkBox3.Checked==true)
            {
                button3.Enabled = true;
            }
            if (checkBox4.Checked==true)
            {
                    button4.Enabled = true;
            }
            if (checkBox5.Checked==true)
            {
                    button5.Enabled = true;
            }
            if (checkBox6.Checked==true)
            {
                button6.Enabled = true;
            }
            if (checkBox7.Checked==true)
            {
                button7.Enabled=true;
            }
            if (checkBox8.Checked==true)
            {
                button8.Enabled=true;
            }
           if (checkBox9.Checked==true)
               {
               button9.Enabled =true;
               }
            if (checkBox10.Checked==true)
                {
                button10.Enabled=true;
                }
            if (checkBox11.Checked==true)
                {
                button11.Enabled=true;
                }

            if (checkBox1.Checked == false)
            {
                button2.Enabled = false;
            }
            if (checkBox2.Checked == false)
            {
                button1.Enabled = false;
            }
            if (checkBox3.Checked == false)
            {
                button3.Enabled = false;
            }
            if (checkBox4.Checked == false)
            {
                button4.Enabled = false;
            }
            if (checkBox5.Checked == false)
            {
                button5.Enabled = false;
            }
            if (checkBox6.Checked == false)
            {
                button6.Enabled = false;
            }
            if (checkBox7.Checked == false)
            {
                button7.Enabled = false;
            }
            if (checkBox8.Checked == false)
            {
                button8.Enabled = false;
            }
            if (checkBox9.Checked == false)
            {
                button9.Enabled = false;
            }
            if (checkBox10.Checked == false)
            {
                button10.Enabled = false;
            }
            if (checkBox11.Checked == false)
            {
                button11.Enabled = false;
            }
            }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 yeni = new Form6();
            yeni.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 yeni = new Form5();
            yeni.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 yeni = new Form7();
            yeni.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            yeni.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 yeni = new Form9();
            yeni.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form10 yeni = new Form10();
            yeni.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form11 yeni = new Form11();
            yeni.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form12 yeni = new Form12();
            yeni.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form13 yeni = new Form13();
            yeni.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form14 yeni = new Form14();
            yeni.Show();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form20 yeni = new Form20();
            yeni.Show();
            this.Hide();
        }
    }
}
