using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json; // System.Text.Json yerine

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
                        // Beni hatırla seçiliyse, bilgileri doldur
                        if (settings.RememberMe)
                        {
                            txtUsername.Text = settings.LastUsername;
                            chkRememberMe.Checked = true;
                            // Son seçilen rolü otomatik seç
                            if (!string.IsNullOrEmpty(settings.LastRole))
                            {
                                selectedRole = settings.LastRole;
                                if (settings.LastRole == "Admin")
                                {
                                    ShowLoginPanel("🔐 Admin Girişi");
                                }
                                else if (settings.LastRole == "Kullanıcı")
                                {
                                    ShowLoginPanel("📚 Kütüphaneci Girişi");
                                }
                            }
                        }
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
            btnRegister.Click += btnRegister_Click; // KAYIT OL BUTONU İÇİN EKLENDİ
            btnCancel.Click += BtnCancel_Click;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            linkForgotPassword.LinkClicked += LinkForgotPassword_LinkClicked;
            txtPassword.KeyPress += TxtPassword_KeyPress;

            // Form Load event'i
            this.Load += LoginForm_Load;
            this.FormClosing += LoginForm_FormClosing;
            this.FormClosed += LoginForm_FormClosed;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Height = 350;
            if (string.IsNullOrEmpty(selectedRole))
            {
                panelLogin.Visible = false;
                panelButtons.Visible = false;
                panelRoleSelection.Visible = true;
            }
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

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Focus();
            }
            else
            {
                txtPassword.Focus();
            }
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
                settings.LastUsername = username;
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
                MessageBox.Show("Giriş sırasında bir hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelButtons.Visible = false;
            panelRoleSelection.Visible = true;
            this.Height = 350;
            txtUsername.Clear();
            txtPassword.Clear();
            chkShowPassword.Checked = false;

            if (!settings.RememberMe)
            {
                chkRememberMe.Checked = false;
            }

            selectedRole = "";
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

                // RegistrationForm varsa aç
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
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!settings.RememberMe)
            {
                settings.LastUsername = string.Empty;
                settings.LastRole = string.Empty;
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
    }
}