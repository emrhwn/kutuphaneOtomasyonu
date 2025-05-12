using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeMenuStrip();
        }

        private void InitializeMenuStrip()
        {
            MenuStrip mainMenu = new MenuStrip();
            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);

            // Kitap İşlemleri Menüsü
            ToolStripMenuItem booksMenu = new ToolStripMenuItem("Kitap İşlemleri");
            booksMenu.DropDownItems.Add("Kitap Listesi", null, (s, e) => OpenForm(new BooksForm()));
            booksMenu.DropDownItems.Add("Yazar Listesi", null, (s, e) => OpenForm(new AuthorsForm()));
            mainMenu.Items.Add(booksMenu);

            // Üye İşlemleri Menüsü
            ToolStripMenuItem membersMenu = new ToolStripMenuItem("Üye İşlemleri");
            membersMenu.DropDownItems.Add("Üye Listesi", null, (s, e) => OpenForm(new MembersForm()));
            mainMenu.Items.Add(membersMenu);

            // Ödünç İşlemleri Menüsü
            ToolStripMenuItem loansMenu = new ToolStripMenuItem("Ödünç İşlemleri");
            loansMenu.DropDownItems.Add("Ödünç Listesi", null, (s, e) => OpenForm(new LoansForm()));
            loansMenu.DropDownItems.Add("Rezervasyon Listesi", null, (s, e) => OpenForm(new ReservationsForm()));
            mainMenu.Items.Add(loansMenu);

            // Raporlar Menüsü
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Raporlar");
            reportsMenu.DropDownItems.Add("Stok Raporu", null, (s, e) => OpenForm(new StockReportForm()));
            reportsMenu.DropDownItems.Add("Gecikmiş İadeler", null, (s, e) => OpenForm(new OverdueReportForm()));
            mainMenu.Items.Add(reportsMenu);
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }
    }
} 