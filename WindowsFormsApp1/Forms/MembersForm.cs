using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class MembersForm : Form
    {
        private readonly LibraryContext _context;

        public MembersForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadMembers();
        }

        private void LoadMembers()
        {
            try
            {
                var members = _context.Members.ToList();
                bindingSource.DataSource = members;
                dgvMembers.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üyeler yüklenirken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new MemberEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadMembers();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                var member = (Member)dgvMembers.SelectedRows[0].DataBoundItem;
                using (var form = new MemberEditForm(member))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadMembers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlenecek üyeyi seçin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                var member = (Member)dgvMembers.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show(
                    $"{member.FirstName} {member.LastName} isimli üyeyi silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _context.Members.Remove(member);
                        _context.SaveChanges();
                        LoadMembers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Üye silinirken bir hata oluştu: " + ex.Message, "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek üyeyi seçin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMembers.SelectedRows.Count > 0)
                {
                    var member = (Member)dgvMembers.SelectedRows[0].DataBoundItem;
                    member.IsActive = !member.IsActive;
                    _context.SaveChanges();
                    LoadMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üyelik durumu değiştirilirken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var searchText = txtSearch.Text.ToLower();
                var searchType = cmbSearchType.SelectedItem.ToString();

                var query = _context.Members.AsQueryable();

                switch (searchType)
                {
                    case "Ad":
                        query = query.Where(m => m.FirstName.ToLower().Contains(searchText));
                        break;
                    case "Soyad":
                        query = query.Where(m => m.LastName.ToLower().Contains(searchText));
                        break;
                    case "E-posta":
                        query = query.Where(m => m.Email.ToLower().Contains(searchText));
                        break;
                    case "Telefon":
                        query = query.Where(m => m.Phone.Contains(searchText));
                        break;
                }

                bindingSource.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama yapılırken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
} 