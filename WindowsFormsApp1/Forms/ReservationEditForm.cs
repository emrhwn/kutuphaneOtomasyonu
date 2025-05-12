using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class ReservationEditForm : Form
    {
        private readonly LibraryContext _context;
        private readonly Reservation _reservation;
        private readonly bool _isNew;

        public ReservationEditForm(Reservation reservation = null)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _isNew = reservation == null;
            _reservation = reservation ?? new Reservation();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Kitapları yükle
                var books = _context.Books
                    .Where(b => b.AvailableCopies > 0)
                    .ToList();
                cmbBook.DataSource = books;
                cmbBook.DisplayMember = "Title";
                cmbBook.ValueMember = "Id";

                // Üyeleri yükle
                var members = _context.Members
                    .Where(m => m.IsActive)
                    .ToList();
                cmbMember.DataSource = members;
                cmbMember.DisplayMember = "FullName";
                cmbMember.ValueMember = "Id";

                // Rezervasyon durumlarını yükle
                cmbStatus.Items.AddRange(new[] { "Beklemede", "Onaylandı", "İptal Edildi", "Tamamlandı" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReservationEditForm_Load(object sender, EventArgs e)
        {
            if (!_isNew)
            {
                cmbBook.SelectedValue = _reservation.BookId;
                cmbMember.SelectedValue = _reservation.MemberId;
                dtpReservationDate.Value = _reservation.ReservationDate;
                dtpExpiryDate.Value = _reservation.ExpiryDate;
                cmbStatus.SelectedItem = _reservation.Status;
                txtNotes.Text = _reservation.Notes;
            }
            else
            {
                dtpReservationDate.Value = DateTime.Now;
                dtpExpiryDate.Value = DateTime.Now.AddDays(7); // Varsayılan olarak 7 gün
                cmbStatus.SelectedItem = "Beklemede";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBook.SelectedItem == null || cmbMember.SelectedItem == null || 
                    string.IsNullOrEmpty(cmbStatus.SelectedItem?.ToString()))
                {
                    MessageBox.Show("Lütfen gerekli alanları doldurun.", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _reservation.BookId = (int)cmbBook.SelectedValue;
                _reservation.MemberId = (int)cmbMember.SelectedValue;
                _reservation.ReservationDate = dtpReservationDate.Value;
                _reservation.ExpiryDate = dtpExpiryDate.Value;
                _reservation.Status = cmbStatus.SelectedItem.ToString();
                _reservation.Notes = txtNotes.Text.Trim();

                if (_isNew)
                {
                    _context.Reservations.Add(_reservation);
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