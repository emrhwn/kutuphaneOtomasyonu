namespace kutupHaneOtomasyonu.Forms
{
    partial class LibrarianLoanHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblTotalFines = new System.Windows.Forms.Label();
            this.lblReturnedLoans = new System.Windows.Forms.Label();
            this.lblOverdueLoans = new System.Windows.Forms.Label();
            this.lblActiveLoans = new System.Windows.Forms.Label();
            this.lblTotalLoans = new System.Windows.Forms.Label();
            this.dgvLoanHistory = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1084, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Ödünç Geçmişim";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.btnExport);
            this.panelFilter.Controls.Add(this.btnRefresh);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Controls.Add(this.lblSearch);
            this.panelFilter.Controls.Add(this.cmbFilter);
            this.panelFilter.Controls.Add(this.lblFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1084, 60);
            this.panelFilter.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(968, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "📥 Dışa Aktar";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(650, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "🔄 Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(380, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSearch.Location = new System.Drawing.Point(340, 21);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(34, 17);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Ara:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Tümü",
            "Aktif",
            "İade Edilmiş",
            "Gecikmiş"});
            this.cmbFilter.Location = new System.Drawing.Point(70, 18);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(200, 25);
            this.cmbFilter.TabIndex = 1;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblFilter.Location = new System.Drawing.Point(20, 21);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(44, 17);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filtre:";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelStats.Controls.Add(this.lblTotalFines);
            this.panelStats.Controls.Add(this.lblReturnedLoans);
            this.panelStats.Controls.Add(this.lblOverdueLoans);
            this.panelStats.Controls.Add(this.lblActiveLoans);
            this.panelStats.Controls.Add(this.lblTotalLoans);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 120);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1084, 50);
            this.panelStats.TabIndex = 2;
            // 
            // lblTotalFines
            // 
            this.lblTotalFines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTotalFines.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalFines.ForeColor = System.Drawing.Color.White;
            this.lblTotalFines.Location = new System.Drawing.Point(868, 10);
            this.lblTotalFines.Name = "lblTotalFines";
            this.lblTotalFines.Size = new System.Drawing.Size(200, 30);
            this.lblTotalFines.TabIndex = 4;
            this.lblTotalFines.Text = "Toplam Ceza: ₺0";
            this.lblTotalFines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReturnedLoans
            // 
            this.lblReturnedLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblReturnedLoans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReturnedLoans.ForeColor = System.Drawing.Color.White;
            this.lblReturnedLoans.Location = new System.Drawing.Point(656, 10);
            this.lblReturnedLoans.Name = "lblReturnedLoans";
            this.lblReturnedLoans.Size = new System.Drawing.Size(200, 30);
            this.lblReturnedLoans.TabIndex = 3;
            this.lblReturnedLoans.Text = "İade Edilmiş: 0";
            this.lblReturnedLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOverdueLoans
            // 
            this.lblOverdueLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOverdueLoans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOverdueLoans.ForeColor = System.Drawing.Color.White;
            this.lblOverdueLoans.Location = new System.Drawing.Point(444, 10);
            this.lblOverdueLoans.Name = "lblOverdueLoans";
            this.lblOverdueLoans.Size = new System.Drawing.Size(200, 30);
            this.lblOverdueLoans.TabIndex = 2;
            this.lblOverdueLoans.Text = "Gecikmiş: 0";
            this.lblOverdueLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActiveLoans
            // 
            this.lblActiveLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.lblActiveLoans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActiveLoans.ForeColor = System.Drawing.Color.White;
            this.lblActiveLoans.Location = new System.Drawing.Point(232, 10);
            this.lblActiveLoans.Name = "lblActiveLoans";
            this.lblActiveLoans.Size = new System.Drawing.Size(200, 30);
            this.lblActiveLoans.TabIndex = 1;
            this.lblActiveLoans.Text = "Aktif: 0";
            this.lblActiveLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalLoans
            // 
            this.lblTotalLoans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalLoans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalLoans.ForeColor = System.Drawing.Color.White;
            this.lblTotalLoans.Location = new System.Drawing.Point(20, 10);
            this.lblTotalLoans.Name = "lblTotalLoans";
            this.lblTotalLoans.Size = new System.Drawing.Size(200, 30);
            this.lblTotalLoans.TabIndex = 0;
            this.lblTotalLoans.Text = "Toplam İşlem: 0";
            this.lblTotalLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLoanHistory
            // 
            this.dgvLoanHistory.AllowUserToAddRows = false;
            this.dgvLoanHistory.AllowUserToDeleteRows = false;
            this.dgvLoanHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoanHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoanHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoanHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoanHistory.Location = new System.Drawing.Point(0, 170);
            this.dgvLoanHistory.Name = "dgvLoanHistory";
            this.dgvLoanHistory.ReadOnly = true;
            this.dgvLoanHistory.RowHeadersWidth = 51;
            this.dgvLoanHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanHistory.Size = new System.Drawing.Size(1084, 391);
            this.dgvLoanHistory.TabIndex = 3;
            this.dgvLoanHistory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLoanHistory_CellFormatting);
            // 
            // LibrarianLoanHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.dgvLoanHistory);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelHeader);
            this.Name = "LibrarianLoanHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ödünç Geçmişim";
            this.Load += new System.EventHandler(this.LibrarianLoanHistoryForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblTotalFines;
        private System.Windows.Forms.Label lblReturnedLoans;
        private System.Windows.Forms.Label lblOverdueLoans;
        private System.Windows.Forms.Label lblActiveLoans;
        private System.Windows.Forms.Label lblTotalLoans;
        private System.Windows.Forms.DataGridView dgvLoanHistory;
    }
}