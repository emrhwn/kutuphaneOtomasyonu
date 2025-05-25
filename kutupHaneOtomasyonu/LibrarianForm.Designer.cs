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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnListBooks = new System.Windows.Forms.Button();
            this.btnBookDetails = new System.Windows.Forms.Button();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.btnLoanBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnLoanHistory = new System.Windows.Forms.Button();
            this.btnMemberDetails = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnListReservations = new System.Windows.Forms.Button();
            this.btnCreateReservation = new System.Windows.Forms.Button();
            this.btnUpdateReservation = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtSearchBook = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(216, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "KÜTÜPHANECİ PANELİ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(57, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = " Kitap İşlemleri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(548, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ödünç İşlemleri";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(548, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Üye İşlemleri";
            // 
            // btnListBooks
            // 
            this.btnListBooks.Location = new System.Drawing.Point(34, 209);
            this.btnListBooks.Name = "btnListBooks";
            this.btnListBooks.Size = new System.Drawing.Size(163, 31);
            this.btnListBooks.TabIndex = 4;
            this.btnListBooks.Text = "Kitapları Listele";
            this.btnListBooks.UseVisualStyleBackColor = true;
            // 
            // btnBookDetails
            // 
            this.btnBookDetails.Location = new System.Drawing.Point(34, 162);
            this.btnBookDetails.Name = "btnBookDetails";
            this.btnBookDetails.Size = new System.Drawing.Size(163, 31);
            this.btnBookDetails.TabIndex = 5;
            this.btnBookDetails.Text = "Kitap Detayları";
            this.btnBookDetails.UseVisualStyleBackColor = true;
            // 
            // btnSearchBook
            // 
            this.btnSearchBook.Location = new System.Drawing.Point(34, 114);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(163, 31);
            this.btnSearchBook.TabIndex = 6;
            this.btnSearchBook.Text = "Kitap Ara";
            this.btnSearchBook.UseVisualStyleBackColor = true;
            // 
            // btnLoanBook
            // 
            this.btnLoanBook.Location = new System.Drawing.Point(494, 125);
            this.btnLoanBook.Name = "btnLoanBook";
            this.btnLoanBook.Size = new System.Drawing.Size(214, 31);
            this.btnLoanBook.TabIndex = 7;
            this.btnLoanBook.Text = "Ödünç Ver";
            this.btnLoanBook.UseVisualStyleBackColor = true;
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(494, 162);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(214, 31);
            this.btnReturnBook.TabIndex = 8;
            this.btnReturnBook.Text = "İade Al";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            // 
            // btnLoanHistory
            // 
            this.btnLoanHistory.Location = new System.Drawing.Point(494, 209);
            this.btnLoanHistory.Name = "btnLoanHistory";
            this.btnLoanHistory.Size = new System.Drawing.Size(214, 31);
            this.btnLoanHistory.TabIndex = 9;
            this.btnLoanHistory.Text = "Ödünç Geçmişi";
            this.btnLoanHistory.UseVisualStyleBackColor = true;
            // 
            // btnMemberDetails
            // 
            this.btnMemberDetails.Location = new System.Drawing.Point(514, 312);
            this.btnMemberDetails.Name = "btnMemberDetails";
            this.btnMemberDetails.Size = new System.Drawing.Size(214, 31);
            this.btnMemberDetails.TabIndex = 11;
            this.btnMemberDetails.Text = "Üye Detayları";
            this.btnMemberDetails.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(57, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Rezervasyon İşlemleri";
            // 
            // btnListReservations
            // 
            this.btnListReservations.Location = new System.Drawing.Point(34, 313);
            this.btnListReservations.Name = "btnListReservations";
            this.btnListReservations.Size = new System.Drawing.Size(214, 31);
            this.btnListReservations.TabIndex = 14;
            this.btnListReservations.Text = "Rezervasyonları Listele";
            this.btnListReservations.UseVisualStyleBackColor = true;
            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.Location = new System.Drawing.Point(34, 356);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new System.Drawing.Size(214, 31);
            this.btnCreateReservation.TabIndex = 15;
            this.btnCreateReservation.Text = "Rezervasyon Yap";
            this.btnCreateReservation.UseVisualStyleBackColor = true;
            // 
            // btnUpdateReservation
            // 
            this.btnUpdateReservation.Location = new System.Drawing.Point(34, 405);
            this.btnUpdateReservation.Name = "btnUpdateReservation";
            this.btnUpdateReservation.Size = new System.Drawing.Size(214, 31);
            this.btnUpdateReservation.TabIndex = 16;
            this.btnUpdateReservation.Text = "Rezervasyon Güncelle";
            this.btnUpdateReservation.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(596, 418);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(192, 31);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtSearchBook
            // 
            this.txtSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSearchBook.Location = new System.Drawing.Point(222, 115);
            this.txtSearchBook.Name = "txtSearchBook";
            this.txtSearchBook.Size = new System.Drawing.Size(160, 26);
            this.txtSearchBook.TabIndex = 18;
            // 
            // LibrarianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.txtSearchBook);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdateReservation);
            this.Controls.Add(this.btnCreateReservation);
            this.Controls.Add(this.btnListReservations);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMemberDetails);
            this.Controls.Add(this.btnLoanHistory);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnLoanBook);
            this.Controls.Add(this.btnSearchBook);
            this.Controls.Add(this.btnBookDetails);
            this.Controls.Add(this.btnListBooks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LibrarianForm";
            this.Text = "LibrarianForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnListBooks;
        private System.Windows.Forms.Button btnBookDetails;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.Button btnLoanBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnLoanHistory;
        private System.Windows.Forms.Button btnMemberDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnListReservations;
        private System.Windows.Forms.Button btnCreateReservation;
        private System.Windows.Forms.Button btnUpdateReservation;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtSearchBook;
    }
}