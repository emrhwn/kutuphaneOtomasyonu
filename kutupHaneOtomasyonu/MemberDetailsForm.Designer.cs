namespace kutupHaneOtomasyonu.Forms
{
    partial class MemberDetailsForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbMembers = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxLoans = new System.Windows.Forms.GroupBox();
            this.lblLoanCount = new System.Windows.Forms.Label();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalLoans = new System.Windows.Forms.Label();
            this.lblActiveLoans = new System.Windows.Forms.Label();
            this.lblOverdueLoans = new System.Windows.Forms.Label();
            this.lblTotalFines = new System.Windows.Forms.Label();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblMembershipDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnNewLoan = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.groupBoxStatistics.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblFormTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 60);
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
            this.btnClose.Location = new System.Drawing.Point(720, 15);
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
            this.lblFormTitle.Size = new System.Drawing.Size(152, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "👤 Üye Detayları";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.cmbMembers);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 60);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(20);
            this.panelSearch.Size = new System.Drawing.Size(800, 100);
            this.panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(700, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "🔍 Ara";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbMembers
            // 
            this.cmbMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMembers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMembers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMembers.FormattingEnabled = true;
            this.cmbMembers.Location = new System.Drawing.Point(150, 60);
            this.cmbMembers.Name = "cmbMembers";
            this.cmbMembers.Size = new System.Drawing.Size(540, 25);
            this.cmbMembers.TabIndex = 2;
            this.cmbMembers.SelectedIndexChanged += new System.EventHandler(this.cmbMembers_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(150, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(540, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSearch.Location = new System.Drawing.Point(20, 33);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(77, 20);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Üye Ara:";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxLoans);
            this.panelMain.Controls.Add(this.groupBoxStatistics);
            this.panelMain.Controls.Add(this.groupBoxDetails);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 160);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(800, 480);
            this.panelMain.TabIndex = 2;
            // 
            // groupBoxLoans
            // 
            this.groupBoxLoans.Controls.Add(this.lblLoanCount);
            this.groupBoxLoans.Controls.Add(this.dgvLoans);
            this.groupBoxLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLoans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxLoans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxLoans.Location = new System.Drawing.Point(20, 260);
            this.groupBoxLoans.Name = "groupBoxLoans";
            this.groupBoxLoans.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxLoans.Size = new System.Drawing.Size(760, 200);
            this.groupBoxLoans.TabIndex = 2;
            this.groupBoxLoans.TabStop = false;
            this.groupBoxLoans.Text = "📚 Ödünç Kayıtları";
            // 
            // lblLoanCount
            // 
            this.lblLoanCount.AutoSize = true;
            this.lblLoanCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLoanCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoanCount.Location = new System.Drawing.Point(15, 170);
            this.lblLoanCount.Name = "lblLoanCount";
            this.lblLoanCount.Size = new System.Drawing.Size(112, 15);
            this.lblLoanCount.TabIndex = 1;
            this.lblLoanCount.Text = "Toplam: 0 kayıt";
            // 
            // dgvLoans
            // 
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.Location = new System.Drawing.Point(15, 34);
            this.dgvLoans.MultiSelect = false;
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.RowHeadersWidth = 25;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(730, 151);
            this.dgvLoans.TabIndex = 0;
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxStatistics.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxStatistics.Location = new System.Drawing.Point(20, 140);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxStatistics.Size = new System.Drawing.Size(760, 120);
            this.groupBoxStatistics.TabIndex = 1;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "📊 İstatistikler";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalLoans, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblActiveLoans, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblOverdueLoans, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalFines, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 34);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(730, 71);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(54, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Toplam Ödünç";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(240, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Aktif Ödünç";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(418, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Geciken Kitap";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(617, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Toplam Ceza";
            // 
            // lblTotalLoans
            // 
            this.lblTotalLoans.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalLoans.AutoSize = true;
            this.lblTotalLoans.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalLoans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalLoans.Location = new System.Drawing.Point(90, 45);
            this.lblTotalLoans.Name = "lblTotalLoans";
            this.lblTotalLoans.Size = new System.Drawing.Size(21, 25);
            this.lblTotalLoans.TabIndex = 4;
            this.lblTotalLoans.Text = "0";
            // 
            // lblActiveLoans
            // 
            this.lblActiveLoans.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblActiveLoans.AutoSize = true;
            this.lblActiveLoans.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblActiveLoans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblActiveLoans.Location = new System.Drawing.Point(272, 45);
            this.lblActiveLoans.Name = "lblActiveLoans";
            this.lblActiveLoans.Size = new System.Drawing.Size(21, 25);
            this.lblActiveLoans.TabIndex = 5;
            this.lblActiveLoans.Text = "0";
            // 
            // lblOverdueLoans
            // 
            this.lblOverdueLoans.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOverdueLoans.AutoSize = true;
            this.lblOverdueLoans.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOverdueLoans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOverdueLoans.Location = new System.Drawing.Point(454, 45);
            this.lblOverdueLoans.Name = "lblOverdueLoans";
            this.lblOverdueLoans.Size = new System.Drawing.Size(21, 25);
            this.lblOverdueLoans.TabIndex = 6;
            this.lblOverdueLoans.Text = "0";
            // 
            // lblTotalFines
            // 
            this.lblTotalFines.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalFines.AutoSize = true;
            this.lblTotalFines.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalFines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTotalFines.Location = new System.Drawing.Point(638, 45);
            this.lblTotalFines.Name = "lblTotalFines";
            this.lblTotalFines.Size = new System.Drawing.Size(35, 25);
            this.lblTotalFines.TabIndex = 7;
            this.lblTotalFines.Text = "0₺";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxDetails.Location = new System.Drawing.Point(20, 20);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxDetails.Size = new System.Drawing.Size(760, 120);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "ℹ️ Üye Bilgileri";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLastName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPhone, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMembershipDate, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 71);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Soyad:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "E-mail:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(367, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefon:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(367, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Adres:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(367, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Üyelik Tarihi:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(367, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Durum:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFirstName.Location = new System.Drawing.Point(90, 1);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(12, 15);
            this.lblFirstName.TabIndex = 7;
            this.lblFirstName.Text = "-";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLastName.Location = new System.Drawing.Point(90, 18);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(12, 15);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "-";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.Location = new System.Drawing.Point(90, 35);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(12, 15);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "-";
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhone.Location = new System.Drawing.Point(454, 1);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(12, 15);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "-";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.Location = new System.Drawing.Point(454, 18);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(12, 15);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "-";
            // 
            // lblMembershipDate
            // 
            this.lblMembershipDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMembershipDate.AutoSize = true;
            this.lblMembershipDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMembershipDate.Location = new System.Drawing.Point(454, 35);
            this.lblMembershipDate.Name = "lblMembershipDate";
            this.lblMembershipDate.Size = new System.Drawing.Size(12, 15);
            this.lblMembershipDate.TabIndex = 12;
            this.lblMembershipDate.Text = "-";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblStatus.Location = new System.Drawing.Point(454, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(12, 15);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "-";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelBottom.Controls.Add(this.btnNewLoan);
            this.panelBottom.Controls.Add(this.btnEdit);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 640);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(20);
            this.panelBottom.Size = new System.Drawing.Size(800, 60);
            this.panelBottom.TabIndex = 3;
            // 
            // btnNewLoan
            // 
            this.btnNewLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewLoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNewLoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewLoan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNewLoan.ForeColor = System.Drawing.Color.White;
            this.btnNewLoan.Location = new System.Drawing.Point(580, 15);
            this.btnNewLoan.Name = "btnNewLoan";
            this.btnNewLoan.Size = new System.Drawing.Size(100, 35);
            this.btnNewLoan.TabIndex = 1;
            this.btnNewLoan.Text = "📚 Ödünç Ver";
            this.btnNewLoan.UseVisualStyleBackColor = false;
            this.btnNewLoan.Click += new System.EventHandler(this.btnNewLoan_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(690, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 35);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "✏️ Düzenle";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // MemberDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MemberDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Üye Detayları";
            this.Load += new System.EventHandler(this.MemberDetailsForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxLoans.ResumeLayout(false);
            this.groupBoxLoans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.groupBoxStatistics.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxDetails.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbMembers;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxLoans;
        private System.Windows.Forms.Label lblLoanCount;
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalLoans;
        private System.Windows.Forms.Label lblActiveLoans;
        private System.Windows.Forms.Label lblOverdueLoans;
        private System.Windows.Forms.Label lblTotalFines;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblMembershipDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnNewLoan;
        private System.Windows.Forms.Button btnEdit;
    }
}