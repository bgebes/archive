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
    public partial class Form16 : Form
    {
        int sayaç = 0;
        public static WebBrowser ekran;
        public Form16()
        {
            InitializeComponent();
            ekran = webBrowser1;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            HtmlElement eleman;
            eleman = webBrowser1.Document.All["headline"];
            eleman.InnerText = "⍟ Oyun Çekilişi Kazanan Açıklandı ⍟"; //Başlık

            eleman = webBrowser1.Document.All["body"];
            eleman.InnerText = textBox1.Text; //Açıklama  
        }
        private void Form16_Load_1(object sender, EventArgs e)
        {
            txtokumatt();
            if (Form21.tek.Checked == true)
            {
                if (Form21.tek.Enabled = true && Form3.teamtürkman.Checked == true && Form3.cobeprospectus.Checked == false) //TeamTürkman
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");
                }
                if (Form21.tek.Enabled = true && Form3.teamtürkman.Checked == false && Form3.cobeprospectus.Checked == true) //CobeProspectus
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");
                }
            }
            if (Form21.çift.Checked == true)
            {
                if (Form22.sayı == 1)
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");
                    Form22.sayı = 0;
                }
                if (Form22.sayı == 2)
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");
                    Form22.sayı = 0;
                }
            }
        }
        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if ("https://steamcommunity.com/groups/Teamturkmen/announcements/create" == webBrowser1.Url.ToString() || "https://steamcommunity.com/groups/cobeprospectus/announcements/create" == webBrowser1.Url.ToString())
            {
                timer1.Start();
            }
        }
        public void txtokumatt() 
        {
            var yazı = File.ReadLines(@"text\sonuç.txt");
            foreach (var txt in yazı)
            {
                listBox1.Items.Add(txt);
            }
            string s1 = "";
            foreach (object item in listBox1.Items) s1 += item.ToString() + "\r\n";
            textBox1.Text = s1;
        } // TT
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayaç++;
            if (sayaç == 1)
            {
                button1.PerformClick();
                timer1.Stop();
            }
        }
    }
}
