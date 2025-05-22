namespace kutupHaneOtomasyonu
{
    partial class AdminForm
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
            this.btnKullanicilar = new System.Windows.Forms.Button();
            this.btnKitaplar = new System.Windows.Forms.Button();
            this.btnUyeler = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnRaporlar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(52, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMİN PANELİ";
            // 
            // btnKullanicilar
            // 
            this.btnKullanicilar.Location = new System.Drawing.Point(91, 133);
            this.btnKullanicilar.Name = "btnKullanicilar";
            this.btnKullanicilar.Size = new System.Drawing.Size(139, 33);
            this.btnKullanicilar.TabIndex = 1;
            this.btnKullanicilar.Text = "Kullanıcıları Yönet\t";
            this.btnKullanicilar.UseVisualStyleBackColor = true;
            // 
            // btnKitaplar
            // 
            this.btnKitaplar.Location = new System.Drawing.Point(91, 182);
            this.btnKitaplar.Name = "btnKitaplar";
            this.btnKitaplar.Size = new System.Drawing.Size(139, 33);
            this.btnKitaplar.TabIndex = 2;
            this.btnKitaplar.Text = "Kitapları Yönet\t";
            this.btnKitaplar.UseVisualStyleBackColor = true;
            // 
            // btnUyeler
            // 
            this.btnUyeler.Location = new System.Drawing.Point(91, 232);
            this.btnUyeler.Name = "btnUyeler";
            this.btnUyeler.Size = new System.Drawing.Size(139, 33);
            this.btnUyeler.TabIndex = 3;
            this.btnUyeler.Text = "Üyeleri Yönet\t";
            this.btnUyeler.UseVisualStyleBackColor = true;
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(330, 339);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(139, 33);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış Yap\t";
            this.btnCikis.UseVisualStyleBackColor = true;
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.Location = new System.Drawing.Point(91, 281);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Size = new System.Drawing.Size(139, 33);
            this.btnRaporlar.TabIndex = 5;
            this.btnRaporlar.Text = "Raporlar\t";
            this.btnRaporlar.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRaporlar);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnUyeler);
            this.Controls.Add(this.btnKitaplar);
            this.Controls.Add(this.btnKullanicilar);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKullanicilar;
        private System.Windows.Forms.Button btnKitaplar;
        private System.Windows.Forms.Button btnUyeler;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnRaporlar;
    }
}