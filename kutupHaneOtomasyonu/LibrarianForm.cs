using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;

namespace kutupHaneOtomasyonu
{
    public partial class LibrarianForm : Form
    {
        private LibraryContext _context;
        private int _userId;
        private User _currentUser;
        private string placeholderText = "Kitap adı veya ISBN...";

        // Parametresiz yapıcı metot
        public LibrarianForm()
        {
            InitializeComponent();
            InitializeContext();
            _userId = 0;
            SetupPlaceholder();
        }

        // Parametreli yapıcı metot
        public LibrarianForm(int userId)
        {
            InitializeComponent();
            InitializeContext();
            _userId = userId;
            SetupPlaceholder();
        }

        private void InitializeContext()
        {
            try
            {
                _context = new LibraryContext();
                // Lazy loading'i aktif et
                _context.Configuration.LazyLoadingEnabled = true;
                _context.Configuration.ProxyCreationEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı kurulamadı: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupPlaceholder()
        {
            if (txtSearchBook != null)
            {
                // Placeholder text ayarları
                txtSearchBook.Text = placeholderText;
                txtSearchBook.ForeColor = Color.Gray;

                // Event handler'ları ekle
                txtSearchBook.Enter += TxtSearchBook_Enter;
                txtSearchBook.Leave += TxtSearchBook_Leave;
            }
        }

        private void TxtSearchBook_Enter(object sender, EventArgs e)
        {
            if (txtSearchBook.Text == placeholderText)
            {
                txtSearchBook.Text = "";
                txtSearchBook.ForeColor = Color.Black;
            }
        }

        private void TxtSearchBook_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBook.Text))
            {
                txtSearchBook.Text = placeholderText;
                txtSearchBook.ForeColor = Color.Gray;
            }
        }

        private void LibrarianForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Form yüklendiğinde yapılacak işlemler
                LoadUserInfo();
                LoadQuickStats();

