using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public static NotifyIcon uyarı;
        public static TextBox kutu;
        public Form1()
        {
            InitializeComponent();
            kutu = textBox2;
            uyarı = notifyIcon1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                DialogResult = MessageBox.Show("Link Girmeden Giriş Yapıyorsunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://steamcommunity.com/login/home");
        }
        private void steamıÇalıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("D:\\Steam\\Steam.exe");
        }
        private void hatırlatmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form20 yeni = new Form20();
            yeni.Show();
            this.Hide();
        }   
        private void çekilişDuyurusuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 yeni = new Form18();
            yeni.Show();
            this.Hide();
        }
        private void hatırlatmaDakikalaraGöreSeçimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 yeni = new Form4();
            yeni.Show();
            this.Hide();
        }
        private void kATILIMSONLANDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15 yeni = new Form15();
            yeni.Show();
            this.Hide();
        }
        private void sONUÇToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 yeni = new Form16();
            yeni.Show();
            this.Hide();
        }
        private void ıLKDAVETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 yeni = new Form17();
            yeni.Show();
            this.Hide();
        }
        private void programıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void girişEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                textBox2.ReadOnly = false;
            }           
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == true)
            {
                textBox2.ReadOnly = false;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if ("https://steamcommunity.com/login/home" != webBrowser1.Url.ToString())
                {
                if ("https://steamcommunity.com/id/darkangel249" == webBrowser1.Url.ToString() || "https://steamcommunity.com/id/hdfndsmsk" == webBrowser1.Url.ToString() || "https://steamcommunity.com/id/darkangel249/" == webBrowser1.Url.ToString())
                {
                    webBrowser1.Visible = false;
                    this.MaximizeBox = false;
                }
                if ("https://steamcommunity.com/id/darkangel249" == webBrowser1.Url.ToString())
                {
                    notifyIcon1.ShowBalloonTip(1, "Giriş Yapıldı!", "Hoşgeldiniz Berkay Bey!", ToolTipIcon.Info);
                }
                if ("https://steamcommunity.com/id/hdfndsmsk" == webBrowser1.Url.ToString())
                {
                    notifyIcon1.ShowBalloonTip(1, "Giriş Yapıldı!", "Hoşgeldiniz Coşkun Bey!", ToolTipIcon.Info);
                }
            }
        }
    }
}