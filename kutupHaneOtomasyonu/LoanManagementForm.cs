using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;

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
            var loansData = _context.Loans.ToList();

            var loans = loansData.Select(l => new
            {
                l.LoanId,
                MemberName = l.Member.FirstName + " " + l.Member.LastName,
                BookTitle = l.Book.Title,
                l.LoanDate,
                l.DueDate,
                l.ReturnDate,
                Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                    (int)(DateTime.Now - l.DueDate).TotalDays : 0,
                Fine = l.Fine.HasValue ? l.Fine.Value : 0m
            })
            .OrderByDescending(l => l.LoanDate)
            .ToList();

            dgvLoans.DataSource = loans;

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

            // Geciken kayıtları renklendir
            foreach (DataGridViewRow row in dgvLoans.Rows)
            {
                int daysLate = Convert.ToInt32(row.Cells["DaysLate"].Value);
                if (daysLate > 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                }
            }
        }

        private void LoadMembers()
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

        private void LoadBooks()
        {
            var books = _context.Books
                .Where(b => b.AvailableCopies > 0)
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    b.BookId,
                    DisplayText = b.Title + " - " + b.Author.Name + " (Mevcut: " + b.AvailableCopies + ")"
                })
                .ToList();

            cmbBook.DataSource = books;
            cmbBook.DisplayMember = "DisplayText";
            cmbBook.ValueMember = "BookId";
            cmbBook.SelectedIndex = -1;
        }

        private void UpdateStatistics()
        {
            int totalLoans = _context.Loans.Count();
            int activeLoans = _context.Loans.Count(l => l.ReturnDate == null);
            int overdueLoans = _context.Loans.Count(l => l.ReturnDate == null && l.DueDate < DateTime.Now);

            // Fine toplamını hesapla
            var allLoans = _context.Loans.ToList();
            decimal totalFines = allLoans.Where(l => l.Fine.HasValue).Sum(l => l.Fine.Value);

            lblTotalLoans.Text = $"Toplam Ödünç: {totalLoans}";
            lblActiveLoans.Text = $"Aktif Ödünç: {activeLoans}";
            lblOverdueLoans.Text = $"Geciken: {overdueLoans}";
            lblTotalFines.Text = $"Toplam Ceza: {totalFines:C2}";
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
                book.AvailableCopies--;

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
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
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
                    book.AvailableCopies++;

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
            var allBooks = _context.Books
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    b.BookId,
                    DisplayText = b.Title + " - " + b.Author.Name +
                        (b.BookId == currentBookId ? " (Mevcut Kitap)" : " (Mevcut: " + b.AvailableCopies + ")")
                })
                .ToList();

            cmbBook.DataSource = allBooks;
            cmbBook.DisplayMember = "DisplayText";
            cmbBook.ValueMember = "BookId";
            cmbBook.SelectedValue = currentBookId;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            var loansData = _context.Loans
                .Where(l => l.Member.FirstName.ToLower().Contains(searchText) ||
                           l.Member.LastName.ToLower().Contains(searchText) ||
                           l.Book.Title.ToLower().Contains(searchText) ||
                           l.Book.ISBN.Contains(searchText))
                .ToList();

            var loans = loansData.Select(l => new
            {
                l.LoanId,
                MemberName = l.Member.FirstName + " " + l.Member.LastName,
                BookTitle = l.Book.Title,
                l.LoanDate,
                l.DueDate,
                l.ReturnDate,
                Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                    (int)(DateTime.Now - l.DueDate).TotalDays : 0,
                Fine = l.Fine.HasValue ? l.Fine.Value : 0m
            })
            .OrderByDescending(l => l.LoanDate)
            .ToList();

            dgvLoans.DataSource = loans;
        }

        private void chkShowReturned_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowReturned.Checked)
            {
                LoadLoans(); // Tümünü göster
            }
            else
            {
                // Sadece iade edilmemişleri göster
                var activeLoansData = _context.Loans
                    .Where(l => l.ReturnDate == null)
                    .ToList();

                var activeLoans = activeLoansData.Select(l => new
                {
                    l.LoanId,
                    MemberName = l.Member.FirstName + " " + l.Member.LastName,
                    BookTitle = l.Book.Title,
                    l.LoanDate,
                    l.DueDate,
                    l.ReturnDate,
                    Status = "Ödünçte",
                    DaysLate = l.DueDate < DateTime.Now ?
                        (int)(DateTime.Now - l.DueDate).TotalDays : 0,
                    Fine = l.Fine.HasValue ? l.Fine.Value : 0m
                })
                .OrderByDescending(l => l.LoanDate)
                .ToList();

                dgvLoans.DataSource = activeLoans;
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