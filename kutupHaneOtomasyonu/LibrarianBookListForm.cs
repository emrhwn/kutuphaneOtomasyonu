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
                // Sadece Books ve Authors tablolarını kullan
                var books = _context.Books.ToList();
                var authors = _context.Authors.ToList();

                // Bellekte join işlemi yap (Kategori olmadan)
                var booksList = (from b in books
                                 join a in authors on b.AuthorId equals a.AuthorId into authorJoin
                                 from author in authorJoin.DefaultIfEmpty()
                                 select new
                                 {
                                     BookId = b.BookId,
                                     Title = b.Title ?? "",
                                     AuthorName = author != null ? author.Name : "Bilinmeyen Yazar",
                                     ISBN = b.ISBN ?? "",
                                     Publisher = b.Publisher ?? "",
                                     PublicationYear = b.PublicationYear,
                                     TotalCopies = b.TotalCopies,
                                     AvailableCopies = b.AvailableCopies,
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
                dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
                dgvBooks.Columns["Publisher"].HeaderText = "Yayınevi";
                dgvBooks.Columns["PublicationYear"].HeaderText = "Yayın Yılı";
                dgvBooks.Columns["TotalCopies"].HeaderText = "Toplam";
                dgvBooks.Columns["AvailableCopies"].HeaderText = "Mevcut";
                dgvBooks.Columns["Status"].HeaderText = "Durum";

                // Kolon genişlikleri
                dgvBooks.Columns["BookId"].Width = 50;
                dgvBooks.Columns["Title"].Width = 250;
                dgvBooks.Columns["AuthorName"].Width = 150;
                dgvBooks.Columns["ISBN"].Width = 120;

                // Durum kolonu renklendirme
                dgvBooks.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(searchText))
                {
                    LoadBooks();
                    return;
                }

                // Tüm verileri çek
                var books = _context.Books.ToList();
                var authors = _context.Authors.ToList();

                // Bellekte filtreleme ve join
                var searchResults = (from b in books
                                     join a in authors on b.AuthorId equals a.AuthorId into authorJoin
                                     from author in authorJoin.DefaultIfEmpty()
                                     where (b.Title != null && b.Title.ToLower().Contains(searchText)) ||
                                           (author != null && author.Name != null && author.Name.ToLower().Contains(searchText)) ||
                                           (b.ISBN != null && b.ISBN.ToLower().Contains(searchText)) ||
                                           (b.Publisher != null && b.Publisher.ToLower().Contains(searchText))
                                     select new
                                     {
                                         BookId = b.BookId,
                                         Title = b.Title ?? "",
                                         AuthorName = author != null ? author.Name : "Bilinmeyen Yazar",
                                         ISBN = b.ISBN ?? "",
                                         Publisher = b.Publisher ?? "",
                                         PublicationYear = b.PublicationYear,
                                         TotalCopies = b.TotalCopies,
                                         AvailableCopies = b.AvailableCopies,
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