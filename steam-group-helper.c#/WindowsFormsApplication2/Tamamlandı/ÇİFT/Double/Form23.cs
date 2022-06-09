using System;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;

namespace WindowsFormsApplication2
{
    public partial class Form23 : Form
    {
        int sayaç;
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            birinci();
            ikinci();
            timer1.Stop();
            this.Hide();
        }
        void ikinci()
        {
            Uri url = new Uri("https://steamcommunity.com/groups/cobeprospectus#announcements");


            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//a");

            foreach (var baslik in basliklar)
            {
                string link = baslik.Attributes["href"].Value;
                listBox2.Items.Add(link);
            }
            string listBoxEleman = this.listBox1.GetItemText(this.listBox2.Items[80]);
            Form22.cb.Text = listBoxEleman;
        }
        void birinci()
        {
            Uri url = new Uri("https://steamcommunity.com/groups/Teamturkmen#announcements");


            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//a");

            foreach (var baslik in basliklar)
            {
                string link = baslik.Attributes["href"].Value;
                listBox1.Items.Add(link);
            }
            string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[79]);
            Form22.tt.Text = listBoxEleman.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayaç++;          
            if (sayaç ==2)
            {
                button1.PerformClick();
            }
        }
    }
}
