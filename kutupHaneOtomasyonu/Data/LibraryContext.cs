using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using kutupHaneOtomasyonu.Models;

namespace kutupHaneOtomasyonu.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=LibraryContext")
        {
            // Lazy loading ayarları
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;

            // Migration stratejisi
            Database.SetInitializer<LibraryContext>(
                new CreateDatabaseIfNotExists<LibraryContext>());
        }

        // DbSet tanımlamaları
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Convention'ları kaldır
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // User tablosu konfigürasyonu
            ConfigureUserEntity(modelBuilder);

            // Book tablosu konfigürasyonu
            ConfigureBookEntity(modelBuilder);

            // Member tablosu konfigürasyonu
            ConfigureMemberEntity(modelBuilder);

            // Loan tablosu konfigürasyonu
            ConfigureLoanEntity(modelBuilder);

            // Reservation tablosu konfigürasyonu
            ConfigureReservationEntity(modelBuilder);

            // Author tablosu konfigürasyonu
            ConfigureAuthorEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureUserEntity(DbModelBuilder modelBuilder)
        {
            // Tablo adı
            modelBuilder.Entity<User>()
                .ToTable("Users");

            // Username - Unique Index
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Username")
                    {
                        IsUnique = true
                    }));

            // Email - Unique Index
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Email")
                    {
                        IsUnique = true
                    }));

            // PasswordHash
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            // Phone
            modelBuilder.Entity<User>()
                .Property(u => u.Phone)
                .HasMaxLength(20);

            // Role
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(20);
        }

        private void ConfigureBookEntity(DbModelBuilder modelBuilder)
        {
            // Tablo adı
            modelBuilder.Entity<Book>()
                .ToTable("Books");

            // ISBN - Unique Index (varsa)
            if (typeof(Book).GetProperty("ISBN") != null)
            {
                modelBuilder.Entity<Book>()
                    .Property(b => b.ISBN)
                    .HasMaxLength(20)
                    .HasColumnAnnotation(
                        IndexAnnotation.AnnotationName,
                        new IndexAnnotation(new IndexAttribute("IX_ISBN")
                        {
                            IsUnique = true
                        }));
            }
        }

        private void ConfigureMemberEntity(DbModelBuilder modelBuilder)
        {
            // Tablo adı
            modelBuilder.Entity<Member>()
                .ToTable("Members");

            // Email - Unique Index (varsa)
            if (typeof(Member).GetProperty("Email") != null)
            {
                modelBuilder.Entity<Member>()
                    .Property(m => m.Email)
                    .HasMaxLength(100)
                    .HasColumnAnnotation(
                        IndexAnnotation.AnnotationName,
                        new IndexAnnotation(new IndexAttribute("IX_Member_Email")
                        {
                            IsUnique = true
                        }));
            }
        }

        private void ConfigureLoanEntity(DbModelBuilder modelBuilder)
        {
            // Tablo adı
            modelBuilder.Entity<Loan>()
                .ToTable("Loans");

            // FineAmount - Decimal precision
            modelBuilder.Entity<Loan>()
                .Property(l => l.FineAmount)
                .HasPrecision(18, 2);

            // Book ilişkisi
            modelBuilder.Entity<Loan>()
                .HasRequired(l => l.Book)
                .WithMany()
                .HasForeignKey(l => l.BookId)
                .WillCascadeOnDelete(false);

            // Member ilişkisi
            modelBuilder.Entity<Loan>()
                .HasRequired(l => l.Member)
                .WithMany()
                .HasForeignKey(l => l.MemberId)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureReservationEntity(DbModelBuilder modelBuilder)
        {
            // Tablo adı
            modelBuilder.Entity<Reservation>()
                .ToTable("Reservations");

            // Book ilişkisi
            modelBuilder.Entity<Reservation>()
                .HasRequired(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.BookId)
                .WillCascadeOnDelete(false);

            // Member ilişkisi
            modelBuilder.Entity<Reservation>()
                .HasRequired(r => r.Member)
                .WithMany()
                .HasForeignKey(r => r.MemberId)
                .WillCascadeOnDelete(false);
        }

        private void ConfigureAuthorEntity(DbModelBuilder modelBuilder)
        {
            // Tablo adı
            modelBuilder.Entity<Author>()
                .ToTable("Authors");
        }

        // SaveChanges override
        public override int SaveChanges()
        {
            // User için CreatedDate otomatik ayarlama
            var userEntries = ChangeTracker.Entries()
                .Where(e => e.Entity is User && e.State == EntityState.Added);

            foreach (var entry in userEntries)
            {
                var user = (User)entry.Entity;
                if (user.CreatedDate == default(DateTime))
                {
                    user.CreatedDate = DateTime.Now;
                }
                if (user.IsActive == default(bool))
                {
                    user.IsActive = true;
                }
            }

            return base.SaveChanges();
        }
    }
}