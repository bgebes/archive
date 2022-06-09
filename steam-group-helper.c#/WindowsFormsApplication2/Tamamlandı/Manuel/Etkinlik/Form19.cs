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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();  
        }
        int saniye = 0;
        string başlangıç = "commentthread_ClanEvent_103582791462181965_";
        string sonkisim = "_0_textarea";
        int sayaç = 0;
        private void Form19_Load(object sender, EventArgs e)
        {
            if (Form3.teamtürkman.Checked == true && Form3.cobeprospectus.Checked == false) //TeamTürkman
            {
                webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/eventEdit");
            }
            if (Form3.teamtürkman.Checked == false && Form3.cobeprospectus.Checked == true) //CobeProspectus
            {
                webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/eventEdit");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            HtmlElement eleman;
            eleman = webBrowser1.Document.All["name"]; //Başlık
            eleman.InnerText = "⊙ STEAM OYUN ÇEKİLİŞİ ⊙"; 

            eleman = webBrowser1.Document.All["notes"]; //Açıklama         
            eleman.InnerText = textBox1.Text;


            foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("timeChoice")) //RadioButton
            {
                if (el.GetAttribute("value") == "quick")
                {
                    el.InvokeMember("click");
                }
            }          
            HtmlElementCollection elementsByTagName = this.webBrowser1.Document.GetElementsByTagName("span"); //Buton
            foreach (HtmlElement element in elementsByTagName)
            {
                if (element.GetAttribute("OuterText").Equals("Etkinlik Oluştur"))
                {
                    element.InvokeMember("Click");
                }
            }
        }
        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }
        private void Timer5_Tick(object sender, EventArgs e)
        {
            saniye = saniye + 1;

            if (saniye == 2)
            {
                HtmlElement eleman;
                eleman = webBrowser1.Document.All[başlangıç + sayı.Text + sonkisim];
                eleman.Focus();
                eleman.InnerText = "Çekiliş Link : " + Form18.link.Text;

                HtmlElementCollection TaName = this.webBrowser1.Document.GetElementsByTagName("span"); //Buton
                foreach (HtmlElement element in TaName)
                {
                    if (element.GetAttribute("OuterText").Equals("Yorum Yap"))
                    {
                        element.InvokeMember("Click");
                    }
                }
            }
            if (saniye == 3)
            {
                HtmlElement eeman;
                eeman = webBrowser1.Document.All[başlangıç + sayı.Text + sonkisim];
                eeman.Focus();
                eeman.InnerText = "Çekiliş Link : " + Form18.link.Text;

                HtmlElementCollection Taae = this.webBrowser1.Document.GetElementsByTagName("span"); //Buton
                foreach (HtmlElement element in Taae)
                {
                    if (element.GetAttribute("OuterText").Equals("Yorum Yap"))
                    {
                        element.InvokeMember("Click");
                    }
                }
            }
            if (saniye == 4)
            {
                HtmlElement elema;
                elema = webBrowser1.Document.All[başlangıç + sayı.Text + sonkisim];
                elema.Focus();
                elema.InnerText = "Çekiliş Link : " + Form18.link.Text;

                HtmlElementCollection TaNam = this.webBrowser1.Document.GetElementsByTagName("span"); //Buton
                foreach (HtmlElement element in TaNam)
                {
                    if (element.GetAttribute("OuterText").Equals("Yorum Yap"))
                    {
                        element.InvokeMember("Click");
                    }
                }
            }
            if (saniye == 5)
            {
                HtmlElement leman;
                leman = webBrowser1.Document.All[başlangıç + sayı.Text + sonkisim];
                leman.Focus();
                leman.InnerText = "Çekiliş Link : " + Form18.link.Text;

                HtmlElementCollection aName = this.webBrowser1.Document.GetElementsByTagName("span"); //Buton
                foreach (HtmlElement element in aName)
                {
                    if (element.GetAttribute("OuterText").Equals("Yorum Yap"))
                    {
                        element.InvokeMember("Click");
                    }
                }
            }
            if (saniye == 6)
            {
                HtmlElement elean;
                elean = webBrowser1.Document.All[başlangıç + sayı.Text + sonkisim];
                elean.Focus();
                elean.InnerText = "Çekiliş Link : " + Form18.link.Text;

                HtmlElementCollection TName = this.webBrowser1.Document.GetElementsByTagName("span"); //Buton
                foreach (HtmlElement element in TName)
                {
                    if (element.GetAttribute("OuterText").Equals("Yorum Yap"))
                    {
                        element.InvokeMember("Click");
                    }
                }
                if(MessageBox.Show("Kapatıyorum!","Info!",MessageBoxButtons.OK,MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Environment.Exit(0);
                }              
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (("https://steamcommunity.com/groups/Teamturkmen#events" != webBrowser1.Url.ToString() && "https://steamcommunity.com/groups/Teamturkmen/eventEdit" != webBrowser1.Url.ToString()) || ("https://steamcommunity.com/groups/cobeprospectus/eventEdit" != webBrowser1.Url.ToString() && "https://steamcommunity.com/groups/cobeprospectus#events" != webBrowser1.Url.ToString()))
            {
                timer2.Start(); //YORUM YAPMA
            }          
            if ("https://steamcommunity.com/groups/Teamturkmen/eventEdit" == webBrowser1.Url.ToString() || "https://steamcommunity.com/groups/cobeprospectus/eventEdit" == webBrowser1.Url.ToString())
            {
                timer1.Start(); // ETKİNLİK YAPMA
            }
        }
        public void ayrıştırma()
        {
            string password = webBrowser1.Url.ToString();
            foreach (char c in password)
                if (char.IsDigit(c))
                {
                    sayı.Text = sayı.Text + c.ToString();
                }
        }
        private void timer1_Tick(object sender, EventArgs e) // ETKİNLİK YAPMA
        {
            sayaç++;
            if (sayaç == 1)
            {
                button1.PerformClick();
                sayaç = 0;
                timer1.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayaç++;

            if (sayaç == 2)
            {
                timer5.Start();
                sayaç = 0;
                timer2.Stop();
            }
        }
    }
}
