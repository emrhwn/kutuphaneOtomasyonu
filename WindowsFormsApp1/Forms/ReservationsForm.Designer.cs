namespace WindowsFormsApp1.Forms
{
    partial class ReservationsForm
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
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewReservation = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnComplete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFilter = new System.Windows.Forms.ToolStripLabel();
            this.cmbFilterType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);

            // DataGridView ayarları
            this.dgvReservations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // ToolStrip ayarları
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnNewReservation,
                this.btnCancel,
                this.btnComplete,
                this.btnRefresh,
                this.toolStripSeparator1,
                this.lblFilter,
                this.cmbFilterType,
                this.toolStripSeparator2,
                this.btnExport
            });

            // Buton ayarları
            this.btnNewReservation.Text = "Yeni Rezervasyon";
            this.btnNewReservation.Image = System.Drawing.SystemIcons.Plus.ToBitmap();
            this.btnCancel.Text = "İptal Et";
            this.btnCancel.Image = System.Drawing.SystemIcons.Delete.ToBitmap();
            this.btnComplete.Text = "Tamamla";
            this.btnComplete.Image = System.Drawing.SystemIcons.Checkmark.ToBitmap();
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Image = System.Drawing.SystemIcons.Refresh.ToBitmap();
            this.btnExport.Text = "Dışa Aktar";
            this.btnExport.Image = System.Drawing.SystemIcons.Save.ToBitmap();

            // Filtre ayarları
            this.lblFilter.Text = "Filtrele:";
            this.cmbFilterType.Items.AddRange(new object[] {
                "Tümü",
                "Bekleyen",
                "Tamamlanan",
                "İptal Edilen"
            });
            this.cmbFilterType.SelectedIndex = 0;

            // Form ayarları
            this.Text = "Rezervasyon Yönetimi";
            this.Size = new System.Drawing.Size(1200, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dgvReservations);
            this.Controls.Add(this.toolStrip1);
        }

        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewReservation;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnComplete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblFilter;
        private System.Windows.Forms.ToolStripComboBox cmbFilterType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.BindingSource bindingSource;
    }
} 