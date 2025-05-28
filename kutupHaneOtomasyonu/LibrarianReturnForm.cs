using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using System.Drawing;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class LibrarianReturnForm : Form
    {
        private LibraryContext _context;
        private int _userId;

        public LibrarianReturnForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LibrarianReturnForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadActiveLoans();
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Form yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadActiveLoans()
        {
            try
            {
                var activeLoans = _context.Loans
                    .Include(l => l.Member)
                    .Include(l => l.Book)
                    .Include(l => l.Book.Author)
                    .Where(l => l.ReturnDate == null)
                    .ToList()
                    .Select(l => new
                    {
                        LoanId = l.LoanId,
                        MemberName = string.Format("{0} {1}", l.Member.FirstName, l.Member.LastName),
                        MemberEmail = l.Member.Email,
                        BookTitle = l.Book.Title,
                        Author = l.Book.Author != null ? l.Book.Author.Name : "Bilinmeyen",
                        ISBN = l.Book.ISBN,
                        LoanDate = l.LoanDate,
                        DueDate = l.DueDate,
                        DaysOverdue = CalculateDaysOverdue(l.DueDate),
                        Fine = CalculateFine(l.DueDate),
                        Status = GetLoanStatus(l.DueDate)
                    })
                    .OrderBy(l => l.DueDate)
                    .ToList();

                dgvActiveLoans.DataSource = activeLoans;
                lblTotalActiveLoans.Text = string.Format("Toplam {0} aktif ödünç", activeLoans.Count);

                // Gecikmiş ödünçleri say
                int overdueCount = activeLoans.Count(l => l.DaysOverdue > 0);
                if (overdueCount > 0)
                {
                    lblTotalActiveLoans.Text += string.Format(" ({0} gecikmiş)", overdueCount);
                    lblTotalActiveLoans.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Aktif ödünçler yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            if (dgvActiveLoans.Columns.Count > 0)
            {
                dgvActiveLoans.Columns["LoanId"].Visible = false;
                dgvActiveLoans.Columns["MemberName"].HeaderText = "Üye Adı";
                dgvActiveLoans.Columns["MemberEmail"].HeaderText = "E-posta";
                dgvActiveLoans.Columns["BookTitle"].HeaderText = "Kitap";
                dgvActiveLoans.Columns["Author"].HeaderText = "Yazar";
                dgvActiveLoans.Columns["ISBN"].HeaderText = "ISBN";
                dgvActiveLoans.Columns["LoanDate"].HeaderText = "Ödünç Tarihi";
                dgvActiveLoans.Columns["DueDate"].HeaderText = "İade Tarihi";
                dgvActiveLoans.Columns["DaysOverdue"].HeaderText = "Gecikme (Gün)";
                dgvActiveLoans.Columns["Fine"].HeaderText = "Ceza (TL)";
                dgvActiveLoans.Columns["Status"].HeaderText = "Durum";

                // Tarih formatları
                dgvActiveLoans.Columns["LoanDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvActiveLoans.Columns["DueDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvActiveLoans.Columns["Fine"].DefaultCellStyle.Format = "C2";

                // Kolon genişlikleri
                dgvActiveLoans.Columns["MemberName"].Width = 150;
                dgvActiveLoans.Columns["BookTitle"].Width = 200;
                dgvActiveLoans.Columns["Author"].Width = 120;
                dgvActiveLoans.Columns["Status"].Width = 100;
            }
        }

        private int CalculateDaysOverdue(DateTime dueDate)
        {
            if (dueDate < DateTime.Now.Date)
            {
                return (DateTime.Now.Date - dueDate).Days;
            }
            return 0;
        }

        private decimal CalculateFine(DateTime dueDate)
        {
            int daysOverdue = CalculateDaysOverdue(dueDate);
            if (daysOverdue > 0)
            {
                // Günlük 1 TL ceza
                return daysOverdue * 1.0m;
            }
            return 0m;
        }

        private string GetLoanStatus(DateTime dueDate)
        {
            if (dueDate < DateTime.Now.Date)
                return "Gecikmiş";
            else if (dueDate == DateTime.Now.Date)
                return "Bugün Teslim";
            else
                return "Normal";
        }

        private void dgvActiveLoans_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvActiveLoans.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    switch (status)
                    {
                        case "Gecikmiş":
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            break;
                        case "Bugün Teslim":
                            e.CellStyle.ForeColor = Color.Orange;
                            e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            break;
                        case "Normal":
                            e.CellStyle.ForeColor = Color.Green;
                            break;
                    }
                }
            }
            else if (dgvActiveLoans.Columns[e.ColumnIndex].Name == "DaysOverdue")
            {
                if (e.Value != null && Convert.ToInt32(e.Value) > 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void dgvActiveLoans_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActiveLoans.SelectedRows.Count > 0)
            {
                var selectedRow = dgvActiveLoans.SelectedRows[0];
                decimal fine = Convert.ToDecimal(selectedRow.Cells["Fine"].Value);
                string memberName = selectedRow.Cells["MemberName"].Value.ToString();
                string bookTitle = selectedRow.Cells["BookTitle"].Value.ToString();
                int daysOverdue = Convert.ToInt32(selectedRow.Cells["DaysOverdue"].Value);

                // Seçili ödünç bilgisini göster
                lblSelectedLoan.Text = string.Format("Seçili: {0} - {1}", memberName, bookTitle);

                if (fine > 0)
                {
                    lblFineAmount.Text = string.Format("Ceza Tutarı: {0:C2} ({1} gün gecikme)", fine, daysOverdue);
                    lblFineAmount.ForeColor = Color.Red;
                    lblFineAmount.Visible = true;
                }
                else
                {
                    lblFineAmount.Visible = false;
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvActiveLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iade edilecek kaydı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgvActiveLoans.SelectedRows[0];
                int loanId = Convert.ToInt32(selectedRow.Cells["LoanId"].Value);
                decimal fine = Convert.ToDecimal(selectedRow.Cells["Fine"].Value);
                string memberName = selectedRow.Cells["MemberName"].Value.ToString();
                string bookTitle = selectedRow.Cells["BookTitle"].Value.ToString();

                string confirmMessage = string.Format(
                    "Üye: {0}\nKitap: {1}\n", memberName, bookTitle);

                if (fine > 0)
                {
                    confirmMessage += string.Format("\nCeza Tutarı: {0:C2}\n", fine);
                }

                confirmMessage += "\nİade işlemini onaylıyor musunuz?";

                if (MessageBox.Show(confirmMessage, "İade Onayı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var loan = _context.Loans.Find(loanId);
                    if (loan != null)
                    {
                        // İade işlemi
                        loan.ReturnDate = DateTime.Now;
                        loan.FineAmount = fine;

                        // Kitap stoğunu güncelle
                        var book = _context.Books.Find(loan.BookId);
                        if (book != null)
                        {
                            book.AvailableCopies++;
                        }

                        _context.SaveChanges();

                        string successMessage = "Kitap başarıyla iade alındı.";
                        if (fine > 0)
                        {
                            successMessage += string.Format("\n\nCeza tutarı: {0:C2}", fine);
                        }

                        MessageBox.Show(successMessage, "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Listeyi yenile
                        LoadActiveLoans();
                        ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("İade işlemi sırasında hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchLoans();
        }

        private void SearchLoans()
        {
            try
            {
                string searchText = txtSearch.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(searchText))
                {
                    LoadActiveLoans();
                    return;
                }

                var filteredLoans = _context.Loans
                    .Include(l => l.Member)
                    .Include(l => l.Book)
                    .Include(l => l.Book.Author)
                    .Where(l => l.ReturnDate == null)
                    .ToList()
                    .Where(l =>
                        string.Format("{0} {1}", l.Member.FirstName, l.Member.LastName).ToLower().Contains(searchText) ||
                        l.Member.Email.ToLower().Contains(searchText) ||
                        l.Book.Title.ToLower().Contains(searchText) ||
                        l.Book.ISBN.ToLower().Contains(searchText) ||
                        (l.Book.Author != null && l.Book.Author.Name.ToLower().Contains(searchText)))
                    .Select(l => new
                    {
                        LoanId = l.LoanId,
                        MemberName = string.Format("{0} {1}", l.Member.FirstName, l.Member.LastName),
                        MemberEmail = l.Member.Email,
                        BookTitle = l.Book.Title,
                        Author = l.Book.Author != null ? l.Book.Author.Name : "Bilinmeyen",
                        ISBN = l.Book.ISBN,
                        LoanDate = l.LoanDate,
                        DueDate = l.DueDate,
                        DaysOverdue = CalculateDaysOverdue(l.DueDate),
                        Fine = CalculateFine(l.DueDate),
                        Status = GetLoanStatus(l.DueDate)
                    })
                    .OrderBy(l => l.DueDate)
                    .ToList();

                dgvActiveLoans.DataSource = filteredLoans;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Arama sırasında hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadActiveLoans();
            ClearSelection();
        }

        private void ClearSelection()
        {
            dgvActiveLoans.ClearSelection();
            lblSelectedLoan.Text = "Seçili: Yok";
            lblFineAmount.Visible = false;
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