using System;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models; // User modeli için gerekebilir
using System.Data.Entity; // DbFunctions için gerekli

namespace kutupHaneOtomasyonu.Forms
{
    public partial class MemberDetailsForm : Form
    {
        private readonly LibraryContext _context;
        public int MemberId { get; set; }
        private int _loggedInUserId; // Giriş yapan kullanıcının ID'si

        // Varsayılan yapıcı metot (diğer üyeleri aramak için)
        public MemberDetailsForm(int memberId = 0)
        {
            InitializeComponent();
            _context = new LibraryContext();
            MemberId = memberId;
            _loggedInUserId = 0; // Varsayılan olarak giriş yapan kullanıcı yok
            SetupFormForMemberId(memberId);
        }

        // Giriş yapan kullanıcının ID'si ile açılan yapıcı metot
        public MemberDetailsForm(int memberId, int loggedInUserId) : this(memberId)
        {
             _loggedInUserId = loggedInUserId;
             // Eğer memberId 0 ise, giriş yapan kullanıcının bilgilerini yükle
             if (memberId == 0 && loggedInUserId > 0)
             {
                 // Giriş yapan kullanıcının üye ID'sini bul veya kullanıcı bilgilerini doğrudan yükle
                 // Bu kısım projenizin User ve Member modelleri arasındaki ilişkiye bağlı
                 var user = _context.Users.FirstOrDefault(u => u.UserId == loggedInUserId);
                 if (user != null)
                 {
                      // Varsayım: Kullanıcının ilgili bir üye kaydı var ve User modelinde MemberId tutuluyor
                      // Veya Kullanıcı bilgileri doğrudan formda gösterilecek
                      // Şimdilik kullanıcı adını üye arama alanına yerleştirelim veya doğrudan yükleyelim
                      // Daha iyi bir yaklaşım: Kullanıcının bilgilerini çekip form alanlarına atamak
                      // Eğer User modelinde MemberId property varsa:
                      // MemberId = user.MemberId;
                      // LoadMemberDetails();
                      // LoadMemberLoans();

                      // Eğer User bilgileri Member bilgileri ile aynı formda gösterilecekse:
                      // Kullanıcı arama kısmını gizle veya pasif yap
                      // Kullanıcı bilgilerini form alanlarına ata (label'lar, textbox'lar vb.)
                      // Örnek (basitçe kullanıcı adını arama kutusuna koyalım):
                      txtSearch.Text = user.Username; // txtSearch adında bir textbox olduğunu varsayıyoruz
                      btnSearch.PerformClick(); // Arama butonuna tıkla (eğer arama metodu login olan kullanıcıyı buluyorsa)

                      // Veya daha direkt olarak: Kullanıcı bilgilerini alıp doğrudan form kontrollerine ata
                      // Bu formun tasarımına göre Label'ların isimlerini ayarlamanız gerekebilir.
                       lblFirstName.Text = user.FullName ?? user.Username; // FullName veya Username göster
                       lblEmail.Text = user.Email;
                       lblPhone.Text = user.Phone;
                       // Diğer alanlar için User modelinde karşılıkları varsa atama yapın
                       // lblAddress.Text = user.Address; // Eğer User modelinde adres varsa
                       // lblMembershipDate.Text = user.CreatedDate.ToShortDateString(); // Katılım tarihi yerine oluşturulma tarihi
                       lblStatus.Text = user.IsActive ? "Aktif" : "Pasif";
                       lblStatus.ForeColor = user.IsActive ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                       // İstatistikler ve ödünç kayıtları kısmı için, eğer kullanıcının üye kaydı yoksa bu kısımlar boş kalabilir veya gizlenebilir.
                       // Eğer User modelinde MemberId varsa, yukarıdaki gibi MemberId'yi set edip LoadMemberDetails/LoadMemberLoans çağırın.
                 }
             }
        }

