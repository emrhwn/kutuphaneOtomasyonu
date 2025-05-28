namespace kutupHaneOtomasyonu.Forms
{
    partial class LibrarianLoanForm
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
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.lblLoanDate = new System.Windows.Forms.Label();
            this.dtpLoanDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpCurrentLoans = new System.Windows.Forms.GroupBox();
            this.dgvCurrentLoans = new System.Windows.Forms.DataGridView();
            this.grpCurrentLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMember.Location = new System.Drawing.Point(20, 20);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(31, 15);
            this.lblMember.TabIndex = 0;
            this.lblMember.Text = "Üye:";
            // 
            // cmbMember
            // 
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(130, 17);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(250, 23);
            this.cmbMember.TabIndex = 1;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBook.Location = new System.Drawing.Point(20, 60);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(37, 15);
            this.lblBook.TabIndex = 2;
            this.lblBook.Text = "Kitap:";
            // 
            // cmbBook
            // 
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBook.FormattingEnabled = true;
            this.cmbBook.Location = new System.Drawing.Point(130, 57);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(250, 23);
            this.cmbBook.TabIndex = 3;
            // 
            // lblLoanDate
            // 
            this.lblLoanDate.AutoSize = true;
            this.lblLoanDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoanDate.Location = new System.Drawing.Point(20, 100);
            this.lblLoanDate.Name = "lblLoanDate";
            this.lblLoanDate.Size = new System.Drawing.Size(78, 15);
            this.lblLoanDate.TabIndex = 4;
            this.lblLoanDate.Text = "Ödünç Tarihi:";
            // 
            // dtpLoanDate
            // 
            this.dtpLoanDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpLoanDate.Location = new System.Drawing.Point(130, 97);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new System.Drawing.Size(250, 23);
            this.dtpLoanDate.TabIndex = 5;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDueDate.Location = new System.Drawing.Point(20, 140);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(64, 15);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "İade Tarihi:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDueDate.Location = new System.Drawing.Point(130, 137);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(250, 23);
            this.dtpDueDate.TabIndex = 7;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNotes.Location = new System.Drawing.Point(20, 180);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(41, 15);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Notlar:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(130, 177);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 60);
            this.txtNotes.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(130, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "💾 Ödünç Ver";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(260, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "❌ İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpCurrentLoans
            // 
            this.grpCurrentLoans.Controls.Add(this.dgvCurrentLoans);
            this.grpCurrentLoans.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpCurrentLoans.Location = new System.Drawing.Point(400, 20);
            this.grpCurrentLoans.Name = "grpCurrentLoans";
            this.grpCurrentLoans.Size = new System.Drawing.Size(360, 265);
            this.grpCurrentLoans.TabIndex = 12;
            this.grpCurrentLoans.TabStop = false;
            this.grpCurrentLoans.Text = "Mevcut Ödünçler";
            // 
            // dgvCurrentLoans
            // 
            this.dgvCurrentLoans.AllowUserToAddRows = false;
            this.dgvCurrentLoans.AllowUserToDeleteRows = false;
            this.dgvCurrentLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvCurrentLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentLoans.Location = new System.Drawing.Point(10, 20);
            this.dgvCurrentLoans.Name = "dgvCurrentLoans";
            this.dgvCurrentLoans.ReadOnly = true;
            this.dgvCurrentLoans.RowHeadersWidth = 51;
            this.dgvCurrentLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentLoans.Size = new System.Drawing.Size(340, 235);
            this.dgvCurrentLoans.TabIndex = 0;
            // 
            // LibrarianLoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 311);
            this.Controls.Add(this.grpCurrentLoans);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpLoanDate);
            this.Controls.Add(this.lblLoanDate);
            this.Controls.Add(this.cmbBook);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.cmbMember);
            this.Controls.Add(this.lblMember);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LibrarianLoanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kitap Ödünç Verme";
            this.Load += new System.EventHandler(this.LibrarianLoanForm_Load);
            this.grpCurrentLoans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label lblLoanDate;
        private System.Windows.Forms.DateTimePicker dtpLoanDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpCurrentLoans;
        private System.Windows.Forms.DataGridView dgvCurrentLoans;
    }
}