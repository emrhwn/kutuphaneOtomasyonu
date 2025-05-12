namespace WindowsFormsApp1.Forms
{
    partial class AuthorsForm
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
            this.dgvAuthors = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);

            // DataGridView ayarları
            this.dgvAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuthors.AllowUserToAddRows = false;
            this.dgvAuthors.AllowUserToDeleteRows = false;
            this.dgvAuthors.ReadOnly = true;
            this.dgvAuthors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuthors.MultiSelect = false;
            this.dgvAuthors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // ToolStrip ayarları
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnAdd,
                this.btnEdit,
                this.btnDelete,
                this.btnRefresh,
                new System.Windows.Forms.ToolStripSeparator(),
                this.txtSearch,
                this.btnSearch
            });

            // Buton ayarları
            this.btnAdd.Text = "Yeni Ekle";
            this.btnAdd.Image = System.Drawing.SystemIcons.Plus.ToBitmap();
            this.btnEdit.Text = "Düzenle";
            this.btnEdit.Image = System.Drawing.SystemIcons.Pencil.ToBitmap();
            this.btnDelete.Text = "Sil";
            this.btnDelete.Image = System.Drawing.SystemIcons.Delete.ToBitmap();
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Image = System.Drawing.SystemIcons.Refresh.ToBitmap();
            this.btnSearch.Text = "Ara";
            this.btnSearch.Image = System.Drawing.SystemIcons.Find.ToBitmap();

            // Form ayarları
            this.Text = "Yazar Yönetimi";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.dgvAuthors);
            this.Controls.Add(this.toolStrip1);
        }

        private System.Windows.Forms.DataGridView dgvAuthors;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.BindingSource bindingSource;
    }
} 