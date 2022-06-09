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
    public partial class Form17 : Form
    {
        int sayaç = 0;
        public Form17()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            HtmlElement eleman;
            eleman = webBrowser1.Document.All["headline"];
            eleman.InnerText = "İLK TÜM ARK. DAVET EDEN KİŞİYE RANDOM OYUN"; //Başlık

            eleman = webBrowser1.Document.All["body"];
            eleman.InnerText = textBox1.Text; //Açıklama         

            webBrowser1.Document.GetElementById("PostAnnouncementButton").InvokeMember("click"); //Buton
        }
        private void Form17_Load(object sender, EventArgs e)
        {
            txtokumatt();
            txtokumacb();
            if (Form21.tek.Enabled == true && Form3.teamtürkman.Checked == true && Form3.cobeprospectus.Checked == false) //TeamTürkman
            {
                webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");
            }
            if (Form21.tek.Enabled == true && Form3.teamtürkman.Checked == false && Form3.cobeprospectus.Checked == true) //CobeProspectus
            {
                webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");
                textBox1.Text = textBox2.Text;
            }
        }
        private void Form17_FormClosing(object sender, FormClosingEventArgs e)
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
        public void txtokumatt() // TEAM TURKMAN
        {
            var yazı = File.ReadLines(@"text\ilkdavettt.txt");
            foreach (var txt in yazı)
            {
                listBox1.Items.Add(txt);
            }
            string s1 = "";
            foreach (object item in listBox1.Items) s1 += item.ToString() + "\r\n";
            textBox1.Text = s1;
            s1 = null;
            listBox1.Items.Clear();
        }
        public void txtokumacb() // COBE PROSPECTUS
        {
            var yazı = File.ReadLines(@"text\ilkdavetcb.txt");
            foreach (var txt in yazı)
            {
                listBox1.Items.Add(txt.ToString());
            }
            string s1 = "";
            foreach (object item in listBox1.Items) s1 += item.ToString() + "\r\n";
            textBox2.Text = s1;
            s1 = null;
            listBox1.Items.Clear();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayaç++;
            if (sayaç == 1)
            {
                button1.PerformClick();
                this.Hide();
                timer1.Stop();
            }        
        }
    }
}
