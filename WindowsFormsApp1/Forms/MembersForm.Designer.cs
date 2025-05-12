namespace WindowsFormsApp1.Forms
{
    partial class MembersForm
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
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSearch = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.cmbSearchType = new System.Windows.Forms.ToolStripComboBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnToggleStatus = new System.Windows.Forms.ToolStripButton();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);

            // DataGridView ayarları
            this.dgvMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // ToolStrip ayarları
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnAdd,
                this.btnEdit,
                this.btnDelete,
                this.btnRefresh,
                this.toolStripSeparator1,
                this.lblSearch,
                this.txtSearch,
                this.cmbSearchType,
                this.btnSearch,
                this.toolStripSeparator2,
                this.btnToggleStatus
            });

            // Buton ayarları
            this.btnAdd.Text = "Yeni Üye";
            this.btnAdd.Image = System.Drawing.SystemIcons.Plus.ToBitmap();
            this.btnEdit.Text = "Düzenle";
            this.btnEdit.Image = System.Drawing.SystemIcons.Pencil.ToBitmap();
            this.btnDelete.Text = "Sil";
            this.btnDelete.Image = System.Drawing.SystemIcons.Delete.ToBitmap();
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Image = System.Drawing.SystemIcons.Refresh.ToBitmap();
            this.btnSearch.Text = "Ara";
            this.btnSearch.Image = System.Drawing.SystemIcons.Find.ToBitmap();
            this.btnToggleStatus.Text = "Üyelik Durumu";
            this.btnToggleStatus.Image = System.Drawing.SystemIcons.Shield.ToBitmap();

            // Arama ayarları
            this.lblSearch.Text = "Ara:";
            this.cmbSearchType.Items.AddRange(new object[] {
                "Ad",
                "Soyad",
                "E-posta",
                "Telefon"
            });
            this.cmbSearchType.SelectedIndex = 0;

            // Form ayarları
            this.Text = "Üye Yönetimi";
            this.Size = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.toolStrip1);
        }

        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripComboBox cmbSearchType;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnToggleStatus;
        private System.Windows.Forms.BindingSource bindingSource;
    }
} 