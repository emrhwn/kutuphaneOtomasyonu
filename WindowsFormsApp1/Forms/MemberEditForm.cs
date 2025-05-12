using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class MemberEditForm : Form
    {
        private readonly LibraryContext _context;
        private readonly Member _member;
        private readonly bool _isNew;

        public MemberEditForm(Member member = null)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _isNew = member == null;
            _member = member ?? new Member();
        }

        private void MemberEditForm_Load(object sender, EventArgs e)
        {
            if (!_isNew)
            {
                txtFirstName.Text = _member.FirstName;
                txtLastName.Text = _member.LastName;
                txtEmail.Text = _member.Email;
                txtPhone.Text = _member.Phone;
                txtAddress.Text = _member.Address;
                chkIsActive.Checked = _member.IsActive;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || 
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurun.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _member.FirstName = txtFirstName.Text.Trim();
                _member.LastName = txtLastName.Text.Trim();
                _member.Email = txtEmail.Text.Trim();
                _member.Phone = txtPhone.Text.Trim();
                _member.Address = txtAddress.Text.Trim();
                _member.IsActive = chkIsActive.Checked;

                if (_isNew)
                {
                    _context.Members.Add(_member);
                }

                _context.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
} 