        private void MemberDetailsForm_Load(object sender, EventArgs e)
        {
            // **START Debug Message**
            MessageBox.Show($"Form Açıldı.\nMemberId: {MemberId}\nLoggedInUserId: {_loggedInUserId}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // **END Debug Message**

            // Eğer belirli bir üye ID'si ile açıldıysa veya giriş yapan kullanıcı kendi detaylarını görüntülüyorsa
            if (MemberId > 0)
            {
                LoadMemberDetails();
                LoadMemberLoans();
                // Üye arama kısmını gizle veya pasif yap
                panelSearch.Visible = false; // panelSearch adında bir panel olduğunu varsayalım
            }
            else if (_loggedInUserId > 0) // Giriş yapan kullanıcının ID'si varsa (ve MemberId 0 ise)
            {
                 var user = _context.Users.FirstOrDefault(u => u.UserId == _loggedInUserId);
                 if (user != null && user.MemberId.HasValue) // User modelinde MemberId varsa ve değeri varsa
                 {
                      // User'daki MemberId'yi formun MemberId property'sine ata
                      this.MemberId = user.MemberId.Value;

                      // Üye detaylarını ve ödünçlerini yükle
                      LoadMemberDetails();
                      LoadMemberLoans();

                      // Kullanıcı arama kısmını gizle
                      panelSearch.Visible = false;
                 }
                 else if (user != null && !user.MemberId.HasValue) // Kullanıcı bulundu ama MemberId yok
                 {
                     // Kullanıcının üye kaydıyla doğrudan bağlantısı yoksa ne yapılacağını belirle.
                     // Örneğin, sadece kullanıcı bilgilerini göster, istatistik ve ödünç kısımlarını gizle/temizle.
                      MessageBox.Show("Giriş yapan kullanıcının bir üye kaydı ile doğrudan bağlantısı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      // Kullanıcı bilgilerini form alanlarına ata (User modelindeki bilgilere göre)
                      lblFirstName.Text = user.FullName ?? user.Username; // FullName veya Username göster
                      lblLastName.Text = ""; // User modelinde LastName yoksa boş bırak
                      lblEmail.Text = user.Email;
                      lblPhone.Text = user.Phone;
                      lblAddress.Text = "Bilinmiyor"; // User modelinde adres yoksa varsayılan değer
                      lblMembershipDate.Text = user.CreatedDate.ToShortDateString(); // Katılım tarihi yerine oluşturulma tarihi
                      lblStatus.Text = user.IsActive ? "Aktif" : "Pasif";
                      lblStatus.ForeColor = user.IsActive ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                      // İstatistikler ve ödünç kayıtları kısımlarını temizle/gizle
                      ClearStatisticsAndLoans();

                      // Kullanıcı arama kısmını gizle
                      panelSearch.Visible = false;

                 }
                 else // Kullanıcı bulunamadıysa
                 {
                     MessageBox.Show("Giriş yapan kullanıcı bilgileri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     this.Close();
                 }
            }
            else // MemberId 0 ve _loggedInUserId 0 ise (genel arama modu)
            {
                // **START Debug Message**
                MessageBox.Show("Mod: Genel Arama", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // **END Debug Message**
                LoadAllMembers(); // Tüm üyeleri combobox'a yükle
                // Üye arama kısmını göster ve aktif yap
                panelSearch.Visible = true; // panelSearch adında bir panel olduğunu varsayalım
            }
        }

        // Formun açılış modunu ayarlayan yardımcı metot
        private void SetupFormForMemberId(int memberId)
        {
             if (memberId > 0)
            {
                this.Text = "Üye Detayları";
                // Üye arama kısmını gizle veya pasif yap
                // panelSearch.Visible = false; // Form_Load içinde yapılıyor
            }
            else
            {
                this.Text = "Üye Ara";
                // Üye arama kısmını göster ve aktif yap
                // panelSearch.Visible = true; // Form_Load içinde yapılıyor
            }
        }

        private void LoadAllMembers()
        {
            try
            {
                var members = _context.Members
                    .Select(m => new
                    {
                        m.MemberId,
                        FullName = m.FirstName + " " + m.LastName,
                        m.Email,
                        m.Phone,
                        m.MembershipDate,
                        Status = m.IsActive ? "Aktif" : "Pasif"
                    })
                    .OrderBy(m => m.FullName)
                    .ToList();

                cmbMembers.DataSource = members;
                cmbMembers.DisplayMember = "FullName";
                cmbMembers.ValueMember = "MemberId";
                cmbMembers.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üyeler yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMemberDetails()
        {
            try
            {
                var member = _context.Members
                    .Where(m => m.MemberId == MemberId)
                    .Select(m => new
                    {
                        m.FirstName,
                        m.LastName,
                        m.Email,
                        m.Phone,
                        m.Address,
                        m.MembershipDate,
                        m.IsActive
                    })
                    .FirstOrDefault();

                if (member != null)
                {
                    lblFirstName.Text = member.FirstName ?? "Bilinmiyor";
                    lblLastName.Text = member.LastName ?? "Bilinmiyor";
                    lblEmail.Text = member.Email ?? "Bilinmiyor";
                    lblPhone.Text = member.Phone ?? "Bilinmiyor";
                    lblAddress.Text = member.Address ?? "Bilinmiyor";
                    lblMembershipDate.Text = member.MembershipDate.ToShortDateString();
                    lblStatus.Text = member.IsActive ? "Aktif" : "Pasif";
                    lblStatus.ForeColor = member.IsActive ?
                        System.Drawing.Color.Green : System.Drawing.Color.Red;

                    // Üye istatistiklerini yükle
                    LoadMemberStatistics();
                }
                else
                {
                    MessageBox.Show("Üye bulunamadı!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üye detayları yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMemberStatistics()
        {
            try
            {
                int totalLoans = _context.Loans.Count(l => l.MemberId == MemberId);
                int activeLoans = _context.Loans.Count(l => l.MemberId == MemberId && l.ReturnDate == null);
                int overdueLoans = _context.Loans.Count(l => l.MemberId == MemberId &&
                    l.ReturnDate == null && l.DueDate < DateTime.Now);

                var totalFine = _context.Loans
                    .Where(l => l.MemberId == MemberId)
                    .Sum(l => l.Fine);

                lblTotalLoans.Text = totalLoans.ToString();
                lblActiveLoans.Text = activeLoans.ToString();
                lblOverdueLoans.Text = overdueLoans.ToString();
                lblTotalFines.Text = string.Format("{0:C}", totalFine ?? 0m);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üye istatistikleri yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMemberLoans()
        {
            try
            {
                var loans = _context.Loans
                    .Where(l => l.MemberId == MemberId)
                    .Select(l => new
                    {
                        l.LoanId,
                        BookTitle = l.Book.Title,
                        AuthorName = l.Book.Author.Name,
                        l.LoanDate,
                        l.DueDate,
                        l.ReturnDate,
                        Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                        DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                             DbFunctions.DiffDays(l.DueDate, DateTime.Now) : 0,
                        Fine = l.Fine.HasValue ? l.Fine.Value : 0
                    })
                    .OrderByDescending(l => l.LoanDate)
                    .ToList();

                dgvLoans.DataSource = loans;

                // Kolon başlıklarını ayarla
                if (dgvLoans.Columns.Count > 0)
                {
                    dgvLoans.Columns["LoanId"].HeaderText = "ID";
                    dgvLoans.Columns["BookTitle"].HeaderText = "Kitap Adı";
                    dgvLoans.Columns["AuthorName"].HeaderText = "Yazar";
                    dgvLoans.Columns["LoanDate"].HeaderText = "Ödünç Tarihi";
                    dgvLoans.Columns["DueDate"].HeaderText = "İade Tarihi";
                    dgvLoans.Columns["ReturnDate"].HeaderText = "Teslim Tarihi";
                    dgvLoans.Columns["Status"].HeaderText = "Durum";
                    dgvLoans.Columns["DaysLate"].HeaderText = "Gecikme (Gün)";
                    dgvLoans.Columns["Fine"].HeaderText = "Ceza (TL)";
                }

                // Geciken kayıtları renklendir
                foreach (DataGridViewRow row in dgvLoans.Rows)
                {
                    int daysLate = Convert.ToInt32(row.Cells["DaysLate"].Value);
                    if (daysLate > 0)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }
                }

                lblLoanCount.Text = string.Format("Toplam: {0} kayıt", loans.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünç kayıtları yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMembers.SelectedIndex >= 0)
            {
                MemberId = Convert.ToInt32(cmbMembers.SelectedValue);
                LoadMemberDetails();
                LoadMemberLoans();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Üye arama butonu işlevi
            // txtSearch'deki metne göre üyeleri ara
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Lütfen aramak istediğiniz üyenin adını, soyadını veya e-posta adresini girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var foundMember = _context.Members
                    .Where(m => m.FirstName.Contains(searchTerm) ||
                                m.LastName.Contains(searchTerm) ||
                                m.Email.Contains(searchTerm))
                    .FirstOrDefault(); // İlk eşleşen üyeyi al

                if (foundMember != null)
                {
                    MemberId = foundMember.MemberId;
                    LoadMemberDetails();
                    LoadMemberLoans();
                    // Arama başarılı olunca arama panelini gizle veya temizle
                     txtSearch.Clear();
                     if (this.Controls.Find("panelSearch", true).FirstOrDefault() is Panel pnl)
                     {
                        pnl.Visible = false;
                     }
                }
                else
                {
                    MessageBox.Show("Belirtilen kriterlere uyan üye bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Üye aranırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Üye bilgilerini düzenleme formu açılabilir
            MessageBox.Show("Üye düzenleme özelliği yakında eklenecek.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNewLoan_Click(object sender, EventArgs e)
        {
            // Yeni ödünç verme formu açılır, mevcut üye seçili olarak
             if (MemberId <= 0)
            {
                MessageBox.Show("Lütfen önce bir üye seçin veya bulun.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // LibrarianLoanForm formunu aç ve seçili üye ID'sini aktar
            // Eğer LibrarianLoanForm'un üye ID'si alan bir yapıcı metodu varsa:
            // var loanForm = new LibrarianLoanForm(this.MemberId);
            // loanForm.ShowDialog();

            // Eğer yapıcı metot kullanıcı ID'si alıyorsa ve üye ID'si başka bir yolla aktarılıyorsa:
            // var loanForm = new LibrarianLoanForm(_loggedInUserId); // Giriş yapan kullanıcı ID'si
            // loanForm.SetMember(this.MemberId); // Yeni metot eklenebilir LibrarianLoanForm'a
            // loanForm.ShowDialog();

            // Şimdilik sadece bir mesaj gösterelim
             MessageBox.Show($"Üye ID {MemberId} için yeni ödünç formu açılacak (implementasyon gerekli).", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        // Helper method to clear statistics and loan display if no member is loaded
        private void ClearStatisticsAndLoans()
        {
            lblTotalLoans.Text = "0";
            lblActiveLoans.Text = "0";
            lblOverdueLoans.Text = "0";
            lblTotalFines.Text = "0,00 ₺"; // Para birimini projenize göre ayarlayın
            dgvLoans.DataSource = null; // DataGridView'i temizle
            lblLoanCount.Text = "Toplam: 0 kayıt";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context?.Dispose();
        }
    }
}
