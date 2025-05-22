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
    }
}

