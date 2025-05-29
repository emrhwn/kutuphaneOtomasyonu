using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;

namespace kutupHaneOtomasyonu
{
    public partial class ReservationManagementForm : Form
    {
        private readonly LibraryContext _context;
        private int _userId;
        private int _reservationId;
        private bool _isNewReservation = true;

        // Parametresiz yapıcı metot
        public ReservationManagementForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            _userId = 0;
            _reservationId = 0;
        }

        // Kullanıcı ID'si ile yapıcı metot
        public ReservationManagementForm(int userId)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _userId = userId;
            _reservationId = 0;
        }

        // Rezervasyon ID'si ile yapıcı metot (güncelleme için)
        public ReservationManagementForm(int userId, int reservationId)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _userId = userId;
            _reservationId = reservationId;
            _isNewReservation = false;
        }

        private void ReservationManagementForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
            LoadFormData();
            SetupFormMode();
        }

        private void LoadFormData()
        {
            try
            {
                // Durum ComboBox'ını doldur
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("Beklemede");
                cmbStatus.Items.Add("Tamamlandı");
                cmbStatus.Items.Add("İptal");
                cmbStatus.SelectedIndex = 0;

                // Tarih seçicileri bugünün tarihine ayarla
                dtpReservationDate.Value = DateTime.Today;
                dtpExpectedDate.Value = DateTime.Today.AddDays(14); // 14 gün sonrası

                // Eğer mevcut bir rezervasyon güncelleniyor ise
                if (!_isNewReservation && _reservationId > 0)
                {
                    LoadReservationData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReservationData()
        {
            // Bu metot, mevcut bir rezervasyonu yükler
            MessageBox.Show("Rezervasyon verileri yükleniyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetupFormMode()
        {
            // Form modunu ayarla
            if (_isNewReservation)
            {
                this.Text = "Yeni Rezervasyon";
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Rezervasyon Güncelle";
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            // Yeni rezervasyon moduna geç
            _isNewReservation = true;
            ClearForm();
            SetupFormMode();
        }

        private void btnExistingReservation_Click(object sender, EventArgs e)
        {
            // Mevcut rezervasyon moduna geç
            _isNewReservation = false;
            ClearForm();
            SetupFormMode();
            LoadReservations(); // Mevcut rezervasyonları yükle
        }

        private void ClearForm()
        {
            // Form kontrollerini temizle
            txtReservationId.Clear();
            txtBookId.Clear();
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtMemberId.Clear();
            txtMemberName.Clear();
            dtpReservationDate.Value = DateTime.Today;
            dtpExpectedDate.Value = DateTime.Today.AddDays(14);
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }

        private void btnFindReservation_Click(object sender, EventArgs e)
        {
            // Rezervasyon bul (Bu metot mevcut rezervasyonları listelemek için kullanılmayacak)
            MessageBox.Show("Rezervasyon aranıyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelectBook_Click(object sender, EventArgs e)
        {
            // Kitap seç
            MessageBox.Show("Kitap seçme işlemi yapılıyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelectMember_Click(object sender, EventArgs e)
        {
            // Üye seç
            MessageBox.Show("Üye seçme işlemi yapılıyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Rezervasyon kaydet
            MessageBox.Show("Rezervasyon kaydediliyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Rezervasyon güncelle
            MessageBox.Show("Rezervasyon güncelleniyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Rezervasyon sil
            MessageBox.Show("Rezervasyon siliniyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // İptal et ve formu kapat
            this.Close();
        }

        // Yeni metot: Mevcut rezervasyonları yükle
        private void LoadReservations()
        {
            try
            {
                var reservations = _context.Reservations
                    .Select(r => new
                    {
                        ReservationId = r.ReservationId,
                        BookTitle = r.Book.Title,
                        MemberName = r.Member.FirstName + " " + r.Member.LastName,
                        ReservationDate = r.ReservationDate,
                        ExpiryDate = r.ExpiryDate,
                        Status = r.Status
                    })
                    .OrderByDescending(r => r.ReservationDate)
                    .ToList();

                // DataGridView'e veriyi ata (dgvReservations isimli bir DataGridView'in form tasarımına eklendiğini varsayıyoruz)
                // Eğer DataGridView'iniz farklı bir isimdeyse, aşağıdaki satırı güncelleyin:
                // yourDataGridViewName.DataSource = reservations;

                // Örnek: Formda bir DataGridView kontrolü olduğunu varsayarak:
                 if (this.Controls.Find("dgvReservations", true).FirstOrDefault() is DataGridView dgv)
                 {
                     dgv.DataSource = reservations;
                 }
                 else
                 {
                     // DataGridView bulunamadıysa hata mesajı veya loglama ekleyebilirsiniz
                     MessageBox.Show("Rezervasyonları listelemek için dgvReservations adında bir DataGridView kontrolü bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mevcut rezervasyonlar yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}