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
    public partial class BaseListForm : Form
    {
        private string placeholderText = "Ara...";
        private Color placeholderColor = Color.Gray;
        private Color normalTextColor = Color.Black;

        public BaseListForm()
        {
            InitializeComponent();
            SetupPlaceholder();
        }

        private void SetupPlaceholder()
        {
            // txtSearch kontrolünüz varsa
            if (txtSearch != null)
            {
                txtSearch.Text = placeholderText;
                txtSearch.ForeColor = placeholderColor;

                // Enter ve Leave eventlerini bağla
                txtSearch.Enter += TxtSearch_Enter;
                txtSearch.Leave += TxtSearch_Leave;
                txtSearch.TextChanged += TxtSearch_TextChanged;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == placeholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = normalTextColor;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = placeholderText;
                txtSearch.ForeColor = placeholderColor;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            // Arama işlevi için override edilebilir
            if (txtSearch.Text != placeholderText && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                PerformSearch(txtSearch.Text);
            }
        }

        // Alt sınıflarda override edilecek
        protected virtual void PerformSearch(string searchText)
        {
            // Alt sınıflarda implement edilecek
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Placeholder text'i değiştirmek için property
        public string SearchPlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                if (txtSearch != null && txtSearch.Text == placeholderText || string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = placeholderText;
                }
            }
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {

        }
    }
}