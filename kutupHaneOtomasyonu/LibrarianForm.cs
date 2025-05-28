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
using kutupHaneOtomasyonu.Forms;

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
                    // Entity Framework ile kullanıcı bilgilerini çek
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
                // Kitap listesi formu
                LibrarianBookListForm bookListForm = new LibrarianBookListForm();
                bookListForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap listesi formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookDetails_Click(object sender, EventArgs e)
        {
            try
            {
                // Kitap detayları formu
                BookDetailsForm detailsForm = new BookDetailsForm();
                detailsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitap detayları formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Ödünç İşlemleri
        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Ödünç verme formu
                LibrarianLoanForm loanForm = new LibrarianLoanForm(_userId);
                loanForm.ShowDialog();

                // Form kapandıktan sonra istatistikleri güncelle
                LoadQuickStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödünç verme formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                // İade alma formu
                LibrarianReturnForm returnForm = new LibrarianReturnForm(_userId);
                returnForm.ShowDialog();

                // Form kapandıktan sonra istatistikleri güncelle
                LoadQuickStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İade formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoanHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Ödünç geçmişi formu
                LibrarianLoanHistoryForm historyForm = new LibrarianLoanHistoryForm(_userId);
                historyForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödünç geçmişi formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Rezervasyon İşlemleri
        private void btnListReservations_Click(object sender, EventArgs e)
        {
            try
            {
                // Rezervasyon listesi formu
                ReservationListForm listForm = new ReservationListForm(_userId);
                listForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon listesi açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni rezervasyon formu
                LibrarianReservationForm reservationForm = new LibrarianReservationForm(_userId);
                reservationForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                // Rezervasyon güncelleme formu
                LibrarianReservationUpdateForm updateForm = new LibrarianReservationUpdateForm(_userId);
                updateForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon güncelleme formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Üye İşlemleri
        private void btnMemberDetails_Click(object sender, EventArgs e)
        {
            try
            {
                // Üye detayları formu
                MemberDetailsForm memberForm = new MemberDetailsForm(_userId);
                memberForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üye detayları formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMemberReports_Click(object sender, EventArgs e)
        {
            try
            {
                // Üye raporları formu
                ReportForm reportsForm = new ReportForm();
                reportsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üye raporları formu açılırken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Footer İşlemleri
        // btnSettings_Click metodu kaldırıldı

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                // Raporlar formu
                ReportForm reportsForm = new ReportForm();
                reportsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Raporlar formu açılırken hata oluştu: " + ex.Message,
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