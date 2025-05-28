using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutupHaneOtomasyonu
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            // Kitap yönetim formunu aç
            MessageBox.Show("Kitap Yönetim Ekranı Açılacak");
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            // Kullanıcı yönetim formunu aç
            MessageBox.Show("Kullanıcı Yönetim Ekranı Açılacak");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // Rapor formunu aç
            MessageBox.Show("Rapor Ekranı Açılacak");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Designer.cs dosyasında tanımlı olan event handler'lar
        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Çıkış işlemi
            DialogResult result = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnEmanetler_Click(object sender, EventArgs e)
        {
            // Emanetler modülü
            MessageBox.Show("Emanetler Yönetim Ekranı Açılacak", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKitaplar_Click(object sender, EventArgs e)
        {
            // Kitaplar modülü
            MessageBox.Show("Kitaplar Yönetim Ekranı Açılacak", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKullanicilar_Click(object sender, EventArgs e)
        {
            // Kullanıcılar modülü
            MessageBox.Show("Kullanıcılar Yönetim Ekranı Açılacak", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            // Raporlar modülü
            MessageBox.Show("Raporlar Ekranı Açılacak", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            // Üyeler modülü
            MessageBox.Show("Üyeler Yönetim Ekranı Açılacak", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}