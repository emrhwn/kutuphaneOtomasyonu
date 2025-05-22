using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace kutupHaneOtomasyonu
{
    public partial class RegistrationForm : Form
    {
        private readonly LibraryContext _context;

        public RegistrationForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcı adı benzersiz mi kontrol et
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                MessageBox.Show("Bu kullanıcı adı zaten alınmış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıyı veritabanına ekle
            var user = new User
            {
                Username = username,
                PasswordHash = password, // Şifreyi hashleyerek saklayın (gerçek uygulamada hash işlemi yapılmalı)
                Email = email,
                Phone = phone,
                Role = "Kullanıcı" // Kütüphaneci yerine kullanıcı olarak ayarlıyoruz
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            MessageBox.Show("Kayıt başarılı! Giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Kayıt formunu kapat
        }
    }
}