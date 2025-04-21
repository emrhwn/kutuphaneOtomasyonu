using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde çalışır
        private void Form1_Load(object sender, EventArgs e)
        {
            // ComboBox - Yazarlar
            cmbAuthor.Items.Add("J.K. Rowling");
            cmbAuthor.Items.Add("George Orwell");
            cmbAuthor.Items.Add("Stephen King");

            // ComboBox - Durum
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Borrowed");

            // NumericUpDown - Yıl
            nudYear.Minimum = 1900;
            nudYear.Maximum = DateTime.Now.Year;
            nudYear.Value = 2020;
        }

        // DataGridView hücresine tıklanınca
        private void dgvKitaplar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Şu anlık boş, sonradan doldurulacak
        }
    }
}
