namespace kutupHaneOtomasyonu
{
    partial class AdminForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnRaporlar = new System.Windows.Forms.Button();
            this.btnRezervasyonlar = new System.Windows.Forms.Button();
            this.btnKullanicilar = new System.Windows.Forms.Button();
            this.btnEmanetler = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btnKitaplar = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblOduncKitap = new System.Windows.Forms.Label();
            this.lblAktifUye = new System.Windows.Forms.Label();
            this.lblToplamKitap = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yönetimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitaplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emanetlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnManageBooks = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 28);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1333, 98);
            this.panelTop.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(16, 62);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(106, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Hoş Geldiniz";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(595, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kütüphane Yönetim Sistemi - Admin";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelMenu.Controls.Add(this.btnCikis);
            this.panelMenu.Controls.Add(this.btnRaporlar);
            this.panelMenu.Controls.Add(this.btnRezervasyonlar);
            this.panelMenu.Controls.Add(this.btnKullanicilar);
            this.panelMenu.Controls.Add(this.btnEmanetler);
            this.panelMenu.Controls.Add(this.btnAyarlar);
            this.panelMenu.Controls.Add(this.btnKitaplar);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 126);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(267, 547);
            this.panelMenu.TabIndex = 1;
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(16, 468);
            this.btnCikis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(233, 62);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRaporlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnRaporlar.ForeColor = System.Drawing.Color.White;
            this.btnRaporlar.Location = new System.Drawing.Point(16, 381);
            this.btnRaporlar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Size = new System.Drawing.Size(233, 62);
            this.btnRaporlar.TabIndex = 5;
            this.btnRaporlar.Text = "Raporlar";
            this.btnRaporlar.UseVisualStyleBackColor = false;
            this.btnRaporlar.Click += new System.EventHandler(this.btnRaporlar_Click);
            // 
            // btnRezervasyonlar
            // 
            this.btnRezervasyonlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRezervasyonlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervasyonlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnRezervasyonlar.ForeColor = System.Drawing.Color.White;
            this.btnRezervasyonlar.Location = new System.Drawing.Point(13, 311);
            this.btnRezervasyonlar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRezervasyonlar.Name = "btnRezervasyonlar";
            this.btnRezervasyonlar.Size = new System.Drawing.Size(233, 62);
            this.btnRezervasyonlar.TabIndex = 4;
            this.btnRezervasyonlar.Text = "Rezervasyonlar";
            this.btnRezervasyonlar.UseVisualStyleBackColor = false;
            this.btnRezervasyonlar.Click += new System.EventHandler(this.btnRezervasyonlar_Click);
            // 
            // btnKullanicilar
            // 
            this.btnKullanicilar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnKullanicilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullanicilar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnKullanicilar.ForeColor = System.Drawing.Color.White;
            this.btnKullanicilar.Location = new System.Drawing.Point(13, 241);
            this.btnKullanicilar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKullanicilar.Name = "btnKullanicilar";
            this.btnKullanicilar.Size = new System.Drawing.Size(233, 62);
            this.btnKullanicilar.TabIndex = 3;
            this.btnKullanicilar.Text = "Kullanıcılar";
            this.btnKullanicilar.UseVisualStyleBackColor = false;
            this.btnKullanicilar.Click += new System.EventHandler(this.btnKullanicilar_Click);
            // 
            // btnEmanetler
            // 
            this.btnEmanetler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEmanetler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmanetler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnEmanetler.ForeColor = System.Drawing.Color.White;
            this.btnEmanetler.Location = new System.Drawing.Point(13, 168);
            this.btnEmanetler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEmanetler.Name = "btnEmanetler";
            this.btnEmanetler.Size = new System.Drawing.Size(233, 62);
            this.btnEmanetler.TabIndex = 2;
            this.btnEmanetler.Text = "Emanetler";
            this.btnEmanetler.UseVisualStyleBackColor = false;
            this.btnEmanetler.Click += new System.EventHandler(this.btnEmanetler_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnAyarlar.ForeColor = System.Drawing.Color.White;
            this.btnAyarlar.Location = new System.Drawing.Point(13, 94);
            this.btnAyarlar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(233, 62);
            this.btnAyarlar.TabIndex = 1;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // btnKitaplar
            // 
            this.btnKitaplar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnKitaplar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitaplar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnKitaplar.ForeColor = System.Drawing.Color.White;
            this.btnKitaplar.Location = new System.Drawing.Point(13, 24);
            this.btnKitaplar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKitaplar.Name = "btnKitaplar";
            this.btnKitaplar.Size = new System.Drawing.Size(233, 62);
            this.btnKitaplar.TabIndex = 0;
            this.btnKitaplar.Text = "Kitaplar";
            this.btnKitaplar.UseVisualStyleBackColor = false;
            this.btnKitaplar.Click += new System.EventHandler(this.btnKitaplar_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.groupBoxStats);
            this.panelMain.Controls.Add(this.pictureBoxLogo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(267, 126);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1066, 547);
            this.panelMain.TabIndex = 2;
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.lblOduncKitap);
            this.groupBoxStats.Controls.Add(this.lblAktifUye);
            this.groupBoxStats.Controls.Add(this.lblToplamKitap);
            this.groupBoxStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxStats.Location = new System.Drawing.Point(67, 62);
            this.groupBoxStats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxStats.Size = new System.Drawing.Size(400, 185);
            this.groupBoxStats.TabIndex = 1;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Hızlı İstatistikler";
            // 
            // lblOduncKitap
            // 
            this.lblOduncKitap.AutoSize = true;
            this.lblOduncKitap.Location = new System.Drawing.Point(27, 123);
            this.lblOduncKitap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOduncKitap.Name = "lblOduncKitap";
            this.lblOduncKitap.Size = new System.Drawing.Size(159, 25);
            this.lblOduncKitap.TabIndex = 2;
            this.lblOduncKitap.Text = "Ödünçte Kitap: 0";
            // 
            // lblAktifUye
            // 
            this.lblAktifUye.AutoSize = true;
            this.lblAktifUye.Location = new System.Drawing.Point(27, 86);
            this.lblAktifUye.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAktifUye.Name = "lblAktifUye";
            this.lblAktifUye.Size = new System.Drawing.Size(112, 25);
            this.lblAktifUye.TabIndex = 1;
            this.lblAktifUye.Text = "Aktif Üye: 0";
            // 
            // lblToplamKitap
            // 
            this.lblToplamKitap.AutoSize = true;
            this.lblToplamKitap.Location = new System.Drawing.Point(27, 49);
            this.lblToplamKitap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamKitap.Name = "lblToplamKitap";
            this.lblToplamKitap.Size = new System.Drawing.Size(150, 25);
            this.lblToplamKitap.TabIndex = 0;
            this.lblToplamKitap.Text = "Toplam Kitap: 0";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(533, 123);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(400, 246);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.yönetimToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1333, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // yönetimToolStripMenuItem
            // 
            this.yönetimToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitaplarToolStripMenuItem,
            this.ayarlarToolStripMenuItem,
            this.emanetlerToolStripMenuItem,
            this.raporlarToolStripMenuItem});
            this.yönetimToolStripMenuItem.Name = "yönetimToolStripMenuItem";
            this.yönetimToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.yönetimToolStripMenuItem.Text = "Yönetim";
            // 
            // kitaplarToolStripMenuItem
            // 
            this.kitaplarToolStripMenuItem.Name = "kitaplarToolStripMenuItem";
            this.kitaplarToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.kitaplarToolStripMenuItem.Text = "Kitaplar";
            this.kitaplarToolStripMenuItem.Click += new System.EventHandler(this.kitaplarToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            this.ayarlarToolStripMenuItem.Click += new System.EventHandler(this.ayarlarToolStripMenuItem_Click);
            // 
            // emanetlerToolStripMenuItem
            // 
            this.emanetlerToolStripMenuItem.Name = "emanetlerToolStripMenuItem";
            this.emanetlerToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.emanetlerToolStripMenuItem.Text = "Emanetler";
            this.emanetlerToolStripMenuItem.Click += new System.EventHandler(this.emanetlerToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            this.raporlarToolStripMenuItem.Click += new System.EventHandler(this.raporlarToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 673);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1333, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 20);
            this.toolStripStatusLabel1.Text = "Hazır";
            // 
            // btnManageBooks
            // 
            this.btnManageBooks.Location = new System.Drawing.Point(0, 0);
            this.btnManageBooks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Size = new System.Drawing.Size(100, 28);
            this.btnManageBooks.TabIndex = 5;
            this.btnManageBooks.Visible = false;
            this.btnManageBooks.Click += new System.EventHandler(this.btnManageBooks_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(0, 0);
            this.btnManageUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(100, 28);
            this.btnManageUsers.TabIndex = 6;
            this.btnManageUsers.Visible = false;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(0, 0);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(100, 28);
            this.btnReports.TabIndex = 7;
            this.btnReports.Visible = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 8;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 699);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnManageBooks);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnExit);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kütüphane Yönetim Sistemi - Admin Panel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Button btnRezervasyonlar;
        private System.Windows.Forms.Button btnKullanicilar;
        private System.Windows.Forms.Button btnEmanetler;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Button btnKitaplar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblOduncKitap;
        private System.Windows.Forms.Label lblAktifUye;
        private System.Windows.Forms.Label lblToplamKitap;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yönetimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitaplarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emanetlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        // Eski button'lar (geriye dönük uyumluluk için)
        private System.Windows.Forms.Button btnManageBooks;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExit;
    }
}