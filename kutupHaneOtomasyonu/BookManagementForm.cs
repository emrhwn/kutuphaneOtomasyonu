using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;

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
            ClearForm();
        }

        private void LoadBooks()
        {
            var books = _context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    Author = b.Author.Name,
                    b.ISBN,
                    b.PublicationYear,
                    b.Publisher,
                    b.Category,
                    b.TotalCopies,
                    b.AvailableCopies
                })
                .ToList();

            dgvBooks.DataSource = books;

            // Kolon başlıklarını düzenle
            dgvBooks.Columns["BookId"].HeaderText = "ID";
            dgvBooks.Columns["Title"].HeaderText = "Kitap Adı";
            dgvBooks.Columns["Author"].HeaderText = "Yazar";
            dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
            dgvBooks.Columns["PublicationYear"].HeaderText = "Yayın Yılı";
            dgvBooks.Columns["Publisher"].HeaderText = "Yayınevi";
            dgvBooks.Columns["Category"].HeaderText = "Kategori";
            dgvBooks.Columns["TotalCopies"].HeaderText = "Toplam";
            dgvBooks.Columns["AvailableCopies"].HeaderText = "Mevcut";
        }

        private void LoadAuthors()
        {
            var authors = _context.Authors.OrderBy(a => a.Name).ToList();
            cmbAuthor.DataSource = authors;
            cmbAuthor.DisplayMember = "Name";
            cmbAuthor.ValueMember = "AuthorId";
            cmbAuthor.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var book = new Book
                    {
                        Title = txtTitle.Text.Trim(),
                        AuthorId = (int)cmbAuthor.SelectedValue,
                        ISBN = txtISBN.Text.Trim(),
                        PublicationYear = (int)nudPublicationYear.Value,
                        Publisher = txtPublisher.Text.Trim(),
                        Category = cmbCategory.Text,
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
                        book.Title = txtTitle.Text.Trim();
                        book.AuthorId = (int)cmbAuthor.SelectedValue;
                        book.ISBN = txtISBN.Text.Trim();
                        book.PublicationYear = (int)nudPublicationYear.Value;
                        book.Publisher = txtPublisher.Text.Trim();
                        book.Category = cmbCategory.Text;
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
                        // Ödünç verilmiş mi kontrol et
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
                selectedBookId = Convert.ToInt32(row.Cells["BookId"].Value);

                var book = _context.Books.Find(selectedBookId);
                if (book != null)
                {
                    txtTitle.Text = book.Title;
                    cmbAuthor.SelectedValue = book.AuthorId;
                    txtISBN.Text = book.ISBN;
                    nudPublicationYear.Value = book.PublicationYear;
                    txtPublisher.Text = book.Publisher;
                    cmbCategory.Text = book.Category;
                    nudTotalCopies.Value = book.TotalCopies;
                    nudAvailableCopies.Value = book.AvailableCopies;
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
                .Where(b => b.Title.ToLower().Contains(searchText) ||
                           b.ISBN.Contains(searchText) ||
                           b.Author.Name.ToLower().Contains(searchText) ||
                           b.Category.ToLower().Contains(searchText))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    Author = b.Author.Name,
                    b.ISBN,
                    b.PublicationYear,
                    b.Publisher,
                    b.Category,
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
            cmbAuthor.SelectedIndex = -1;
            txtISBN.Clear();
            nudPublicationYear.Value = DateTime.Now.Year;
            txtPublisher.Clear();
            cmbCategory.SelectedIndex = -1;
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