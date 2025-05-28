using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace kutupHaneOtomasyonu
{
    public partial class LoginForm : Form
    {
        private readonly LibraryContext _context;

        public LoginForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gerçek uygulamada şifre hash'lenerek saklanmalı ve karşılaştırılmalıdır
                var user = _context.Users
                    .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

                if (user == null)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Hoş geldiniz, {user.Username}!", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (user.Role == "Admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else if (user.Role == "Kullanıcı") // Kütüphaneci yerine Kullanıcı
                {
                    LibrarianForm librarianForm = new LibrarianForm(user.UserId);
                    librarianForm.Show();
                }
                else
                {
                    MessageBox.Show("Tanımsız rol tespit edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide(); // Giriş formunu gizle
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Kayıt olma işlemleri için yeni form aç
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog(); // Kayıt formunu modal olarak göster
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Programı tamamen kapat
        }
    }
}