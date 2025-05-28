using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly LibraryContext _context;
        private int selectedUserId = 0;

        public UserManagementForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadRoles();
            ClearForm();
        }

        private void LoadUsers()
        {
            var users = _context.Users
                .Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.Email,
                    u.Phone,
                    u.Role,
                    u.CreatedDate,
                    u.IsActive,
                    Status = u.IsActive ? "Aktif" : "Pasif",
                    LastLogin = u.LastLoginDate ?? DateTime.MinValue
                })
                .ToList();

            dgvUsers.DataSource = users;

            // Kolon başlıklarını düzenle
            dgvUsers.Columns["UserId"].HeaderText = "ID";
            dgvUsers.Columns["Username"].HeaderText = "Kullanıcı Adı";
            dgvUsers.Columns["Email"].HeaderText = "E-posta";
            dgvUsers.Columns["Phone"].HeaderText = "Telefon";
            dgvUsers.Columns["Role"].HeaderText = "Rol";
            dgvUsers.Columns["CreatedDate"].HeaderText = "Oluşturma Tarihi";
            dgvUsers.Columns["IsActive"].Visible = false;
            dgvUsers.Columns["Status"].HeaderText = "Durum";
            dgvUsers.Columns["LastLogin"].HeaderText = "Son Giriş";

            // İstatistikleri güncelle
            UpdateStatistics();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Kullanıcı");
            cmbRole.SelectedIndex = -1;
        }

        private void UpdateStatistics()
        {
            int totalUsers = _context.Users.Count();
            int activeUsers = _context.Users.Count(u => u.IsActive);
            int adminCount = _context.Users.Count(u => u.Role == "Admin");
            int userCount = _context.Users.Count(u => u.Role == "Kullanıcı");

            lblTotalUsers.Text = $"Toplam Kullanıcı: {totalUsers}";
            lblActiveUsers.Text = $"Aktif Kullanıcı: {activeUsers}";
            lblAdminCount.Text = $"Admin Sayısı: {adminCount}";
            lblUserCount.Text = $"Kütüphaneci Sayısı: {userCount}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    // Kullanıcı adı kontrolü
                    if (_context.Users.Any(u => u.Username == txtUsername.Text.Trim()))
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor!", "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Focus();
                        return;
                    }

                    var user = new User
                    {
                        Username = txtUsername.Text.Trim(),
                        PasswordHash = txtPassword.Text.Trim(), // Gerçek uygulamada hash'lenmeli
                        Email = txtEmail.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Role = cmbRole.Text,
                        CreatedDate = DateTime.Now,
                        IsActive = chkIsActive.Checked
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    MessageBox.Show("Kullanıcı başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek kullanıcıyı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateForm(isUpdate: true))
            {
                try
                {
                    var user = _context.Users.Find(selectedUserId);
                    if (user != null)
                    {
                        // Başka kullanıcı aynı kullanıcı adını kullanıyor mu?
                        if (_context.Users.Any(u => u.Username == txtUsername.Text.Trim() && u.UserId != selectedUserId))
                        {
                            MessageBox.Show("Bu kullanıcı adı başka bir kullanıcı tarafından kullanılıyor!",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                            return;
                        }

                        user.Username = txtUsername.Text.Trim();
                        user.Email = txtEmail.Text.Trim();
                        user.Phone = txtPhone.Text.Trim();
                        user.Role = cmbRole.Text;
                        user.IsActive = chkIsActive.Checked;

                        // Şifre değiştirilmek isteniyorsa
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            user.PasswordHash = txtPassword.Text.Trim();
                        }

                        _context.SaveChanges();

                        MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadUsers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Lütfen silinecek kullanıcıyı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Admin sayısı kontrolü
            var user = _context.Users.Find(selectedUserId);
            if (user != null && user.Role == "Admin")
            {
                int adminCount = _context.Users.Count(u => u.Role == "Admin" && u.IsActive);
                if (adminCount <= 1)
                {
                    MessageBox.Show("Sistemde en az bir aktif admin kullanıcısı bulunmalıdır!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var result = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (user != null)
                    {
                        _context.Users.Remove(user);
                        _context.SaveChanges();

                        MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadUsers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Lütfen şifresi sıfırlanacak kullanıcıyı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bu kullanıcının şifresini sıfırlamak istediğinizden emin misiniz?\n\nYeni şifre: 123456",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var user = _context.Users.Find(selectedUserId);
                    if (user != null)
                    {
                        user.PasswordHash = "123456"; // Gerçek uygulamada hash'lenmeli
                        _context.SaveChanges();

                        MessageBox.Show("Şifre başarıyla sıfırlandı.\nYeni şifre: 123456", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);

                var user = _context.Users.Find(selectedUserId);
                if (user != null)
                {
                    txtUsername.Text = user.Username;
                    txtPassword.Text = ""; // Güvenlik için şifre gösterilmez
                    txtEmail.Text = user.Email;
                    txtPhone.Text = user.Phone;
                    cmbRole.Text = user.Role;
                    chkIsActive.Checked = user.IsActive;

                    // Güncelleme modunda şifre zorunlu değil
                    lblPasswordInfo.Visible = true;
                    lblPasswordInfo.Text = "* Şifreyi değiştirmek istemiyorsanız boş bırakın";
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            var users = _context.Users
                .Where(u => u.Username.ToLower().Contains(searchText) ||
                           u.Email.ToLower().Contains(searchText) ||
                           u.Phone.Contains(searchText) ||
                           u.Role.ToLower().Contains(searchText))
                .Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.Email,
                    u.Phone,
                    u.Role,
                    u.CreatedDate,
                    u.IsActive,
                    Status = u.IsActive ? "Aktif" : "Pasif",
                    LastLogin = u.LastLoginDate ?? DateTime.MinValue
                })
                .ToList();

            dgvUsers.DataSource = users;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private bool ValidateForm(bool isUpdate = false)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Yeni kullanıcı eklerken şifre zorunlu
            if (!isUpdate && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Şifre boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("E-posta boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // E-posta formatı kontrolü
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen rol seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedUserId = 0;
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cmbRole.SelectedIndex = -1;
            chkIsActive.Checked = true;
            txtSearch.Clear();
            lblPasswordInfo.Visible = false;
            chkShowPassword.Checked = false;
        }
        // MemberManagementForm.cs dosyasına ekleyin

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close(); // Mevcut formu kapat, AdminForm'a geri dön
        }

        // Form yüklendiğinde butonu ayarla
        private void MemberManagementForm_Load(object sender, EventArgs e)
        {
            // Mevcut kodlarınız...

            // Ana menü butonunu ayarla
            SetupBackToMainButton();
        }

        private void SetupBackToMainButton()
        {
            // Eğer designer'da buton yoksa programmatik olarak ekle
            if (this.Controls["btnBackToMain"] == null)
            {
                Button btnBackToMain = new Button();
                btnBackToMain.Name = "btnBackToMain";
                btnBackToMain.Text = "🏠 Ana Menüye Dön";
                btnBackToMain.Size = new Size(140, 35);
                btnBackToMain.Location = new Point(10, 10); // Sol üst köşe
                btnBackToMain.BackColor = Color.FromArgb(52, 152, 219); // Mavi
                btnBackToMain.ForeColor = Color.White;
                btnBackToMain.FlatStyle = FlatStyle.Flat;
                btnBackToMain.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                btnBackToMain.Cursor = Cursors.Hand;
                btnBackToMain.Click += btnBackToMain_Click;

                this.Controls.Add(btnBackToMain);
                btnBackToMain.BringToFront(); // En öne getir
            }
        }

        private void UserManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}