namespace WindowsFormsApp1
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
            this.dgvKitaplar = new System.Windows.Forms.DataGridView();
            this.pnlDetaylar = new System.Windows.Forms.Panel();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitaplar)).BeginInit();
            this.pnlDetaylar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKitaplar
            // 
            this.dgvKitaplar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKitaplar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKitaplar.Location = new System.Drawing.Point(0, 0);
            this.dgvKitaplar.Name = "dgvKitaplar";
            this.dgvKitaplar.RowHeadersWidth = 51;
            this.dgvKitaplar.RowTemplate.Height = 24;
            this.dgvKitaplar.Size = new System.Drawing.Size(800, 450);
            this.dgvKitaplar.TabIndex = 0;
            this.dgvKitaplar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKitaplar_CellContentClick);
            // 
            // pnlDetaylar
            // 
            this.pnlDetaylar.Controls.Add(this.label1);
            this.pnlDetaylar.Controls.Add(this.btnDeleteBook);
            this.pnlDetaylar.Controls.Add(this.btnUpdateBook);
            this.pnlDetaylar.Controls.Add(this.btnAddBook);
            this.pnlDetaylar.Controls.Add(this.cmbStatus);
            this.pnlDetaylar.Controls.Add(this.lblStatus);
            this.pnlDetaylar.Controls.Add(this.nudYear);
            this.pnlDetaylar.Controls.Add(this.lblYear);
            this.pnlDetaylar.Controls.Add(this.cmbAuthor);
            this.pnlDetaylar.Controls.Add(this.lblAuthor);
            this.pnlDetaylar.Controls.Add(this.txtTitle);
            this.pnlDetaylar.Controls.Add(this.lblTitle);
            this.pnlDetaylar.Controls.Add(this.txtISBN);
            this.pnlDetaylar.Controls.Add(this.lblISBN);
            this.pnlDetaylar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetaylar.Location = new System.Drawing.Point(550, 0);
            this.pnlDetaylar.Name = "pnlDetaylar";
            this.pnlDetaylar.Size = new System.Drawing.Size(250, 450);
            this.pnlDetaylar.TabIndex = 1;
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(20, 41);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(41, 16);
            this.lblISBN.TabIndex = 0;
            this.lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(82, 38);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(156, 22);
            this.txtISBN.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 73);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(47, 16);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Başlık:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(82, 70);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(156, 22);
            this.txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(20, 111);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(48, 16);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Author:";
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.FormattingEnabled = true;
            this.cmbAuthor.Location = new System.Drawing.Point(82, 108);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(156, 24);
            this.cmbAuthor.TabIndex = 5;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(23, 148);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(39, 16);
            this.lblYear.TabIndex = 6;
            this.lblYear.Text = "Year:";
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(82, 146);
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(156, 22);
            this.nudYear.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(22, 189);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Available,Borrowed"});
            this.cmbStatus.Location = new System.Drawing.Point(82, 186);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(156, 24);
            this.cmbStatus.TabIndex = 9;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(16, 232);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(73, 23);
            this.btnAddBook.TabIndex = 10;
            this.btnAddBook.Text = "Ekle";
            this.btnAddBook.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Location = new System.Drawing.Point(95, 232);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(73, 23);
            this.btnUpdateBook.TabIndex = 11;
            this.btnUpdateBook.Text = "Güncelle";
            this.btnUpdateBook.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(174, 231);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(73, 23);
            this.btnDeleteBook.TabIndex = 12;
            this.btnDeleteBook.Text = "Sil";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kitap Yönetim";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlDetaylar);
            this.Controls.Add(this.dgvKitaplar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKitaplar)).EndInit();
            this.pnlDetaylar.ResumeLayout(false);
            this.pnlDetaylar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKitaplar;
        private System.Windows.Forms.Panel pnlDetaylar;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.Button btnAddBook;
    }
}

