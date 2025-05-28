using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kutupHaneOtomasyonu.Data;
using kutupHaneOtomasyonu.Models;

namespace kutupHaneOtomasyonu.Forms
{
    public partial class MemberManagementForm : Form
    {
        private readonly LibraryContext _context;
        private int selectedMemberId = 0;

        public MemberManagementForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void MemberManagementForm_Load(object sender, EventArgs e)
        {
            LoadMembers();
            ClearForm();
        }

        private void LoadMembers()
        {
            var members = _context.Members
                .Select(m => new
                {
                    m.MemberId,
                    m.FirstName,
                    m.LastName,
                    FullName = m.FirstName + " " + m.LastName,
                    m.Email,
                    m.Phone,
                    m.Address,
                    m.MembershipDate,
                    m.IsActive,
                    Status = m.IsActive ? "Aktif" : "Pasif",
                    ActiveLoans = m.Loans.Count(l => l.ReturnDate == null)
                })
                .ToList();

            dgvMembers.DataSource = members;

            // Kolon başlıklarını düzenle
            dgvMembers.Columns["MemberId"].HeaderText = "ID";
            dgvMembers.Columns["FirstName"].Visible = false;
            dgvMembers.Columns["LastName"].Visible = false;
            dgvMembers.Columns["FullName"].HeaderText = "Ad Soyad";
            dgvMembers.Columns["Email"].HeaderText = "E-posta";
            dgvMembers.Columns["Phone"].HeaderText = "Telefon";
            dgvMembers.Columns["Address"].HeaderText = "Adres";
            dgvMembers.Columns["MembershipDate"].HeaderText = "Üyelik Tarihi";
            dgvMembers.Columns["IsActive"].Visible = false;
            dgvMembers.Columns["Status"].HeaderText = "Durum";
            dgvMembers.Columns["ActiveLoans"].HeaderText = "Aktif Ödünç";

            // İstatistikleri güncelle
            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            int totalMembers = _context.Members.Count();
            int activeMembers = _context.Members.Count(m => m.IsActive);
            int inactiveMembers = totalMembers - activeMembers;
            int membersWithLoans = _context.Members.Count(m => m.Loans.Any(l => l.ReturnDate == null));

            lblTotalMembers.Text = $"Toplam Üye: {totalMembers}";
            lblActiveMembers.Text = $"Aktif Üye: {activeMembers}";
            lblInactiveMembers.Text = $"Pasif Üye: {inactiveMembers}";
            lblMembersWithLoans.Text = $"Kitap Ödünç Alan: {membersWithLoans}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var member = new Member
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        MembershipDate = dtpMembershipDate.Value,
                        IsActive = chkIsActive.Checked
                    };

                    _context.Members.Add(member);
                    _context.SaveChanges();

                    MessageBox.Show("Üye başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadMembers();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek üyeyi seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateForm())
            {
                try
                {
                    var member = _context.Members.Find(selectedMemberId);
                    if (member != null)
                    {
                        member.FirstName = txtFirstName.Text.Trim();
                        member.LastName = txtLastName.Text.Trim();
                        member.Email = txtEmail.Text.Trim();
                        member.Phone = txtPhone.Text.Trim();
                        member.Address = txtAddress.Text.Trim();
                        member.MembershipDate = dtpMembershipDate.Value;
                        member.IsActive = chkIsActive.Checked;

                        _context.SaveChanges();

                        MessageBox.Show("Üye başarıyla güncellendi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadMembers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Lütfen silinecek üyeyi seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bu üyeyi silmek istediğinizden emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var member = _context.Members.Find(selectedMemberId);
                    if (member != null)
                    {
                        // Aktif ödünç kitabı var mı kontrol et
                        var hasActiveLoans = _context.Loans
                            .Any(l => l.MemberId == selectedMemberId && l.ReturnDate == null);

                        if (hasActiveLoans)
                        {
                            MessageBox.Show("Bu üyenin teslim etmediği kitaplar var. Önce kitapları teslim alın!",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _context.Members.Remove(member);
                        _context.SaveChanges();

                        MessageBox.Show("Üye başarıyla silindi.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadMembers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
                selectedMemberId = Convert.ToInt32(row.Cells["MemberId"].Value);

                var member = _context.Members.Find(selectedMemberId);
                if (member != null)
                {
                    txtFirstName.Text = member.FirstName;
                    txtLastName.Text = member.LastName;
                    txtEmail.Text = member.Email;
                    txtPhone.Text = member.Phone;
                    txtAddress.Text = member.Address;
                    dtpMembershipDate.Value = member.MembershipDate;
                    chkIsActive.Checked = member.IsActive;

                    // Üyenin ödünç aldığı kitapları göster
                    LoadMemberLoans(selectedMemberId);
                }
            }
        }

        private void LoadMemberLoans(int memberId)
        {
            var loans = _context.Loans
                .Where(l => l.MemberId == memberId)
                .Select(l => new
                {
                    l.Book.Title,
                    l.LoanDate,
                    l.DueDate,
                    l.ReturnDate,
                    Status = l.ReturnDate == null ? "Ödünçte" : "İade Edildi",
                    DaysLate = l.ReturnDate == null && l.DueDate < DateTime.Now ?
                        (int)(DateTime.Now - l.DueDate).TotalDays : 0
                })
                .OrderByDescending(l => l.LoanDate)
                .ToList();

            dgvMemberLoans.DataSource = loans;

            // Kolon başlıklarını düzenle
            if (dgvMemberLoans.Columns.Count > 0)
            {
                dgvMemberLoans.Columns["Title"].HeaderText = "Kitap Adı";
                dgvMemberLoans.Columns["LoanDate"].HeaderText = "Ödünç Tarihi";
                dgvMemberLoans.Columns["DueDate"].HeaderText = "İade Tarihi";
                dgvMemberLoans.Columns["ReturnDate"].HeaderText = "Teslim Tarihi";
                dgvMemberLoans.Columns["Status"].HeaderText = "Durum";
                dgvMemberLoans.Columns["DaysLate"].HeaderText = "Gecikme (Gün)";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            var members = _context.Members
                .Where(m => m.FirstName.ToLower().Contains(searchText) ||
                           m.LastName.ToLower().Contains(searchText) ||
                           m.Email.ToLower().Contains(searchText) ||
                           m.Phone.Contains(searchText))
                .Select(m => new
                {
                    m.MemberId,
                    m.FirstName,
                    m.LastName,
                    FullName = m.FirstName + " " + m.LastName,
                    m.Email,
                    m.Phone,
                    m.Address,
                    m.MembershipDate,
                    m.IsActive,
                    Status = m.IsActive ? "Aktif" : "Pasif",
                    ActiveLoans = m.Loans.Count(l => l.ReturnDate == null)
                })
                .ToList();

            dgvMembers.DataSource = members;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Ad boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Soyad boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("E-posta boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // E-posta formatı kontrolü
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Telefon boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedMemberId = 0;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpMembershipDate.Value = DateTime.Now;
            chkIsActive.Checked = true;
            txtSearch.Clear();
            dgvMemberLoans.DataSource = null;
        }

        private void MemberManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context?.Dispose();
        }
    }
}