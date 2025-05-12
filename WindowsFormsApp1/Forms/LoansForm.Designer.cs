namespace WindowsFormsApp1.Forms
{
    partial class LoansForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewLoan = new System.Windows.Forms.ToolStripButton();
            this.btnReturn = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFilter = new System.Windows.Forms.ToolStripLabel();
            this.cmbFilterType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);

            // DataGridView ayarları
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.AllowUserToAddRows = false;
            this.dgvLoans.AllowUserToDeleteRows = false;
            this.dgvLoans.ReadOnly = true;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.MultiSelect = false;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // ToolStrip ayarları
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnNewLoan,
                this.btnReturn,
                this.btnRefresh,
                this.toolStripSeparator1,
                this.lblFilter,
                this.cmbFilterType,
                this.toolStripSeparator2,
                this.btnExport
            });

            // Buton ayarları
            this.btnNewLoan.Text = "Yeni Ödünç";
            this.btnNewLoan.Image = System.Drawing.SystemIcons.Plus.ToBitmap();
            this.btnReturn.Text = "İade Al";
            this.btnReturn.Image = System.Drawing.SystemIcons.Checkmark.ToBitmap();
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Image = System.Drawing.SystemIcons.Refresh.ToBitmap();
            this.btnExport.Text = "Dışa Aktar";
            this.btnExport.Image = System.Drawing.SystemIcons.Save.ToBitmap();

            // Filtre ayarları
            this.lblFilter.Text = "Filtrele:";
            this.cmbFilterType.Items.AddRange(new object[] {
                "Tümü",
                "Aktif Ödünçler",
                "Gecikmiş İadeler",
                "Tamamlanan İadeler"
            });
            this.cmbFilterType.SelectedIndex = 0;

            // Form ayarları
            this.Text = "Ödünç İşlemleri";
            this.Size = new System.Drawing.Size(1200, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.toolStrip1);
        }

        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewLoan;
        private System.Windows.Forms.ToolStripButton btnReturn;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblFilter;
        private System.Windows.Forms.ToolStripComboBox cmbFilterType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.BindingSource bindingSource;
    }
} 