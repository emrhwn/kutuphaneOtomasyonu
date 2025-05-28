using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace kutupHaneOtomasyonu
{
    public partial class RegistrationForm : Form
    {
        private LibraryContext _context;

        // LoginForm'dan gelen seçili rol
        private string _selectedRole;
        public string SelectedRole
        {
            get { return _selectedRole; }
            set { _selectedRole = value; }
        }

        // Kayıt olan kullanıcının adı
        private string _registeredUsername;
        public string RegisteredUsername
        {
            get { return _registeredUsername; }
            private set { _registeredUsername = value; }
        }

        public RegistrationForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // Form başlığını role göre ayarla
            if (!string.IsNullOrEmpty(SelectedRole))
            {
                this.Text = SelectedRole + " Kayıt Formu";
                if (lblTitle != null)
                    lblTitle.Text = SelectedRole + " Kaydı";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // Alan kontrolü
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifre uzunluk kontrolü
            if (password.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // E-posta format kontrolü
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kullanıcı adı benzersiz mi kontrol et
                bool usernameExists = _context.Users.Any(u => u.Username == username);
                if (usernameExists)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten alınmış.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // E-posta adresi benzersiz mi kontrol et
                bool emailExists = _context.Users.Any(u => u.Email == email);
                if (emailExists)
                {
                    MessageBox.Show("Bu e-posta adresi zaten kayıtlı.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Yeni kullanıcı oluştur
                User newUser = new User();
                newUser.Username = username;
                newUser.PasswordHash = password; // Gerçek uygulamada hash işlemi yapılmalı
                newUser.Email = email;
                newUser.Phone = phone;
                newUser.Role = string.IsNullOrEmpty(SelectedRole) ? "Kullanıcı" : SelectedRole;

                // Entity Framework ile veritabanına ekle
                _context.Users.Add(newUser);
                _context.SaveChanges();

                // Kayıt olan kullanıcı adını sakla
                RegisteredUsername = username;

                MessageBox.Show(newUser.Role + " kaydı başarıyla tamamlandı!\nGiriş yapabilirsiniz.",
                    "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DialogResult'u ayarla ve formu kapat
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // .NET Framework 4.7 için regex ile e-posta kontrolü
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = chkShowPassword.Checked ? '\0' : '●';
            txtPassword.PasswordChar = passwordChar;
            txtConfirmPassword.PasswordChar = passwordChar;
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Kullanıcı adı yazılırken kontrol
            if (txtUsername.Text.Length > 0)
            {
                // Boşluk karakteri kontrolü
                if (txtUsername.Text.Contains(" "))
                {
                    if (lblUsernameError != null)
                    {
                        lblUsernameError.Text = "Kullanıcı adı boşluk içeremez";
                        lblUsernameError.Visible = true;
                    }
                }
                else
                {
                    if (lblUsernameError != null)
                        lblUsernameError.Visible = false;
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Context'i temizle
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}