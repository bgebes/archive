namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.steamıÇalıştırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.girişEkranıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otomatikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hatırlatmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çekilişDuyurusuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hatırlatmaDakikalaraGöreSeçimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kATILIMSONLANDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sONUÇToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ıLKDAVETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programıKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1255, 59);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(1118, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.Location = new System.Drawing.Point(12, 9);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1100, 38);
            this.textBox2.TabIndex = 2;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Steam Duyuru Yardımcısı";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.steamıÇalıştırToolStripMenuItem,
            this.girişEkranıToolStripMenuItem,
            this.otomatikToolStripMenuItem,
            this.manuelToolStripMenuItem,
            this.programıKapatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 124);
            // 
            // steamıÇalıştırToolStripMenuItem
            // 
            this.steamıÇalıştırToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.steamıÇalıştırToolStripMenuItem.Name = "steamıÇalıştırToolStripMenuItem";
            this.steamıÇalıştırToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.steamıÇalıştırToolStripMenuItem.Text = "Steam\'ı Çalıştır";
            this.steamıÇalıştırToolStripMenuItem.Click += new System.EventHandler(this.steamıÇalıştırToolStripMenuItem_Click);
            // 
            // girişEkranıToolStripMenuItem
            // 
            this.girişEkranıToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.girişEkranıToolStripMenuItem.Name = "girişEkranıToolStripMenuItem";
            this.girişEkranıToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.girişEkranıToolStripMenuItem.Text = "Giriş Ekranı";
            this.girişEkranıToolStripMenuItem.Click += new System.EventHandler(this.girişEkranıToolStripMenuItem_Click);
            // 
            // otomatikToolStripMenuItem
            // 
            this.otomatikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hatırlatmaToolStripMenuItem});
            this.otomatikToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otomatikToolStripMenuItem.Name = "otomatikToolStripMenuItem";
            this.otomatikToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.otomatikToolStripMenuItem.Text = "Otomatik";
            // 
            // hatırlatmaToolStripMenuItem
            // 
            this.hatırlatmaToolStripMenuItem.Name = "hatırlatmaToolStripMenuItem";
            this.hatırlatmaToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.hatırlatmaToolStripMenuItem.Text = "Hatırlatma";
            this.hatırlatmaToolStripMenuItem.Click += new System.EventHandler(this.hatırlatmaToolStripMenuItem_Click);
            // 
            // manuelToolStripMenuItem
            // 
            this.manuelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çekilişDuyurusuToolStripMenuItem,
            this.hatırlatmaDakikalaraGöreSeçimToolStripMenuItem,
            this.kATILIMSONLANDIToolStripMenuItem,
            this.sONUÇToolStripMenuItem,
            this.ıLKDAVETToolStripMenuItem});
            this.manuelToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuelToolStripMenuItem.Name = "manuelToolStripMenuItem";
            this.manuelToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.manuelToolStripMenuItem.Text = "Manuel";
            // 
            // çekilişDuyurusuToolStripMenuItem
            // 
            this.çekilişDuyurusuToolStripMenuItem.Name = "çekilişDuyurusuToolStripMenuItem";
            this.çekilişDuyurusuToolStripMenuItem.Size = new System.Drawing.Size(330, 24);
            this.çekilişDuyurusuToolStripMenuItem.Text = "Çekiliş Duyurusu";
            this.çekilişDuyurusuToolStripMenuItem.Click += new System.EventHandler(this.çekilişDuyurusuToolStripMenuItem_Click);
            // 
            // hatırlatmaDakikalaraGöreSeçimToolStripMenuItem
            // 
            this.hatırlatmaDakikalaraGöreSeçimToolStripMenuItem.Name = "hatırlatmaDakikalaraGöreSeçimToolStripMenuItem";
            this.hatırlatmaDakikalaraGöreSeçimToolStripMenuItem.Size = new System.Drawing.Size(330, 24);
            this.hatırlatmaDakikalaraGöreSeçimToolStripMenuItem.Text = "Hatırlatma Dakikalara Göre Seçim";
            this.hatırlatmaDakikalaraGöreSeçimToolStripMenuItem.Click += new System.EventHandler(this.hatırlatmaDakikalaraGöreSeçimToolStripMenuItem_Click);
            // 
            // kATILIMSONLANDIToolStripMenuItem
            // 
            this.kATILIMSONLANDIToolStripMenuItem.Name = "kATILIMSONLANDIToolStripMenuItem";
            this.kATILIMSONLANDIToolStripMenuItem.Size = new System.Drawing.Size(330, 24);
            this.kATILIMSONLANDIToolStripMenuItem.Text = "KATILIM SONLANDI";
            this.kATILIMSONLANDIToolStripMenuItem.Click += new System.EventHandler(this.kATILIMSONLANDIToolStripMenuItem_Click);
            // 
            // sONUÇToolStripMenuItem
            // 
            this.sONUÇToolStripMenuItem.Name = "sONUÇToolStripMenuItem";
            this.sONUÇToolStripMenuItem.Size = new System.Drawing.Size(330, 24);
            this.sONUÇToolStripMenuItem.Text = "SONUÇ";
            this.sONUÇToolStripMenuItem.Click += new System.EventHandler(this.sONUÇToolStripMenuItem_Click);
            // 
            // ıLKDAVETToolStripMenuItem
            // 
            this.ıLKDAVETToolStripMenuItem.Name = "ıLKDAVETToolStripMenuItem";
            this.ıLKDAVETToolStripMenuItem.Size = new System.Drawing.Size(330, 24);
            this.ıLKDAVETToolStripMenuItem.Text = "ILK DAVET";
            this.ıLKDAVETToolStripMenuItem.Click += new System.EventHandler(this.ıLKDAVETToolStripMenuItem_Click);
            // 
            // programıKapatToolStripMenuItem
            // 
            this.programıKapatToolStripMenuItem.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programıKapatToolStripMenuItem.Name = "programıKapatToolStripMenuItem";
            this.programıKapatToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.programıKapatToolStripMenuItem.Text = "Program\'ı Kapat";
            this.programıKapatToolStripMenuItem.Click += new System.EventHandler(this.programıKapatToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 59);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Sayfası";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem otomatikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hatırlatmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çekilişDuyurusuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hatırlatmaDakikalaraGöreSeçimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kATILIMSONLANDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sONUÇToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ıLKDAVETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem steamıÇalıştırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programıKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem girişEkranıToolStripMenuItem;
    }
}

