using System;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class BookDetailsForm : Form
    {
        private readonly LibraryContext _context;
        public int BookId { get; set; }

        public BookDetailsForm(int bookId = 0)
        {
            InitializeComponent();
            _context = new LibraryContext();
            BookId = bookId;
            this.Text = "Kitap Detayları";
            this.Size = new System.Drawing.Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void BookDetailsForm_Load(object sender, EventArgs e)
        {
            if (BookId > 0)
            {
                LoadBookDetails();
            }
        }

        private void LoadBookDetails()
        {
            try
            {
                var book = _context.Books
                    .Where(b => b.BookId == BookId)
                    .Select(b => new
                    {
                        b.Title,
                        AuthorName = b.Author.Name,
                        b.ISBN,
                        b.PublicationYear,
                        b.Publisher,
                        b.TotalCopies,
                        b.AvailableCopies,
                        CategoryName = b.Category, // String olarak direkt kullan
                        b.Description
                    })
                    .FirstOrDefault();

                if (book != null)
                {
                    lblTitle.Text = book.Title ?? "Bilinmiyor";
                    lblAuthor.Text = book.AuthorName ?? "Bilinmiyor";
                    lblISBN.Text = book.ISBN ?? "Bilinmiyor";
                    lblYear.Text = book.PublicationYear.ToString();
                    lblPublisher.Text = book.Publisher ?? "Bilinmiyor";
                    lblCategory.Text = book.CategoryName ?? "Bilinmiyor";
                    lblCopies.Text = string.Format("{0} / {1}", book.AvailableCopies, book.TotalCopies);
                    txtDescription.Text = book.Description ?? "Açıklama henüz eklenmemiş.";
                }
                else
                {
                    MessageBox.Show("Kitap bulunamadı!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitap detayları yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // BookManagementForm'u düzenleme modunda aç
                BookManagementForm editForm = new BookManagementForm();
                // Eğer BookManagementForm'da EditBook metodu varsa
                // editForm.EditBook(BookId);
                editForm.ShowDialog();

                // Form kapatıldıktan sonra verileri yenile
                LoadBookDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Düzenleme formu açılırken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            try
            {
                // Kitap mevcut mu kontrol et
                var book = _context.Books.Find(BookId);
                if (book == null)
                {
                    MessageBox.Show("Kitap bulunamadı!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (book.AvailableCopies <= 0)
                {
                    MessageBox.Show("Bu kitapın mevcut kopyası bulunmamaktadır.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // LoanManagementForm'u aç
                LoanManagementForm loanForm = new LoanManagementForm();
                loanForm.ShowDialog();

                // Form kapatıldıktan sonra verileri yenile
                LoadBookDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünç verme formu açılırken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}