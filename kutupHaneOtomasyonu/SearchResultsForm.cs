using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class SearchResultsForm : Form
    {
        private readonly LibraryContext _context;
        private string _searchText;

        public SearchResultsForm(string searchText)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _searchText = searchText;
        }

        private void SearchResultsForm_Load(object sender, EventArgs e)
        {
            lblSearchText.Text = $"'{_searchText}' için arama sonuçları";
            PerformSearch();
        }

        private void PerformSearch()
        {
            SearchBooks();
            SearchMembers();
            SearchAuthors();
            UpdateSummary();
        }

        private void SearchBooks()
        {
            var books = _context.Books
                .Where(b => b.Title.ToLower().Contains(_searchText.ToLower()) ||
                           b.ISBN.Contains(_searchText) ||
                           b.Author.Name.ToLower().Contains(_searchText.ToLower()) ||
                           b.Category.Name.ToLower().Contains(_searchText.ToLower()) ||
                           b.Publisher.ToLower().Contains(_searchText.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    Author = b.Author.Name,
                    b.ISBN,
                    b.Category,
                    b.Publisher,
                    b.PublicationYear,
                    Available = b.AvailableCopies > 0 ? "Mevcut" : "Mevcut Değil",
                    b.AvailableCopies
                })
                .ToList();

            dgvBooks.DataSource = books;

            // Kolon başlıklarını düzenle
            if (dgvBooks.Columns.Count > 0)
            {
                dgvBooks.Columns["BookId"].Visible = false;
                dgvBooks.Columns["Title"].HeaderText = "Kitap Adı";
                dgvBooks.Columns["Author"].HeaderText = "Yazar";
                dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
                dgvBooks.Columns["Category"].HeaderText = "Kategori";
                dgvBooks.Columns["Publisher"].HeaderText = "Yayınevi";
                dgvBooks.Columns["PublicationYear"].HeaderText = "Yayın Yılı";
                dgvBooks.Columns["Available"].HeaderText = "Durum";
                dgvBooks.Columns["AvailableCopies"].HeaderText = "Mevcut";
            }

            lblBooksCount.Text = $"Kitaplar ({books.Count()})";
        }

        private void SearchMembers()
        {
            var members = _context.Members
                .Where(m => m.FirstName.ToLower().Contains(_searchText.ToLower()) ||
                           m.LastName.ToLower().Contains(_searchText.ToLower()) ||
                           m.Email.ToLower().Contains(_searchText.ToLower()) ||
                           m.Phone.Contains(_searchText))
                .Select(m => new
                {
                    m.MemberId,
                    FullName = m.FirstName + " " + m.LastName,
                    m.Email,
                    m.Phone,
                    m.Address,
                    Status = m.IsActive ? "Aktif" : "Pasif",
                    m.MembershipDate,
                    ActiveLoans = m.Loans.Count(l => l.ReturnDate == null)
                })
                .ToList();

            dgvMembers.DataSource = members;

            // Kolon başlıklarını düzenle
            if (dgvMembers.Columns.Count > 0)
            {
                dgvMembers.Columns["MemberId"].Visible = false;
                dgvMembers.Columns["FullName"].HeaderText = "Ad Soyad";
                dgvMembers.Columns["Email"].HeaderText = "E-posta";
                dgvMembers.Columns["Phone"].HeaderText = "Telefon";
                dgvMembers.Columns["Address"].HeaderText = "Adres";
                dgvMembers.Columns["Status"].HeaderText = "Durum";
                dgvMembers.Columns["MembershipDate"].HeaderText = "Üyelik Tarihi";
                dgvMembers.Columns["ActiveLoans"].HeaderText = "Ödünç Kitap";
            }

            lblMembersCount.Text = $"Üyeler ({members.Count})";
        }

        private void SearchAuthors()
        {
            var authors = _context.Authors
                .Where(a => a.Name.ToLower().Contains(_searchText.ToLower()) ||
                           a.Biography.ToLower().Contains(_searchText.ToLower()))
                .Select(a => new
                {
                    a.AuthorId,
                    a.Name,
                    a.Biography,
                    BookCount = a.Books.Count(),
                    TotalCopies = a.Books.Sum(b => b.TotalCopies),
                    AvailableCopies = a.Books.Sum(b => b.AvailableCopies)
                })
                .ToList();

            dgvAuthors.DataSource = authors;

            // Kolon başlıklarını düzenle
            if (dgvAuthors.Columns.Count > 0)
            {
                dgvAuthors.Columns["AuthorId"].Visible = false;
                dgvAuthors.Columns["Name"].HeaderText = "Yazar Adı";
                dgvAuthors.Columns["Biography"].HeaderText = "Biyografi";
                dgvAuthors.Columns["BookCount"].HeaderText = "Kitap Sayısı";
                dgvAuthors.Columns["TotalCopies"].HeaderText = "Toplam Kopya";
                dgvAuthors.Columns["AvailableCopies"].HeaderText = "Mevcut Kopya";
            }

            lblAuthorsCount.Text = $"Yazarlar ({authors.Count()})";
        }

        private void UpdateSummary()
        {
            int totalResults = dgvBooks.Rows.Count + dgvMembers.Rows.Count + dgvAuthors.Rows.Count;
            lblTotalResults.Text = $"Toplam {totalResults} sonuç bulundu";

            // En alakalı sonucu göster
            if (dgvBooks.Rows.Count > 0)
            {
                tabControl1.SelectedTab = tabBooks;
            }
            else if (dgvMembers.Rows.Count > 0)
            {
                tabControl1.SelectedTab = tabMembers;
            }
            else if (dgvAuthors.Rows.Count > 0)
            {
                tabControl1.SelectedTab = tabAuthors;
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            // Enter tuşuna basıldığında arama yap
            if (txtSearchBox.Text.Length >= 2)
            {
                _searchText = txtSearchBox.Text;
                PerformSearch();
            }
        }

        private void txtSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                _searchText = txtSearchBox.Text;
                PerformSearch();
            }
        }

        private void btnLoanBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow != null)
            {
                int bookId = Convert.ToInt32(dgvBooks.CurrentRow.Cells["BookId"].Value);
                string bookTitle = dgvBooks.CurrentRow.Cells["Title"].Value.ToString();

                // Kitap mevcut mu kontrol et
                var book = _context.Books.Find(bookId);
                if (book != null && book.AvailableCopies > 0)
                {
                    // Ödünç verme formunu aç
                    MessageBox.Show($"'{bookTitle}' kitabı için ödünç verme ekranına yönlendiriliyorsunuz.",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // LoanManagementForm'u aç ve kitabı seçili hale getir
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bu kitap şu anda mevcut değil.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnViewMemberDetails_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow != null)
            {
                int memberId = Convert.ToInt32(dgvMembers.CurrentRow.Cells["MemberId"].Value);
                string memberName = dgvMembers.CurrentRow.Cells["FullName"].Value.ToString();

                MessageBox.Show($"'{memberName}' üyesinin detayları gösteriliyor.",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Üye detay formunu aç
                this.Close();
            }
        }

        private void btnViewAuthorBooks_Click(object sender, EventArgs e)
        {
            if (dgvAuthors.CurrentRow != null)
            {
                int authorId = Convert.ToInt32(dgvAuthors.CurrentRow.Cells["AuthorId"].Value);
                string authorName = dgvAuthors.CurrentRow.Cells["Name"].Value.ToString();

                // Yazarın kitaplarını göster
                var authorBooks = _context.Books
                    .Where(b => b.AuthorId == authorId)
                    .Select(b => new
                    {
                        b.Title,
                        b.ISBN,
                        b.Category,
                        b.PublicationYear,
                        b.AvailableCopies,
                        Status = b.AvailableCopies > 0 ? "Mevcut" : "Mevcut Değil"
                    })
                    .ToList();

                string bookList = $"{authorName} yazarının kitapları:\n\n";
                foreach (var book in authorBooks)
                {
                    bookList += $"• {book.Title} ({book.PublicationYear}) - {book.Status}\n";
                }

                MessageBox.Show(bookList, "Yazar Kitapları",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportResults_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV Dosyası|*.csv|Text Dosyası|*.txt";
            saveDialog.Title = "Arama Sonuçlarını Kaydet";
            saveDialog.FileName = $"AramaSonuclari_{_searchText}_{DateTime.Now:yyyyMMdd}";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Basit bir export işlemi
                    System.IO.StreamWriter file = new System.IO.StreamWriter(saveDialog.FileName);
                    file.WriteLine($"Arama Terimi: {_searchText}");
                    file.WriteLine($"Arama Tarihi: {DateTime.Now}");
                    file.WriteLine($"Toplam Sonuç: {dgvBooks.Rows.Count + dgvMembers.Rows.Count + dgvAuthors.Rows.Count}");
                    file.WriteLine("\n--- BULUNAN KİTAPLAR ---");
                    file.WriteLine($"{dgvBooks.Rows.Count} adet kitap bulundu");
                    file.WriteLine("\n--- BULUNAN ÜYELER ---");
                    file.WriteLine($"{dgvMembers.Rows.Count} adet üye bulundu");
                    file.WriteLine("\n--- BULUNAN YAZARLAR ---");
                    file.WriteLine($"{dgvAuthors.Rows.Count} adet yazar bulundu");
                    file.Close();

                    MessageBox.Show("Arama sonuçları başarıyla kaydedildi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kaydetme hatası: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SearchResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}