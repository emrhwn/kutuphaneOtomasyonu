namespace kutupHaneOtomasyonu
{
    partial class SettingsForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLibraryName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.numMaxLoanDays = new System.Windows.Forms.NumericUpDown();
            this.numMaxBooksPerMember = new System.Windows.Forms.NumericUpDown();
            this.numLateFee = new System.Windows.Forms.NumericUpDown();
            this.numMaxResDays = new System.Windows.Forms.NumericUpDown();
            this.numMaxResCount = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLoanDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBooksPerMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLateFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(684, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "|                 SİSTEM AYARLARI                     |\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(29, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Genel Ayarlar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(29, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kütüphane Adı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(29, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Adres:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(30, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Telefon:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(29, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "E-Posta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(30, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ödünç Verme Ayarları:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(32, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Maksimum Ödünç Süresi:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(32, 407);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Maksimum Kitap Sayısı:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(32, 441);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Gecikme Cezası:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(29, 496);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(261, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Rezervasyon Ayarları:";
            this.label11.Click += new System.EventHandler(this.label8_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(31, 538);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(278, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Maksimum Rezervasyon Süresi:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(31, 576);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(273, 24);
            this.label13.TabIndex = 0;
            this.label13.Text = "Maksimum Rezervasyon Sayısı:";
            // 
            // txtLibraryName
            // 
            this.txtLibraryName.Location = new System.Drawing.Point(175, 161);
            this.txtLibraryName.Name = "txtLibraryName";
            this.txtLibraryName.Size = new System.Drawing.Size(174, 22);
            this.txtLibraryName.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(100, 198);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(174, 22);
            this.txtAddress.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(116, 235);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(174, 22);
            this.txtPhone.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(116, 269);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(174, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // numMaxLoanDays
            // 
            this.numMaxLoanDays.Location = new System.Drawing.Point(265, 368);
            this.numMaxLoanDays.Name = "numMaxLoanDays";
            this.numMaxLoanDays.Size = new System.Drawing.Size(159, 22);
            this.numMaxLoanDays.TabIndex = 2;
            // 
            // numMaxBooksPerMember
            // 
            this.numMaxBooksPerMember.Location = new System.Drawing.Point(243, 410);
            this.numMaxBooksPerMember.Name = "numMaxBooksPerMember";
            this.numMaxBooksPerMember.Size = new System.Drawing.Size(159, 22);
            this.numMaxBooksPerMember.TabIndex = 2;
            // 
            // numLateFee
            // 
            this.numLateFee.Location = new System.Drawing.Point(190, 444);
            this.numLateFee.Name = "numLateFee";
            this.numLateFee.Size = new System.Drawing.Size(159, 22);
            this.numLateFee.TabIndex = 2;
            // 
            // numMaxResDays
            // 
            this.numMaxResDays.Location = new System.Drawing.Point(310, 541);
            this.numMaxResDays.Name = "numMaxResDays";
            this.numMaxResDays.Size = new System.Drawing.Size(163, 22);
            this.numMaxResDays.TabIndex = 2;
            // 
            // numMaxResCount
            // 
            this.numMaxResCount.Location = new System.Drawing.Point(310, 579);
            this.numMaxResCount.Name = "numMaxResCount";
            this.numMaxResCount.Size = new System.Drawing.Size(163, 22);
            this.numMaxResCount.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(398, 627);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(524, 627);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 682);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numMaxResCount);
            this.Controls.Add(this.numMaxResDays);
            this.Controls.Add(this.numLateFee);
            this.Controls.Add(this.numMaxBooksPerMember);
            this.Controls.Add(this.numMaxLoanDays);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtLibraryName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLoanDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBooksPerMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLateFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLibraryName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.NumericUpDown numMaxLoanDays;
        private System.Windows.Forms.NumericUpDown numMaxBooksPerMember;
        private System.Windows.Forms.NumericUpDown numLateFee;
        private System.Windows.Forms.NumericUpDown numMaxResDays;
        private System.Windows.Forms.NumericUpDown numMaxResCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}