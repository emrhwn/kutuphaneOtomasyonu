using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class AuthorsForm : Form
    {
        private readonly LibraryContext _context;

        public AuthorsForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            try
            {
                var authors = _context.Authors.ToList();
                bindingSource.DataSource = authors;
                dgvAuthors.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazarlar yüklenirken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Yazar ekleme formunu aç
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Seçili yazarı düzenleme formunu aç
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // TODO: Seçili yazarı sil
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAuthors();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // TODO: Arama işlemini gerçekleştir
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
} 