using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form18 : Form
    {
        public static TextBox link;
        public Form18()
        {
            InitializeComponent();
            link = textBox2;
        }
        int timex = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            HtmlElement eleman;
            eleman = webBrowser1.Document.All["headline"];
            eleman.InnerText = "⊙ STEAM KEY ÇEKİLİŞİ ⊙"; //Başlık

            eleman = webBrowser1.Document.All["body"];
            eleman.InnerText = textBox1.Text; //Açıklama
            
        }
        private void Form18_Load(object sender, EventArgs e)
        {
            textokuma();
            if (Form3.teamtürkman.Checked == true && Form3.cobeprospectus.Checked == false) //TeamTürkman
            {
                webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");
            }
            if (Form3.teamtürkman.Checked == false && Form3.cobeprospectus.Checked == true) //CobeProspectus
            {
                webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");

            }
        }
        private void Form18_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            etkinlikyapma();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if ("https://steamcommunity.com/groups/Teamturkmen/announcements/create" == webBrowser1.Url.ToString() || "https://steamcommunity.com/groups/cobeprospectus/announcements/create" == webBrowser1.Url.ToString())
            {
                timer1.Start();
            }
        }
        public void textokuma()
        {
            var yazı = File.ReadLines(@"text\çekiliş.txt");
            foreach (var txt in yazı)
            {
                listBox1.Items.Add(txt.ToString());
            }
            string s1 = "";
            foreach (object item in listBox1.Items) s1 += item.ToString() + "\r\n";
            textBox1.Text = s1;        
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timex++;
            if (timex == 1)
            {
                button1.PerformClick();
                timer1.Stop();
            }
        }
        public void etkinlikyapma()
        {
            Form19 yeni = new Form19();
            yeni.Show();
            this.Hide();
        }
    }
}
