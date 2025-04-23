using System.Data.Entity;

namespace WindowsFormsApp1.Models
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext() : base("DefaultConnection")
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
    }
}
