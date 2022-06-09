using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace WindowsFormsApplication2
{
    public partial class Form24 : Form
    {
        public static int sayfanumara;
        int sayaç = 0;
        int hata = 0;
        public Form24()
        {
            InitializeComponent();  
        }
        void yöntem4()
        {
            try
            {
                HtmlElementCollection elementsByTagName = this.webBrowser1.Document.GetElementsByTagName("bdi");
                foreach (HtmlElement element in elementsByTagName)
                {
                    listBox1.Items.Add(element.InnerText);                
                }
            }
            catch (ArgumentNullException)
            {
                if (MessageBox.Show("Bir Hata Oluştu","Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error)==DialogResult.OK)
                {
                    zamanlama.Stop();
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    zamanlama.Start();
                }
            }          
        }
        private void Form24_Load(object sender, EventArgs e)
        {
            /*
            if (Form3.teamtürkman.Checked == true)
            {
                radioButton1.Checked = true;
            }
            if (Form3.cobeprospectus.Checked == true)
            {
                radioButton2.Checked = true;
            }
            */
        }
        void butonatıklat()
        {
            HtmlElementCollection elementsByTagName = this.webBrowser1.Document.GetElementsByTagName("a"); //Buton
            foreach (HtmlElement element in elementsByTagName)
            {
                if (element.GetAttribute("OuterText").Equals(">"))
                {
                    element.InvokeMember("Click");
                }
            }
        }
        void katılımcılar()
        {
            int a, b, c;
            a = Convert.ToInt32(textBox3.Text);
            b = a % 10;
            c = sayfanumara;
            if (sayaç == 3 * c) //BİTİŞ
            {
                yöntem4();
                if (b != 0)
                {
                    for (int i = 0; i < b; i++)
                    {
                        string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                        listBox2.Items.Add(listBoxEleman.ToString());
                    }
                }
                if (b == 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                        listBox2.Items.Add(listBoxEleman.ToString());
                    }
                }
                listBox1.Items.Clear();
                textBox1.Text = listBox2.Items.Count.ToString();
                sayaç = 0;
                netsayı();
                kopyalama();
                zamanlama.Stop();
            }
            if (sayaç == 3) //1.sayfa
            {
                yöntem4();
                for (int i=0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 6) //2.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 9) //3.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 12) //4.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 15) //5.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 18) //6.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 21) //7.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 24) //8.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 27) //9.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 30) //10.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 33) //11.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 36) //12.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 39) //13.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 42) //14.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 45) //15.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 48) //16.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 51) //17.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 54) //18.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 57) //19.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }
            if (sayaç == 60) //20.sayfa
            {
                yöntem4();
                for (int i = 0; i < 10; i++)
                {
                    string listBoxEleman = this.listBox1.GetItemText(this.listBox1.Items[i]);
                    listBox2.Items.Add(listBoxEleman.ToString());
                }
                butonatıklat();
                listBox1.Items.Clear();
            }           
        }
        private void zamanlama_Tick(object sender, EventArgs e)
        {
            sayaç++;
            katılımcılar();
        }       
        void ikinci() //CB
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
            string listBoxEleman = this.listBox2.GetItemText(this.listBox2.Items[80]);
            webBrowser1.Navigate(listBoxEleman);
            listBox2.Items.Clear();
        }
        void birinci() //TT
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
            webBrowser1.Navigate(listBoxEleman);
            listBox1.Items.Clear();
        }
        void netsayı()
        {
            int a, b, c;
            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox3.Text);
            c = b % 10;
                for (int i = a; i > 0; i--)
                {
                    string eleman = this.listBox2.GetItemText(this.listBox2.Items[i - 1]);
                    if (listBox1.Items.Contains(eleman) == false)
                    {
                        listBox1.Items.Add(eleman);
                        listBox2.Items.Remove(eleman);
                    }
                    else
                    {
                        hata++;
                        listBox2.Items.Remove(eleman);
                    }
                }          
            textBox1.Text = listBox1.Items.Count.ToString();
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Text = hata.ToString();
            textBox2.Visible = true;
            label4.Visible = true;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) //TT
            {
                birinci();
            }
            if (radioButton2.Checked == true) //CB
            {
                ikinci();
            }
        }
        void kopyalama()
        {
            int a;
            a = Convert.ToInt32(textBox1.Text);
            try
            {
                
                DialogResult = MessageBox.Show("Listeyi Kopyalamak İster Misiniz ?", "Öneri", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    for (int i = a; i > 0; i--)
                    {
                        listBox3.Items.Add(listBox1.GetItemText(listBox1.Items[i - 1]));
                    }
                    System.Diagnostics.Process.Start("https://www.cekilisyap.com/hizli-cekilis");
                    string s1 = "";
                    foreach (object item in listBox3.Items) s1 += item.ToString() + "\r\n";
                    Clipboard.SetText(s1);
                }
                if (DialogResult == DialogResult.No)
                {

                }               
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Kopyalanamadı!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        void sayfanumarasi()
        {
            int a;
            a = Convert.ToInt32(textBox3.Text);
            sayfanumara = a / 10;
            if (a % 10 != 0)
            {
                sayfanumara++;
            }
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                textBox3.Enabled = false;
                sayfanumarasi();
                zamanlama.Start();
            }
        }
        private void Form24_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    } 
}
 