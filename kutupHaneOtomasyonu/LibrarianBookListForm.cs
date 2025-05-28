using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using System.Drawing;
using System.Collections.Generic;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class LibrarianBookListForm : Form
    {
        private LibraryContext _context;

        public LibrarianBookListForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LibrarianBookListForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBooks();
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Form yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                // Entity Framework sorgusu - sadece veri çekme
                var booksData = _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        AuthorName = b.Author.Name,
                        CategoryName = b.Category.Name,
                        b.ISBN,
                        b.Publisher,
                        b.PublicationYear,
                        b.TotalCopies,
                        b.AvailableCopies
                    })
                    .ToList(); // Veritabanından çek

                // Bellekte dönüştürme ve null kontrolleri
                var booksList = booksData.Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorName = b.AuthorName ?? "Bilinmeyen Yazar",
                    CategoryName = b.CategoryName ?? "Kategorisiz",
                    b.ISBN,
                    b.Publisher,
                    b.PublicationYear,
                    b.TotalCopies,
                    b.AvailableCopies,
                    Status = b.AvailableCopies > 0 ? "Mevcut" : "Tükendi"
                }).ToList();

                dgvBooks.DataSource = booksList;
                lblTotalBooks.Text = string.Format("Toplam: {0} kitap", booksList.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitaplar yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            if (dgvBooks.Columns.Count > 0)
            {
                // Kolon başlıkları
                dgvBooks.Columns["BookId"].HeaderText = "ID";
                dgvBooks.Columns["Title"].HeaderText = "Kitap Adı";
                dgvBooks.Columns["AuthorName"].HeaderText = "Yazar";
                dgvBooks.Columns["CategoryName"].HeaderText = "Kategori";
                dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
                dgvBooks.Columns["Publisher"].HeaderText = "Yayınevi";
                dgvBooks.Columns["PublicationYear"].HeaderText = "Yayın Yılı";
                dgvBooks.Columns["TotalCopies"].HeaderText = "Toplam";
                dgvBooks.Columns["AvailableCopies"].HeaderText = "Mevcut";
                dgvBooks.Columns["Status"].HeaderText = "Durum";

                // Kolon genişlikleri
                dgvBooks.Columns["BookId"].Width = 50;
                dgvBooks.Columns["Title"].Width = 200;
                dgvBooks.Columns["AuthorName"].Width = 150;
                dgvBooks.Columns["CategoryName"].Width = 100;
                dgvBooks.Columns["ISBN"].Width = 100;

                // Durum kolonu renklendirme
                dgvBooks.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    LoadBooks();
                    return;
                }

                // Entity Framework sorgusu
                var searchData = _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .Where(b => b.Title.Contains(searchText) ||
                               b.Author.Name.Contains(searchText) ||
                               b.ISBN.Contains(searchText) ||
                               b.Publisher.Contains(searchText))
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        AuthorName = b.Author.Name,
                        CategoryName = b.Category.Name,
                        b.ISBN,
                        b.Publisher,
                        b.PublicationYear,
                        b.TotalCopies,
                        b.AvailableCopies
                    })
                    .ToList(); // Veritabanından çek

                // Bellekte dönüştürme
                var searchResults = searchData.Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorName = b.AuthorName ?? "Bilinmeyen Yazar",
                    CategoryName = b.CategoryName ?? "Kategorisiz",
                    b.ISBN,
                    b.Publisher,
                    b.PublicationYear,
                    b.TotalCopies,
                    b.AvailableCopies,
                    Status = b.AvailableCopies > 0 ? "Mevcut" : "Tükendi"
                }).ToList();

                dgvBooks.DataSource = searchResults;
                lblTotalBooks.Text = string.Format("Toplam: {0} kitap bulundu", searchResults.Count);
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
            LoadBooks();
        }

        private void dgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBooks.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null && e.Value.ToString() == "Tükendi")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (e.Value != null && e.Value.ToString() == "Mevcut")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
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