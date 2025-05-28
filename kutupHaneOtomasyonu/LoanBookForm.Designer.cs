namespace kutupHaneOtomasyonu
{
    partial class LoanBookForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.lblCopiesUnit = new System.Windows.Forms.Label();
            this.txtAvailableCopies = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.btnSelectBook = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxMember = new System.Windows.Forms.GroupBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.btnSelectMember = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxLoan = new System.Windows.Forms.GroupBox();
            this.lblLoanPeriod = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpLoanDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.groupBoxBook.SuspendLayout();
            this.groupBoxMember.SuspendLayout();
            this.groupBoxLoan.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(932, 86);
            this.panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(267, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "📚 Kitap Ödünç Verme";
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.BackColor = System.Drawing.Color.White;
            this.groupBoxBook.Controls.Add(this.lblCopiesUnit);
            this.groupBoxBook.Controls.Add(this.txtAvailableCopies);
            this.groupBoxBook.Controls.Add(this.txtAuthor);
            this.groupBoxBook.Controls.Add(this.txtBookTitle);
            this.groupBoxBook.Controls.Add(this.txtBookId);
            this.groupBoxBook.Controls.Add(this.btnSelectBook);
            this.groupBoxBook.Controls.Add(this.label4);
            this.groupBoxBook.Controls.Add(this.label7);
            this.groupBoxBook.Controls.Add(this.label5);
            this.groupBoxBook.Controls.Add(this.label3);
            this.groupBoxBook.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.groupBoxBook.Location = new System.Drawing.Point(40, 111);
            this.groupBoxBook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.groupBoxBook.Size = new System.Drawing.Size(853, 185);
            this.groupBoxBook.TabIndex = 1;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "📖 Kitap Bilgileri";
            // 
            // lblCopiesUnit
            // 
            this.lblCopiesUnit.AutoSize = true;
            this.lblCopiesUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCopiesUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblCopiesUnit.Location = new System.Drawing.Point(293, 137);
            this.lblCopiesUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopiesUnit.Name = "lblCopiesUnit";
            this.lblCopiesUnit.Size = new System.Drawing.Size(39, 20);
            this.lblCopiesUnit.TabIndex = 9;
            this.lblCopiesUnit.Text = "adet";
            // 
            // txtAvailableCopies
            // 
            this.txtAvailableCopies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAvailableCopies.Location = new System.Drawing.Point(173, 132);
            this.txtAvailableCopies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAvailableCopies.Name = "txtAvailableCopies";
            this.txtAvailableCopies.ReadOnly = true;
            this.txtAvailableCopies.Size = new System.Drawing.Size(105, 30);
            this.txtAvailableCopies.TabIndex = 8;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAuthor.Location = new System.Drawing.Point(507, 89);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(265, 30);
            this.txtAuthor.TabIndex = 6;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBookTitle.Location = new System.Drawing.Point(133, 89);
            this.txtBookTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.ReadOnly = true;
            this.txtBookTitle.Size = new System.Drawing.Size(265, 30);
            this.txtBookTitle.TabIndex = 4;
            // 
            // txtBookId
            // 
            this.txtBookId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBookId.Location = new System.Drawing.Point(133, 46);
            this.txtBookId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(199, 30);
            this.txtBookId.TabIndex = 1;
            // 
            // btnSelectBook
            // 
            this.btnSelectBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSelectBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectBook.ForeColor = System.Drawing.Color.White;
            this.btnSelectBook.Location = new System.Drawing.Point(360, 43);
            this.btnSelectBook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectBook.Name = "btnSelectBook";
            this.btnSelectBook.Size = new System.Drawing.Size(133, 34);
            this.btnSelectBook.TabIndex = 2;
            this.btnSelectBook.Text = "📚 Kitap Seç";
            this.btnSelectBook.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(27, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mevcut Kopya:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label7.Location = new System.Drawing.Point(427, 92);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Yazar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(27, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Kitap Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(27, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kitap ID:";
            // 
            // groupBoxMember
            // 
            this.groupBoxMember.BackColor = System.Drawing.Color.White;
            this.groupBoxMember.Controls.Add(this.txtMemberName);
            this.groupBoxMember.Controls.Add(this.txtMemberId);
            this.groupBoxMember.Controls.Add(this.btnSelectMember);
            this.groupBoxMember.Controls.Add(this.label9);
            this.groupBoxMember.Controls.Add(this.label10);
            this.groupBoxMember.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.groupBoxMember.Location = new System.Drawing.Point(40, 320);
            this.groupBoxMember.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxMember.Name = "groupBoxMember";
            this.groupBoxMember.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.groupBoxMember.Size = new System.Drawing.Size(853, 123);
            this.groupBoxMember.TabIndex = 2;
            this.groupBoxMember.TabStop = false;
            this.groupBoxMember.Text = "👤 Üye Bilgileri";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMemberName.Location = new System.Drawing.Point(613, 46);
            this.txtMemberName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.ReadOnly = true;
            this.txtMemberName.Size = new System.Drawing.Size(212, 30);
            this.txtMemberName.TabIndex = 4;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMemberId.Location = new System.Drawing.Point(133, 46);
            this.txtMemberId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(199, 30);
            this.txtMemberId.TabIndex = 1;
            // 
            // btnSelectMember
            // 
            this.btnSelectMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSelectMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelectMember.ForeColor = System.Drawing.Color.White;
            this.btnSelectMember.Location = new System.Drawing.Point(360, 43);
            this.btnSelectMember.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectMember.Name = "btnSelectMember";
            this.btnSelectMember.Size = new System.Drawing.Size(133, 34);
            this.btnSelectMember.TabIndex = 2;
            this.btnSelectMember.Text = "👤 Üye Seç";
            this.btnSelectMember.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label9.Location = new System.Drawing.Point(520, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 23);
            this.label9.TabIndex = 3;
            this.label9.Text = "Üye Adı:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label10.Location = new System.Drawing.Point(27, 49);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Üye ID:";
            // 
            // groupBoxLoan
            // 
            this.groupBoxLoan.BackColor = System.Drawing.Color.White;
            this.groupBoxLoan.Controls.Add(this.lblLoanPeriod);
            this.groupBoxLoan.Controls.Add(this.dtpDueDate);
            this.groupBoxLoan.Controls.Add(this.dtpLoanDate);
            this.groupBoxLoan.Controls.Add(this.label12);
            this.groupBoxLoan.Controls.Add(this.label11);
            this.groupBoxLoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxLoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.groupBoxLoan.Location = new System.Drawing.Point(40, 468);
            this.groupBoxLoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLoan.Name = "groupBoxLoan";
            this.groupBoxLoan.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.groupBoxLoan.Size = new System.Drawing.Size(853, 148);
            this.groupBoxLoan.TabIndex = 3;
            this.groupBoxLoan.TabStop = false;
            this.groupBoxLoan.Text = "📅 Ödünç Bilgileri";
            // 
            // lblLoanPeriod
            // 
            this.lblLoanPeriod.AutoSize = true;
            this.lblLoanPeriod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLoanPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblLoanPeriod.Location = new System.Drawing.Point(467, 68);
            this.lblLoanPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoanPeriod.Name = "lblLoanPeriod";
            this.lblLoanPeriod.Size = new System.Drawing.Size(209, 23);
            this.lblLoanPeriod.TabIndex = 4;
            this.lblLoanPeriod.Text = "📊 Ödünç Süresi: 14 gün";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpDueDate.Location = new System.Drawing.Point(173, 89);
            this.dtpDueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(239, 30);
            this.dtpDueDate.TabIndex = 3;
            // 
            // dtpLoanDate
            // 
            this.dtpLoanDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpLoanDate.Location = new System.Drawing.Point(173, 46);
            this.dtpLoanDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new System.Drawing.Size(239, 30);
            this.dtpLoanDate.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label12.Location = new System.Drawing.Point(27, 92);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 23);
            this.label12.TabIndex = 2;
            this.label12.Text = "İade Tarihi:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label11.Location = new System.Drawing.Point(27, 49);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Ödünç Tarihi:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnLoan);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 640);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(932, 86);
            this.panelButtons.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(560, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 49);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "❌ İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnLoan
            // 
            this.btnLoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoan.ForeColor = System.Drawing.Color.White;
            this.btnLoan.Location = new System.Drawing.Point(333, 18);
            this.btnLoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(200, 49);
            this.btnLoan.TabIndex = 0;
            this.btnLoan.Text = "✅ Ödünç Ver";
            this.btnLoan.UseVisualStyleBackColor = false;
            // 
            // LoanBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(932, 726);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxLoan);
            this.Controls.Add(this.groupBoxMember);
            this.Controls.Add(this.groupBoxBook);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "LoanBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap Ödünç Verme Sistemi";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            this.groupBoxMember.ResumeLayout(false);
            this.groupBoxMember.PerformLayout();
            this.groupBoxLoan.ResumeLayout(false);
            this.groupBoxLoan.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.Label lblCopiesUnit;
        private System.Windows.Forms.TextBox txtAvailableCopies;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Button btnSelectBook;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxMember;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Button btnSelectMember;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBoxLoan;
        private System.Windows.Forms.Label lblLoanPeriod;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.DateTimePicker dtpLoanDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoan;
    }
}