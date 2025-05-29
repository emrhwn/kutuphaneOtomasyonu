using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing;

namespace kutupHaneOtomasyonu
{
    // Settings sınıfı
    public class Settings
    {
        public string SelectedRole { get; set; }
        public string LastRole { get; set; }
        public string LastUsername { get; set; }
        public bool RememberMe { get; set; }
        public Settings()
        {
            SelectedRole = string.Empty;
            LastRole = string.Empty;
            LastUsername = string.Empty;
            RememberMe = false;
        }
    }

    public partial class LoginForm : Form
    {
        private readonly LibraryContext _context;
        private string selectedRole = "";
        private Settings settings;
        private const string SETTINGS_FILE = "settings.json";

        public LoginForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            settings = new Settings();
            InitializeEventHandlers();
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SETTINGS_FILE))
                {
                    string json = File.ReadAllText(SETTINGS_FILE);
                    Settings loadedSettings = JsonConvert.DeserializeObject<Settings>(json);
                    if (loadedSettings != null)
                    {
                        settings = loadedSettings;
                        // Settings yüklendi ama otomatik rol seçimi yapılmayacak
                        // Kullanıcı manuel olarak rol seçecek
                    }
                }
            }
            catch (Exception ex)
            {
                // Ayarlar yüklenemezse sessizce devam et
                Console.WriteLine("Ayarlar yüklenirken hata: " + ex.Message);
            }
        }

        private void SaveSettings()
        {
            try
            {
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(SETTINGS_FILE, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ayarlar kaydedilirken hata: " + ex.Message);
            }
        }

        private void InitializeEventHandlers()
        {
            // Event handler'ları bağla
            btnAdminLogin.Click += BtnAdminLogin_Click;
            btnLibrarianLogin.Click += BtnLibrarianLogin_Click;
            btnLogin.Click += btnLogin_Click;
            btnRegister.Click += btnRegister_Click;
            btnCancel.Click += BtnCancel_Click;
            btnBack.Click += BtnBack_Click;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            linkForgotPassword.LinkClicked += LinkForgotPassword_LinkClicked;
            txtPassword.KeyPress += TxtPassword_KeyPress;
            txtUsername.KeyPress += TxtUsername_KeyPress;

            // Form event'leri
            this.Load += LoginForm_Load;
            this.FormClosing += LoginForm_FormClosing;
            this.FormClosed += LoginForm_FormClosed;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Her zaman rol seçim ekranından başla
            this.Height = 350;
            selectedRole = "";
            panelLogin.Visible = false;
            panelButtons.Visible = false;
            panelRoleSelection.Visible = true;

            // Buton görünümlerini normal renklerle ayarla
            ResetButtonAppearance();
        }

        private void ResetButtonAppearance()
        {
            // Normal renkler - soluk değil
            btnAdminLogin.BackColor = Color.FromArgb(231, 76, 60); // Canlı kırmızı
            btnLibrarianLogin.BackColor = Color.FromArgb(52, 152, 219); // Canlı mavi
            btnAdminLogin.Text = "🔐 Admin\r\nGirişi";
            btnLibrarianLogin.Text = "📚 Kütüphaneci\r\nGirişi";
        }

        private void BtnAdminLogin_Click(object sender, EventArgs e)
        {
            selectedRole = "Admin";
            ShowLoginPanel("🔐 Admin Girişi");
        }

        private void BtnLibrarianLogin_Click(object sender, EventArgs e)
        {
            selectedRole = "Kullanıcı";
            ShowLoginPanel("📚 Kütüphaneci Girişi");
        }

        private void ShowLoginPanel(string roleText)
        {
            panelRoleSelection.Visible = false;
            panelLogin.Visible = true;
            panelButtons.Visible = true;
            lblCurrentRole.Text = roleText;
            this.Height = 580;

            // Settings'i uygula - sadece aynı rol için
            if (settings.RememberMe && selectedRole == settings.LastRole && !string.IsNullOrEmpty(settings.LastUsername))
            {
                txtUsername.Text = settings.LastUsername;
                chkRememberMe.Checked = true;
                txtPassword.Focus();
            }
            else
            {
                // Temiz başlangıç
                txtUsername.Clear();
                txtPassword.Clear();
                chkRememberMe.Checked = false;
                txtUsername.Focus();
            }
        }

        // GERİ BUTONU METODU
        private void BtnBack_Click(object sender, EventArgs e)
        {
            GoBackToRoleSelection();
        }

        private void GoBackToRoleSelection()
        {
            // Rol seçim ekranına dön
            panelLogin.Visible = false;
            panelButtons.Visible = false;
            panelRoleSelection.Visible = true;
            this.Height = 350;

            // Formu temizle
            txtUsername.Clear();
            txtPassword.Clear();
            chkShowPassword.Checked = false;
            chkRememberMe.Checked = false;
            selectedRole = "";

            // Buton görünümlerini normal renklerle sıfırla
            ResetButtonAppearance();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Username == username &&
                                       u.PasswordHash == password &&
                                       u.Role == selectedRole);

                if (user == null)
                {
                    MessageBox.Show("Kullanıcı adı, şifre veya rol hatalı.", "Giriş Başarısız",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Settings'i güncelle
                settings.LastUsername = chkRememberMe.Checked ? username : "";
                settings.LastRole = selectedRole;
                settings.RememberMe = chkRememberMe.Checked;
                settings.SelectedRole = selectedRole;

                // Ayarları kaydet
                SaveSettings();

                MessageBox.Show("Hoş geldiniz, " + user.Username + "!", "Giriş Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                if (user.Role == "Admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.FormClosed += (s, args) => this.Close();
                    adminForm.Show();
                }
                else if (user.Role == "Kullanıcı")
                {
                    LibrarianForm librarianForm = new LibrarianForm(user.UserId);
                    librarianForm.FormClosed += (s, args) => this.Close();
                    librarianForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş sırasında bir hata oluştu: " + ex.Message +
                                (ex.InnerException != null ? "\\nInner Exception: " + ex.InnerException.Message : ""),
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // İptal butonu da geri fonksiyonunu kullanır
            GoBackToRoleSelection();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Önce rol seçili mi kontrol et
                if (string.IsNullOrEmpty(selectedRole))
                {
                    MessageBox.Show("Lütfen önce bir rol seçiniz (Admin veya Kütüphaneci).",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // RegistrationForm'u aç
                RegistrationForm registrationForm = new RegistrationForm();
                registrationForm.SelectedRole = selectedRole;

                if (registrationForm.ShowDialog() == DialogResult.OK)
                {
                    txtUsername.Text = registrationForm.RegisteredUsername;
                    txtPassword.Clear();
                    txtPassword.Focus();
                    MessageBox.Show("Kayıt başarılı! Şimdi giriş yapabilirsiniz.",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt formu açılırken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void LinkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Şifre sıfırlama için sistem yöneticinizle iletişime geçin.",
                "Şifremi Unuttum", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                GoBackToRoleSelection();
                e.Handled = true;
            }
        }

        private void TxtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                GoBackToRoleSelection();
                e.Handled = true;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // "Beni Hatırla" seçili değilse kullanıcı adını temizle
            if (!chkRememberMe.Checked)
            {
                settings.LastUsername = "";
                settings.RememberMe = false;
            }
            SaveSettings();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            Application.Exit();
        }

        // Form kapatılırken onay iste
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Uygulamadan çıkmak istediğinizden emin misiniz?",
                    "Çıkış Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        // ESC tuşu ile form genelinde geri gitme
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && panelLogin.Visible)
            {
                GoBackToRoleSelection();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}