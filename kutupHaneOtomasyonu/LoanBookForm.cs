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

            // DateTimePicker ayarları
            dtpLoanDate.Value = DateTime.Now; // Bugünün tarihi
            dtpDueDate.Value = DateTime.Now.AddDays(14); // 14 gün sonra iade tarihi
        }

        private void LoanBookForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
            dtpLoanDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(14);
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
                    // txtBookTitle.Text = "Kitap Adı";
                    // txtAuthor.Text = "Yazar Adı";
                    // txtAvailableCopies.Text = "5";

                    MessageBox.Show("Kitap bilgileri getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lütfen bir kitap ID'si girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // txtMemberName.Text = "Üye Adı Soyadı";

                    MessageBox.Show("Üye bilgileri getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lütfen bir üye ID'si girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            // Ödünç verme işlemi
            try
            {
                // Kontroller
                if (string.IsNullOrEmpty(txtBookId.Text) || string.IsNullOrEmpty(txtBookTitle.Text))
                {
                    MessageBox.Show("Lütfen bir kitap seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtMemberId.Text) || string.IsNullOrEmpty(txtMemberName.Text))
                {
                    MessageBox.Show("Lütfen bir üye seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mevcut kopya kontrolü
                int availableCopies = 0;
                if (!string.IsNullOrEmpty(txtAvailableCopies.Text))
                {
                    availableCopies = Convert.ToInt32(txtAvailableCopies.Text);
                }

                if (availableCopies <= 0)
                {
                    MessageBox.Show("Bu kitabın mevcut kopyası bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ödünç verme işlemini gerçekleştir
                DialogResult result = MessageBox.Show(
                    $"Kitap: {txtBookTitle.Text}\n" +
                    $"Üye: {txtMemberName.Text}\n" +
                    $"İade Tarihi: {dtpDueDate.Value.ToShortDateString()}\n\n" +
                    "Ödünç verme işlemini onaylıyor musunuz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Veritabanına kaydet
                    // ...

                    MessageBox.Show("Kitap başarıyla ödünç verildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // İptal işlemi
            this.Close();
        }
    }
}