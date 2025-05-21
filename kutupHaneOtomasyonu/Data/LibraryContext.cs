using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using kutupHaneOtomasyonu.Models;

namespace kutupHaneOtomasyonu.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("LibraryContext")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // İsimlendirme convention’ı değiştirerek tablo adlarını çoğullaştırmaktan vazgeçmek isterseniz:
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Loan.FineAmount alanı için SQL Server'da decimal(18,2) ayarı
            modelBuilder.Entity<Loan>()
                .Property(l => l.FineAmount)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