                // Üye işlemleri bölümünü kısıtla
                Button btnListMembers = this.Controls.Find("btnListMembers", true).FirstOrDefault() as Button;
                if (btnListMembers != null)
                {
                    btnListMembers.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserInfo()
        {
            if (_userId > 0 && _context != null)
            {
                try
                {
                    // Entity Framework ile kullanıcı bilgilerini çek - HATA DÜZELTİLDİ
                    _currentUser = _context.Users
                        .Where(u => u.UserId == _userId)
                        .FirstOrDefault();

                    if (_currentUser != null)
                    {
                        // Kullanıcı bilgilerini form başlığına ekle
                        this.Text = "Kütüphaneci Paneli - " + _currentUser.Username;

                        // Welcome label'ını güncelle
                        Label lblWelcome = this.Controls.Find("lblWelcome", true).FirstOrDefault() as Label;
                        if (lblWelcome != null)
                        {
                            lblWelcome.Text = "Hoş geldiniz, " + _currentUser.Username;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı bilgileri yüklenirken hata oluştu: " + ex.Message,
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadQuickStats()
        {
            try
            {
                if (_context != null)
                {
                    // Toplam kitap sayısı
                    int totalBooks = _context.Books.Count();
                    Label lblTotalBooks = this.Controls.Find("lblTotalBooks", true).FirstOrDefault() as Label;
                    if (lblTotalBooks != null)
                    {
                        lblTotalBooks.Text = "📚 Toplam Kitap: " + totalBooks.ToString("N0");
                    }

                    // Aktif üye sayısı
                    int totalMembers = _context.Members.Where(m => m.IsActive).Count();
                    Label lblTotalMembers = this.Controls.Find("lblTotalMembers", true).FirstOrDefault() as Label;
                    if (lblTotalMembers != null)
                    {
                        lblTotalMembers.Text = "👤 Aktif Üye: " + totalMembers.ToString("N0");
                    }

                    // Şu anda ödünç verilen kitap sayısı
                    int currentLoans = _context.Loans.Where(l => l.ReturnDate == null).Count();
                    Label lblTotalLoans = this.Controls.Find("lblTotalLoans", true).FirstOrDefault() as Label;
                    if (lblTotalLoans != null)
                    {
                        lblTotalLoans.Text = "📖 Ödünç: " + currentLoans.ToString("N0");
                    }
                }
            }
            catch (Exception)
            {
                // Hata durumunda varsayılan değerleri göster
                Label lblTotalBooks = this.Controls.Find("lblTotalBooks", true).FirstOrDefault() as Label;
                Label lblTotalMembers = this.Controls.Find("lblTotalMembers", true).FirstOrDefault() as Label;
                Label lblTotalLoans = this.Controls.Find("lblTotalLoans", true).FirstOrDefault() as Label;

                if (lblTotalBooks != null) lblTotalBooks.Text = "📚 Toplam Kitap: --";
                if (lblTotalMembers != null) lblTotalMembers.Text = "👤 Aktif Üye: --";
                if (lblTotalLoans != null) lblTotalLoans.Text = "📖 Ödünç: --";
            }
        }

        #region Kitap İşlemleri
        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearchBook.Text;

                // Placeholder text kontrolü
                if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm == placeholderText)
                {
                    MessageBox.Show("Lütfen aranacak kitap adını veya ISBN'i girin.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearchBook.Focus();
                    return;
                }

                if (_context != null)
                {
                    // Entity Framework ile kitap arama
                    var searchResults = _context.Books
                        .Include(b => b.Author)
                        .Where(b => b.Title.Contains(searchTerm) ||
                                   b.ISBN.Contains(searchTerm) ||
                                   b.Author.Name.Contains(searchTerm))
                        .Select(b => new
                        {
                            b.BookId,
                            b.Title,
                            AuthorName = b.Author.Name,
                            b.Category,
                            b.ISBN,
                            b.Publisher,
                            b.PublicationYear,
                            b.TotalCopies,
                            b.AvailableCopies
                        })
                        .ToList();

                    if (searchResults.Any())
                    {
                        // DataGridView'a sonuçları yükle
                        DataGridView dataGridViewBooks = this.Controls.Find("dataGridViewBooks", true).FirstOrDefault() as DataGridView;
                        if (dataGridViewBooks != null)
                        {
                            dataGridViewBooks.DataSource = searchResults;
                            dataGridViewBooks.Visible = true;
                        }
                        MessageBox.Show(searchResults.Count + " kitap bulundu.",
                            "Arama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Arama kriterlerinize uygun kitap bulunamadı.",
                            "Sonuç Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap arama işleminde hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListBooks_Click(object sender, EventArgs e)
        {
            try
            {
                if (_context != null)
                {
                    // Entity Framework ile tüm kitapları çek
                    var books = _context.Books
                        .Include(b => b.Author)
                        .Select(b => new
                        {
                            b.BookId,
                            b.Title,
                            AuthorName = b.Author.Name,
                            b.Category,
                            b.ISBN,
                            b.Publisher,
                            b.PublicationYear,
                            b.TotalCopies,
                            b.AvailableCopies
                        })
                        .ToList();

                    DataGridView dataGridViewBooks = this.Controls.Find("dataGridViewBooks", true).FirstOrDefault() as DataGridView;
                    if (dataGridViewBooks != null)
                    {
                        dataGridViewBooks.DataSource = books;
                        dataGridViewBooks.Visible = true;
                    }

                    MessageBox.Show("Kitaplar başarıyla listelendi.",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitaplar listelenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kitap detayları görüntüleniyor...",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Ödünç İşlemleri
        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kitap ödünç verme işlemi...",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Form kapandıktan sonra istatistikleri güncelle
            LoadQuickStats();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kitap iade işlemi...",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Form kapandıktan sonra istatistikleri güncelle
            LoadQuickStats();
        }

        private void btnLoanHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (_context != null && _userId > 0)
                {
                    // Sadece kütüphanecinin kendi ödünç geçmişini göster
                    var loanHistory = _context.Loans
                        .Include(l => l.Book)
                        .Where(l => l.MemberId == _userId)
                        .Select(l => new
                        {
                            l.LoanId,
                            BookTitle = l.Book.Title,
                            l.LoanDate,
                            l.DueDate,
                            l.ReturnDate,
                            l.FineAmount,
                            Status = l.ReturnDate.HasValue ? "İade Edildi" :
                                    (l.DueDate < DateTime.Now ? "Gecikmiş" : "Ödünç Verildi")
                        })
                        .ToList();

                    DataGridView dataGridViewLoans = this.Controls.Find("dataGridViewLoans", true).FirstOrDefault() as DataGridView;
                    if (dataGridViewLoans != null)
                    {
                        dataGridViewLoans.DataSource = loanHistory;
                        dataGridViewLoans.Visible = true;
                    }

                    MessageBox.Show("Ödünç geçmişiniz başarıyla listelendi.",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödünç geçmişi listelenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Rezervasyon İşlemleri
        private void btnListReservations_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Rezervasyonlar listeleniyor...",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar listelenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Yeni rezervasyon oluşturuluyor...",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon oluşturulurken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Rezervasyon güncelleniyor...",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon güncellenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Üye İşlemleri
        private void btnMemberDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentUser != null)
                {
                    StringBuilder userDetails = new StringBuilder();
                    userDetails.AppendLine("Kullanıcı Adı: " + _currentUser.Username);

                    if (!string.IsNullOrEmpty(_currentUser.Email))
                        userDetails.AppendLine("E-posta: " + _currentUser.Email);

                    if (!string.IsNullOrEmpty(_currentUser.Phone))
                        userDetails.AppendLine("Telefon: " + _currentUser.Phone);

                    MessageBox.Show(userDetails.ToString(), "Üye Bilgilerim",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Üye bilgileri yüklenemedi.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üye detayları gösterilirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMemberReports_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Üye raporları görüntüleniyor...",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üye raporları görüntülenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Footer İşlemleri
        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Ayarlar açılıyor...",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ayarlar açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Raporlar görüntüleniyor...",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Raporlar görüntülenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Çıkmak istediğinizden emin misiniz?",
                    "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Context'i güvenli şekilde kapat
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }

                    // Ana forma dön
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çıkış işleminde hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        // Form kapatılırken resources'ları temizle
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
            catch (Exception ex)
            {
                // Log the error but don't show message to user during closing
                System.Diagnostics.Debug.WriteLine("Context dispose error: " + ex.Message);
            }
            finally
            {
                base.OnFormClosed(e);
            }
        }
    }
}