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
    public partial class Form2 : Form
    {
        int sayaç = 0;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElement eleman;
            eleman = webBrowser1.Document.All["headline"];
            eleman.InnerText = "ÇEKİLİŞE SON 50 DK | HERKES KATILABİLİR"; //Başlık

            eleman = webBrowser1.Document.All["body"];
            eleman.InnerText = "[code][h1][b]Çekiliş Duyurusuna Gitmek İçin → [url=" + textBox1.Text + "] Buraya Tıkla [/url][/b][/h1][/code]"; //Açıklama         

            webBrowser1.Document.GetElementById("PostAnnouncementButton").InvokeMember("click"); //Buton
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if(Form21.tek.Checked ==true)    
            {
                 textBox1.Text = Form1.kutu.Text;
                 if (Form3.teamtürkman.Checked == true && Form3.cobeprospectus.Checked == false) //TeamTürkman
                 {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");     
                 }
                 if (Form3.teamtürkman.Checked == false && Form3.cobeprospectus.Checked == true) //CobeProspectus
                 {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");
                 }
            }
            if(Form21.çift.Checked ==true)
            {
                if(Form22.sayı==1)
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/Teamturkmen/announcements/create");
                    textBox1.Text = Form22.tt.Text;
                    Form22.sayı = 0;
                }
                if (Form22.sayı == 2)
                {
                    webBrowser1.Navigate("https://steamcommunity.com/groups/cobeprospectus/announcements/create");
                    textBox1.Text = Form22.cb.Text;
                    Form22.sayı = 0;
                }              
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if ("https://steamcommunity.com/groups/Teamturkmen/announcements/create" == webBrowser1.Url.ToString() || "https://steamcommunity.com/groups/cobeprospectus/announcements/create" == webBrowser1.Url.ToString())
            {
                timer1.Start();
            }
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