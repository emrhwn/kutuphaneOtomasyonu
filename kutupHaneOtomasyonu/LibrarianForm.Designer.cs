namespace kutupHaneOtomasyonu
{
    partial class LibrarianForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelQuickStats = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.lblTotalMembers = new System.Windows.Forms.Label();
            this.lblTotalLoans = new System.Windows.Forms.Label();
            this.groupBoxBooks = new System.Windows.Forms.GroupBox();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.btnBookDetails = new System.Windows.Forms.Button();
            this.btnListBooks = new System.Windows.Forms.Button();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.groupBoxLoans = new System.Windows.Forms.GroupBox();
            this.btnLoanHistory = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnLoanBook = new System.Windows.Forms.Button();
            this.groupBoxMembers = new System.Windows.Forms.GroupBox();
            this.btnMemberReports = new System.Windows.Forms.Button();
            this.btnMemberDetails = new System.Windows.Forms.Button();
            this.groupBoxReservations = new System.Windows.Forms.GroupBox();
            this.btnUpdateReservation = new System.Windows.Forms.Button();
            this.btnCreateReservation = new System.Windows.Forms.Button();
            this.btnListReservations = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.panelQuickStats.SuspendLayout();
            this.groupBoxBooks.SuspendLayout();
            this.groupBoxLoans.SuspendLayout();
            this.groupBoxMembers.SuspendLayout();
            this.groupBoxReservations.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelHeader.Controls.Add(this.pictureBoxProfile);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProfile.Location = new System.Drawing.Point(30, 20);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 2;
            this.pictureBoxProfile.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(350, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "📚 KÜTÜPHANECİ PANELİ";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(400, 45);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 19);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Hoş geldiniz, [Kütüphaneci Adı]";
            // 
            // panelQuickStats
            // 
            this.panelQuickStats.BackColor = System.Drawing.Color.White;
            this.panelQuickStats.Controls.Add(this.label5);
            this.panelQuickStats.Controls.Add(this.lblTotalBooks);
            this.panelQuickStats.Controls.Add(this.lblTotalMembers);
            this.panelQuickStats.Controls.Add(this.lblTotalLoans);
            this.panelQuickStats.Location = new System.Drawing.Point(30, 100);
            this.panelQuickStats.Name = "panelQuickStats";
            this.panelQuickStats.Padding = new System.Windows.Forms.Padding(20);
            this.panelQuickStats.Size = new System.Drawing.Size(940, 80);
            this.panelQuickStats.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(20, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "📊 Hızlı Durum";
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalBooks.ForeColor = System.Drawing.Color.White;
            this.lblTotalBooks.Location = new System.Drawing.Point(200, 40);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(150, 25);
            this.lblTotalBooks.TabIndex = 1;
            this.lblTotalBooks.Text = "📚 Toplam Kitap: 1,250";
            this.lblTotalBooks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalMembers.ForeColor = System.Drawing.Color.White;
            this.lblTotalMembers.Location = new System.Drawing.Point(370, 40);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(150, 25);
            this.lblTotalMembers.TabIndex = 2;
            this.lblTotalMembers.Text = "👤 Aktif Üye: 320";
            this.lblTotalMembers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalLoans
            // 
            this.lblTotalLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTotalLoans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalLoans.ForeColor = System.Drawing.Color.White;
            this.lblTotalLoans.Location = new System.Drawing.Point(540, 40);
            this.lblTotalLoans.Name = "lblTotalLoans";
            this.lblTotalLoans.Size = new System.Drawing.Size(150, 25);
            this.lblTotalLoans.TabIndex = 3;
            this.lblTotalLoans.Text = "📖 Ödünç: 185";
            this.lblTotalLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxBooks
            // 
            this.groupBoxBooks.BackColor = System.Drawing.Color.White;
            this.groupBoxBooks.Controls.Add(this.txtSearchBook);
            this.groupBoxBooks.Controls.Add(this.btnBookDetails);
            this.groupBoxBooks.Controls.Add(this.btnListBooks);
            this.groupBoxBooks.Controls.Add(this.btnSearchBook);
            this.groupBoxBooks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.groupBoxBooks.Location = new System.Drawing.Point(30, 200);
            this.groupBoxBooks.Name = "groupBoxBooks";
            this.groupBoxBooks.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxBooks.Size = new System.Drawing.Size(450, 160);
            this.groupBoxBooks.TabIndex = 2;
            this.groupBoxBooks.TabStop = false;
            this.groupBoxBooks.Text = "📚 Kitap İşlemleri";
            // 
            // btnSearchBook
            // 
            this.btnSearchBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearchBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearchBook.ForeColor = System.Drawing.Color.White;
            this.btnSearchBook.Location = new System.Drawing.Point(20, 40);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(120, 35);
            this.btnSearchBook.TabIndex = 0;
            this.btnSearchBook.Text = "🔍 Kitap Ara";
            this.btnSearchBook.UseVisualStyleBackColor = false;
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);
            // 
            // txtSearchBook
            // 
            this.txtSearchBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSearchBook.Location = new System.Drawing.Point(160, 45);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(270, 25);
            this.txtSearchBook.TabIndex = 1;
            // PlaceholderText satırı kaldırıldı
            // 
            // btnListBooks
            // 
            this.btnListBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnListBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListBooks.ForeColor = System.Drawing.Color.White;
            this.btnListBooks.Location = new System.Drawing.Point(20, 90);
            this.btnListBooks.Name = "btnListBooks";
            this.btnListBooks.Size = new System.Drawing.Size(180, 35);
            this.btnListBooks.TabIndex = 2;
            this.btnListBooks.Text = "📋 Kitapları Listele";
            this.btnListBooks.UseVisualStyleBackColor = false;
            this.btnListBooks.Click += new System.EventHandler(this.btnListBooks_Click);
            // 
            // btnBookDetails
            // 
            this.btnBookDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBookDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBookDetails.ForeColor = System.Drawing.Color.White;
            this.btnBookDetails.Location = new System.Drawing.Point(230, 90);
            this.btnBookDetails.Name = "btnBookDetails";
            this.btnBookDetails.Size = new System.Drawing.Size(180, 35);
            this.btnBookDetails.TabIndex = 3;
            this.btnBookDetails.Text = "📖 Kitap Detayları";
            this.btnBookDetails.UseVisualStyleBackColor = false;
            this.btnBookDetails.Click += new System.EventHandler(this.btnBookDetails_Click);
            // 
            // groupBoxLoans
            // 
            this.groupBoxLoans.BackColor = System.Drawing.Color.White;
            this.groupBoxLoans.Controls.Add(this.btnLoanHistory);
            this.groupBoxLoans.Controls.Add(this.btnReturnBook);
            this.groupBoxLoans.Controls.Add(this.btnLoanBook);
            this.groupBoxLoans.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxLoans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.groupBoxLoans.Location = new System.Drawing.Point(520, 200);
            this.groupBoxLoans.Name = "groupBoxLoans";
            this.groupBoxLoans.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxLoans.Size = new System.Drawing.Size(450, 160);
            this.groupBoxLoans.TabIndex = 3;
            this.groupBoxLoans.TabStop = false;
            this.groupBoxLoans.Text = "📖 Ödünç İşlemleri";
            // 
            // btnLoanBook
            // 
            this.btnLoanBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLoanBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoanBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoanBook.ForeColor = System.Drawing.Color.White;
            this.btnLoanBook.Location = new System.Drawing.Point(20, 40);
            this.btnLoanBook.Name = "btnLoanBook";
            this.btnLoanBook.Size = new System.Drawing.Size(180, 35);
            this.btnLoanBook.TabIndex = 0;
            this.btnLoanBook.Text = "📚➡️ Ödünç Ver";
            this.btnLoanBook.UseVisualStyleBackColor = false;
            this.btnLoanBook.Click += new System.EventHandler(this.btnLoanBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReturnBook.ForeColor = System.Drawing.Color.White;
            this.btnReturnBook.Location = new System.Drawing.Point(230, 40);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(180, 35);
            this.btnReturnBook.TabIndex = 1;
            this.btnReturnBook.Text = "📚⬅️ İade Al";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnLoanHistory
            // 
            this.btnLoanHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnLoanHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoanHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoanHistory.ForeColor = System.Drawing.Color.White;
            this.btnLoanHistory.Location = new System.Drawing.Point(125, 90);
            this.btnLoanHistory.Name = "btnLoanHistory";
            this.btnLoanHistory.Size = new System.Drawing.Size(200, 35);
            this.btnLoanHistory.TabIndex = 2;
            this.btnLoanHistory.Text = "📊 Ödünç Geçmişi";
            this.btnLoanHistory.UseVisualStyleBackColor = false;
            this.btnLoanHistory.Click += new System.EventHandler(this.btnLoanHistory_Click);
            // 
            // groupBoxMembers
            // 
            this.groupBoxMembers.BackColor = System.Drawing.Color.White;
            this.groupBoxMembers.Controls.Add(this.btnMemberReports);
            this.groupBoxMembers.Controls.Add(this.btnMemberDetails);
            this.groupBoxMembers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxMembers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.groupBoxMembers.Location = new System.Drawing.Point(30, 380);
            this.groupBoxMembers.Name = "groupBoxMembers";
            this.groupBoxMembers.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxMembers.Size = new System.Drawing.Size(450, 100);
            this.groupBoxMembers.TabIndex = 4;
            this.groupBoxMembers.TabStop = false;
            this.groupBoxMembers.Text = "👤 Üye İşlemleri";
            // 
            // btnMemberDetails
            // 
            this.btnMemberDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnMemberDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMemberDetails.ForeColor = System.Drawing.Color.White;
            this.btnMemberDetails.Location = new System.Drawing.Point(20, 40);
            this.btnMemberDetails.Name = "btnMemberDetails";
            this.btnMemberDetails.Size = new System.Drawing.Size(180, 35);
            this.btnMemberDetails.TabIndex = 0;
            this.btnMemberDetails.Text = "👤 Üye Detayları";
            this.btnMemberDetails.UseVisualStyleBackColor = false;
            this.btnMemberDetails.Click += new System.EventHandler(this.btnMemberDetails_Click);
            // 
            // btnMemberReports
            // 
            this.btnMemberReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnMemberReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMemberReports.ForeColor = System.Drawing.Color.White;
            this.btnMemberReports.Location = new System.Drawing.Point(230, 40);
            this.btnMemberReports.Name = "btnMemberReports";
            this.btnMemberReports.Size = new System.Drawing.Size(180, 35);
            this.btnMemberReports.TabIndex = 1;
            this.btnMemberReports.Text = "📈 Üye Raporları";
            this.btnMemberReports.UseVisualStyleBackColor = false;
            this.btnMemberReports.Click += new System.EventHandler(this.btnMemberReports_Click);
            // 
            // groupBoxReservations
            // 
            this.groupBoxReservations.BackColor = System.Drawing.Color.White;
            this.groupBoxReservations.Controls.Add(this.btnUpdateReservation);
            this.groupBoxReservations.Controls.Add(this.btnCreateReservation);
            this.groupBoxReservations.Controls.Add(this.btnListReservations);
            this.groupBoxReservations.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.groupBoxReservations.Location = new System.Drawing.Point(520, 380);
            this.groupBoxReservations.Name = "groupBoxReservations";
            this.groupBoxReservations.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxReservations.Size = new System.Drawing.Size(450, 140);
            this.groupBoxReservations.TabIndex = 5;
            this.groupBoxReservations.TabStop = false;
            this.groupBoxReservations.Text = "🔖 Rezervasyon İşlemleri";
            // 
            // btnListReservations
            // 
            this.btnListReservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnListReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListReservations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListReservations.ForeColor = System.Drawing.Color.White;
            this.btnListReservations.Location = new System.Drawing.Point(20, 40);
            this.btnListReservations.Name = "btnListReservations";
            this.btnListReservations.Size = new System.Drawing.Size(200, 35);
            this.btnListReservations.TabIndex = 0;
            this.btnListReservations.Text = "📋 Rezervasyonları Listele";
            this.btnListReservations.UseVisualStyleBackColor = false;
            this.btnListReservations.Click += new System.EventHandler(this.btnListReservations_Click);
            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnCreateReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreateReservation.ForeColor = System.Drawing.Color.White;
            this.btnCreateReservation.Location = new System.Drawing.Point(20, 85);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new System.Drawing.Size(180, 35);
            this.btnCreateReservation.TabIndex = 1;
            this.btnCreateReservation.Text = "➕ Rezervasyon Yap";
            this.btnCreateReservation.UseVisualStyleBackColor = false;
            this.btnCreateReservation.Click += new System.EventHandler(this.btnCreateReservation_Click);
            // 
            // btnUpdateReservation
            // 
            this.btnUpdateReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnUpdateReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateReservation.ForeColor = System.Drawing.Color.White;
            this.btnUpdateReservation.Location = new System.Drawing.Point(230, 85);
            this.btnUpdateReservation.Name = "btnUpdateReservation";
            this.btnUpdateReservation.Size = new System.Drawing.Size(180, 35);
            this.btnUpdateReservation.TabIndex = 2;
            this.btnUpdateReservation.Text = "🔄 Rezervasyon Güncelle";
            this.btnUpdateReservation.UseVisualStyleBackColor = false;
            this.btnUpdateReservation.Click += new System.EventHandler(this.btnUpdateReservation_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelFooter.Controls.Add(this.btnExit);
            this.panelFooter.Controls.Add(this.btnReports);
            this.panelFooter.Controls.Add(this.btnSettings);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 540);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1000, 60);
            this.panelFooter.TabIndex = 6;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(30, 15);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 30);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "⚙️ Ayarlar";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(170, 15);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(120, 30);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "📊 Raporlar";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(850, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "🚪 Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LibrarianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.groupBoxReservations);
            this.Controls.Add(this.groupBoxMembers);
            this.Controls.Add(this.groupBoxLoans);
            this.Controls.Add(this.groupBoxBooks);
            this.Controls.Add(this.panelQuickStats);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LibrarianForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kütüphaneci Yönetim Paneli";
            this.Load += new System.EventHandler(this.LibrarianForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.panelQuickStats.ResumeLayout(false);
            this.panelQuickStats.PerformLayout();
            this.groupBoxBooks.ResumeLayout(false);
            this.groupBoxBooks.PerformLayout();
            this.groupBoxLoans.ResumeLayout(false);
            this.groupBoxMembers.ResumeLayout(false);
            this.groupBoxReservations.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelQuickStats;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblTotalMembers;
        private System.Windows.Forms.Label lblTotalLoans;
        private System.Windows.Forms.GroupBox groupBoxBooks;
        private System.Windows.Forms.TextBox txtSearchBook;
        private System.Windows.Forms.Button btnBookDetails;
        private System.Windows.Forms.Button btnListBooks;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.GroupBox groupBoxLoans;
        private System.Windows.Forms.Button btnLoanHistory;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnLoanBook;
        private System.Windows.Forms.GroupBox groupBoxMembers;
        private System.Windows.Forms.Button btnMemberReports;
        private System.Windows.Forms.Button btnMemberDetails;
        private System.Windows.Forms.GroupBox groupBoxReservations;
        private System.Windows.Forms.Button btnUpdateReservation;
        private System.Windows.Forms.Button btnCreateReservation;
        private System.Windows.Forms.Button btnListReservations;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSettings;
    }
}