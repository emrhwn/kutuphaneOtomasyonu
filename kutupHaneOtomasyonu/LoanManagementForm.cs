using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class LoanManagementForm : Form
    {
        private readonly LibraryContext _context;
        private int selectedLoanId = 0;

        public LoanManagementForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LoanManagementForm_Load(object sender, EventArgs e)
        {
            LoadLoans();
            LoadMembers();
            LoadBooks();
            UpdateStatistics();
            ClearForm();
        }

        private void LoadLoans()
        {
            try
            {
                var loans = (from l in _context.Loans
                             join m in _context.Members on l.MemberId equals m.MemberId
                             join b in _context.Books on l.BookId equals b.BookId
                             select new
                             {
                                 l.LoanId,
                                 MemberName = m.FirstName + " " + m.LastName,
                                 BookTitle = b.Title,
                                 l.LoanDate,
                                 l.DueDate,
                                 l.ReturnDate,
                                 Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                                 DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                                     System.Data.Entity.DbFunctions.DiffDays(l.DueDate, DateTime.Now) ?? 0 : 0,
                                 Fine = l.Fine ?? 0m
                             })
                             .OrderByDescending(l => l.LoanDate)
                             .ToList();

                dgvLoans.DataSource = loans;

                // DataGridView ayarlarını kontrol et
                if (dgvLoans.Columns.Count > 0)
                {
                    // Kolon başlıklarını düzenle
                    dgvLoans.Columns["LoanId"].HeaderText = "ID";
                    dgvLoans.Columns["MemberName"].HeaderText = "Üye Adı";
                    dgvLoans.Columns["BookTitle"].HeaderText = "Kitap Adı";
                    dgvLoans.Columns["LoanDate"].HeaderText = "Ödünç Tarihi";
                    dgvLoans.Columns["DueDate"].HeaderText = "İade Tarihi";
                    dgvLoans.Columns["ReturnDate"].HeaderText = "Teslim Tarihi";
                    dgvLoans.Columns["Status"].HeaderText = "Durum";
                    dgvLoans.Columns["DaysLate"].HeaderText = "Gecikme (Gün)";
                    dgvLoans.Columns["Fine"].HeaderText = "Ceza (TL)";

                    // Kolon genişliklerini ayarla
                    dgvLoans.Columns["LoanId"].Width = 50;
                    dgvLoans.Columns["MemberName"].Width = 150;
                    dgvLoans.Columns["BookTitle"].Width = 200;
                    dgvLoans.Columns["LoanDate"].Width = 100;
                    dgvLoans.Columns["DueDate"].Width = 100;
                    dgvLoans.Columns["ReturnDate"].Width = 100;
                    dgvLoans.Columns["Status"].Width = 80;
                    dgvLoans.Columns["DaysLate"].Width = 80;
                    dgvLoans.Columns["Fine"].Width = 80;

                    // Tarih formatlarını düzenle
                    dgvLoans.Columns["LoanDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvLoans.Columns["DueDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvLoans.Columns["ReturnDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                    // Para formatını düzenle
                    dgvLoans.Columns["Fine"].DefaultCellStyle.Format = "C2";
                    dgvLoans.Columns["Fine"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("tr-TR");

                    // Sütun hizalamalarını ayarla
                    dgvLoans.Columns["LoanId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvLoans.Columns["DaysLate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvLoans.Columns["Fine"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvLoans.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Geciken kayıtları renklendir
                    foreach (DataGridViewRow row in dgvLoans.Rows)
                    {
                        if (row.Cells["DaysLate"].Value != null)
                        {
                            int daysLate = Convert.ToInt32(row.Cells["DaysLate"].Value);
                            string status = row.Cells["Status"].Value?.ToString();

                            if (daysLate > 0 && status == "Ödünçte")
                            {
                                // Gecikmiş ve hala iade edilmemiş
                                row.DefaultCellStyle.BackColor = Color.MistyRose;
                                row.DefaultCellStyle.ForeColor = Color.DarkRed;
                            }
                            else if (daysLate > 0 && status == "İade Edildi")
                            {
                                // Geç iade edilmiş
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                            }
                            else if (status == "İade Edildi")
                            {
                                // Zamanında iade edilmiş
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                        }
                    }

                    // Seçim modunu ayarla
                    dgvLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvLoans.MultiSelect = false;
                    dgvLoans.ReadOnly = true;
                    dgvLoans.AllowUserToAddRows = false;
                    dgvLoans.AllowUserToDeleteRows = false;
                    dgvLoans.AllowUserToOrderColumns = true;
                    dgvLoans.RowHeadersVisible = false;

                    // Alternatif satır renkleri
                    dgvLoans.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                }

                // Durum bilgisini güncelle
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Emanet kayıtları yüklenirken hata oluştu:\n{ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Durum çubuğunu güncelleme metodu
        private void UpdateStatusBar()
        {
            try
            {
                var totalLoans = dgvLoans.Rows.Count;
                var activeLoans = dgvLoans.Rows.Cast<DataGridViewRow>()
                    .Count(r => r.Cells["Status"].Value?.ToString() == "Ödünçte");
                var overdueLoans = dgvLoans.Rows.Cast<DataGridViewRow>()
                    .Count(r => Convert.ToInt32(r.Cells["DaysLate"].Value) > 0 &&
                                r.Cells["Status"].Value?.ToString() == "Ödünçte");

                // Eğer status label'larınız varsa
                // lblTotalLoans.Text = $"Toplam: {totalLoans}";
                // lblActiveLoans.Text = $"Aktif: {activeLoans}";
                // lblOverdueLoans.Text = $"Gecikmiş: {overdueLoans}";
            }
            catch { }
        }

        private void LoadMembers()
        {
            try
            {
                var members = _context.Members
                    .Where(m => m.IsActive)
                    .OrderBy(m => m.FirstName)
                    .ThenBy(m => m.LastName)
                    .Select(m => new
                    {
                        m.MemberId,
                        FullName = m.FirstName + " " + m.LastName
                    })
                    .ToList();

                cmbMember.DataSource = members;
                cmbMember.DisplayMember = "FullName";
                cmbMember.ValueMember = "MemberId";
                cmbMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Üyeler yüklenirken hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var books = (from b in _context.Books
                             join a in _context.Authors on b.AuthorId equals a.AuthorId
                             where b.AvailableCopies > 0
                             select new
                             {
                                 b.BookId,
                                 b.Title,
                                 AuthorName = a.FirstName + " " + a.LastName,
                                 b.AvailableCopies
                             }).ToList();

                var booksWithDisplay = books.Select(b => new
                {
                    b.BookId,
                    DisplayText = b.Title + " - " + b.AuthorName + " (Mevcut: " + b.AvailableCopies + ")"
                }).ToList();

                cmbBook.DataSource = booksWithDisplay;
                cmbBook.DisplayMember = "DisplayText";
                cmbBook.ValueMember = "BookId";
                cmbBook.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitaplar yüklenirken hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            try
            {
                // Temel istatistikler
                int totalLoans = _context.Loans.Count();
                int activeLoans = _context.Loans.Where(l => l.ReturnDate == null).Count();
                int overdueLoans = _context.Loans
                    .Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now)
                    .Count();

                // Fine toplamını hesapla
                decimal totalFines = 0;
                var loansWithFines = _context.Loans.Where(l => l.Fine != null).ToList();
                if (loansWithFines.Any())
                {
                    totalFines = loansWithFines.Sum(l => l.Fine.Value);
                }

                // Label'ları güncelle
                lblTotalLoans.Text = String.Format("Toplam Ödünç: {0}", totalLoans);
                lblActiveLoans.Text = String.Format("Aktif Ödünç: {0}", activeLoans);
                lblOverdueLoans.Text = String.Format("Geciken: {0}", overdueLoans);
                lblTotalFines.Text = String.Format("Toplam Ceza: {0:C2}", totalFines);
            }
            catch (Exception ex)
            {
                // Varsayılan değerler
                lblTotalLoans.Text = "Toplam Ödünç: 0";
                lblActiveLoans.Text = "Aktif Ödünç: 0";
                lblOverdueLoans.Text = "Geciken: 0";
                lblTotalFines.Text = "Toplam Ceza: ₺0,00";

                // Debug için
                System.Diagnostics.Debug.WriteLine("UpdateStatistics Error: " + ex.Message);
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex == -1 || cmbBook.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen üye ve kitap seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int memberId = (int)cmbMember.SelectedValue;
                int bookId = (int)cmbBook.SelectedValue;

                // Üyenin aktif ödünç sayısını kontrol et
                int activeLoanCount = _context.Loans
                    .Count(l => l.MemberId == memberId && l.ReturnDate == null);

                if (activeLoanCount >= 3) // Maksimum 3 kitap
                {
                    MessageBox.Show("Bu üye zaten 3 kitap ödünç almış. Daha fazla kitap alamaz!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Üyenin gecikmiş kitabı var mı?
                bool hasOverdue = _context.Loans
                    .Any(l => l.MemberId == memberId && l.ReturnDate == null && l.DueDate < DateTime.Now);

                if (hasOverdue)
                {
                    MessageBox.Show("Bu üyenin gecikmiş kitabı var. Önce teslim edilmeli!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var loan = new Loan
                {
                    MemberId = memberId,
                    BookId = bookId,
                    LoanDate = dtpLoanDate.Value,
                    DueDate = dtpDueDate.Value
                };

                _context.Loans.Add(loan);

                // Kitabın mevcut kopyasını azalt
                var book = _context.Books.Find(bookId);
                if (book != null)
                {
                    book.AvailableCopies--;
                }

                _context.SaveChanges();

                MessageBox.Show("Kitap başarıyla ödünç verildi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLoans();
                LoadBooks();
                UpdateStatistics();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nDetay: {ex.InnerException?.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedLoanId == 0)
            {
                MessageBox.Show("Lütfen iade edilecek kaydı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var loan = _context.Loans.Find(selectedLoanId);
                if (loan != null && loan.ReturnDate == null)
                {
                    loan.ReturnDate = DateTime.Now;

                    // Gecikme cezası hesapla
                    if (loan.DueDate < DateTime.Now)
                    {
                        int daysLate = (int)(DateTime.Now - loan.DueDate).TotalDays;
                        loan.Fine = daysLate * 1.0m; // Günlük 1 TL ceza

                        MessageBox.Show($"Kitap {daysLate} gün gecikmeli.\nCeza tutarı: {loan.Fine:C2}",
                            "Gecikme Cezası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Kitabın mevcut kopyasını artır
                    var book = _context.Books.Find(loan.BookId);
                    if (book != null)
                    {
                        book.AvailableCopies++;
                    }

                    _context.SaveChanges();

                    MessageBox.Show("Kitap başarıyla iade alındı.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLoans();
                    LoadBooks();
                    UpdateStatistics();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Bu kitap zaten iade edilmiş.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (selectedLoanId == 0)
            {
                MessageBox.Show("Lütfen süre uzatılacak kaydı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var loan = _context.Loans.Find(selectedLoanId);
                if (loan != null && loan.ReturnDate == null)
                {
                    // Gecikmiş mi kontrol et
                    if (loan.DueDate < DateTime.Now)
                    {
                        MessageBox.Show("Gecikmiş kitapların süresi uzatılamaz!", "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Süreyi 7 gün uzat
                    loan.DueDate = loan.DueDate.AddDays(7);
                    _context.SaveChanges();

                    MessageBox.Show("Ödünç süresi 7 gün uzatıldı.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLoans();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoans.Rows[e.RowIndex];
                selectedLoanId = Convert.ToInt32(row.Cells["LoanId"].Value);

                var loan = _context.Loans
                    .Where(l => l.LoanId == selectedLoanId)
                    .Select(l => new
                    {
                        l.MemberId,
                        l.BookId,
                        l.LoanDate,
                        l.DueDate,
                        l.ReturnDate
                    })
                    .FirstOrDefault();

                if (loan != null)
                {
                    cmbMember.SelectedValue = loan.MemberId;
                    dtpLoanDate.Value = loan.LoanDate;
                    dtpDueDate.Value = loan.DueDate;

                    // İade edilmişse butonları devre dışı bırak
                    bool isReturned = loan.ReturnDate.HasValue;
                    btnReturn.Enabled = !isReturned;
                    btnExtend.Enabled = !isReturned;

                    if (!isReturned)
                    {
                        // İade edilmemiş kitap için mevcut kitapları göster
                        LoadBooksForReturn(loan.BookId);
                    }
                }
            }
        }

        private void LoadBooksForReturn(int currentBookId)
        {
            try
            {
                var allBooks = _context.Books
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        b.AvailableCopies
                    })
                    .ToList();

                var booksWithDisplay = allBooks.Select(b => new
                {
                    b.BookId,
                    DisplayText = b.Title +
                        (b.BookId == currentBookId ? " (Mevcut Kitap)" : " (Mevcut: " + b.AvailableCopies + ")")
                }).ToList();

                cmbBook.DataSource = booksWithDisplay;
                cmbBook.DisplayMember = "DisplayText";
                cmbBook.ValueMember = "BookId";
                cmbBook.SelectedValue = currentBookId;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadBooksForReturn Error: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();

                var loans = (from l in _context.Loans
                             join m in _context.Members on l.MemberId equals m.MemberId
                             join b in _context.Books on l.BookId equals b.BookId
                             where m.FirstName.ToLower().Contains(searchText) ||
                                   m.LastName.ToLower().Contains(searchText) ||
                                   b.Title.ToLower().Contains(searchText) ||
                                   b.ISBN.Contains(searchText)
                             select new
                             {
                                 l.LoanId,
                                 MemberName = m.FirstName + " " + m.LastName,
                                 BookTitle = b.Title,
                                 l.LoanDate,
                                 l.DueDate,
                                 l.ReturnDate,
                                 Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                                 DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                                     System.Data.Entity.DbFunctions.DiffDays(l.DueDate, DateTime.Now) ?? 0 : 0,
                                 Fine = l.Fine ?? 0m
                             })
                             .OrderByDescending(l => l.LoanDate)
                             .ToList();

                dgvLoans.DataSource = loans;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Search Error: " + ex.Message);
            }
        }

        private void chkShowReturned_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkShowReturned.Checked)
                {
                    LoadLoans(); // Tümünü göster
                }
                else
                {
                    // Sadece iade edilmemişleri göster
                    var activeLoans = (from l in _context.Loans
                                       join m in _context.Members on l.MemberId equals m.MemberId
                                       join b in _context.Books on l.BookId equals b.BookId
                                       where l.ReturnDate == null
                                       select new
                                       {
                                           l.LoanId,
                                           MemberName = m.FirstName + " " + m.LastName,
                                           BookTitle = b.Title,
                                           l.LoanDate,
                                           l.DueDate,
                                           l.ReturnDate,
                                           Status = "Ödünçte",
                                           DaysLate = l.DueDate < DateTime.Now ?
                                               System.Data.Entity.DbFunctions.DiffDays(l.DueDate, DateTime.Now) ?? 0 : 0,
                                           Fine = l.Fine ?? 0m
                                       })
                                       .OrderByDescending(l => l.LoanDate)
                                       .ToList();

                    dgvLoans.DataSource = activeLoans;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filtreleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpLoanDate_ValueChanged(object sender, EventArgs e)
        {
            // İade tarihini otomatik ayarla (14 gün)
            dtpDueDate.Value = dtpLoanDate.Value.AddDays(14);
        }

        private void ClearForm()
        {
            selectedLoanId = 0;
            cmbMember.SelectedIndex = -1;
            cmbBook.SelectedIndex = -1;
            dtpLoanDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(14);
            txtSearch.Clear();
            btnReturn.Enabled = true;
            btnExtend.Enabled = true;
        }

        private void LoanManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}