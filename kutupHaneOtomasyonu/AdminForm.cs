using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Forms; // Forms namespace'ini ekleyin

namespace kutupHaneOtomasyonu
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
            this.Text = "Kütüphane Yönetim Sistemi - Admin Panel";

            // Hoş geldin mesajı - SetText yerine Text kullanın
            if (lblWelcome != null)
            {
                lblWelcome.Text = $"Hoş Geldiniz! Tarih: {DateTime.Now:dd.MM.yyyy}";
            }
        }

        // Kitaplar Yönetimi
        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            try
            {
                BookManagementForm bookForm = new BookManagementForm();
                bookForm.ShowDialog(); // Modal olarak aç
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitaplar formu açılırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Üyeler Yönetimi
        private void btnUyeler_Click(object sender, EventArgs e)
        {
            try
            {
                MemberManagementForm memberForm = new MemberManagementForm();
                memberForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Üyeler formu açılırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Emanetler (Ödünç Verme) Yönetimi
        private void btnEmanetler_Click(object sender, EventArgs e)
        {
            try
            {
                LoanManagementForm loanForm = new LoanManagementForm();
                loanForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Emanetler formu açılırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kullanıcılar Yönetimi (Sistem Kullanıcıları)
        private void btnKullanicilar_Click(object sender, EventArgs e)
        {
            try
            {
                // Eğer UserManagementForm varsa
                UserManagementForm userForm = new UserManagementForm();
                userForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcılar formu açılırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Raporlar
        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            try
            {
                // Eğer ReportsForm varsa
                ReportForm reportsForm = new ReportForm();
                reportsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Raporlar formu açılırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eski button event'ler - geriye dönük uyumluluk için
        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            btnKitaplar_Click(sender, e);
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            btnUyeler_Click(sender, e);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            btnRaporlar_Click(sender, e);
        }

        // Çıkış İşlemleri
        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Kütüphane yönetim sisteminden çıkmak istediğinizden emin misiniz?",
                "Çıkış Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnCikis_Click(sender, e);
        }

        // Hızlı Erişim Metodları
        private void OpenQuickStats()
        {
            try
            {
                // Hızlı istatistikler için basit bir form açabilirsiniz
                MessageBox.Show("Hızlı İstatistikler:\n" +
                    "• Toplam Kitap: [Veritabanından çekilecek]\n" +
                    "• Aktif Üye: [Veritabanından çekilecek]\n" +
                    "• Ödünçte Kitap: [Veritabanından çekilecek]",
                    "Sistem Özeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstatistikler yüklenirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form kapanırken
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Uygulamayı kapatmak istediğinizden emin misiniz?",
                    "Çıkış",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        // Rezervasyonlar butonu click eventi
        private void btnRezervasyonlar_Click(object sender, EventArgs e)
        {
            try
            {
                // Admin için rezervasyon formu
                CreateReservationForm reservationForm = new CreateReservationForm();
                reservationForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rezervasyon formu açılırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menü Strip Events (eğer menü kullanıyorsanız)
        private void kitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnKitaplar_Click(sender, e);
        }

        private void üyelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUyeler_Click(sender, e);
        }

        private void emanetlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEmanetler_Click(sender, e);
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRaporlar_Click(sender, e);
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCikis_Click(sender, e);
        }
    }
}