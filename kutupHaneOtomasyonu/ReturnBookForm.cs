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
    public partial class ReturnBookForm : Form
    {
        private decimal finePerDay = 2.0m; // Günlük ceza miktarı (2 TL)

        public ReturnBookForm()
        {
            InitializeComponent();
        }

        private void ReturnBookForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde bugünün tarihini ayarla
            dateTimePicker1.Value = DateTime.Now;

            

            // Başlangıçta tüm alanları temizle
            ClearForm();
        }

        private void btnFindLoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLoanId.Text))
                {
                    MessageBox.Show("Lütfen bir Ödünç ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int loanId;
                if (!int.TryParse(txtLoanId.Text, out loanId))
                {
                    MessageBox.Show("Geçerli bir Ödünç ID girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Veritabanından ödünç kaydını bul
                // Bu kısımda Entity Framework kullanarak Loans tablosundan veri çekebilirsiniz

                // Örnek veri doldurma (gerçek projede veritabanından gelecek)
                LoadLoanData(loanId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödünç kaydı arama hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoanData(int loanId)
        {
            // Bu metot veritabanından veri çekecek, şimdilik örnek veri
            // Gerçek uygulamada Entity Framework ile Loans, Books, Members tablolarından JOIN yaparak veri çekilecek

            try
            {
                // Örnek veri (gerçek projede veritabanından gelecek)
                txtBookTitle.Text = "Örnek Kitap Adı";
                txtMemberName.Text = "Örnek Üye Adı";
                txtLoanDate.Text = DateTime.Now.AddDays(-20).ToShortDateString();
                txtDueDate.Text = DateTime.Now.AddDays(-6).ToShortDateString();

                // Gecikme durumunu hesapla
                CalculateLateFee();

                MessageBox.Show("Ödünç kaydı bulundu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception )
            {
                MessageBox.Show("Ödünç kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearLoanData();
            }
        }

        private void CalculateLateFee()
        {
            try
            {
                DateTime dueDate = DateTime.Parse(txtDueDate.Text);
                DateTime returnDate = dateTimePicker1.Value;

                if (returnDate > dueDate)
                {
                    // Gecikme var
                    int lateDays = (returnDate - dueDate).Days;
                    decimal fineAmount = lateDays * finePerDay;

                    txtStatus.Text = $"{lateDays} gün gecikme";
                    txtFineAmount.Text = fineAmount.ToString("C"); // Para birimi formatında

                    // Arka plan rengini değiştir
                    txtStatus.BackColor = Color.LightCoral;
                    txtFineAmount.BackColor = Color.LightCoral;
                }
                else
                {
                    // Gecikme yok
                    txtStatus.Text = "Zamanında";
                    txtFineAmount.Text = "0,00 ₺";

                    // Arka plan rengini yeşil yap
                    txtStatus.BackColor = Color.LightGreen;
                    txtFineAmount.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gecikme hesaplama hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol et
                if (string.IsNullOrEmpty(txtLoanId.Text) ||
                    string.IsNullOrEmpty(txtBookTitle.Text) ||
                    string.IsNullOrEmpty(txtMemberName.Text))
                {
                    MessageBox.Show("Lütfen önce bir ödünç kaydı bulun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Onay iste
                var result = MessageBox.Show(
                    $"Kitap iade edilsin mi?\n\nKitap: {txtBookTitle.Text}\nÜye: {txtMemberName.Text}\nCeza: {txtFineAmount.Text}",
                    "İade Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // İade işlemini veritabanına kaydet
                    ProcessReturn();

                    MessageBox.Show("Kitap başarıyla iade edildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İade işlemi hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessReturn()
        {
            // Bu metotta veritabanı işlemleri yapılacak:
            // 1. Loans tablosunda ReturnDate güncellenecek
            // 2. Books tablosunda AvailableCopies artırılacak
            // 3. Eğer ceza varsa Fines tablosuna kayıt eklenecek

            // Örnek Entity Framework kodu:
            /*
            using (var context = new LibraryContext())
            {
                var loan = context.Loans.Find(int.Parse(txtLoanId.Text));
                if (loan != null)
                {
                    loan.ReturnDate = dateTimePicker1.Value;
                    loan.Status = "Returned";
                    
                    // Kitap kopyasını artır
                    var book = context.Books.Find(loan.BookId);
                    if (book != null)
                    {
                        book.AvailableCopies++;
                    }
                    
                    // Ceza varsa kaydet
                    if (txtFineAmount.Text != "0,00 ₺")
                    {
                        var fine = new Fine
                        {
                            LoanId = loan.Id,
                            Amount = decimal.Parse(txtFineAmount.Text.Replace("₺", "").Replace(",", ".")),
                            IsPaid = false,
                            CreatedDate = DateTime.Now
                        };
                        context.Fines.Add(fine);
                    }
                    
                    context.SaveChanges();
                }
            }
            */
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("İşlemi iptal etmek istediğinizden emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // İade tarihi değiştiğinde cezayı yeniden hesapla
            if (!string.IsNullOrEmpty(txtDueDate.Text))
            {
                CalculateLateFee();
            }
        }

        private void txtLoanId_TextChanged(object sender, EventArgs e)
        {
            // Ödünç ID değiştiğinde diğer alanları temizle
            if (string.IsNullOrEmpty(txtLoanId.Text))
            {
                ClearLoanData();
            }
        }

        private void ClearForm()
        {
            txtLoanId.Clear();
            ClearLoanData();
        }

        private void ClearLoanData()
        {
            txtBookTitle.Clear();
            txtMemberName.Clear();
            txtLoanDate.Clear();
            txtDueDate.Clear();
            txtStatus.Clear();
            txtFineAmount.Clear();

            // Arka plan renklerini sıfırla
            txtStatus.BackColor = SystemColors.Window;
            txtFineAmount.BackColor = SystemColors.Window;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Label tıklama olayı - gerekirse kullanılabilir
        }

        // Klavye kısayolları için
        private void ReturnBookForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşu ile ödünç arama
                if (txtLoanId.Focused && !string.IsNullOrEmpty(txtLoanId.Text))
                {
                    btnFindLoan_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                // Escape tuşu ile çıkış
                btnCancel_Click(sender, e);
            }
        }
    }
}