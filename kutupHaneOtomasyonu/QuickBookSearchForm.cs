using System;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class QuickBookSearchForm : Form
    {
        private readonly LibraryContext _context;

        public QuickBookSearchForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            this.Text = "Hızlı Kitap Arama";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void QuickBookSearchForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorName = b.Author.Name,
                    b.ISBN,
                    b.PublicationYear,
                    b.TotalCopies,
                    b.AvailableCopies,
                    Status = b.AvailableCopies > 0 ? "Mevcut" : "Ödünçte"
                })
                .OrderBy(b => b.Title)
                .ToList();

            dgvBooks.DataSource = books;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            var filteredBooks = _context.Books
                .Where(b => b.Title.ToLower().Contains(searchText) ||
                           b.ISBN.Contains(searchText) ||
                           b.Author.Name.ToLower().Contains(searchText))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorName = b.Author.Name,
                    b.ISBN,
                    b.PublicationYear,
                    b.TotalCopies,
                    b.AvailableCopies,
                    Status = b.AvailableCopies > 0 ? "Mevcut" : "Ödünçte"
                })
                .OrderBy(b => b.Title)
                .ToList();

            dgvBooks.DataSource = filteredBooks;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadBooks();
            txtSearch.Focus();
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvBooks.SelectedRows.Count > 0;
            btnBookDetails.Enabled = hasSelection;
            btnLoanBook.Enabled = hasSelection;

            // Kayıt sayısını güncelle
            lblRecordCount.Text = $"Toplam: {dgvBooks.Rows.Count} kayıt";
        }

        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnBookDetails_Click(sender, e);
            }
        }

        private void btnBookDetails_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookId"].Value);
                BookDetailsForm detailsForm = new BookDetailsForm(bookId);
                detailsForm.ShowDialog();
            }
        }

        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookId"].Value);
                // LoanManagementForm'u aç ve seçili kitapla ödünç verme işlemini başlat
                LoanManagementForm loanForm = new LoanManagementForm();
                loanForm.ShowDialog();
            }
        }
    }
}