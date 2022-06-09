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
    public partial class Form15 : Form
    {
        int sayaç = 0;
        public static WebBrowser ekran;
        public Form15()
        {
            InitializeComponent();
            ekran = webBrowser1;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            HtmlElement eleman;
            eleman = webBrowser1.Document.All["headline"];
            eleman.InnerText = "KATILIM SONLANDI | SONUÇLARI BEKLEYİNİZ"; //Başlık

            eleman = webBrowser1.Document.All["body"];
            eleman.InnerText = textBox1.Text; //Açıklama         

            webBrowser1.Document.GetElementById("PostAnnouncementButton").InvokeMember("click"); //Buton
        }
        private void Form15_Load(object sender, EventArgs e)
        {
            txtokuma();
            if (Form21.tek.Checked == true)
            {
                if (Form3.teamtürkman.Checked == true && Form3.cobeprospectus.Checked == false) //TeamTürkman
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");
                }
                if (Form3.teamtürkman.Checked == false && Form3.cobeprospectus.Checked == true) //CobeProspectus
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");
                }
            }
            if (Form21.çift.Checked == true)
            {
                if (Form22.sayı == 1)
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");
                }
                if (Form22.sayı == 2)
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");
                }
            }
        }
        private void Form15_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if ("https://steamcommunity.com/groups/Teamturkmen/announcements/create" == webBrowser1.Url.ToString() || "https://steamcommunity.com/groups/cobeprospectus/announcements/create" == webBrowser1.Url.ToString())
            {
                timer1.Start();
            }
        }
        public void txtokuma()
        {
            var yazı = File.ReadLines(@"text\katılımsonlandı.txt");
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
            sayaç++;
            if (sayaç == 2)
            {
                button1.PerformClick();
                timer1.Stop();
                this.Hide();
            }
        }
    }
}
