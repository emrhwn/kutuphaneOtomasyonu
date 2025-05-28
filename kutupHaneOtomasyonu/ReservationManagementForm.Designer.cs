namespace kutupHaneOtomasyonu
{
    partial class ReservationManagementForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnNewReservation = new System.Windows.Forms.Button();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.btnSelectBook = new System.Windows.Forms.Button();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblBookId = new System.Windows.Forms.Label();
            this.btnExistingReservation = new System.Windows.Forms.Button();
            this.lblReservationId = new System.Windows.Forms.Label();
            this.txtReservationId = new System.Windows.Forms.TextBox();
            this.btnFindReservation = new System.Windows.Forms.Button();
            this.groupBoxMember = new System.Windows.Forms.GroupBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.btnSelectMember = new System.Windows.Forms.Button();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.groupBoxReservation = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.dtpExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblExpectedDate = new System.Windows.Forms.Label();
            this.lblReservationDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.groupBoxBook.SuspendLayout();
            this.groupBoxMember.SuspendLayout();
            this.groupBoxReservation.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(350, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🗓️ Rezervasyon Yönetimi";
            // 
            // btnNewReservation
            // 
            this.btnNewReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNewReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNewReservation.ForeColor = System.Drawing.Color.White;
            this.btnNewReservation.Location = new System.Drawing.Point(200, 90);
            this.btnNewReservation.Name = "btnNewReservation";
            this.btnNewReservation.Size = new System.Drawing.Size(180, 35);
            this.btnNewReservation.TabIndex = 1;
            this.btnNewReservation.Text = "➕ Yeni Rezervasyon";
            this.btnNewReservation.UseVisualStyleBackColor = false;
            this.btnNewReservation.Click += new System.EventHandler(this.btnNewReservation_Click);
            // 
            // btnExistingReservation
            // 
            this.btnExistingReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnExistingReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExistingReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExistingReservation.ForeColor = System.Drawing.Color.White;
            this.btnExistingReservation.Location = new System.Drawing.Point(620, 90);
            this.btnExistingReservation.Name = "btnExistingReservation";
            this.btnExistingReservation.Size = new System.Drawing.Size(180, 35);
            this.btnExistingReservation.TabIndex = 2;
            this.btnExistingReservation.Text = "📝 Mevcut Rezervasyon";
            this.btnExistingReservation.UseVisualStyleBackColor = false;
            this.btnExistingReservation.Click += new System.EventHandler(this.btnExistingReservation_Click);
            // 
            // lblReservationId
            // 
            this.lblReservationId.AutoSize = true;
            this.lblReservationId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblReservationId.Location = new System.Drawing.Point(200, 145);
            this.lblReservationId.Name = "lblReservationId";
            this.lblReservationId.Size = new System.Drawing.Size(112, 19);
            this.lblReservationId.TabIndex = 3;
            this.lblReservationId.Text = "Rezervasyon ID:";
            // 
            // txtReservationId
            // 
            this.txtReservationId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtReservationId.Location = new System.Drawing.Point(330, 142);
            this.txtReservationId.Name = "txtReservationId";
            this.txtReservationId.Size = new System.Drawing.Size(150, 25);
            this.txtReservationId.TabIndex = 4;
            // 
            // btnFindReservation
            // 
            this.btnFindReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnFindReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFindReservation.ForeColor = System.Drawing.Color.White;
            this.btnFindReservation.Location = new System.Drawing.Point(500, 140);
            this.btnFindReservation.Name = "btnFindReservation";
            this.btnFindReservation.Size = new System.Drawing.Size(150, 30);
            this.btnFindReservation.TabIndex = 5;
            this.btnFindReservation.Text = "🔍 Rezervasyon Bul";
            this.btnFindReservation.UseVisualStyleBackColor = false;
            this.btnFindReservation.Click += new System.EventHandler(this.btnFindReservation_Click);
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.BackColor = System.Drawing.Color.White;
            this.groupBoxBook.Controls.Add(this.txtAuthor);
            this.groupBoxBook.Controls.Add(this.txtBookTitle);
            this.groupBoxBook.Controls.Add(this.txtBookId);
            this.groupBoxBook.Controls.Add(this.lblAuthor);
            this.groupBoxBook.Controls.Add(this.btnSelectBook);
            this.groupBoxBook.Controls.Add(this.lblBookTitle);
            this.groupBoxBook.Controls.Add(this.lblBookId);
            this.groupBoxBook.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.groupBoxBook.Location = new System.Drawing.Point(50, 190);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxBook.Size = new System.Drawing.Size(900, 120);
            this.groupBoxBook.TabIndex = 6;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "📚 Kitap Bilgileri";
            // 
            // lblBookId
            // 
            this.lblBookId.AutoSize = true;
            this.lblBookId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBookId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblBookId.Location = new System.Drawing.Point(30, 40);
            this.lblBookId.Name = "lblBookId";
            this.lblBookId.Size = new System.Drawing.Size(62, 19);
            this.lblBookId.TabIndex = 0;
            this.lblBookId.Text = "Kitap ID:";
            // 
            // txtBookId
            // 
            this.txtBookId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBookId.Location = new System.Drawing.Point(120, 37);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(150, 25);
            this.txtBookId.TabIndex = 1;
            // 
            // btnSelectBook
            // 
            this.btnSelectBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSelectBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectBook.ForeColor = System.Drawing.Color.White;
            this.btnSelectBook.Location = new System.Drawing.Point(290, 35);
            this.btnSelectBook.Name = "btnSelectBook";
            this.btnSelectBook.Size = new System.Drawing.Size(100, 28);
            this.btnSelectBook.TabIndex = 2;
            this.btnSelectBook.Text = "Kitap Seç";
            this.btnSelectBook.UseVisualStyleBackColor = false;
            this.btnSelectBook.Click += new System.EventHandler(this.btnSelectBook_Click);
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBookTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblBookTitle.Location = new System.Drawing.Point(420, 40);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(70, 19);
            this.lblBookTitle.TabIndex = 3;
            this.lblBookTitle.Text = "Kitap Adı:";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBookTitle.Location = new System.Drawing.Point(500, 37);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.ReadOnly = true;
            this.txtBookTitle.Size = new System.Drawing.Size(200, 25);
            this.txtBookTitle.TabIndex = 4;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblAuthor.Location = new System.Drawing.Point(30, 75);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(47, 19);
            this.lblAuthor.TabIndex = 5;
            this.lblAuthor.Text = "Yazar:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAuthor.Location = new System.Drawing.Point(120, 72);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(200, 25);
            this.txtAuthor.TabIndex = 6;
            // 
            // groupBoxMember
            // 
            this.groupBoxMember.BackColor = System.Drawing.Color.White;
            this.groupBoxMember.Controls.Add(this.txtMemberName);
            this.groupBoxMember.Controls.Add(this.txtMemberId);
            this.groupBoxMember.Controls.Add(this.btnSelectMember);
            this.groupBoxMember.Controls.Add(this.lblMemberName);
            this.groupBoxMember.Controls.Add(this.lblMemberId);
            this.groupBoxMember.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.groupBoxMember.Location = new System.Drawing.Point(50, 330);
            this.groupBoxMember.Name = "groupBoxMember";
            this.groupBoxMember.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxMember.Size = new System.Drawing.Size(900, 100);
            this.groupBoxMember.TabIndex = 7;
            this.groupBoxMember.TabStop = false;
            this.groupBoxMember.Text = "👤 Üye Bilgileri";
            // 
            // lblMemberId
            // 
            this.lblMemberId.AutoSize = true;
            this.lblMemberId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMemberId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblMemberId.Location = new System.Drawing.Point(30, 40);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(56, 19);
            this.lblMemberId.TabIndex = 0;
            this.lblMemberId.Text = "Üye ID:";
            // 
            // txtMemberId
            // 
            this.txtMemberId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMemberId.Location = new System.Drawing.Point(120, 37);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(150, 25);
            this.txtMemberId.TabIndex = 1;
            // 
            // btnSelectMember
            // 
            this.btnSelectMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSelectMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectMember.ForeColor = System.Drawing.Color.White;
            this.btnSelectMember.Location = new System.Drawing.Point(290, 35);
            this.btnSelectMember.Name = "btnSelectMember";
            this.btnSelectMember.Size = new System.Drawing.Size(100, 28);
            this.btnSelectMember.TabIndex = 2;
            this.btnSelectMember.Text = "Üye Seç";
            this.btnSelectMember.UseVisualStyleBackColor = false;
            this.btnSelectMember.Click += new System.EventHandler(this.btnSelectMember_Click);
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMemberName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblMemberName.Location = new System.Drawing.Point(420, 40);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(63, 19);
            this.lblMemberName.TabIndex = 3;
            this.lblMemberName.Text = "Üye Adı:";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMemberName.Location = new System.Drawing.Point(500, 37);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.ReadOnly = true;
            this.txtMemberName.Size = new System.Drawing.Size(200, 25);
            this.txtMemberName.TabIndex = 4;
            // 
            // groupBoxReservation
            // 
            this.groupBoxReservation.BackColor = System.Drawing.Color.White;
            this.groupBoxReservation.Controls.Add(this.cmbStatus);
            this.groupBoxReservation.Controls.Add(this.txtNotes);
            this.groupBoxReservation.Controls.Add(this.dtpExpectedDate);
            this.groupBoxReservation.Controls.Add(this.dtpReservationDate);
            this.groupBoxReservation.Controls.Add(this.lblNotes);
            this.groupBoxReservation.Controls.Add(this.lblStatus);
            this.groupBoxReservation.Controls.Add(this.lblExpectedDate);
            this.groupBoxReservation.Controls.Add(this.lblReservationDate);
            this.groupBoxReservation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.groupBoxReservation.Location = new System.Drawing.Point(50, 450);
            this.groupBoxReservation.Name = "groupBoxReservation";
            this.groupBoxReservation.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxReservation.Size = new System.Drawing.Size(900, 170);
            this.groupBoxReservation.TabIndex = 8;
            this.groupBoxReservation.TabStop = false;
            this.groupBoxReservation.Text = "🗓️ Rezervasyon Bilgileri";
            // 
            // lblReservationDate
            // 
            this.lblReservationDate.AutoSize = true;
            this.lblReservationDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblReservationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblReservationDate.Location = new System.Drawing.Point(30, 40);
            this.lblReservationDate.Name = "lblReservationDate";
            this.lblReservationDate.Size = new System.Drawing.Size(132, 19);
            this.lblReservationDate.TabIndex = 0;
            this.lblReservationDate.Text = "Rezervasyon Tarihi:";
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpReservationDate.Location = new System.Drawing.Point(180, 37);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(180, 25);
            this.dtpReservationDate.TabIndex = 1;
            // 
            // lblExpectedDate
            // 
            this.lblExpectedDate.AutoSize = true;
            this.lblExpectedDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblExpectedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblExpectedDate.Location = new System.Drawing.Point(400, 40);
            this.lblExpectedDate.Name = "lblExpectedDate";
            this.lblExpectedDate.Size = new System.Drawing.Size(114, 19);
            this.lblExpectedDate.TabIndex = 2;
            this.lblExpectedDate.Text = "Beklenen Teslim:";
            // 
            // dtpExpectedDate
            // 
            this.dtpExpectedDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpExpectedDate.Location = new System.Drawing.Point(530, 37);
            this.dtpExpectedDate.Name = "dtpExpectedDate";
            this.dtpExpectedDate.Size = new System.Drawing.Size(180, 25);
            this.dtpExpectedDate.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblStatus.Location = new System.Drawing.Point(30, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 19);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Durum:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Beklemede",
            "Tamamlandı",
            "İptal"});
            this.cmbStatus.Location = new System.Drawing.Point(100, 77);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbStatus.TabIndex = 5;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNotes.Location = new System.Drawing.Point(30, 120);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(50, 19);
            this.lblNotes.TabIndex = 6;
            this.lblNotes.Text = "Notlar:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNotes.Location = new System.Drawing.Point(100, 117);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(750, 35);
            this.txtNotes.TabIndex = 7;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnUpdate);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 640);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1000, 80);
            this.panelButtons.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(200, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "💾 Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(340, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "🔄 Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(480, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(620, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "❌ İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReservationManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxReservation);
            this.Controls.Add(this.groupBoxMember);
            this.Controls.Add(this.groupBoxBook);
            this.Controls.Add(this.btnFindReservation);
            this.Controls.Add(this.txtReservationId);
            this.Controls.Add(this.lblReservationId);
            this.Controls.Add(this.btnExistingReservation);
            this.Controls.Add(this.btnNewReservation);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReservationManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervasyon Yönetim Sistemi";
            this.Load += new System.EventHandler(this.ReservationManagementForm_Load);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            this.groupBoxMember.ResumeLayout(false);
            this.groupBoxMember.PerformLayout();
            this.groupBoxReservation.ResumeLayout(false);
            this.groupBoxReservation.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNewReservation;
        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Button btnSelectBook;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.Button btnExistingReservation;
        private System.Windows.Forms.Label lblReservationId;
        private System.Windows.Forms.TextBox txtReservationId;
        private System.Windows.Forms.Button btnFindReservation;
        private System.Windows.Forms.GroupBox groupBoxMember;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Button btnSelectMember;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.GroupBox groupBoxReservation;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DateTimePicker dtpExpectedDate;
        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblExpectedDate;
        private System.Windows.Forms.Label lblReservationDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelButtons;
    }
}