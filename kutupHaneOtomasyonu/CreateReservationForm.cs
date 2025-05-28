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

namespace kutupHaneOtomasyonu
{
    public partial class CreateReservationForm : Form
    {
        private readonly LibraryContext _context;
        private int _currentUserId;
        private int _selectedBookId = 0;
        private int _selectedMemberId = 0;
        private bool _isNewReservation = true;

        public CreateReservationForm(int userId = 0)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _currentUserId = userId;
            this.Text = "Rezervasyon İşlemleri";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateReservationForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
            SetupEventHandlers();
        }

        private void InitializeForm()
        {
            // Varsayılan değerler
            dtpReservationDate.Value = DateTime.Now;
            dtpExpectedDate.Value = DateTime.Now.AddDays(7); // 7 gün sonra
            cmbStatus.SelectedIndex = 0; // "Beklemede"

            // Yeni rezervasyon modu
            btnNewReservation_Click(null, null);

            // Form durumu
            UpdateFormState();
        }

        private void SetupEventHandlers()
        {
            btnSelectBook.Click += BtnSelectBook_Click;
            btnSelectMember.Click += BtnSelectMember_Click;
            btnNewReservation.Click += btnNewReservation_Click;
            btnExistingReservation.Click += BtnExistingReservation_Click;
            btnSave.Click += BtnSave_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnCancel.Click += BtnCancel_Click;
            txtBookId.TextChanged += TxtBookId_TextChanged;
            txtMemberId.TextChanged += TxtMemberId_TextChanged;
            this.Load += CreateReservationForm_Load;
        }

        private void BtnSelectBook_Click(object sender, EventArgs e)
        {
            try
            {
                // Kitap seçim formu açılacak
                // Şimdilik basit input dialog
                string bookId = Microsoft.VisualBasic.Interaction.InputBox(
                    "Kitap ID'sini girin:", "Kitap Seç", "");

                if (!string.IsNullOrEmpty(bookId) && int.TryParse(bookId, out int id))
                {
                    txtBookId.Text = bookId;
                    LoadBookInfo(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitap seçilirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSelectMember_Click(object sender, EventArgs e)
        {
            try
            {
                // Üye seçim formu açılacak
                // Şimdilik basit input dialog
                string memberId = Microsoft.VisualBasic.Interaction.InputBox(
                    "Üye ID'sini girin:", "Üye Seç", "");

                if (!string.IsNullOrEmpty(memberId) && int.TryParse(memberId, out int id))
                {
                    txtMemberId.Text = memberId;
                    LoadMemberInfo(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üye seçilirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBookId_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookId.Text, out int bookId))
            {
                LoadBookInfo(bookId);
            }
            else
            {
                ClearBookInfo();
            }
        }

        private void TxtMemberId_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtMemberId.Text, out int memberId))
            {
                LoadMemberInfo(memberId);
            }
            else
            {
                ClearMemberInfo();
            }
        }

        private void LoadBookInfo(int bookId)
        {
            try
            {
                var book = _context.Books
                    .Where(b => b.BookId == bookId)
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        AuthorName = b.Author.Name,
                        b.AvailableCopies
                    })
                    .FirstOrDefault();

                if (book != null)
                {
                    _selectedBookId = book.BookId;
                    txtBookTitle.Text = book.Title;
                    txtAuthor.Text = book.AuthorName;
                    txtAvailableCopies.Text = book.AvailableCopies.ToString();

                    // Mevcut kopya yoksa uyarı
                    if (book.AvailableCopies <= 0)
                    {
                        txtAvailableCopies.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        txtAvailableCopies.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    ClearBookInfo();
                    MessageBox.Show("Kitap bulunamadı!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Kitap bilgisi yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMemberInfo(int memberId)
        {
            try
            {
                var member = _context.Members
                    .Where(m => m.MemberId == memberId)
                    .Select(m => new
                    {
                        m.MemberId,
                        FullName = m.FirstName + " " + m.LastName,
                        Status = m.IsActive ? "Aktif" : "Pasif"
                    })
                    .FirstOrDefault();

                if (member != null)
                {
                    _selectedMemberId = member.MemberId;
                    txtMemberName.Text = member.FullName;
                    txtMemberStatus.Text = member.Status;

                    // Üye durumu kontrolü
                    if (member.Status == "Aktif")
                    {
                        txtMemberStatus.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        txtMemberStatus.BackColor = Color.LightCoral;
                    }
                }
                else
                {
                    ClearMemberInfo();
                    MessageBox.Show("Üye bulunamadı!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üye bilgisi yüklenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBookInfo()
        {
            _selectedBookId = 0;
            txtBookTitle.Clear();
            txtAuthor.Clear();
            txtAvailableCopies.Clear();
            txtAvailableCopies.BackColor = Color.White;
        }

        private void ClearMemberInfo()
        {
            _selectedMemberId = 0;
            txtMemberName.Clear();
            txtMemberStatus.Clear();
            txtMemberStatus.BackColor = Color.White;
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            _isNewReservation = true;
            ClearForm();
            UpdateFormState();

            // Otomatik ID oluştur
            txtReservationId.Text = DateTime.Now.Ticks.ToString().Substring(10);
        }

        private void BtnExistingReservation_Click(object sender, EventArgs e)
        {
            _isNewReservation = false;
            UpdateFormState();

            // Mevcut rezervasyon seçimi için ID'yi temizle
            txtReservationId.Clear();
        }

        private void UpdateFormState()
        {
            if (_isNewReservation)
            {
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNewReservation.BackColor = Color.FromArgb(46, 204, 113);
                btnExistingReservation.BackColor = Color.FromArgb(149, 165, 166);
                dtpReservationDate.Value = DateTime.Now;
                cmbStatus.SelectedIndex = 0; // "Beklemede"
            }
            else
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnNewReservation.BackColor = Color.FromArgb(149, 165, 166);
                btnExistingReservation.BackColor = Color.FromArgb(243, 156, 18);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                // Rezervasyon oluşturma işlemi burada yapılacak
                // Şimdilik mesaj göster
                MessageBox.Show(
                    string.Format("Rezervasyon başarıyla oluşturuldu!\n\nKitap: {0}\nÜye: {1}\nTarih: {2:dd.MM.yyyy}",
                    txtBookTitle.Text, txtMemberName.Text, dtpReservationDate.Value),
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon kaydedilirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                MessageBox.Show("Rezervasyon başarıyla güncellendi!", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Rezervasyon güncellenirken hata oluştu: {0}", ex.Message),
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bu rezervasyonu silmek istediğinizden emin misiniz?",
                "Rezervasyon Silme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    MessageBox.Show("Rezervasyon başarıyla silindi!", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Rezervasyon silinirken hata oluştu: {0}", ex.Message),
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (_selectedBookId <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir kitap seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBookId.Focus();
                return false;
            }

            if (_selectedMemberId <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir üye seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMemberId.Focus();
                return false;
            }

            if (txtMemberStatus.Text == "Pasif")
            {
                MessageBox.Show("Pasif üyeler için rezervasyon yapılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpExpectedDate.Value <= dtpReservationDate.Value)
            {
                MessageBox.Show("Beklenen teslim tarihi rezervasyon tarihinden sonra olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpExpectedDate.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtReservationId.Clear();
            txtBookId.Clear();
            txtMemberId.Clear();
            ClearBookInfo();
            ClearMemberInfo();
            dtpReservationDate.Value = DateTime.Now;
            dtpExpectedDate.Value = DateTime.Now.AddDays(7);
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            // Bu metod eski adı, BtnSave_Click kullanılıyor
            BtnSave_Click(sender, e);
        }

      
    }
}