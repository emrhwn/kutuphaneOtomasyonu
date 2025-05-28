using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System.Drawing;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class LibrarianLoanForm : Form
    {
        private LibraryContext _context;
        private int _userId;

        public LibrarianLoanForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LibrarianLoanForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMembers();
                LoadAvailableBooks();
                LoadCurrentLoans();
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Form yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMembers()
        {
            try
            {
                var members = _context.Members
                    .Where(m => m.IsActive)
                    .ToList()
                    .Select(m => new
                    {
                        MemberId = m.MemberId,
                        FullName = string.Format("{0} {1} ({2})", m.FirstName, m.LastName, m.Email)
                    })
                    .OrderBy(m => m.FullName)
                    .ToList();

                cmbMember.DataSource = members;
                cmbMember.DisplayMember = "FullName";
                cmbMember.ValueMember = "MemberId";
                cmbMember.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üyeler yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableBooks()
        {
            try
            {
                var books = _context.Books
                    .Include(b => b.Author)
                    .Where(b => b.AvailableCopies > 0)
                    .ToList()
                    .Select(b => new
                    {
                        BookId = b.BookId,
                        DisplayText = string.Format("{0} - {1} (Stok: {2})",
                            b.Title,
                            b.Author != null ? b.Author.Name : "Bilinmeyen",
                            b.AvailableCopies)
                    })
                    .OrderBy(b => b.DisplayText)
                    .ToList();

                cmbBook.DataSource = books;
                cmbBook.DisplayMember = "DisplayText";
                cmbBook.ValueMember = "BookId";
                cmbBook.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitaplar yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentLoans()
        {
            try
            {
                var loans = _context.Loans
                    .Include(l => l.Member)
                    .Include(l => l.Book)
                    .Where(l => l.ReturnDate == null)
                    .ToList()
                    .Select(l => new
                    {
                        Member = string.Format("{0} {1}", l.Member.FirstName, l.Member.LastName),
                        Book = l.Book.Title,
                        DueDate = l.DueDate
                    })
                    .ToList();

                dgvCurrentLoans.DataSource = loans;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünçler yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            if (dgvCurrentLoans.Columns.Count > 0)
            {
                dgvCurrentLoans.Columns["Member"].HeaderText = "Üye";
                dgvCurrentLoans.Columns["Book"].HeaderText = "Kitap";
                dgvCurrentLoans.Columns["DueDate"].HeaderText = "İade Tarihi";
                dgvCurrentLoans.Columns["DueDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                var loan = new Loan
                {
                    MemberId = (int)cmbMember.SelectedValue,
                    BookId = (int)cmbBook.SelectedValue,
                    LoanDate = dtpLoanDate.Value.Date,
                    DueDate = dtpDueDate.Value.Date,
                    Notes = txtNotes.Text.Trim()
                };

                // Kitap stok güncelle
                var book = _context.Books.Find(loan.BookId);
                if (book != null && book.AvailableCopies > 0)
                {
                    book.AvailableCopies--;
                    _context.Loans.Add(loan);
                    _context.SaveChanges();

                    MessageBox.Show("Kitap başarıyla ödünç verildi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kitap stokta yok!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünç verme sırasında hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir üye seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMember.Focus();
                return false;
            }

            if (cmbBook.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir kitap seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBook.Focus();
                return false;
            }

            if (dtpDueDate.Value.Date <= dtpLoanDate.Value.Date)
            {
                MessageBox.Show("İade tarihi, ödünç tarihinden sonra olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDueDate.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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