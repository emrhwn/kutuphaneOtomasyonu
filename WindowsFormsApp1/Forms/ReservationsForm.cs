using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class ReservationsForm : Form
    {
        private readonly LibraryContext _context;

        public ReservationsForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                var reservations = _context.Reservations
                    .Include("Book")
                    .Include("Member")
                    .ToList();
                bindingSource.DataSource = reservations;
                dgvReservations.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar yüklenirken bir hata oluştu: " + ex.Message, "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ReservationEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                var reservation = (Reservation)dgvReservations.SelectedRows[0].DataBoundItem;
                using (var form = new ReservationEditForm(reservation))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadReservations();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlenecek rezervasyonu seçin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                var reservation = (Reservation)dgvReservations.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show(
                    $"Seçili rezervasyonu silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _context.Reservations.Remove(reservation);
                        _context.SaveChanges();
                        LoadReservations();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Rezervasyon silinirken bir hata oluştu: " + ex.Message, "Hata", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek rezervasyonu seçin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var searchText = txtSearch.Text.ToLower();
                var searchType = cmbSearchType.SelectedItem.ToString();

                var query = _context.Reservations
                    .Include("Book")
                    .Include("Member")
                    .AsQueryable();

                switch (searchType)
                {
                    case "Üye":
                        query = query.Where(r => 
                            r.Member.FirstName.ToLower().Contains(searchText) || 
                            r.Member.LastName.ToLower().Contains(searchText));
                        break;
                    case "Kitap":
                        query = query.Where(r => r.Book.Title.ToLower().Contains(searchText));
                        break;
                    case "Durum":
                        query = query.Where(r => r.Status.ToLower().Contains(searchText));
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