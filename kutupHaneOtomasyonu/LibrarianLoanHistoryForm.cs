using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class LibrarianLoanHistoryForm : Form
    {
        private LibraryContext _context;
        private int _userId;

        public LibrarianLoanHistoryForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LibrarianLoanHistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                cmbFilter.SelectedIndex = 0;
                LoadLoanHistory();
                SetupDataGridView();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Form yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoanHistory()
        {
            try
            {
                // Entity Framework sorgusu - eager loading ile
                var loansQuery = _context.Loans
                    .Include(l => l.Member)
                    .Include(l => l.Book)
                    .Include(l => l.Book.Author)
                    .Where(l => l.UserId == _userId);

                // Veritabanından veri çekme
                var loans = loansQuery.ToList();

                // Projection (view model oluşturma)
                var loanViewModels = loans.Select(l => new
                {
                    LoanId = l.LoanId,
                    MemberName = string.Format("{0} {1}", l.Member.FirstName, l.Member.LastName),
                    BookTitle = l.Book.Title,
                    Author = l.Book.Author != null ? l.Book.Author.Name : "Bilinmeyen",
                    LoanDate = l.LoanDate,
                    DueDate = l.DueDate,
                    ReturnDate = l.ReturnDate,
                    FineAmount = l.FineAmount,  // Direkt kullan, nullable değil
                    Status = GetLoanStatus(l),
                    DaysOverdue = CalculateDaysOverdue(l)
                })
                .OrderByDescending(l => l.LoanDate)
                .ToList();

                dgvLoanHistory.DataSource = loanViewModels;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünç geçmişi yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper metodlar
        private string GetLoanStatus(Loan loan)
        {
            if (loan.ReturnDate.HasValue)
                return "İade Edildi";
            else if (loan.DueDate < DateTime.Now)
                return "Gecikmiş";
            else
                return "Ödünçte";
        }

        private int CalculateDaysOverdue(Loan loan)
        {
            if (loan.ReturnDate.HasValue)
                return 0;

            if (loan.DueDate < DateTime.Now)
                return (DateTime.Now - loan.DueDate).Days;

            return 0;
        }

        private void SetupDataGridView()
        {
            if (dgvLoanHistory.Columns.Count > 0)
            {
                dgvLoanHistory.Columns["LoanId"].Visible = false;
                dgvLoanHistory.Columns["MemberName"].HeaderText = "Üye Adı";
                dgvLoanHistory.Columns["BookTitle"].HeaderText = "Kitap";
                dgvLoanHistory.Columns["Author"].HeaderText = "Yazar";
                dgvLoanHistory.Columns["LoanDate"].HeaderText = "Ödünç Tarihi";
                dgvLoanHistory.Columns["DueDate"].HeaderText = "İade Tarihi";
                dgvLoanHistory.Columns["ReturnDate"].HeaderText = "Teslim Tarihi";
                dgvLoanHistory.Columns["FineAmount"].HeaderText = "Ceza (TL)";
                dgvLoanHistory.Columns["Status"].HeaderText = "Durum";
                dgvLoanHistory.Columns["DaysOverdue"].HeaderText = "Gecikme (Gün)";

                // Tarih formatları
                dgvLoanHistory.Columns["LoanDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvLoanHistory.Columns["DueDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvLoanHistory.Columns["ReturnDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvLoanHistory.Columns["FineAmount"].DefaultCellStyle.Format = "C2";

                // Kolon genişlikleri
                dgvLoanHistory.Columns["MemberName"].Width = 150;
                dgvLoanHistory.Columns["BookTitle"].Width = 200;
                dgvLoanHistory.Columns["Author"].Width = 120;
                dgvLoanHistory.Columns["Status"].Width = 100;

                dgvLoanHistory.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void dgvLoanHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLoanHistory.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    switch (status)
                    {
                        case "İade Edildi":
                            e.CellStyle.ForeColor = Color.Green;
                            break;
                        case "Gecikmiş":
                            e.CellStyle.ForeColor = Color.Red;
                            break;
                        case "Ödünçte":
                            e.CellStyle.ForeColor = Color.Orange;
                            break;
                    }
                }
            }
            else if (dgvLoanHistory.Columns[e.ColumnIndex].Name == "DaysOverdue")
            {
                if (e.Value != null && Convert.ToInt32(e.Value) > 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void UpdateStatistics()
        {
            try
            {
                // Entity Framework aggregate queries
                var query = _context.Loans.Where(l => l.UserId == _userId);

                int totalLoans = query.Count();
                int activeLoans = query.Count(l => l.ReturnDate == null);
                int overdueLoans = query.Count(l => l.ReturnDate == null && l.DueDate < DateTime.Now);
                int returnedLoans = query.Count(l => l.ReturnDate != null);

                // Sum için null kontrolü
                decimal totalFines = query
                    .Where(l => l.FineAmount != null)
                    .Sum(l => (decimal?)l.FineAmount) ?? 0m;

                lblTotalLoans.Text = string.Format("Toplam İşlem: {0}", totalLoans);
                lblActiveLoans.Text = string.Format("Aktif: {0}", activeLoans);
                lblOverdueLoans.Text = string.Format("Gecikmiş: {0}", overdueLoans);
                lblReturnedLoans.Text = string.Format("İade Edilmiş: {0}", returnedLoans);
                lblTotalFines.Text = string.Format("Toplam Ceza: {0:C2}", totalFines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("İstatistikler yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            try
            {
                // Base query
                IQueryable<Loan> query = _context.Loans
                    .Include(l => l.Member)
                    .Include(l => l.Book)
                    .Include(l => l.Book.Author)
                    .Where(l => l.UserId == _userId);

                // Apply status filter
                if (cmbFilter.SelectedIndex > 0)
                {
                    switch (cmbFilter.SelectedItem.ToString())
                    {
                        case "Aktif":
                            query = query.Where(l => l.ReturnDate == null);
                            break;
                        case "İade Edilmiş":
                            query = query.Where(l => l.ReturnDate != null);
                            break;
                        case "Gecikmiş":
                            query = query.Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now);
                            break;
                    }
                }

                // Execute query
                var loans = query.ToList();

                // Apply text search in memory
                string searchText = txtSearch.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(searchText))
                {
                    loans = loans.Where(l =>
                        string.Format("{0} {1}", l.Member.FirstName, l.Member.LastName).ToLower().Contains(searchText) ||
                        l.Book.Title.ToLower().Contains(searchText) ||
                        (l.Book.Author != null && l.Book.Author.Name.ToLower().Contains(searchText))
                    ).ToList();
                }

                // Create view models
                var results = loans.Select(l => new
                {
                    LoanId = l.LoanId,
                    MemberName = string.Format("{0} {1}", l.Member.FirstName, l.Member.LastName),
                    BookTitle = l.Book.Title,
                    Author = l.Book.Author != null ? l.Book.Author.Name : "Bilinmeyen",
                    LoanDate = l.LoanDate,
                    DueDate = l.DueDate,
                    ReturnDate = l.ReturnDate,
                    FineAmount = l.FineAmount,  // Direkt kullan, nullable değil
                    Status = GetLoanStatus(l),
                    DaysOverdue = CalculateDaysOverdue(l)
                })
                .OrderByDescending(l => l.LoanDate)
                .ToList();

                dgvLoanHistory.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Filtre uygulanırken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            txtSearch.Clear();
            LoadLoanHistory();
            UpdateStatistics();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dışa aktarma özelliği yakında eklenecek.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Public method to refresh loan history
        public void RefreshLoanHistory()
        {
            LoadLoanHistory();
            UpdateStatistics();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }

        }
    }
}