using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApplication2
{
    public partial class Form21 : Form
    {
        public static CheckBox tek;
        public static CheckBox çift;
        WebBrowser web = new WebBrowser();
        public Form21()
        {
            InitializeComponent();
            tek = bir;
            çift = ikinci;
        }
        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bir.Checked = true;
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ikinci.Checked = true;
            Form22 çoklu = new Form22();
            çoklu.Show();
            this.Hide();
        }
        private void Form21_Load(object sender, EventArgs e)
        {
            web.ScriptErrorsSuppressed = true;
            web.Navigate("");
            web.DocumentCompleted += web_DocumentCompleted;
        }
        private void web_DocumentCompleted(object sender, EventArgs e)
        {
            
        }
    }
}
