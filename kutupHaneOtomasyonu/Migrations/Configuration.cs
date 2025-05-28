namespace kutupHaneOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using kutupHaneOtomasyonu.Models;
    using kutupHaneOtomasyonu.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<kutupHaneOtomasyonu.Data.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // false yerine true yapın
            AutomaticMigrationDataLossAllowed = true; // Veri kaybına izin ver
            MigrationsDirectory = @"Migrations";
            ContextKey = "kutupHaneOtomasyonu.Data.LibraryContext";
        }

        protected override void Seed(kutupHaneOtomasyonu.Data.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Varsayılan Admin kullanıcısı ekleme
            context.Users.AddOrUpdate(
                u => u.Username,
                new User
                {
                    Username = "admin",
                    PasswordHash = "admin123", // Gerçek uygulamada hash'lenmiş olmalı
                    Email = "admin@library.com",
                    Phone = "5551234567",
                    Role = "Admin",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            );

            // Varsayılan Kütüphaneci kullanıcısı ekleme
            context.Users.AddOrUpdate(
                u => u.Username,
                new User
                {
                    Username = "kutuphane1",
                    PasswordHash = "kutup123", // Gerçek uygulamada hash'lenmiş olmalı
                    Email = "kutuphane1@library.com",
                    Phone = "5557654321",
                    Role = "Kullanıcı",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
            );

            // Örnek Yazarlar
            context.Authors.AddOrUpdate(
                a => a.Name,
                new Author { Name = "Orhan Pamuk", Biography = "Nobel ödüllü Türk yazar" },
                new Author { Name = "Yaşar Kemal", Biography = "Türk edebiyatının önemli isimlerinden" },
                new Author { Name = "Sabahattin Ali", Biography = "Türk yazar ve şair" },
                new Author { Name = "Ahmet Hamdi Tanpınar", Biography = "Türk romancı, deneme yazarı ve şair" },
                new Author { Name = "Oğuz Atay", Biography = "Türk romancı ve oyun yazarı" }
            );

            // SaveChanges çağrısı - Yazarları kaydet
            context.SaveChanges();

            // Örnek Kitaplar
            var orhanPamuk = context.Authors.FirstOrDefault(a => a.Name == "Orhan Pamuk");
            var yasarKemal = context.Authors.FirstOrDefault(a => a.Name == "Yaşar Kemal");
            var sabahattinAli = context.Authors.FirstOrDefault(a => a.Name == "Sabahattin Ali");

            if (orhanPamuk != null)
            {
                context.Books.AddOrUpdate(
                    b => b.ISBN,
                    new Book
                    {
                        Title = "Kar",
                        AuthorId = orhanPamuk.AuthorId,
                        ISBN = "9789750826023",
                        PublicationYear = 2002,
                        Publisher = "İletişim Yayınları",
                        Category = "Roman",
                        TotalCopies = 5,
                        AvailableCopies = 5
                    },
                    new Book
                    {
                        Title = "Masumiyet Müzesi",
                        AuthorId = orhanPamuk.AuthorId,
                        ISBN = "9789750826030",
                        PublicationYear = 2008,
                        Publisher = "İletişim Yayınları",
                        Category = "Roman",
                        TotalCopies = 3,
                        AvailableCopies = 3
                    }
                );
            }

            if (yasarKemal != null)
            {
                context.Books.AddOrUpdate(
                    b => b.ISBN,
                    new Book
                    {
                        Title = "İnce Memed",
                        AuthorId = yasarKemal.AuthorId,
                        ISBN = "9789750719387",
                        PublicationYear = 1955,
                        Publisher = "Yapı Kredi Yayınları",
                        Category = "Roman",
                        TotalCopies = 4,
                        AvailableCopies = 4
                    }
                );
            }

            if (sabahattinAli != null)
            {
                context.Books.AddOrUpdate(
                    b => b.ISBN,
                    new Book
                    {
                        Title = "Kürk Mantolu Madonna",
                        AuthorId = sabahattinAli.AuthorId,
                        ISBN = "9789753638029",
                        PublicationYear = 1943,
                        Publisher = "Yapı Kredi Yayınları",
                        Category = "Roman",
                        TotalCopies = 6,
                        AvailableCopies = 6
                    }
                );
            }

            // Örnek Üyeler
            context.Members.AddOrUpdate(
                m => m.Email,
                new Member
                {
                    FirstName = "Ali",
                    LastName = "Yılmaz",
                    Email = "ali.yilmaz@email.com",
                    Phone = "5551112233",
                    Address = "Ankara, Türkiye",
                    MembershipDate = DateTime.Now.AddMonths(-6),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Ayşe",
                    LastName = "Demir",
                    Email = "ayse.demir@email.com",
                    Phone = "5552223344",
                    Address = "İstanbul, Türkiye",
                    MembershipDate = DateTime.Now.AddMonths(-3),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Mehmet",
                    LastName = "Kaya",
                    Email = "mehmet.kaya@email.com",
                    Phone = "5553334455",
                    Address = "İzmir, Türkiye",
                    MembershipDate = DateTime.Now.AddMonths(-1),
                    IsActive = true
                }
            );

            // Tüm değişiklikleri kaydet
            context.SaveChanges();
        }
    }
}