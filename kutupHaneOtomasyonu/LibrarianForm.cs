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
                MessageBox.Show(string.Format("Veritabanı bağlantısı kurulamadı: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupPlaceholder()
        {
            // Placeholder text ayarları
            txtSearchBook.Text = placeholderText;
            txtSearchBook.ForeColor = Color.Gray;

            // Event handler'ları ekle
            txtSearchBook.Enter += TxtSearchBook_Enter;
            txtSearchBook.Leave += TxtSearchBook_Leave;
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
                MessageBox.Show(string.Format("Form yüklenirken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserInfo()
        {
            if (_userId > 0 && _context != null)
            {
                try
                {
                    // Entity Framework ile kullanıcı bilgilerini çek
                    _currentUser = _context.Users
                        .Where(u => u.UserId == _userId)
                        .FirstOrDefault();

                    if (_currentUser != null)
                    {
                        // Kullanıcı bilgilerini form başlığına ekle
                        this.Text = string.Format("Kütüphaneci Paneli - {0}", _currentUser.Username);

                        // Welcome label'ını güncelle
                        Label lblWelcome = this.Controls.Find("lblWelcome", true).FirstOrDefault() as Label;
                        if (lblWelcome != null)
                        {
                            lblWelcome.Text = string.Format("Hoş geldiniz, {0}", _currentUser.Username);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Kullanıcı bilgileri yüklenirken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        lblTotalBooks.Text = string.Format("📚 Toplam Kitap: {0:N0}", totalBooks);
                    }

                    // Aktif üye sayısı
                    int totalMembers = _context.Members.Where(m => m.IsActive).Count();
                    Label lblTotalMembers = this.Controls.Find("lblTotalMembers", true).FirstOrDefault() as Label;
                    if (lblTotalMembers != null)
                    {
                        lblTotalMembers.Text = string.Format("👤 Aktif Üye: {0:N0}", totalMembers);
                    }

                    // Şu anda ödünç verilen kitap sayısı
                    int currentLoans = _context.Loans.Where(l => l.ReturnDate == null).Count();
                    Label lblTotalLoans = this.Controls.Find("lblTotalLoans", true).FirstOrDefault() as Label;
                    if (lblTotalLoans != null)
                    {
                        lblTotalLoans.Text = string.Format("📖 Ödünç: {0:N0}", currentLoans);
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
                    MessageBox.Show("Lütfen aranacak kitap adını veya ISBN'i girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            BookId = b.BookId,
                            Title = b.Title,
                            AuthorName = b.Author.Name,
                            Category = b.Category,
                            ISBN = b.ISBN,
                            Publisher = b.Publisher,
                            PublicationYear = b.PublicationYear,
                            TotalCopies = b.TotalCopies,
                            AvailableCopies = b.AvailableCopies
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

                        MessageBox.Show(string.Format("{0} kitap bulundu.", searchResults.Count), "Arama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Arama kriterlerinize uygun kitap bulunamadı.", "Sonuç Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitap arama işleminde hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            BookId = b.BookId,
                            Title = b.Title,
                            AuthorName = b.Author.Name,
                            Category = b.Category,
                            ISBN = b.ISBN,
                            Publisher = b.Publisher,
                            PublicationYear = b.PublicationYear,
                            TotalCopies = b.TotalCopies,
                            AvailableCopies = b.AvailableCopies
                        })
                        .ToList();

                    DataGridView dataGridViewBooks = this.Controls.Find("dataGridViewBooks", true).FirstOrDefault() as DataGridView;
                    if (dataGridViewBooks != null)
                    {
                        dataGridViewBooks.DataSource = books;
                        dataGridViewBooks.Visible = true;
                    }

                    MessageBox.Show("Kitaplar başarıyla listelendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitaplar listelenirken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kitap detayları görüntüleniyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Ödünç İşlemleri

        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Kitap ödünç verme formunu aç
                LoanBookForm loanBookForm = new LoanBookForm();
                loanBookForm.ShowDialog();

                // Form kapandıktan sonra istatistikleri güncelle
                LoadQuickStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünç verme formu açılırken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Kitap iade formunu aç
                ReturnBookForm returnBookForm = new ReturnBookForm();
                returnBookForm.ShowDialog();

                // Form kapandıktan sonra istatistikleri güncelle
                LoadQuickStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("İade formu açılırken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                            LoanId = l.LoanId,
                            BookTitle = l.Book.Title,
                            LoanDate = l.LoanDate,
                            DueDate = l.DueDate,
                            ReturnDate = l.ReturnDate,
                            FineAmount = l.FineAmount,
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

                    MessageBox.Show("Ödünç geçmişiniz başarıyla listelendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünç geçmişi listelenirken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Rezervasyon İşlemleri

        private void btnListReservations_Click(object sender, EventArgs e)
        {
            try
            {
                if (_context != null && _userId > 0)
                {
                    var reservations = _context.Reservations
                        .Include(r => r.Book)
                        .Where(r => r.MemberId == _userId)
                        .Select(r => new
                        {
                            ReservationId = r.ReservationId,
                            BookTitle = r.Book.Title,
                            ReservationDate = r.ReservationDate,
                            Status = r.Status
                        })
                        .ToList();

                    DataGridView dataGridViewReservations = this.Controls.Find("dataGridViewReservations", true).FirstOrDefault() as DataGridView;
                    if (dataGridViewReservations != null)
                    {
                        dataGridViewReservations.DataSource = reservations;
                        dataGridViewReservations.Visible = true;
                    }

                    MessageBox.Show("Rezervasyonlarınız başarıyla listelendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyonlar listelenirken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                ReservationManagementForm reservationForm = new ReservationManagementForm(_userId);
                reservationForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon formu açılırken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                ReservationManagementForm reservationForm = new ReservationManagementForm(_userId);
                reservationForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon güncelleme formu açılırken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    userDetails.AppendLine(string.Format("Kullanıcı Adı: {0}", _currentUser.Username));

                    if (!string.IsNullOrEmpty(_currentUser.Email))
                        userDetails.AppendLine(string.Format("E-posta: {0}", _currentUser.Email));

                    if (!string.IsNullOrEmpty(_currentUser.Phone))
                        userDetails.AppendLine(string.Format("Telefon: {0}", _currentUser.Phone));

                    MessageBox.Show(userDetails.ToString(), "Üye Bilgilerim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Üye bilgileri yüklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üye detayları gösterilirken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMemberReports_Click(object sender, EventArgs e)
        {
            try
            {
                if (_context != null && _userId > 0)
                {
                    int totalLoans = _context.Loans.Where(l => l.MemberId == _userId).Count();
                    int activeLoans = _context.Loans.Where(l => l.MemberId == _userId && l.ReturnDate == null).Count();
                    int overdueLoans = _context.Loans.Where(l => l.MemberId == _userId && l.ReturnDate == null && l.DueDate < DateTime.Now).Count();
                    int totalReservations = _context.Reservations.Where(r => r.MemberId == _userId).Count();

                    string statsMessage = string.Format("📊 Kişisel İstatistikleriniz:\n\n" +
                                        "📚 Toplam Ödünç: {0}\n" +
                                        "📖 Aktif Ödünç: {1}\n" +
                                        "⚠️ Gecikmiş: {2}\n" +
                                        "🔖 Rezervasyonlar: {3}",
                                        totalLoans, activeLoans, overdueLoans, totalReservations);

                    MessageBox.Show(statsMessage, "Üye İstatistikleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("İstatistikler yüklenirken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Footer İşlemleri

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ayarlar formu açılırken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                ReportForm reportForm = new ReportForm();
                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Raporlar formu açılırken hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                MessageBox.Show(string.Format("Çıkış işleminde hata oluştu: {0}", ex.Message), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                System.Diagnostics.Debug.WriteLine(string.Format("Context dispose error: {0}", ex.Message));
            }
            finally
            {
                base.OnFormClosed(e);
            }
        }

        // Form disposing edilirken
       
        }
    }

