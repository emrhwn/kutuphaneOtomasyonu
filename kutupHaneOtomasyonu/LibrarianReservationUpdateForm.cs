using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System.Drawing;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class LibrarianReservationUpdateForm : Form
    {
        private LibraryContext _context;
        private int _userId;
        private int _selectedReservationId;
        private bool _isEditMode = false;

        public LibrarianReservationUpdateForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LibrarianReservationUpdateForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMyReservations();
                LoadMembers();
                LoadBooks();
                SetupDataGridView();
                SetNewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Form yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyReservations()
        {
            try
            {
                // Sadece bu kütüphanecinin oluşturduğu rezervasyonlar
                var reservations = _context.Reservations
                    .Include(r => r.Member)
                    .Include(r => r.Book)
                    .Where(r => r.CreatedByUserId == _userId)
                    .ToList()
                    .Select(r => new
                    {
                        ReservationId = r.ReservationId,
                        MemberName = string.Format("{0} {1}", r.Member.FirstName, r.Member.LastName),
                        BookTitle = r.Book.Title,
                        ReservationDate = r.ReservationDate,
                        ExpiryDate = r.ExpiryDate,
                        Status = r.IsActive ? "Aktif" : "Pasif",
                        Notes = r.Notes
                    })
                    .OrderByDescending(r => r.ReservationDate)
                    .ToList();

                dgvReservations.DataSource = reservations;
                lblTotalReservations.Text = string.Format("Toplam {0} rezervasyon", reservations.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyonlar yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            if (dgvReservations.Columns.Count > 0)
            {
                dgvReservations.Columns["ReservationId"].Visible = false;
                dgvReservations.Columns["MemberName"].HeaderText = "Üye Adı";
                dgvReservations.Columns["BookTitle"].HeaderText = "Kitap";
                dgvReservations.Columns["ReservationDate"].HeaderText = "Rezervasyon Tarihi";
                dgvReservations.Columns["ExpiryDate"].HeaderText = "Son Geçerlilik";
                dgvReservations.Columns["Status"].HeaderText = "Durum";
                dgvReservations.Columns["Notes"].HeaderText = "Notlar";

                // Tarih formatları
                dgvReservations.Columns["ReservationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvReservations.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

                // Kolon genişlikleri
                dgvReservations.Columns["MemberName"].Width = 150;
                dgvReservations.Columns["BookTitle"].Width = 200;
                dgvReservations.Columns["Status"].Width = 80;
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
                        FullName = string.Format("{0} {1}", m.FirstName, m.LastName)
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

        private void LoadBooks()
        {
            try
            {
                // Sadece stokta olmayan kitaplar (rezervasyon mantığı)
                var books = _context.Books
                    .Include(b => b.Author)
                    .Where(b => b.AvailableCopies == 0)
                    .ToList()
                    .Select(b => new
                    {
                        BookId = b.BookId,
                        DisplayText = string.Format("{0} - {1} (Stokta Yok)",
                            b.Title,
                            b.Author != null ? b.Author.Name : "Bilinmeyen")
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

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvReservations.SelectedRows.Count > 0;
            btnDelete.Enabled = dgvReservations.SelectedRows.Count > 0;
        }

        private void dgvReservations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
            if (dgvReservations.SelectedRows.Count == 0)
                return;

            try
            {
                var row = dgvReservations.SelectedRows[0];
                _selectedReservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);

                // Rezervasyon bilgilerini getir
                var reservation = _context.Reservations
                    .Include(r => r.Member)
                    .Include(r => r.Book)
                    .FirstOrDefault(r => r.ReservationId == _selectedReservationId);

                if (reservation != null)
                {
                    // Form alanlarını doldur
                    cmbMember.SelectedValue = reservation.MemberId;
                    cmbBook.SelectedValue = reservation.BookId;
                    dtpReservationDate.Value = reservation.ReservationDate;
                    dtpExpiryDate.Value = reservation.ExpiryDate;
                    chkIsActive.Checked = reservation.IsActive;
                    txtNotes.Text = reservation.Notes;

                    SetEditMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon düzenlenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
                return;

            if (MessageBox.Show("Seçili rezervasyonu silmek istediğinizden emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var row = dgvReservations.SelectedRows[0];
                    int reservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);

                    var reservation = _context.Reservations.Find(reservationId);
                    if (reservation != null && reservation.CreatedByUserId == _userId)
                    {
                        _context.Reservations.Remove(reservation);
                        _context.SaveChanges();

                        MessageBox.Show("Rezervasyon başarıyla silindi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadMyReservations();
                        SetNewMode();
                    }
                    else
                    {
                        MessageBox.Show("Bu rezervasyonu silme yetkiniz yok.", "Yetki Hatası",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Silme işlemi sırasında hata: {0}", ex.Message),
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                if (_isEditMode)
                {
                    // Güncelleme
                    var reservation = _context.Reservations.Find(_selectedReservationId);
                    if (reservation != null && reservation.CreatedByUserId == _userId)
                    {
                        reservation.MemberId = (int)cmbMember.SelectedValue;
                        reservation.BookId = (int)cmbBook.SelectedValue;
                        reservation.ReservationDate = dtpReservationDate.Value.Date;
                        reservation.ExpiryDate = dtpExpiryDate.Value.Date;
                        reservation.IsActive = chkIsActive.Checked;
                        reservation.Notes = txtNotes.Text.Trim();

                        _context.SaveChanges();
                        MessageBox.Show("Rezervasyon başarıyla güncellendi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bu rezervasyonu güncelleme yetkiniz yok.", "Yetki Hatası",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    // Yeni kayıt
                    var reservation = new Reservation
                    {
                        MemberId = (int)cmbMember.SelectedValue,
                        BookId = (int)cmbBook.SelectedValue,
                        ReservationDate = dtpReservationDate.Value.Date,
                        ExpiryDate = dtpExpiryDate.Value.Date,
                        IsActive = chkIsActive.Checked,
                        Notes = txtNotes.Text.Trim(),
                        CreatedByUserId = _userId
                    };

                    _context.Reservations.Add(reservation);
                    _context.SaveChanges();

                    MessageBox.Show("Rezervasyon başarıyla oluşturuldu.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadMyReservations();
                SetNewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kayıt sırasında hata oluştu: {0}", ex.Message),
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

            if (dtpExpiryDate.Value.Date <= dtpReservationDate.Value.Date)
            {
                MessageBox.Show("Son geçerlilik tarihi, rezervasyon tarihinden sonra olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpExpiryDate.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                SetNewMode();
            }
            else
            {
                this.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetNewMode();
        }

        private void SetNewMode()
        {
            _isEditMode = false;
            _selectedReservationId = 0;

            // Form temizle
            cmbMember.SelectedIndex = -1;
            cmbBook.SelectedIndex = -1;
            dtpReservationDate.Value = DateTime.Now;
            dtpExpiryDate.Value = DateTime.Now.AddDays(7);
            chkIsActive.Checked = true;
            txtNotes.Clear();

            // Buton durumları
            btnSave.Text = "💾 Kaydet";
            btnCancel.Text = "❌ Kapat";
            lblMode.Text = "Mod: Yeni Rezervasyon";
            lblMode.ForeColor = Color.Green;

            // DataGrid seçimini kaldır
            dgvReservations.ClearSelection();
        }

        private void SetEditMode()
        {
            _isEditMode = true;

            // Buton durumları
            btnSave.Text = "💾 Güncelle";
            btnCancel.Text = "❌ İptal";
            lblMode.Text = string.Format("Mod: Düzenleme (ID: {0})", _selectedReservationId);
            lblMode.ForeColor = Color.Orange;
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