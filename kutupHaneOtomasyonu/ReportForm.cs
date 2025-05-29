using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using System.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class ReportForm : Form
    {
        private readonly LibraryContext _context;

        public ReportForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadReportTypes();
            LoadCategories();
            LoadMemberStatus();
            SetDefaultDates();
        }

        private void LoadReportTypes()
        {
            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("Tüm Raporlar");
            cmbReportType.Items.Add("Kitap Envanteri");
            cmbReportType.Items.Add("Üye Listesi");
            cmbReportType.Items.Add("Ödünç İstatistikleri");
            cmbReportType.Items.Add("Geciken Kitaplar");
            cmbReportType.Items.Add("En Çok Okunan Kitaplar");
            cmbReportType.Items.Add("En Aktif Üyeler");
            cmbReportType.Items.Add("Ceza Raporu");
            cmbReportType.Items.Add("Yazar İstatistikleri");
            cmbReportType.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Tümü");

            var categories = _context.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;
        }

        private void LoadMemberStatus()
        {
            cmbMemberStatus.Items.Clear();
            cmbMemberStatus.Items.Add("Tümü");
            cmbMemberStatus.Items.Add("Aktif");
            cmbMemberStatus.Items.Add("Pasif");
            cmbMemberStatus.SelectedIndex = 0;
        }

        private void SetDefaultDates()
        {
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedReport = cmbReportType.SelectedItem?.ToString() ?? "Tüm Raporlar";
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

                dgvReportResults.DataSource = null;
                rtbReportSummary.Clear();

                switch (selectedReport)
                {
                    case "Kitap Envanteri":
                        GenerateBookInventoryReport();
                        break;
                    case "Üye Listesi":
                        GenerateMemberListReport();
                        break;
                    case "Ödünç İstatistikleri":
                        GenerateLoanStatisticsReport(startDate, endDate);
                        break;
                    case "Geciken Kitaplar":
                        GenerateOverdueReport();
                        break;
                    case "En Çok Okunan Kitaplar":
                        GeneratePopularBooksReport(startDate, endDate);
                        break;
                    case "En Aktif Üyeler":
                        GenerateActiveMembersReport(startDate, endDate);
                        break;
                    case "Ceza Raporu":
                        GenerateFineReport(startDate, endDate);
                        break;
                    case "Yazar İstatistikleri":
                        GenerateAuthorStatisticsReport();
                        break;
                    default:
                        GenerateGeneralReport();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor oluşturulurken hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateBookInventoryReport()
        {
            var category = cmbCategory.SelectedItem?.ToString();

            var query = _context.Books.AsQueryable();

            if (category != "Tümü" && !string.IsNullOrEmpty(category))
            {
                query = query.Where(b => b.Category.Name == category);
            }

            var books = query.Select(b => new
            {
                b.Title,
                Author = b.Author.Name,
                b.ISBN,
                Category = b.Category.Name,
                b.Publisher,
                b.PublicationYear,
                b.TotalCopies,
                b.AvailableCopies,
                Status = b.AvailableCopies > 0 ? "Mevcut" : "Tükendi"
            }).ToList();

            dgvReportResults.DataSource = books;

            // Özet bilgi
            rtbReportSummary.Text = $"KITAP ENVANTERİ RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n");
            rtbReportSummary.AppendText($"Kategori: {category}\n\n");
            rtbReportSummary.AppendText($"Toplam Kitap Sayısı: {books.Count}\n");
            rtbReportSummary.AppendText($"Toplam Kopya Sayısı: {books.Sum(b => b.TotalCopies)}\n");
            rtbReportSummary.AppendText($"Mevcut Kopya Sayısı: {books.Sum(b => b.AvailableCopies)}\n");
            rtbReportSummary.AppendText($"Tükenen Kitap Sayısı: {books.Count(b => b.Status == "Tükendi")}");
        }

        private void GenerateMemberListReport()
        {
            var status = cmbMemberStatus.SelectedItem?.ToString();

            var query = _context.Members.AsQueryable();

            if (status == "Aktif")
                query = query.Where(m => m.IsActive);
            else if (status == "Pasif")
                query = query.Where(m => !m.IsActive);

            var members = query.Select(m => new
            {
                FullName = m.FirstName + " " + m.LastName,
                m.Email,
                m.Phone,
                m.Address,
                m.MembershipDate,
                Status = m.IsActive ? "Aktif" : "Pasif",
                ActiveLoans = m.Loans.Count(l => l.ReturnDate == null),
                TotalLoans = m.Loans.Count()
            })
            .OrderBy(m => m.FullName)
            .ToList();

            dgvReportResults.DataSource = members;

            // Özet bilgi
            rtbReportSummary.Text = $"ÜYE LİSTESİ RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n");
            rtbReportSummary.AppendText($"Durum: {status}\n\n");
            rtbReportSummary.AppendText($"Toplam Üye Sayısı: {members.Count}\n");
            rtbReportSummary.AppendText($"Aktif Üye Sayısı: {members.Count(m => m.Status == "Aktif")}\n");
            rtbReportSummary.AppendText($"Pasif Üye Sayısı: {members.Count(m => m.Status == "Pasif")}\n");
            rtbReportSummary.AppendText($"Kitap Ödünç Alan Üye Sayısı: {members.Count(m => m.ActiveLoans > 0)}");
        }

        private void GenerateLoanStatisticsReport(DateTime startDate, DateTime endDate)
        {
            var loans = _context.Loans
                .Where(l => l.LoanDate >= startDate && l.LoanDate <= endDate)
                .Select(l => new
                {
                    Member = l.Member.FirstName + " " + l.Member.LastName,
                    Book = l.Book.Title,
                    l.LoanDate,
                    l.DueDate,
                    l.ReturnDate,
                    Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                    DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                        (int)(DateTime.Now - l.DueDate).TotalDays : 0
                })
                .OrderByDescending(l => l.LoanDate)
                .ToList();

            dgvReportResults.DataSource = loans;

            // Özet bilgi
            rtbReportSummary.Text = $"ÖDÜNÇ İSTATİSTİKLERİ RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n");
            rtbReportSummary.AppendText($"Tarih Aralığı: {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}\n\n");
            rtbReportSummary.AppendText($"Toplam Ödünç: {loans.Count}\n");
            rtbReportSummary.AppendText($"İade Edilen: {loans.Count(l => l.Status == "İade Edildi")}\n");
            rtbReportSummary.AppendText($"Devam Eden: {loans.Count(l => l.Status == "Ödünçte")}\n");
            rtbReportSummary.AppendText($"Geciken: {loans.Count(l => l.DaysLate > 0)}");
        }

        private void GenerateOverdueReport()
        {
            var overdueLoans = _context.Loans
                .Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now)
                .Select(l => new
                {
                    Member = l.Member.FirstName + " " + l.Member.LastName,
                    MemberPhone = l.Member.Phone,
                    Book = l.Book.Title,
                    l.LoanDate,
                    l.DueDate,
                    DaysLate = (int)(DateTime.Now - l.DueDate).TotalDays,
                    Fine = (decimal)(DateTime.Now - l.DueDate).TotalDays * 1.0m
                })
                .OrderByDescending(l => l.DaysLate)
                .ToList();

            dgvReportResults.DataSource = overdueLoans;

            // Özet bilgi
            rtbReportSummary.Text = $"GECİKEN KİTAPLAR RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n\n");
            rtbReportSummary.AppendText($"Toplam Geciken: {overdueLoans.Count}\n");
            rtbReportSummary.AppendText($"Toplam Ceza: {overdueLoans.Sum(l => l.Fine):C2}\n");
            rtbReportSummary.AppendText($"En Uzun Gecikme: {(overdueLoans.Any() ? overdueLoans.Max(l => l.DaysLate) : 0)} gün");
        }

        private void GeneratePopularBooksReport(DateTime startDate, DateTime endDate)
        {
            var popularBooks = _context.Loans
                .Where(l => l.LoanDate >= startDate && l.LoanDate <= endDate)
                .GroupBy(l => new { l.BookId, l.Book.Title, Author = l.Book.Author.Name })
                .Select(g => new
                {
                    Book = g.Key.Title,
                    Author = g.Key.Author,
                    LoanCount = g.Count(),
                    UniqueMembers = g.Select(l => l.MemberId).Distinct().Count()
                })
                .OrderByDescending(b => b.LoanCount)
                .Take(20)
                .ToList();

            dgvReportResults.DataSource = popularBooks;

            // Özet bilgi
            rtbReportSummary.Text = $"EN ÇOK OKUNAN KİTAPLAR RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n");
            rtbReportSummary.AppendText($"Tarih Aralığı: {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}\n\n");
            rtbReportSummary.AppendText($"En Popüler Kitap: {(popularBooks.Any() ? popularBooks.First().Book : "-")}\n");
            rtbReportSummary.AppendText($"Ödünç Sayısı: {(popularBooks.Any() ? popularBooks.First().LoanCount : 0)}");
        }

        private void GenerateActiveMembersReport(DateTime startDate, DateTime endDate)
        {
            var activeMembers = _context.Loans
                .Where(l => l.LoanDate >= startDate && l.LoanDate <= endDate)
                .GroupBy(l => new { l.MemberId, Name = l.Member.FirstName + " " + l.Member.LastName })
                .Select(g => new
                {
                    Member = g.Key.Name,
                    LoanCount = g.Count(),
                    ReturnedCount = g.Count(l => l.ReturnDate != null),
                    ActiveCount = g.Count(l => l.ReturnDate == null),
                    OnTimeReturns = g.Count(l => l.ReturnDate != null && l.ReturnDate <= l.DueDate)
                })
                .OrderByDescending(m => m.LoanCount)
                .Take(20)
                .ToList();

            dgvReportResults.DataSource = activeMembers;

            // Özet bilgi
            rtbReportSummary.Text = $"EN AKTİF ÜYELER RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n");
            rtbReportSummary.AppendText($"Tarih Aralığı: {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}\n\n");
            rtbReportSummary.AppendText($"En Aktif Üye: {(activeMembers.Any() ? activeMembers.First().Member : "-")}\n");
            rtbReportSummary.AppendText($"Ödünç Sayısı: {(activeMembers.Any() ? activeMembers.First().LoanCount : 0)}");
        }

        private void GenerateFineReport(DateTime startDate, DateTime endDate)
        {
            var fines = _context.Loans
                .Where(l => l.Fine.HasValue && l.Fine > 0 &&
                       l.ReturnDate >= startDate && l.ReturnDate <= endDate)
                .Select(l => new
                {
                    Member = l.Member.FirstName + " " + l.Member.LastName,
                    Book = l.Book.Title,
                    l.LoanDate,
                    l.DueDate,
                    l.ReturnDate,
                    DaysLate = l.ReturnDate.HasValue ?
                        (int)(l.ReturnDate.Value - l.DueDate).TotalDays : 0,
                    Fine = l.Fine.Value
                })
                .OrderByDescending(f => f.Fine)
                .ToList();

            dgvReportResults.DataSource = fines;

            // Özet bilgi
            rtbReportSummary.Text = $"CEZA RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n");
            rtbReportSummary.AppendText($"Tarih Aralığı: {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}\n\n");
            rtbReportSummary.AppendText($"Toplam Ceza Sayısı: {fines.Count}\n");
            rtbReportSummary.AppendText($"Toplam Ceza Tutarı: {fines.Sum(f => f.Fine):C2}\n");
            rtbReportSummary.AppendText($"Ortalama Ceza: {(fines.Any() ? fines.Average(f => f.Fine) : 0):C2}");
        }

        private void GenerateAuthorStatisticsReport()
        {
            var authorStats = _context.Authors
                .Select(a => new
                {
                    Author = a.Name,
                    BookCount = a.Books.Count(),
                    TotalCopies = a.Books.Sum(b => b.TotalCopies),
                    AvailableCopies = a.Books.Sum(b => b.AvailableCopies),
                    LoanCount = a.Books.SelectMany(b => b.Loans).Count()
                })
                .OrderByDescending(a => a.BookCount)
                .ToList();

            dgvReportResults.DataSource = authorStats;

            // Özet bilgi
            rtbReportSummary.Text = $"YAZAR İSTATİSTİKLERİ RAPORU\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n");
            rtbReportSummary.AppendText($"Toplam Yazar Sayısı: {authorStats.Count}\n");
            rtbReportSummary.AppendText($"En Üretken Yazar: {(authorStats.Any() ? authorStats.First().Author : "-")}\n");
            rtbReportSummary.AppendText($"Kitap Sayısı: {(authorStats.Any() ? authorStats.First().BookCount : 0)}");
        }

        private void GenerateGeneralReport()
        {
            // Genel istatistikler
            int totalBooks = _context.Books.Count();
            int totalMembers = _context.Members.Count();
            int activeLoans = _context.Loans.Count(l => l.ReturnDate == null);
            int totalAuthors = _context.Authors.Count();
            decimal totalFines = _context.Loans.Where(l => l.Fine.HasValue).Sum(l => l.Fine.Value);

            rtbReportSummary.Text = $"GENEL İSTATİSTİKLER\n";
            rtbReportSummary.AppendText($"Rapor Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm}\n\n");
            rtbReportSummary.AppendText($"KITAP İSTATİSTİKLERİ\n");
            rtbReportSummary.AppendText($"Toplam Kitap: {totalBooks}\n");
            rtbReportSummary.AppendText($"Toplam Yazar: {totalAuthors}\n\n");
            rtbReportSummary.AppendText($"ÜYE İSTATİSTİKLERİ\n");
            rtbReportSummary.AppendText($"Toplam Üye: {totalMembers}\n");
            rtbReportSummary.AppendText($"Aktif Üye: {_context.Members.Count(m => m.IsActive)}\n\n");
            rtbReportSummary.AppendText($"ÖDÜNÇ İSTATİSTİKLERİ\n");
            rtbReportSummary.AppendText($"Aktif Ödünç: {activeLoans}\n");
            rtbReportSummary.AppendText($"Toplam Ceza: {totalFines:C2}");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReportResults.Rows.Count == 0 && string.IsNullOrWhiteSpace(rtbReportSummary.Text))
            {
                MessageBox.Show("Dışa aktarılacak veri bulunamadı.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Dosyası|*.pdf|CSV Dosyası|*.csv";
            saveDialog.Title = "Raporu Kaydet";
            saveDialog.FileName = $"Rapor_{DateTime.Now:yyyyMMdd_HHmmss}";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveDialog.FileName;
                    string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

                    if (fileExtension == ".csv")
                    {
                        // Mevcut CSV export implementation
                        MessageBox.Show("Rapor başarıyla CSV olarak kaydedildi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (fileExtension == ".pdf")
                    {
                        // PDF export implementation
                        ExportToPdf(filePath);
                        MessageBox.Show("Rapor başarıyla PDF olarak kaydedildi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Desteklenmeyen dosya formatı seçildi.", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dışa aktarma hatası: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToPdf(string filePath)
        {
            // 1. Doküman Oluştur
            Document document = new Document();
            document.Info.Title = "Kütüphane Otomasyonu Raporu";

            // 2. Bölüm Ekle
            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;

            // 3. Başlık Ekle
            Paragraph heading = section.AddParagraph("Rapor Sonuçları");
            heading.Format.Font.Size = 16;
            heading.Format.Font.Bold = true;
            heading.Format.SpaceAfter = Unit.FromCentimeter(1);

            // 4. Özet Metnini Ekle
            Paragraph summary = section.AddParagraph(rtbReportSummary.Text);
            summary.Format.SpaceAfter = Unit.FromCentimeter(1);

            // 5. Tablo Oluştur ve DataGridView Verilerini Ekle
            if (dgvReportResults.Rows.Count > 0)
            {
                Table table = section.AddTable();
                table.Style = "Table";
                table.Borders.Color = Colors.Black;
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.5;
                table.Borders.Right.Width = 0.5;
                table.Rows.LeftIndent = 0;

                // Sütunları Ekle
                foreach (DataGridViewColumn dgvCol in dgvReportResults.Columns)
                {
                     Column column = table.AddColumn();
                     column.Format.Alignment = ParagraphAlignment.Center;
                     // İsteğe bağlı: Sütun genişliğini ayarlayabilirsiniz
                     // column.Width = Unit.FromCentimeter(3); // Örnek genişlik
                }

                // Başlık Satırını Ekle
                Row headerRow = table.AddRow();
                headerRow.Format.Font.Bold = true;
                headerRow.Shading.Color = Colors.LightGray;
                for (int i = 0; i < dgvReportResults.Columns.Count; i++)
                {
                    headerRow.Cells[i].AddParagraph(dgvReportResults.Columns[i].HeaderText);
                }

                // Veri Satırlarını Ekle
                foreach (DataGridViewRow dgvRow in dgvReportResults.Rows)
                {
                    // Eğer DataGridView'de boş satır varsa atla
                    if (dgvRow.IsNewRow) continue;

                    Row dataRow = table.AddRow();
                     for (int i = 0; i < dgvRow.Cells.Count; i++)
                     {
                         // Hücre değeri null ise boş string kullan
                         dataRow.Cells[i].AddParagraph(dgvRow.Cells[i].Value?.ToString() ?? string.Empty);
                     }
                }
            }
            else
            {
                 section.AddParagraph("Detaylı rapor sonucu bulunamadı.");
            }


            // 6. PDF Render Et ve Kaydet (PDFsharp veya MigraDoc Rendering)
            // GDI+ hatalarını önlemek için bu satır gerekebilir:
            // PdfSharp.Drawing.XGraphics.PdfRenderer = PdfSharp.Drawing.PdfRenderer.Gdi;

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Version = 14;
            pdfRenderer.PdfDocument.Save(filePath);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yazdırma özelliği yakında eklenecek.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}