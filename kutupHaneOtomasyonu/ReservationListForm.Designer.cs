namespace kutupHaneOtomasyonu.Forms
{
    partial class ReservationListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalReservations = new System.Windows.Forms.Label();
            this.lblActiveReservations = new System.Windows.Forms.Label();
            this.lblExpiredReservations = new System.Windows.Forms.Label();
            this.lblCompletedReservations = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnCompleteReservation = new System.Windows.Forms.Button();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.btnNewReservation = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblFormTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(920, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✖ Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(20, 17);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(305, 37);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "📋 Rezervasyon Listesi";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelFilter.Controls.Add(this.lblInfo);
            this.panelFilter.Controls.Add(this.btnRefresh);
            this.panelFilter.Controls.Add(this.cmbStatus);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.lblUserInfo);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(20);
            this.panelFilter.Size = new System.Drawing.Size(1000, 100);
            this.panelFilter.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblInfo.Location = new System.Drawing.Point(684, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(304, 19);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "ℹ️ Sadece sizin oluşturduğunuz rezervasyonlar";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(900, 50);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄 Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Tümü",
            "Aktif",
            "Süresi Dolmuş",
            "Tamamlandı",
            "İptal Edildi"});
            this.cmbStatus.Location = new System.Drawing.Point(650, 53);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 31);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(120, 53);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 30);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(590, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Durum:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Arama (Üye):";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblUserInfo.Location = new System.Drawing.Point(20, 25);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(194, 20);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "👤 Kullanıcı: [Yükleniyor...]";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.White;
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.tableLayoutPanel1);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 160);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(20);
            this.panelStats.Size = new System.Drawing.Size(1000, 100);
            this.panelStats.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalReservations, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblActiveReservations, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblExpiredReservations, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCompletedReservations, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(958, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(51, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Toplam (Kendiniz)";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.label4.Location = new System.Drawing.Point(309, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Aktif Olanlar";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(543, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Süresi Dolmuş";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label6.Location = new System.Drawing.Point(790, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tamamlandı";
            // 
            // lblTotalReservations
            // 
            this.lblTotalReservations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalReservations.AutoSize = true;
            this.lblTotalReservations.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTotalReservations.Location = new System.Drawing.Point(102, 23);
            this.lblTotalReservations.Name = "lblTotalReservations";
            this.lblTotalReservations.Size = new System.Drawing.Size(35, 35);
            this.lblTotalReservations.TabIndex = 4;
            this.lblTotalReservations.Text = "0";
            // 
            // lblActiveReservations
            // 
            this.lblActiveReservations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActiveReservations.AutoSize = true;
            this.lblActiveReservations.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblActiveReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblActiveReservations.Location = new System.Drawing.Point(341, 23);
            this.lblActiveReservations.Name = "lblActiveReservations";
            this.lblActiveReservations.Size = new System.Drawing.Size(35, 35);
            this.lblActiveReservations.TabIndex = 5;
            this.lblActiveReservations.Text = "0";
            // 
            // lblExpiredReservations
            // 
            this.lblExpiredReservations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblExpiredReservations.AutoSize = true;
            this.lblExpiredReservations.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblExpiredReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblExpiredReservations.Location = new System.Drawing.Point(580, 23);
            this.lblExpiredReservations.Name = "lblExpiredReservations";
            this.lblExpiredReservations.Size = new System.Drawing.Size(35, 35);
            this.lblExpiredReservations.TabIndex = 6;
            this.lblExpiredReservations.Text = "0";
            // 
            // lblCompletedReservations
            // 
            this.lblCompletedReservations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCompletedReservations.AutoSize = true;
            this.lblCompletedReservations.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCompletedReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblCompletedReservations.Location = new System.Drawing.Point(820, 23);
            this.lblCompletedReservations.Name = "lblCompletedReservations";
            this.lblCompletedReservations.Size = new System.Drawing.Size(35, 35);
            this.lblCompletedReservations.TabIndex = 7;
            this.lblCompletedReservations.Text = "0";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvReservations);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 260);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1000, 360);
            this.panelMain.TabIndex = 3;
            // 
            // dgvReservations
            // 
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservations.Location = new System.Drawing.Point(20, 20);
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.RowHeadersWidth = 25;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.Size = new System.Drawing.Size(960, 320);
            this.dgvReservations.TabIndex = 0;
            this.dgvReservations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservations_CellDoubleClick);
            this.dgvReservations.SelectionChanged += new System.EventHandler(this.dgvReservations_SelectionChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelBottom.Controls.Add(this.lblRecordCount);
            this.panelBottom.Controls.Add(this.btnCompleteReservation);
            this.panelBottom.Controls.Add(this.btnCancelReservation);
            this.panelBottom.Controls.Add(this.btnNewReservation);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 620);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(20);
            this.panelBottom.Size = new System.Drawing.Size(1000, 80);
            this.panelBottom.TabIndex = 4;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRecordCount.Location = new System.Drawing.Point(20, 32);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(321, 23);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Toplam: 0 rezervasyon (Kendi kayıtlarınız)";
            // 
            // btnCompleteReservation
            // 
            this.btnCompleteReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompleteReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnCompleteReservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompleteReservation.Enabled = false;
            this.btnCompleteReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteReservation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCompleteReservation.ForeColor = System.Drawing.Color.White;
            this.btnCompleteReservation.Location = new System.Drawing.Point(660, 25);
            this.btnCompleteReservation.Name = "btnCompleteReservation";
            this.btnCompleteReservation.Size = new System.Drawing.Size(120, 35);
            this.btnCompleteReservation.TabIndex = 2;
            this.btnCompleteReservation.Text = "✅ Tamamla";
            this.btnCompleteReservation.UseVisualStyleBackColor = false;
            this.btnCompleteReservation.Click += new System.EventHandler(this.btnCompleteReservation_Click);
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelReservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelReservation.Enabled = false;
            this.btnCancelReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelReservation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelReservation.ForeColor = System.Drawing.Color.White;
            this.btnCancelReservation.Location = new System.Drawing.Point(790, 25);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(100, 35);
            this.btnCancelReservation.TabIndex = 3;
            this.btnCancelReservation.Text = "❌ İptal Et";
            this.btnCancelReservation.UseVisualStyleBackColor = false;
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
            // 
            // btnNewReservation
            // 
            this.btnNewReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnNewReservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewReservation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNewReservation.ForeColor = System.Drawing.Color.White;
            this.btnNewReservation.Location = new System.Drawing.Point(900, 25);
            this.btnNewReservation.Name = "btnNewReservation";
            this.btnNewReservation.Size = new System.Drawing.Size(80, 35);
            this.btnNewReservation.TabIndex = 1;
            this.btnNewReservation.Text = "➕ Yeni";
            this.btnNewReservation.UseVisualStyleBackColor = false;
            this.btnNewReservation.Click += new System.EventHandler(this.btnNewReservation_Click);
            // 
            // ReservationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ReservationListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rezervasyon Listesi - Kendi Kayıtlarım";
            this.Load += new System.EventHandler(this.ReservationListForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalReservations;
        private System.Windows.Forms.Label lblActiveReservations;
        private System.Windows.Forms.Label lblExpiredReservations;
        private System.Windows.Forms.Label lblCompletedReservations;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnCompleteReservation;
        private System.Windows.Forms.Button btnCancelReservation;
        private System.Windows.Forms.Button btnNewReservation;
        private System.Windows.Forms.Label lblInfo;
    }
}