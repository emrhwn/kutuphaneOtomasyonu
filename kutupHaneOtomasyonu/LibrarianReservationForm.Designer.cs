namespace kutupHaneOtomasyonu.Forms
{
    partial class LibrarianReservationForm
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
            this.panelUser = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxNewReservation = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxMyReservations = new System.Windows.Forms.GroupBox();
            this.lblMyReservationCount = new System.Windows.Forms.Label();
            this.dgvMyReservations = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelUser.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxNewReservation.SuspendLayout();
            this.groupBoxMyReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyReservations)).BeginInit();
            this.panelButtons.SuspendLayout();
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
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(20, 17);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(318, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "📋 Rezervasyon Yönetimi - Kendi";
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelUser.Controls.Add(this.lblMode);
            this.panelUser.Controls.Add(this.lblUserInfo);
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUser.Location = new System.Drawing.Point(0, 60);
            this.panelUser.Name = "panelUser";
            this.panelUser.Padding = new System.Windows.Forms.Padding(20);
            this.panelUser.Size = new System.Drawing.Size(800, 60);
            this.panelUser.TabIndex = 1;
            // 
            // lblMode
            // 
            this.lblMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblMode.Location = new System.Drawing.Point(600, 25);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(149, 19);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "Mod: Yeni Rezervasyon";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblUserInfo.Location = new System.Drawing.Point(20, 25);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(158, 19);
            this.lblUserInfo.TabIndex = 0;
            this.lblUserInfo.Text = "👤 Kullanıcı: [Yükleniyor...]";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 120);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(800, 480);
            this.panelMain.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 20);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxNewReservation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxMyReservations);
            this.splitContainer1.Size = new System.Drawing.Size(760, 440);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxNewReservation
            // 
            this.groupBoxNewReservation.BackColor = System.Drawing.Color.White;
            this.groupBoxNewReservation.Controls.Add(this.btnNew);
            this.groupBoxNewReservation.Controls.Add(this.label6);
            this.groupBoxNewReservation.Controls.Add(this.txtNotes);
            this.groupBoxNewReservation.Controls.Add(this.label5);
            this.groupBoxNewReservation.Controls.Add(this.label4);
            this.groupBoxNewReservation.Controls.Add(this.dtpExpiryDate);
            this.groupBoxNewReservation.Controls.Add(this.dtpReservationDate);
            this.groupBoxNewReservation.Controls.Add(this.label3);
            this.groupBoxNewReservation.Controls.Add(this.label2);
            this.groupBoxNewReservation.Controls.Add(this.cmbBook);
            this.groupBoxNewReservation.Controls.Add(this.cmbMember);
            this.groupBoxNewReservation.Controls.Add(this.label1);
            this.groupBoxNewReservation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNewReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxNewReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxNewReservation.Location = new System.Drawing.Point(0, 0);
            this.groupBoxNewReservation.Name = "groupBoxNewReservation";
            this.groupBoxNewReservation.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxNewReservation.Size = new System.Drawing.Size(760, 250);
            this.groupBoxNewReservation.TabIndex = 0;
            this.groupBoxNewReservation.TabStop = false;
            this.groupBoxNewReservation.Text = "📝 Rezervasyon Bilgileri";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(650, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 30);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "🆕 Yeni";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(400, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Notlar:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(403, 120);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(337, 100);
            this.txtNotes.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Son Geçerlilik:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rezervasyon Tarihi:";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpExpiryDate.Location = new System.Drawing.Point(150, 175);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(220, 23);
            this.dtpExpiryDate.TabIndex = 6;
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReservationDate.Location = new System.Drawing.Point(150, 135);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(220, 23);
            this.dtpReservationDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kitap:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Üye:";
            // 
            // cmbBook
            // 
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBook.FormattingEnabled = true;
            this.cmbBook.Location = new System.Drawing.Point(150, 95);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(220, 23);
            this.cmbBook.TabIndex = 2;
            this.cmbBook.SelectedIndexChanged += new System.EventHandler(this.cmbBook_SelectedIndexChanged);
            // 
            // cmbMember
            // 
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(150, 55);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(220, 23);
            this.cmbMember.TabIndex = 1;
            this.cmbMember.SelectedIndexChanged += new System.EventHandler(this.cmbMember_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(400, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ℹ️ Sadece stokta olmayan kitaplar gösterilir";
            // 
            // groupBoxMyReservations
            // 
            this.groupBoxMyReservations.BackColor = System.Drawing.Color.White;
            this.groupBoxMyReservations.Controls.Add(this.lblMyReservationCount);
            this.groupBoxMyReservations.Controls.Add(this.dgvMyReservations);
            this.groupBoxMyReservations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMyReservations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxMyReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.groupBoxMyReservations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMyReservations.Name = "groupBoxMyReservations";
            this.groupBoxMyReservations.Padding = new System.Windows.Forms.Padding(15);
            this.groupBoxMyReservations.Size = new System.Drawing.Size(760, 186);
            this.groupBoxMyReservations.TabIndex = 0;
            this.groupBoxMyReservations.TabStop = false;
            this.groupBoxMyReservations.Text = "📋 Benim Rezervasyonlarım";
            // 
            // lblMyReservationCount
            // 
            this.lblMyReservationCount.AutoSize = true;
            this.lblMyReservationCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMyReservationCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMyReservationCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblMyReservationCount.Location = new System.Drawing.Point(15, 156);
            this.lblMyReservationCount.Name = "lblMyReservationCount";
            this.lblMyReservationCount.Size = new System.Drawing.Size(247, 15);
            this.lblMyReservationCount.TabIndex = 1;
            this.lblMyReservationCount.Text = "Toplam: 0 rezervasyon (Sizin oluşturduğunuz)";
            // 
            // dgvMyReservations
            // 
            this.dgvMyReservations.AllowUserToAddRows = false;
            this.dgvMyReservations.AllowUserToDeleteRows = false;
            this.dgvMyReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyReservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyReservations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyReservations.Location = new System.Drawing.Point(15, 34);
            this.dgvMyReservations.MultiSelect = false;
            this.dgvMyReservations.Name = "dgvMyReservations";
            this.dgvMyReservations.ReadOnly = true;
            this.dgvMyReservations.RowHeadersWidth = 25;
            this.dgvMyReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyReservations.Size = new System.Drawing.Size(730, 137);
            this.dgvMyReservations.TabIndex = 0;
            this.dgvMyReservations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyReservations_CellDoubleClick);
            this.dgvMyReservations.SelectionChanged += new System.EventHandler(this.dgvMyReservations_SelectionChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 600);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20);
            this.panelButtons.Size = new System.Drawing.Size(800, 80);
            this.panelButtons.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(680, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "❌ Kapat";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(440, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Rezervasyon Oluştur";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(140, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(20, 25);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏️ Düzenle";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // LibrarianReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 680);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "LibrarianReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rezervasyon Yönetimi - Kendi Kayıtlarım";
            this.Load += new System.EventHandler(this.LibrarianReservationForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxNewReservation.ResumeLayout(false);
            this.groupBoxNewReservation.PerformLayout();
            this.groupBoxMyReservations.ResumeLayout(false);
            this.groupBoxMyReservations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyReservations)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxNewReservation;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxMyReservations;
        private System.Windows.Forms.Label lblMyReservationCount;
        private System.Windows.Forms.DataGridView dgvMyReservations;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}