namespace kutupHaneOtomasyonu
{
    partial class CreateReservationForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtAvailableCopies = new System.Windows.Forms.TextBox();
            this.btnSelectBook = new System.Windows.Forms.Button();
            this.groupBoxMember = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtMemberStatus = new System.Windows.Forms.TextBox();
            this.btnSelectMember = new System.Windows.Forms.Button();
            this.groupBoxReservation = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtReservationId = new System.Windows.Forms.TextBox();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnNewReservation = new System.Windows.Forms.Button();
            this.btnExistingReservation = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.groupBoxBook.SuspendLayout();
            this.groupBoxMember.SuspendLayout();
            this.groupBoxReservation.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1049, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(300, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "REZERVASYON İŞLEMLERİ";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlMain.Controls.Add(this.groupBoxBook);
            this.pnlMain.Controls.Add(this.groupBoxMember);
            this.pnlMain.Controls.Add(this.groupBoxReservation);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1049, 528);
            this.pnlMain.TabIndex = 1;
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.BackColor = System.Drawing.Color.White;
            this.groupBoxBook.Controls.Add(this.label3);
            this.groupBoxBook.Controls.Add(this.label4);
            this.groupBoxBook.Controls.Add(this.label5);
            this.groupBoxBook.Controls.Add(this.label6);
            this.groupBoxBook.Controls.Add(this.txtBookId);
            this.groupBoxBook.Controls.Add(this.txtBookTitle);
            this.groupBoxBook.Controls.Add(this.txtAuthor);
            this.groupBoxBook.Controls.Add(this.txtAvailableCopies);
            this.groupBoxBook.Controls.Add(this.btnSelectBook);
            this.groupBoxBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.groupBoxBook.Location = new System.Drawing.Point(20, 20);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Size = new System.Drawing.Size(460, 220);
            this.groupBoxBook.TabIndex = 0;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "Kitap Bilgileri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(20, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kitap ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(20, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Kitap Adı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(20, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yazar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.Location = new System.Drawing.Point(20, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mevcut Kopya:";
            // 
            // txtBookId
            // 
            this.txtBookId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBookId.Location = new System.Drawing.Point(130, 37);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(220, 30);
            this.txtBookId.TabIndex = 2;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBookTitle.Location = new System.Drawing.Point(130, 72);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.ReadOnly = true;
            this.txtBookTitle.Size = new System.Drawing.Size(220, 30);
            this.txtBookTitle.TabIndex = 2;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAuthor.Location = new System.Drawing.Point(130, 107);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(220, 30);
            this.txtAuthor.TabIndex = 2;
            // 
            // txtAvailableCopies
            // 
            this.txtAvailableCopies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAvailableCopies.Location = new System.Drawing.Point(130, 142);
            this.txtAvailableCopies.Name = "txtAvailableCopies";
            this.txtAvailableCopies.ReadOnly = true;
            this.txtAvailableCopies.Size = new System.Drawing.Size(220, 30);
            this.txtAvailableCopies.TabIndex = 2;
            // 
            // btnSelectBook
            // 
            this.btnSelectBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSelectBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSelectBook.ForeColor = System.Drawing.Color.White;
            this.btnSelectBook.Location = new System.Drawing.Point(356, 37);
            this.btnSelectBook.Name = "btnSelectBook";
            this.btnSelectBook.Size = new System.Drawing.Size(85, 30);
            this.btnSelectBook.TabIndex = 5;
            this.btnSelectBook.Text = "Kitap Seç";
            this.btnSelectBook.UseVisualStyleBackColor = false;
            // 
            // groupBoxMember
            // 
            this.groupBoxMember.BackColor = System.Drawing.Color.White;
            this.groupBoxMember.Controls.Add(this.label8);
            this.groupBoxMember.Controls.Add(this.label9);
            this.groupBoxMember.Controls.Add(this.label10);
            this.groupBoxMember.Controls.Add(this.txtMemberId);
            this.groupBoxMember.Controls.Add(this.txtMemberName);
            this.groupBoxMember.Controls.Add(this.txtMemberStatus);
            this.groupBoxMember.Controls.Add(this.btnSelectMember);
            this.groupBoxMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.groupBoxMember.Location = new System.Drawing.Point(20, 260);
            this.groupBoxMember.Name = "groupBoxMember";
            this.groupBoxMember.Size = new System.Drawing.Size(460, 180);
            this.groupBoxMember.TabIndex = 0;
            this.groupBoxMember.TabStop = false;
            this.groupBoxMember.Text = "Üye Bilgileri";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(20, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Üye ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.Location = new System.Drawing.Point(20, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 23);
            this.label9.TabIndex = 1;
            this.label9.Text = "Üye Adı:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.Location = new System.Drawing.Point(20, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 23);
            this.label10.TabIndex = 1;
            this.label10.Text = "Üye Durumu:";
            // 
            // txtMemberId
            // 
            this.txtMemberId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMemberId.Location = new System.Drawing.Point(130, 37);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(220, 30);
            this.txtMemberId.TabIndex = 2;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMemberName.Location = new System.Drawing.Point(130, 72);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.ReadOnly = true;
            this.txtMemberName.Size = new System.Drawing.Size(220, 30);
            this.txtMemberName.TabIndex = 2;
            // 
            // txtMemberStatus
            // 
            this.txtMemberStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMemberStatus.Location = new System.Drawing.Point(130, 107);
            this.txtMemberStatus.Name = "txtMemberStatus";
            this.txtMemberStatus.ReadOnly = true;
            this.txtMemberStatus.Size = new System.Drawing.Size(220, 30);
            this.txtMemberStatus.TabIndex = 2;
            // 
            // btnSelectMember
            // 
            this.btnSelectMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSelectMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMember.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSelectMember.ForeColor = System.Drawing.Color.White;
            this.btnSelectMember.Location = new System.Drawing.Point(356, 37);
            this.btnSelectMember.Name = "btnSelectMember";
            this.btnSelectMember.Size = new System.Drawing.Size(85, 30);
            this.btnSelectMember.TabIndex = 5;
            this.btnSelectMember.Text = "Üye Seç";
            this.btnSelectMember.UseVisualStyleBackColor = false;
            // 
            // groupBoxReservation
            // 
            this.groupBoxReservation.BackColor = System.Drawing.Color.White;
            this.groupBoxReservation.Controls.Add(this.label16);
            this.groupBoxReservation.Controls.Add(this.label12);
            this.groupBoxReservation.Controls.Add(this.label13);
            this.groupBoxReservation.Controls.Add(this.label14);
            this.groupBoxReservation.Controls.Add(this.label15);
            this.groupBoxReservation.Controls.Add(this.txtReservationId);
            this.groupBoxReservation.Controls.Add(this.dtpReservationDate);
            this.groupBoxReservation.Controls.Add(this.dtpExpectedDate);
            this.groupBoxReservation.Controls.Add(this.cmbStatus);
            this.groupBoxReservation.Controls.Add(this.txtNotes);
            this.groupBoxReservation.Controls.Add(this.btnNewReservation);
            this.groupBoxReservation.Controls.Add(this.btnExistingReservation);
            this.groupBoxReservation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.groupBoxReservation.Location = new System.Drawing.Point(500, 20);
            this.groupBoxReservation.Name = "groupBoxReservation";
            this.groupBoxReservation.Size = new System.Drawing.Size(480, 420);
            this.groupBoxReservation.TabIndex = 0;
            this.groupBoxReservation.TabStop = false;
            this.groupBoxReservation.Text = "Rezervasyon Bilgileri";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label16.Location = new System.Drawing.Point(20, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 23);
            this.label16.TabIndex = 1;
            this.label16.Text = "Rezervasyon ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(20, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 23);
            this.label12.TabIndex = 1;
            this.label12.Text = "Rezervasyon Tarihi:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.Location = new System.Drawing.Point(20, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 23);
            this.label13.TabIndex = 1;
            this.label13.Text = "Beklenen Teslim:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label14.Location = new System.Drawing.Point(20, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 23);
            this.label14.TabIndex = 1;
            this.label14.Text = "Durum:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label15.Location = new System.Drawing.Point(20, 215);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 23);
            this.label15.TabIndex = 1;
            this.label15.Text = "Notlar:";
            // 
            // txtReservationId
            // 
            this.txtReservationId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtReservationId.Location = new System.Drawing.Point(160, 37);
            this.txtReservationId.Name = "txtReservationId";
            this.txtReservationId.Size = new System.Drawing.Size(220, 30);
            this.txtReservationId.TabIndex = 2;
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpReservationDate.Location = new System.Drawing.Point(160, 107);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(290, 30);
            this.dtpReservationDate.TabIndex = 3;
            // 
            // dtpExpectedDate
            // 
            this.dtpExpectedDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpExpectedDate.Location = new System.Drawing.Point(160, 142);
            this.dtpExpectedDate.Name = "dtpExpectedDate";
            this.dtpExpectedDate.Size = new System.Drawing.Size(290, 30);
            this.dtpExpectedDate.TabIndex = 3;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Beklemede",
            "Tamamlandı",
            "İptal"});
            this.cmbStatus.Location = new System.Drawing.Point(160, 177);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(290, 31);
            this.cmbStatus.TabIndex = 4;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(160, 212);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(290, 80);
            this.txtNotes.TabIndex = 2;
            // 
            // btnNewReservation
            // 
            this.btnNewReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNewReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewReservation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNewReservation.ForeColor = System.Drawing.Color.White;
            this.btnNewReservation.Location = new System.Drawing.Point(160, 70);
            this.btnNewReservation.Name = "btnNewReservation";
            this.btnNewReservation.Size = new System.Drawing.Size(140, 30);
            this.btnNewReservation.TabIndex = 5;
            this.btnNewReservation.Text = "Yeni Rezervasyon";
            this.btnNewReservation.UseVisualStyleBackColor = false;
            // 
            // btnExistingReservation
            // 
            this.btnExistingReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnExistingReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExistingReservation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExistingReservation.ForeColor = System.Drawing.Color.White;
            this.btnExistingReservation.Location = new System.Drawing.Point(310, 70);
            this.btnExistingReservation.Name = "btnExistingReservation";
            this.btnExistingReservation.Size = new System.Drawing.Size(140, 30);
            this.btnExistingReservation.TabIndex = 5;
            this.btnExistingReservation.Text = "Mevcut Rezervasyon";
            this.btnExistingReservation.UseVisualStyleBackColor = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 608);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1049, 80);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(280, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(420, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(560, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(700, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // CreateReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 688);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CreateReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervasyon İşlemleri";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            this.groupBoxMember.ResumeLayout(false);
            this.groupBoxMember.PerformLayout();
            this.groupBoxReservation.ResumeLayout(false);
            this.groupBoxReservation.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.GroupBox groupBoxMember;
        private System.Windows.Forms.GroupBox groupBoxReservation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtAvailableCopies;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.TextBox txtMemberStatus;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtReservationId;
        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedDate;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSelectBook;
        private System.Windows.Forms.Button btnSelectMember;
        private System.Windows.Forms.Button btnNewReservation;
        private System.Windows.Forms.Button btnExistingReservation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
    }
}