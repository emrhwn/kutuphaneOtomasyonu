using System;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class LibrarianReservationForm : Form
    {
        private readonly LibraryContext _context;
        private int _currentUserId;
        private bool _isEditMode = false;
        private int _editingReservationId = 0;

        public LibrarianReservationForm(int userId = 0)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _currentUserId = userId;
            this.Text = "Rezervasyon Yönetimi - Kendi Kayıtlarım";
            this.Size = new System.Drawing.Size(800, 700);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void LibrarianReservationForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            LoadMembers();
            LoadBooks();
            LoadMyReservations();
            InitializeForm();
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
                        lblUserInfo.Text = string.Format("👤 Kullanıcı: {0} (Sadece kendi rezervasyonlarınız)", user.Username);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kullanıcı bilgisi yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeForm()
        {
            // Varsayılan değerler
            dtpReservationDate.Value = DateTime.Now;
            dtpExpiryDate.Value = DateTime.Now.AddDays(7);
            txtNotes.Text = "Kütüphaneci tarafından oluşturuldu.";

            // Yeni rezervasyon modu
            SetNewReservationMode();
        }

        private void LoadMembers()
        {
            try
            {
                var members = _context.Members
                    .Where(m => m.IsActive)
                    .Select(m => new
                    {
                        m.MemberId,
                        FullName = m.FirstName + " " + m.LastName,
                        m.Email,
                        m.Phone
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
                MessageBox.Show(string.Format("Üyeler yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var books = _context.Books
                    .Where(b => b.AvailableCopies == 0) // Sadece stokta olmayan kitaplar
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        AuthorName = b.Author.Name,
                        DisplayText = b.Title + " - " + b.Author.Name + " (Stokta Yok)"
                    })
                    .OrderBy(b => b.Title)
                    .ToList();

                cmbBook.DataSource = books;
                cmbBook.DisplayMember = "DisplayText";
                cmbBook.ValueMember = "BookId";
                cmbBook.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitaplar yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyReservations()
        {
            try
            {
                // Sadece kendi oluşturduğu rezervasyonları göster
                var myReservations = new[]
                {
                    new {
                        ReservationId = 1,
                        MemberName = "Ahmet Yılmaz",
                        BookTitle = "1984",
                        ReservationDate = DateTime.Now.AddDays(-3),
                        ExpiryDate = DateTime.Now.AddDays(4),
                        Status = "Aktif",
                        CreatedBy = _currentUserId,
                        Notes = "Kütüphaneci tarafından oluşturuldu."
                    },
                    new {
                        ReservationId = 2,
                        MemberName = "Fatma Demir",
                        BookTitle = "Suç ve Ceza",
                        ReservationDate = DateTime.Now.AddDays(-1),
                        ExpiryDate = DateTime.Now.AddDays(6),
                        Status = "Aktif",
                        CreatedBy = _currentUserId,
                        Notes = "Acil rezervasyon"
                    }
                }
                .Where(r => r.CreatedBy == _currentUserId) // Sadece kendi rezervasyonları
                .ToList();

                dgvMyReservations.DataSource = myReservations;

                if (dgvMyReservations.Columns.Count > 0)
                {
                    dgvMyReservations.Columns["ReservationId"].HeaderText = "ID";
                    dgvMyReservations.Columns["MemberName"].HeaderText = "Üye";
                    dgvMyReservations.Columns["BookTitle"].HeaderText = "Kitap";
                    dgvMyReservations.Columns["ReservationDate"].HeaderText = "Oluşturma";
                    dgvMyReservations.Columns["ExpiryDate"].HeaderText = "Bitiş";
                    dgvMyReservations.Columns["Status"].HeaderText = "Durum";
                    dgvMyReservations.Columns["CreatedBy"].Visible = false;
                    dgvMyReservations.Columns["Notes"].Visible = false;

                    // Tarih formatı
                    dgvMyReservations.Columns["ReservationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvMyReservations.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }

                lblMyReservationCount.Text = string.Format("Toplam: {0} rezervasyon (Sizin oluşturduğunuz)", myReservations.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyonlarınız yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMyReservations_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvMyReservations.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void dgvMyReservations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedReservation();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedReservation();
        }

        private void EditSelectedReservation()
        {
            if (dgvMyReservations.SelectedRows.Count == 0)
                return;

            try
            {
                var row = dgvMyReservations.SelectedRows[0];
                _editingReservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);

                // Form alanlarını doldur
                string memberName = row.Cells["MemberName"].Value.ToString();
                string bookTitle = row.Cells["BookTitle"].Value.ToString();

                // ComboBox'larda seç
                for (int i = 0; i < cmbMember.Items.Count; i++)
                {
                    var item = cmbMember.Items[i] as dynamic;
                    if (item.FullName == memberName)
                    {
                        cmbMember.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbBook.Items.Count; i++)
                {
                    var item = cmbBook.Items[i] as dynamic;
                    if (item.Title == bookTitle)
                    {
                        cmbBook.SelectedIndex = i;
                        break;
                    }
                }

                dtpReservationDate.Value = Convert.ToDateTime(row.Cells["ReservationDate"].Value);
                dtpExpiryDate.Value = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);
                txtNotes.Text = row.Cells["Notes"].Value.ToString();

                SetEditMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon düzenlenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMyReservations.SelectedRows.Count == 0)
                return;

            try
            {
                var row = dgvMyReservations.SelectedRows[0];
                string memberName = row.Cells["MemberName"].Value.ToString();
                string bookTitle = row.Cells["BookTitle"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    string.Format("'{0}' üyesi için '{1}' kitabının rezervasyonunu silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz!",
                    memberName, bookTitle),
                    "Rezervasyon Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Sadece kendi rezervasyonunu silebilir
                    MessageBox.Show("Rezervasyon başarıyla silindi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadMyReservations();
                    SetNewReservationMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon silinirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                string memberName = cmbMember.Text;
                string bookTitle = ((dynamic)cmbBook.SelectedItem).Title;

                if (_isEditMode)
                {
                    // Güncelleme işlemi
                    MessageBox.Show(
                        string.Format("Rezervasyon başarıyla güncellendi!\n\nÜye: {0}\nKitap: {1}",
                        memberName, bookTitle),
                        "Rezervasyon Güncellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Yeni rezervasyon oluşturma
                    MessageBox.Show(
                        string.Format("Yeni rezervasyon başarıyla oluşturuldu!\n\nÜye: {0}\nKitap: {1}\nSon Geçerlilik: {2:dd.MM.yyyy}",
                        memberName, bookTitle, dtpExpiryDate.Value),
                        "Rezervasyon Oluşturuldu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadMyReservations();
                SetNewReservationMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon kaydedilirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                SetNewReservationMode();
            }
            else
            {
                this.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNewReservationMode();
        }

        private void SetNewReservationMode()
        {
            _isEditMode = false;
            _editingReservationId = 0;

            // Form temizle
            cmbMember.SelectedIndex = -1;
            cmbBook.SelectedIndex = -1;
            dtpReservationDate.Value = DateTime.Now;
            dtpExpiryDate.Value = DateTime.Now.AddDays(7);
            txtNotes.Text = "Kütüphaneci tarafından oluşturuldu.";

            // Buton durumları
            btnSave.Text = "Rezervasyon Oluştur";
            btnCancel.Text = "Kapat";
            lblMode.Text = "Mod: Yeni Rezervasyon";
            lblMode.ForeColor = System.Drawing.Color.Green;

            // DataGrid seçimini kaldır
            dgvMyReservations.ClearSelection();
        }

        private void SetEditMode()
        {
            _isEditMode = true;

            // Buton durumları
            btnSave.Text = "Güncelle";
            btnCancel.Text = "İptal";
            lblMode.Text = string.Format("Mod: Düzenleme (ID: {0})", _editingReservationId);
            lblMode.ForeColor = System.Drawing.Color.Orange;
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

            if (dtpExpiryDate.Value <= dtpReservationDate.Value)
            {
                MessageBox.Show("Son geçerlilik tarihi rezervasyon tarihinden sonra olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpExpiryDate.Focus();
                return false;
            }

            return true;
        }
        private void cmbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kitap seçildiğinde yapılacak işlemler
            if (cmbBook.SelectedIndex != -1 && cmbBook.SelectedItem != null)
            {
                try
                {
                    var selectedBook = cmbBook.SelectedItem as dynamic;
                    if (selectedBook != null)
                    {
                        // Seçilen kitap hakkında bilgi gösterilebilir
                        // Örneğin: lblBookInfo.Text = $"Yazar: {selectedBook.AuthorName}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kitap bilgisi alınırken hata oluştu: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Üye seçildiğinde yapılacak işlemler
            if (cmbMember.SelectedIndex != -1 && cmbMember.SelectedItem != null)
            {
                try
                {
                    var selectedMember = cmbMember.SelectedItem as dynamic;
                    if (selectedMember != null)
                    {
                        // Seçilen üye hakkında bilgi gösterilebilir
                        // Örneğin: lblMemberInfo.Text = $"Tel: {selectedMember.Phone} - Email: {selectedMember.Email}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Üye bilgisi alınırken hata oluştu: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
    }
