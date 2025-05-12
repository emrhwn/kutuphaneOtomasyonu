using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class BooksForm : Form
    {
        private readonly LibraryContext _context;

        public BooksForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                var books = _context.Books
                    .Include("Author")
                    .ToList();
                bindingSource.DataSource = books;
                dgvBooks.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kitaplar yüklenirken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Kitap ekleme formunu aç
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Seçili kitabı düzenleme formunu aç
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // TODO: Seçili kitabı sil
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var searchText = txtSearch.Text.ToLower();
                var searchType = cmbSearchType.SelectedItem.ToString();

                var query = _context.Books.Include("Author").AsQueryable();

                switch (searchType)
                {
                    case "Başlık":
                        query = query.Where(b => b.Title.ToLower().Contains(searchText));
                        break;
                    case "Yazar":
                        query = query.Where(b => b.Author.Name.ToLower().Contains(searchText));
                        break;
                    case "ISBN":
                        query = query.Where(b => b.ISBN.Contains(searchText));
                        break;
                    case "Kategori":
                        query = query.Where(b => b.Category.ToLower().Contains(searchText));
                        break;
                }

                bindingSource.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama yapılırken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
} 