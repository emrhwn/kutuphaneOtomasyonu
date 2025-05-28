using System;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class ReservationListForm : Form
    {
        private readonly LibraryContext _context;
        private int _currentUserId; // Giriş yapan kütüphaneci ID'si

        public ReservationListForm(int userId = 0) // Constructor'a userId eklendi
        {
            InitializeComponent();
            _context = new LibraryContext();
            _currentUserId = userId;
            this.Text = "Rezervasyon Listesi";
            this.Size = new System.Drawing.Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void ReservationListForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            LoadReservations();
            LoadStatistics();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // ComboBox varsayılan değeri
            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0; // "Tümü" seçili olsun
            }
        }

        private void LoadUserInfo()
        {
            try
            {
                if (_currentUserId > 0)
                {
                    var user = _context.Users.Find(_currentUserId);
                    if (user != null)
                    {
                        lblFormTitle.Text = string.Format("📋 Rezervasyon Listesi - {0}", user.Username);
                        lblUserInfo.Text = string.Format("👤 Kullanıcı: {0}", user.Username);
                    }
                    else
                    {
                        lblFormTitle.Text = "📋 Rezervasyon Listesi - Bilinmeyen Kullanıcı";
                        lblUserInfo.Text = "👤 Kullanıcı: Bilinmeyen";
                    }
                }
                else
                {
                    lblFormTitle.Text = "📋 Rezervasyon Listesi - Tüm Rezervasyonlar";
                    lblUserInfo.Text = "👤 Kullanıcı: Sistem";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kullanıcı bilgisi yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReservations()
        {
            try
            {
                // Kütüphaneci sadece kendi rezervasyonlarını görsün
                var reservations = new[]
                {
                    new {
                        ReservationId = 1,
                        MemberName = "Ahmet Yılmaz",
                        BookTitle = "1984",
                        AuthorName = "George Orwell",
                        ReservationDate = DateTime.Now.AddDays(-5),
                        ExpiryDate = DateTime.Now.AddDays(2),
                        Status = "Aktif",
                        Priority = 1,
                        CreatedBy = _currentUserId, // Kütüphaneci ID'si
                        CreatedByName = "Mevcut Kullanıcı"
                    },
                    new {
                        ReservationId = 2,
                        MemberName = "Fatma Demir",
                        BookTitle = "Suç ve Ceza",
                        AuthorName = "Dostoyevski",
                        ReservationDate = DateTime.Now.AddDays(-3),
                        ExpiryDate = DateTime.Now.AddDays(4),
                        Status = "Aktif",
                        Priority = 1,
                        CreatedBy = _currentUserId,
                        CreatedByName = "Mevcut Kullanıcı"
                    },
                    new {
                        ReservationId = 3,
                        MemberName = "Mehmet Kaya",
                        BookTitle = "Vadideki Zambak",
                        AuthorName = "Honoré de Balzac",
                        ReservationDate = DateTime.Now.AddDays(-7),
                        ExpiryDate = DateTime.Now.AddDays(-1),
                        Status = "Süresi Dolmuş",
                        Priority = 2,
                        CreatedBy = _currentUserId,
                        CreatedByName = "Mevcut Kullanıcı"
                    },
                    // Başka kütüphaneci rezervasyonu - gösterilmeyecek
                    new {
                        ReservationId = 4,
                        MemberName = "Ali Özkan",
                        BookTitle = "Beyaz Zambaklar Ülkesinde",
                        AuthorName = "Grigory Petrov",
                        ReservationDate = DateTime.Now.AddDays(-2),
                        ExpiryDate = DateTime.Now.AddDays(5),
                        Status = "Aktif",
                        Priority = 1,
                        CreatedBy = 999, // Başka kütüphaneci
                        CreatedByName = "Başka Kullanıcı"
                    }
                }
                .Where(r => r.CreatedBy == _currentUserId) // Sadece kendi rezervasyonları
                .ToList();

                // Filtreleme uygula
                string searchText = txtSearch.Text.ToLower();
                string selectedStatus = cmbStatus.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    reservations = reservations.Where(r =>
                        r.MemberName.ToLower().Contains(searchText) ||
                        r.BookTitle.ToLower().Contains(searchText) ||
                        r.AuthorName.ToLower().Contains(searchText))
                        .ToList();
                }

                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Tümü")
                {
                    reservations = reservations.Where(r => r.Status == selectedStatus).ToList();
                }

                dgvReservations.DataSource = reservations;

                // Kolon başlıklarını ayarla
                if (dgvReservations.Columns.Count > 0)
                {
                    dgvReservations.Columns["ReservationId"].HeaderText = "ID";
                    dgvReservations.Columns["MemberName"].HeaderText = "Üye Adı";
                    dgvReservations.Columns["BookTitle"].HeaderText = "Kitap Adı";
                    dgvReservations.Columns["AuthorName"].HeaderText = "Yazar";
                    dgvReservations.Columns["ReservationDate"].HeaderText = "Rezervasyon Tarihi";
                    dgvReservations.Columns["ExpiryDate"].HeaderText = "Son Geçerlilik";
                    dgvReservations.Columns["Status"].HeaderText = "Durum";
                    dgvReservations.Columns["Priority"].HeaderText = "Öncelik";

                    // CreatedBy ve CreatedByName kolonlarını gizle
                    dgvReservations.Columns["CreatedBy"].Visible = false;
                    dgvReservations.Columns["CreatedByName"].Visible = false;

                    // Tarih formatı
                    dgvReservations.Columns["ReservationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvReservations.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                    // Kolon genişlikleri
                    dgvReservations.Columns["ReservationId"].Width = 50;
                    dgvReservations.Columns["MemberName"].Width = 150;
                    dgvReservations.Columns["BookTitle"].Width = 200;
                    dgvReservations.Columns["AuthorName"].Width = 150;
                    dgvReservations.Columns["Status"].Width = 100;
                    dgvReservations.Columns["Priority"].Width = 80;
                }

                // Durum renklendir
                foreach (DataGridViewRow row in dgvReservations.Rows)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Süresi Dolmuş")
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }
                    else if (status == "Aktif")
                    {
                        DateTime expiryDate = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);
                        if (expiryDate <= DateTime.Now.AddDays(1))
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        }
                    }
                }

                lblRecordCount.Text = string.Format("Toplam: {0} rezervasyon (Sadece kendi rezervasyonlarınız)", reservations.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyonlar yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                // Sadece mevcut kullanıcının rezervasyon istatistikleri
                // Gerçek uygulamada bu şekilde olacak:
                /*
                int totalReservations = _context.Reservations.Count(r => r.CreatedBy == _currentUserId);
                int activeReservations = _context.Reservations.Count(r => r.CreatedBy == _currentUserId && r.Status == "Aktif");
                int expiredReservations = _context.Reservations.Count(r => r.CreatedBy == _currentUserId && r.Status == "Süresi Dolmuş");
                int completedReservations = _context.Reservations.Count(r => r.CreatedBy == _currentUserId && r.Status == "Tamamlandı");
                */

                // Şimdilik örnek değerler (kendi rezervasyonlarına göre)
                int userReservations = 3; // Sadece mevcut kullanıcının
                lblTotalReservations.Text = userReservations.ToString();
                lblActiveReservations.Text = "2";
                lblExpiredReservations.Text = "1";
                lblCompletedReservations.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("İstatistikler yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterReservations();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterReservations();
        }

        private void FilterReservations()
        {
            try
            {
                // Filtreleme LoadReservations içinde yapılıyor
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Filtreleme sırasında hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            try
            {
                CreateReservationForm createReservationForm = new CreateReservationForm(_currentUserId); // UserId geçir
                if (createReservationForm.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                    LoadStatistics();
                    MessageBox.Show("Rezervasyon başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Yeni rezervasyon formu açılırken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal edilecek rezervasyonu seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string memberName = dgvReservations.SelectedRows[0].Cells["MemberName"].Value.ToString();
                string bookTitle = dgvReservations.SelectedRows[0].Cells["BookTitle"].Value.ToString();
                string status = dgvReservations.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status == "Süresi Dolmuş" || status == "Tamamlandı")
                {
                    MessageBox.Show("Bu rezervasyon iptal edilemez.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    string.Format("'{0}' üyesinin '{1}' kitabı için rezervasyonunu iptal etmek istediğinizden emin misiniz?",
                    memberName, bookTitle),
                    "Rezervasyon İptali",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Sadece kendi rezervasyonunu iptal edebilir
                    MessageBox.Show("Rezervasyon başarıyla iptal edildi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadReservations();
                    LoadStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon iptal edilirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompleteReservation_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen tamamlanacak rezervasyonu seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string status = dgvReservations.SelectedRows[0].Cells["Status"].Value.ToString();
                if (status != "Aktif")
                {
                    MessageBox.Show("Sadece aktif rezervasyonlar tamamlanabilir.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string memberName = dgvReservations.SelectedRows[0].Cells["MemberName"].Value.ToString();
                string bookTitle = dgvReservations.SelectedRows[0].Cells["BookTitle"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    string.Format("'{0}' üyesi için '{1}' kitabının rezervasyonunu tamamlamak ve ödünç verme işlemine geçmek istiyor musunuz?",
                    memberName, bookTitle),
                    "Rezervasyon Tamamlama",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Rezervasyon tamamlandı, ödünç verme ekranına yönlendir
                    MessageBox.Show("Rezervasyon tamamlandı. Ödünç verme ekranına yönlendiriliyorsunuz.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ödünç verme işlemine yönlendir
                    LoanManagementForm loanForm = new LoanManagementForm();
                    loanForm.ShowDialog();

                    LoadReservations();
                    LoadStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon tamamlanırken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
            LoadStatistics();
            txtSearch.Clear();
            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvReservations.SelectedRows.Count > 0;
            btnCancelReservation.Enabled = hasSelection;
            btnCompleteReservation.Enabled = hasSelection;
        }

        private void dgvReservations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Rezervasyon detaylarını göster
                string memberName = dgvReservations.Rows[e.RowIndex].Cells["MemberName"].Value.ToString();
                string bookTitle = dgvReservations.Rows[e.RowIndex].Cells["BookTitle"].Value.ToString();
                string status = dgvReservations.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                DateTime reservationDate = Convert.ToDateTime(dgvReservations.Rows[e.RowIndex].Cells["ReservationDate"].Value);
                DateTime expiryDate = Convert.ToDateTime(dgvReservations.Rows[e.RowIndex].Cells["ExpiryDate"].Value);
                int priority = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["Priority"].Value);

                string message = string.Format(
                    "Üye: {0}\nKitap: {1}\nYazar: {2}\nDurum: {3}\nÖncelik: {4}\nRezervasyon Tarihi: {5:dd.MM.yyyy}\nSon Geçerlilik: {6:dd.MM.yyyy}\n\nNot: Bu rezervasyon sizin tarafınızdan oluşturulmuştur.",
                    memberName,
                    bookTitle,
                    dgvReservations.Rows[e.RowIndex].Cells["AuthorName"].Value.ToString(),
                    status,
                    priority,
                    reservationDate,
                    expiryDate);

                MessageBox.Show(message, "Rezervasyon Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);
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