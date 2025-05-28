using System;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class MemberDetailsForm : Form
    {
        private readonly LibraryContext _context;
        public int MemberId { get; set; }

        public MemberDetailsForm(int memberId = 0)
        {
            InitializeComponent();
            _context = new LibraryContext();
            MemberId = memberId;
            this.Text = "Üye Detayları";
            this.Size = new System.Drawing.Size(800, 700);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void MemberDetailsForm_Load(object sender, EventArgs e)
        {
            if (MemberId > 0)
            {
                LoadMemberDetails();
                LoadMemberLoans();
            }
            else
            {
                LoadAllMembers();
            }
        }

        private void LoadAllMembers()
        {
            try
            {
                var members = _context.Members
                    .Select(m => new
                    {
                        m.MemberId,
                        FullName = m.FirstName + " " + m.LastName,
                        m.Email,
                        m.Phone,
                        m.MembershipDate,
                        Status = m.IsActive ? "Aktif" : "Pasif"
                    })
                    .OrderBy(m => m.FullName)
                    .ToList();

                cmbMembers.DataSource = members;
                cmbMembers.DisplayMember = "FullName";
                cmbMembers.ValueMember = "MemberId";
                cmbMembers.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üyeler yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMemberDetails()
        {
            try
            {
                var member = _context.Members
                    .Where(m => m.MemberId == MemberId)
                    .Select(m => new
                    {
                        m.FirstName,
                        m.LastName,
                        m.Email,
                        m.Phone,
                        m.Address,
                        m.MembershipDate,
                        m.IsActive
                    })
                    .FirstOrDefault();

                if (member != null)
                {
                    lblFirstName.Text = member.FirstName ?? "Bilinmiyor";
                    lblLastName.Text = member.LastName ?? "Bilinmiyor";
                    lblEmail.Text = member.Email ?? "Bilinmiyor";
                    lblPhone.Text = member.Phone ?? "Bilinmiyor";
                    lblAddress.Text = member.Address ?? "Bilinmiyor";
                    lblMembershipDate.Text = member.MembershipDate.ToShortDateString();
                    lblStatus.Text = member.IsActive ? "Aktif" : "Pasif";
                    lblStatus.ForeColor = member.IsActive ?
                        System.Drawing.Color.Green : System.Drawing.Color.Red;

                    // Üye istatistiklerini yükle
                    LoadMemberStatistics();
                }
                else
                {
                    MessageBox.Show("Üye bulunamadı!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üye detayları yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMemberStatistics()
        {
            try
            {
                int totalLoans = _context.Loans.Count(l => l.MemberId == MemberId);
                int activeLoans = _context.Loans.Count(l => l.MemberId == MemberId && l.ReturnDate == null);
                int overdueLoans = _context.Loans.Count(l => l.MemberId == MemberId &&
                    l.ReturnDate == null && l.DueDate < DateTime.Now);

                var totalFine = _context.Loans
                    .Where(l => l.MemberId == MemberId && l.Fine.HasValue)
                    .Sum(l => l.Fine.Value);

                lblTotalLoans.Text = totalLoans.ToString();
                lblActiveLoans.Text = activeLoans.ToString();
                lblOverdueLoans.Text = overdueLoans.ToString();
                lblTotalFines.Text = string.Format("{0:C}", totalFine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Üye istatistikleri yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMemberLoans()
        {
            try
            {
                var loans = _context.Loans
                    .Where(l => l.MemberId == MemberId)
                    .Select(l => new
                    {
                        l.LoanId,
                        BookTitle = l.Book.Title,
                        AuthorName = l.Book.Author.Name,
                        l.LoanDate,
                        l.DueDate,
                        l.ReturnDate,
                        Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                        DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                            (int)(DateTime.Now - l.DueDate).TotalDays : 0,
                        Fine = l.Fine.HasValue ? l.Fine.Value : 0
                    })
                    .OrderByDescending(l => l.LoanDate)
                    .ToList();

                dgvLoans.DataSource = loans;

                // Kolon başlıklarını ayarla
                if (dgvLoans.Columns.Count > 0)
                {
                    dgvLoans.Columns["LoanId"].HeaderText = "ID";
                    dgvLoans.Columns["BookTitle"].HeaderText = "Kitap Adı";
                    dgvLoans.Columns["AuthorName"].HeaderText = "Yazar";
                    dgvLoans.Columns["LoanDate"].HeaderText = "Ödünç Tarihi";
                    dgvLoans.Columns["DueDate"].HeaderText = "İade Tarihi";
                    dgvLoans.Columns["ReturnDate"].HeaderText = "Teslim Tarihi";
                    dgvLoans.Columns["Status"].HeaderText = "Durum";
                    dgvLoans.Columns["DaysLate"].HeaderText = "Gecikme (Gün)";
                    dgvLoans.Columns["Fine"].HeaderText = "Ceza (TL)";
                }

                // Geciken kayıtları renklendir
                foreach (DataGridViewRow row in dgvLoans.Rows)
                {
                    int daysLate = Convert.ToInt32(row.Cells["DaysLate"].Value);
                    if (daysLate > 0)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    }
                }

                lblLoanCount.Text = string.Format("Toplam: {0} kayıt", loans.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ödünç kayıtları yüklenirken hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMembers.SelectedIndex >= 0)
            {
                MemberId = Convert.ToInt32(cmbMembers.SelectedValue);
                LoadMemberDetails();
                LoadMemberLoans();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadAllMembers();
                return;
            }

            try
            {
                var filteredMembers = _context.Members
                    .Where(m => m.FirstName.ToLower().Contains(searchText) ||
                               m.LastName.ToLower().Contains(searchText) ||
                               m.Email.ToLower().Contains(searchText) ||
                               m.Phone.Contains(searchText))
                    .Select(m => new
                    {
                        m.MemberId,
                        FullName = m.FirstName + " " + m.LastName,
                        m.Email,
                        m.Phone,
                        m.MembershipDate,
                        Status = m.IsActive ? "Aktif" : "Pasif"
                    })
                    .OrderBy(m => m.FullName)
                    .ToList();

                cmbMembers.DataSource = filteredMembers;
                cmbMembers.DisplayMember = "FullName";
                cmbMembers.ValueMember = "MemberId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Arama sırasında hata oluştu: {0}", ex.Message), "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MemberId > 0)
            {
                try
                {
                    MemberManagementForm editForm = new MemberManagementForm();
                    editForm.ShowDialog();
                    LoadMemberDetails();
                    LoadMemberLoans();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Üye düzenleme formu açılırken hata oluştu: {0}", ex.Message),
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir üye seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNewLoan_Click(object sender, EventArgs e)
        {
            if (MemberId > 0)
            {
                try
                {
                    LoanManagementForm loanForm = new LoanManagementForm();
                    loanForm.ShowDialog();
                    LoadMemberLoans();
                    LoadMemberStatistics();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Ödünç verme formu açılırken hata oluştu: {0}", ex.Message),
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce bir üye seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        }
    }
