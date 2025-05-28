using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutupHaneOtomasyonu
{
    public partial class LoanBookForm : Form
    {
        public LoanBookForm()
        {
            InitializeComponent();
        }

        private void LoanBookForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde varsayılan değerleri ayarla
            dateTimePicker1.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(14); // 14 gün sonra iade tarihi
        }

        private void btnSelectBook_Click(object sender, EventArgs e)
        {
            // Kitap seçme işlemi
            try
            {
                if (!string.IsNullOrEmpty(txtBookId.Text))
                {
                    // Veritabanından kitap bilgilerini getir
                    // Bu kısımda Entity Framework veya veritabanı bağlantısı kullanabilirsiniz

                    // Örnek: Kitap bilgilerini doldur
                    txtBookTitle.Text = "Seçilen Kitap Adı";
                    txtAuthor.Text = "Yazar Adı";
                    txtAvailableCopies.Text = "5";
                }
                else
                {
                    MessageBox.Show("Lütfen bir Kitap ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitap seçme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectMember_Click(object sender, EventArgs e)
        {
            // Üye seçme işlemi
            try
            {
                if (!string.IsNullOrEmpty(txtMemberId.Text))
                {
                    // Veritabanından üye bilgilerini getir

                    // Örnek: Üye bilgilerini doldur
                    txtMemberName.Text = "Seçilen Üye Adı";
                }
                else
                {
                    MessageBox.Show("Lütfen bir Üye ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Üye seçme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            // Ödünç verme işlemi
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol et
                if (string.IsNullOrEmpty(txtBookId.Text) ||
                    string.IsNullOrEmpty(txtMemberId.Text) ||
                    string.IsNullOrEmpty(txtBookTitle.Text) ||
                    string.IsNullOrEmpty(txtMemberName.Text))
                {
                    MessageBox.Show("Lütfen tüm gerekli alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mevcut kopya kontrolü
                if (int.Parse(txtAvailableCopies.Text) <= 0)
                {
                    MessageBox.Show("Bu kitaptan mevcut kopya bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ödünç verme işlemini veritabanına kaydet
                // Bu kısımda Entity Framework kullanarak Loans tablosuna kayıt ekleyebilirsiniz

                MessageBox.Show("Kitap başarıyla ödünç verildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizle
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödünç verme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // İptal işlemi
            var result = MessageBox.Show("İşlemi iptal etmek istediğinizden emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ClearForm()
        {
            // Formu temizle
            txtBookId.Clear();
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtAvailableCopies.Clear();
            txtMemberId.Clear();
            txtMemberName.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(14);
        }

        private void txtBookId_TextChanged(object sender, EventArgs e)
        {
            // Kitap ID değiştiğinde diğer alanları temizle
            if (string.IsNullOrEmpty(txtBookId.Text))
            {
                txtBookTitle.Clear();
                txtAuthor.Clear();
                txtAvailableCopies.Clear();
            }
        }

        private void txtMemberId_TextChanged(object sender, EventArgs e)
        {
            // Üye ID değiştiğinde üye adını temizle
            if (string.IsNullOrEmpty(txtMemberId.Text))
            {
                txtMemberName.Clear();
            }
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            // İade tarihi ödünç tarihinden önce olamaz
            if (dtpDueDate.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("İade tarihi ödünç tarihinden önce olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDueDate.Value = dateTimePicker1.Value.AddDays(1);
            }
        }
    }
}