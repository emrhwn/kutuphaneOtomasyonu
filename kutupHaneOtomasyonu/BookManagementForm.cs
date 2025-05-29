using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System.Data.Entity;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class BookManagementForm : Form
    {
        private readonly LibraryContext _context;
        private int selectedBookId = 0;

        public BookManagementForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void BookManagementForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadAuthors();
            LoadCategories();
            ClearForm();
        }

        private void LoadBooks()
        {
            try
            {
                var books = _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        Author = b.Author.Name,
                        b.ISBN,
                        b.PublicationYear,
                        b.Publisher,
                        Category = b.Category.Name,
                        b.TotalCopies,
                        b.AvailableCopies
                    })
                    .ToList();

                if (dgvBooks != null)
                {
                    dgvBooks.DataSource = books;

                    if (dgvBooks.Columns.Count > 0)
                    {
                        if (dgvBooks.Columns.Contains("BookId")) dgvBooks.Columns["BookId"].HeaderText = "ID";
                        if (dgvBooks.Columns.Contains("Title")) dgvBooks.Columns["Title"].HeaderText = "Kitap Adı";
                        if (dgvBooks.Columns.Contains("Author")) dgvBooks.Columns["Author"].HeaderText = "Yazar";
                        if (dgvBooks.Columns.Contains("ISBN")) dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
                        if (dgvBooks.Columns.Contains("PublicationYear")) dgvBooks.Columns["PublicationYear"].HeaderText = "Yayın Yılı";
                        if (dgvBooks.Columns.Contains("Publisher")) dgvBooks.Columns["Publisher"].HeaderText = "Yayınevi";
                        if (dgvBooks.Columns.Contains("Category")) dgvBooks.Columns["Category"].HeaderText = "Kategori";
                        if (dgvBooks.Columns.Contains("TotalCopies")) dgvBooks.Columns["TotalCopies"].HeaderText = "Toplam";
                        if (dgvBooks.Columns.Contains("AvailableCopies")) dgvBooks.Columns["AvailableCopies"].HeaderText = "Mevcut";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kitaplar yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAuthors()
        {
            try
            {
                var authors = _context.Authors.OrderBy(a => a.Name).ToList();
                if (cmbAuthor != null)
                {
                    cmbAuthor.DataSource = authors;
                    cmbAuthor.DisplayMember = "Name";
                    cmbAuthor.ValueMember = "AuthorId";
                    cmbAuthor.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yazarlar yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _context.Categories.OrderBy(c => c.Name).ToList();
                if (cmbCategory != null)
                {
                    cmbCategory.DataSource = categories;
                    cmbCategory.DisplayMember = "Name";
                    cmbCategory.ValueMember = "CategoryId";
                    cmbCategory.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var selectedCategoryName = cmbCategory.SelectedItem as string;
                    var selectedCategory = _context.Categories.FirstOrDefault(c => c.Name == cmbCategory.Text);

                    var book = new Book
                    {
                        Title = txtTitle.Text.Trim(),
                        AuthorId = (int)cmbAuthor.SelectedValue,
                        ISBN = txtISBN.Text.Trim(),
                        PublicationYear = (int)nudPublicationYear.Value,
                        Publisher = txtPublisher.Text.Trim(),
                        Category = selectedCategory,
                        TotalCopies = (int)nudTotalCopies.Value,
                        AvailableCopies = (int)nudAvailableCopies.Value
                    };

                    _context.Books.Add(book);
                    _context.SaveChanges();

                    MessageBox.Show("Kitap başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBooks();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek kitabı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateForm())
            {
                try
                {
                    var book = _context.Books.Find(selectedBookId);
                    if (book != null)
                    {
                        var selectedCategory = _context.Categories.FirstOrDefault(c => c.Name == cmbCategory.Text);

                        book.Title = txtTitle.Text.Trim();
                        book.AuthorId = (int)cmbAuthor.SelectedValue;
                        book.ISBN = txtISBN.Text.Trim();
                        book.PublicationYear = (int)nudPublicationYear.Value;
                        book.Publisher = txtPublisher.Text.Trim();
                        book.Category = selectedCategory;
                        book.TotalCopies = (int)nudTotalCopies.Value;
                        book.AvailableCopies = (int)nudAvailableCopies.Value;

                        _context.SaveChanges();

                        MessageBox.Show("Kitap başarıyla güncellendi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadBooks();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show("Lütfen silinecek kitabı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bu kitabı silmek istediğinizden emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var book = _context.Books.Find(selectedBookId);
                    if (book != null)
                    {
                        var hasLoans = _context.Loans.Any(l => l.BookId == selectedBookId);
                        if (hasLoans)
                        {
                            MessageBox.Show("Bu kitap ödünç verilmiş. Silinemez!", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _context.Books.Remove(book);
                        _context.SaveChanges();

                        MessageBox.Show("Kitap başarıyla silindi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadBooks();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                if (row.Cells["BookId"].Value != null)
                {
                    selectedBookId = Convert.ToInt32(row.Cells["BookId"].Value);

                    var book = _context.Books
                                .Include(b => b.Author)
                                .Include(b => b.Category)
                                .FirstOrDefault(b => b.BookId == selectedBookId);

                    if (book != null)
                    {
                        txtTitle.Text = book.Title;
                        if (cmbAuthor.Items.Count > 0 && book.AuthorId != null) cmbAuthor.SelectedValue = book.AuthorId;
                        txtISBN.Text = book.ISBN;
                        nudPublicationYear.Value = book.PublicationYear;
                        txtPublisher.Text = book.Publisher;
                        if (book.Category != null && cmbCategory.Items.Count > 0 && book.Category.CategoryId != null)
                        {
                            cmbCategory.SelectedValue = book.Category.CategoryId;
                        }
                        else if (cmbCategory.Items.Count > 0)
                        {
                            cmbCategory.SelectedIndex = -1;
                        }
                        nudTotalCopies.Value = book.TotalCopies;
                        nudAvailableCopies.Value = book.AvailableCopies;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            var books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Title.ToLower().Contains(searchText) ||
                           b.ISBN.Contains(searchText) ||
                           (b.Author != null && b.Author.Name.ToLower().Contains(searchText)) ||
                           (b.Category != null && b.Category.Name.ToLower().Contains(searchText)) ||
                           (b.Publisher != null && b.Publisher.ToLower().Contains(searchText)))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    Author = b.Author.Name,
                    b.ISBN,
                    b.PublicationYear,
                    b.Publisher,
                    Category = b.Category.Name,
                    b.TotalCopies,
                    b.AvailableCopies
                })
                .ToList();

            dgvBooks.DataSource = books;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Kitap adı boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (cmbAuthor.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen yazar seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAuthor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("ISBN boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kategori seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (nudAvailableCopies.Value > nudTotalCopies.Value)
            {
                MessageBox.Show("Mevcut kopya sayısı toplam kopya sayısından fazla olamaz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudAvailableCopies.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedBookId = 0;
            txtTitle.Clear();
            if (cmbAuthor.Items.Count > 0) cmbAuthor.SelectedIndex = -1;
            txtISBN.Clear();
            nudPublicationYear.Value = DateTime.Now.Year;
            txtPublisher.Clear();
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = -1;
            nudTotalCopies.Value = 1;
            nudAvailableCopies.Value = 1;
            txtSearch.Clear();
        }

        private void BookManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}