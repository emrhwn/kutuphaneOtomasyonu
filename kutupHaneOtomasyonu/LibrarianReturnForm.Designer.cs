namespace kutupHaneOtomasyonu.Forms
{
    partial class LibrarianReturnForm
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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblTotalActiveLoans = new System.Windows.Forms.Label();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblFineAmount = new System.Windows.Forms.Label();
            this.lblSelectedLoan = new System.Windows.Forms.Label();
            this.dgvActiveLoans = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
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
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(218, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📚 Kitap İade Alma";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.btnRefresh);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Controls.Add(this.lblTotalActiveLoans);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 60);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1084, 60);
            this.panelSearch.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(980, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(500, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.Location = new System.Drawing.Point(450, 21);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(35, 19);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Ara:";
            // 
            // lblTotalActiveLoans
            // 
            this.lblTotalActiveLoans.AutoSize = true;
            this.lblTotalActiveLoans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalActiveLoans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalActiveLoans.Location = new System.Drawing.Point(20, 21);
            this.lblTotalActiveLoans.Name = "lblTotalActiveLoans";
            this.lblTotalActiveLoans.Size = new System.Drawing.Size(146, 19);
            this.lblTotalActiveLoans.TabIndex = 0;
            this.lblTotalActiveLoans.Text = "Toplam 0 aktif ödünç";
            // 
            // panelSelection
            // 
            this.panelSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelSelection.Controls.Add(this.btnReturn);
            this.panelSelection.Controls.Add(this.lblFineAmount);
            this.panelSelection.Controls.Add(this.lblSelectedLoan);
            this.panelSelection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelection.Location = new System.Drawing.Point(0, 481);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(1084, 80);
            this.panelSelection.TabIndex = 2;
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(870, 20);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(200, 40);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "📚 İade Al";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblFineAmount
            // 
            this.lblFineAmount.AutoSize = true;
            this.lblFineAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFineAmount.ForeColor = System.Drawing.Color.Red;
            this.lblFineAmount.Location = new System.Drawing.Point(20, 40);
            this.lblFineAmount.Name = "lblFineAmount";
            this.lblFineAmount.Size = new System.Drawing.Size(139, 21);
            this.lblFineAmount.TabIndex = 1;
            this.lblFineAmount.Text = "Ceza Tutarı: ₺0,00";
            this.lblFineAmount.Visible = false;
            // 
            // lblSelectedLoan
            // 
            this.lblSelectedLoan.AutoSize = true;
            this.lblSelectedLoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedLoan.Location = new System.Drawing.Point(20, 15);
            this.lblSelectedLoan.Name = "lblSelectedLoan";
            this.lblSelectedLoan.Size = new System.Drawing.Size(77, 19);
            this.lblSelectedLoan.TabIndex = 0;
            this.lblSelectedLoan.Text = "Seçili: Yok";
            // 
            // dgvActiveLoans
            // 
            this.dgvActiveLoans.AllowUserToAddRows = false;
            this.dgvActiveLoans.AllowUserToDeleteRows = false;
            this.dgvActiveLoans.AllowUserToResizeRows = false;
            this.dgvActiveLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvActiveLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActiveLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActiveLoans.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.dgvActiveLoans.Location = new System.Drawing.Point(0, 120);
            this.dgvActiveLoans.MultiSelect = false;
            this.dgvActiveLoans.Name = "dgvActiveLoans";
            this.dgvActiveLoans.ReadOnly = true;
            this.dgvActiveLoans.RowHeadersWidth = 51;
            this.dgvActiveLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActiveLoans.Size = new System.Drawing.Size(1084, 361);
            this.dgvActiveLoans.TabIndex = 3;
            this.dgvActiveLoans.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActiveLoans_CellFormatting);
            this.dgvActiveLoans.SelectionChanged += new System.EventHandler(this.dgvActiveLoans_SelectionChanged);
            // 
            // LibrarianReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.dgvActiveLoans);
            this.Controls.Add(this.panelSelection);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelHeader);
            this.Name = "LibrarianReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kitap İade Alma";
            this.Load += new System.EventHandler(this.LibrarianReturnForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTotalActiveLoans;
        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblFineAmount;
        private System.Windows.Forms.Label lblSelectedLoan;
        private System.Windows.Forms.DataGridView dgvActiveLoans;
    }
}