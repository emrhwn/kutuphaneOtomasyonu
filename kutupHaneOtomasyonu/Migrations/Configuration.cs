namespace kutupHaneOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using kutupHaneOtomasyonu.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<kutupHaneOtomasyonu.Data.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(kutupHaneOtomasyonu.Data.LibraryContext context)
        {
            // Use a fixed reference date for all seed data to ensure consistency
            DateTime referenceDate = new DateTime(2024, 1, 1);

            // 1. KATEGORİLER
            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category { Name = "Roman", Description = "Yerli ve yabancı romanlar" },
                new Category { Name = "Bilim Kurgu", Description = "Bilim kurgu ve fantastik kitaplar" },
                new Category { Name = "Tarih", Description = "Tarih konulu kitaplar" },
                new Category { Name = "Bilgisayar", Description = "Yazılım, donanım ve teknoloji kitapları" },
                new Category { Name = "Çocuk", Description = "Çocuklar için kitaplar" },
                new Category { Name = "Şiir", Description = "Şiir kitapları" },
                new Category { Name = "Felsefe", Description = "Felsefe kitapları" },
                new Category { Name = "Psikoloji", Description = "Psikoloji kitapları" },
                new Category { Name = "Kişisel Gelişim", Description = "Kişisel gelişim kitapları" },
                new Category { Name = "Polisiye", Description = "Polisiye ve gerilim romanları" }
            );
            context.SaveChanges();

            // 2. YAZARLAR
            context.Authors.AddOrUpdate(
                a => a.Name,
                new Author { Name = "Orhan Pamuk" },
                new Author { Name = "Yaşar Kemal" },
                new Author { Name = "Sabahattin Ali" },
                new Author { Name = "Ahmet Ümit" },
                new Author { Name = "Elif Şafak" },
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "George Orwell" },
                new Author { Name = "Stephen King" },
                new Author { Name = "Agatha Christie" },
                new Author { Name = "Isaac Asimov" },
                new Author { Name = "J.R.R. Tolkien" },
                new Author { Name = "Fyodor Dostoyevski" },
                new Author { Name = "Victor Hugo" },
                new Author { Name = "İlber Ortaylı" },
                new Author { Name = "Nazım Hikmet" }
            );
            context.SaveChanges();

            // Kategorileri ve yazarları al
            var romanCat = context.Categories.First(c => c.Name == "Roman");
            var bilimKurguCat = context.Categories.First(c => c.Name == "Bilim Kurgu");
            var tarihCat = context.Categories.First(c => c.Name == "Tarih");
            var siirCat = context.Categories.First(c => c.Name == "Şiir");
            var polisiyeCat = context.Categories.First(c => c.Name == "Polisiye");

            var orhanPamuk = context.Authors.First(a => a.Name == "Orhan Pamuk");
            var yasarKemal = context.Authors.First(a => a.Name == "Yaşar Kemal");
            var sabahattinAli = context.Authors.First(a => a.Name == "Sabahattin Ali");
            var ahmetUmit = context.Authors.First(a => a.Name == "Ahmet Ümit");
            var rowling = context.Authors.First(a => a.Name == "J.K. Rowling");
            var orwell = context.Authors.First(a => a.Name == "George Orwell");
            var asimov = context.Authors.First(a => a.Name == "Isaac Asimov");
            var ilberOrtayli = context.Authors.First(a => a.Name == "İlber Ortaylı");
            var nazimHikmet = context.Authors.First(a => a.Name == "Nazım Hikmet");
            var christie = context.Authors.First(a => a.Name == "Agatha Christie");

            // 3. KİTAPLAR
            context.Books.AddOrUpdate(
                b => b.ISBN,
                // Orhan Pamuk
                new Book
                {
                    Title = "Kırmızı Saçlı Kadın",
                    AuthorId = orhanPamuk.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750837357",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 2016,
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Description = "Orhan Pamuk'un mitoloji ve modern hayatı harmanlayan romanı"
                },
                new Book
                {
                    Title = "Masumiyet Müzesi",
                    AuthorId = orhanPamuk.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750825872",
                    Publisher = "İletişim Yayınları",
                    PublicationYear = 2008,
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Description = "1970'lerin İstanbul'unda geçen bir aşk hikayesi"
                },
                new Book
                {
                    Title = "Kar",
                    AuthorId = orhanPamuk.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750818912",
                    Publisher = "İletişim Yayınları",
                    PublicationYear = 2002,
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Description = "Kars'ta geçen politik bir roman"
                },

                // Yaşar Kemal
                new Book
                {
                    Title = "İnce Memed",
                    AuthorId = yasarKemal.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750807008",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 1955,
                    TotalCopies = 6,
                    AvailableCopies = 6,
                    Description = "Çukurova'da geçen efsanevi eşkıya romanı"
                },
                new Book
                {
                    Title = "Yılanı Öldürseler",
                    AuthorId = yasarKemal.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750819643",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 1976,
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Description = "Köy yaşamını anlatan güçlü bir roman"
                },

                // Sabahattin Ali
                new Book
                {
                    Title = "Kürk Mantolu Madonna",
                    AuthorId = sabahattinAli.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750822230",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 1943,
                    TotalCopies = 8,
                    AvailableCopies = 8,
                    Description = "Türk edebiyatının en çok okunan romanlarından"
                },
                new Book
                {
                    Title = "İçimizdeki Şeytan",
                    AuthorId = sabahattinAli.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750822247",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 1940,
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Description = "İnsanın iç dünyasını anlatan psikolojik roman"
                },

                // Ahmet Ümit
                new Book
                {
                    Title = "Beyoğlu Rapsodisi",
                    AuthorId = ahmetUmit.AuthorId,
                    CategoryId = polisiyeCat.CategoryId,
                    ISBN = "9786051114576",
                    Publisher = "Everest Yayınları",
                    PublicationYear = 2003,
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Description = "İstanbul'un tarihiyle iç içe geçmiş polisiye"
                },
                new Book
                {
                    Title = "İstanbul Hatırası",
                    AuthorId = ahmetUmit.AuthorId,
                    CategoryId = polisiyeCat.CategoryId,
                    ISBN = "9786051141145",
                    Publisher = "Everest Yayınları",
                    PublicationYear = 2010,
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Description = "Tarihi mekanlarda geçen gizemli cinayetler"
                },

                // J.K. Rowling
                new Book
                {
                    Title = "Harry Potter ve Felsefe Taşı",
                    AuthorId = rowling.AuthorId,
                    CategoryId = bilimKurguCat.CategoryId,
                    ISBN = "9789750837579",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 1997,
                    TotalCopies = 10,
                    AvailableCopies = 10,
                    Description = "Harry Potter serisinin ilk kitabı"
                },

                // George Orwell
                new Book
                {
                    Title = "1984",
                    AuthorId = orwell.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750742224",
                    Publisher = "Can Yayınları",
                    PublicationYear = 1949,
                    TotalCopies = 7,
                    AvailableCopies = 7,
                    Description = "Distopik bir gelecek romanı"
                },
                new Book
                {
                    Title = "Hayvan Çiftliği",
                    AuthorId = orwell.AuthorId,
                    CategoryId = romanCat.CategoryId,
                    ISBN = "9789750719387",
                    Publisher = "Can Yayınları",
                    PublicationYear = 1945,
                    TotalCopies = 6,
                    AvailableCopies = 6,
                    Description = "Politik bir alegori"
                },

                // Isaac Asimov
                new Book
                {
                    Title = "Ben, Robot",
                    AuthorId = asimov.AuthorId,
                    CategoryId = bilimKurguCat.CategoryId,
                    ISBN = "9786051119120",
                    Publisher = "İthaki Yayınları",
                    PublicationYear = 1950,
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Description = "Robot hikayeleri"
                },

                // İlber Ortaylı
                new Book
                {
                    Title = "Bir Ömür Nasıl Yaşanır?",
                    AuthorId = ilberOrtayli.AuthorId,
                    CategoryId = tarihCat.CategoryId,
                    ISBN = "9786254053128",
                    Publisher = "Kronik Kitap",
                    PublicationYear = 2019,
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Description = "Hayat üzerine düşünceler"
                },

                // Nazım Hikmet
                new Book
                {
                    Title = "Memleketimden İnsan Manzaraları",
                    AuthorId = nazimHikmet.AuthorId,
                    CategoryId = siirCat.CategoryId,
                    ISBN = "9789750822568",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 1966,
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Description = "Nazım Hikmet'in epik şiiri"
                },

                // Agatha Christie
                new Book
                {
                    Title = "On Küçük Zenci",
                    AuthorId = christie.AuthorId,
                    CategoryId = polisiyeCat.CategoryId,
                    ISBN = "9789753638029",
                    Publisher = "Altın Kitaplar",
                    PublicationYear = 1939,
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Description = "Polisiye edebiyatının klasiklerinden"
                }
            );
            context.SaveChanges();

            // 4. KULLANICILAR
            context.Users.AddOrUpdate(
                u => u.Username,
                new User
                {
                    Username = "admin",
                    PasswordHash = "123456",
                    FullName = "Sistem Yöneticisi",
                    Email = "admin@kutuphane.com",
                    Phone = "5551234567",
                    Role = "Admin",
                    CreatedDate = referenceDate,
                    IsActive = true
                },
                new User
                {
                    Username = "personel1",
                    PasswordHash = "123456",
                    FullName = "Ayşe Yılmaz",
                    Email = "ayse@kutuphane.com",
                    Phone = "5559876543",
                    Role = "Personel",
                    CreatedDate = referenceDate.AddDays(-100),
                    IsActive = true
                },
                new User
                {
                    Username = "personel2",
                    PasswordHash = "123456",
                    FullName = "Mehmet Demir",
                    Email = "mehmet@kutuphane.com",
                    Phone = "5554567890",
                    Role = "Personel",
                    CreatedDate = referenceDate.AddDays(-50),
                    IsActive = true
                }
            );
            context.SaveChanges();

            // 5. ÜYELER
            context.Members.AddOrUpdate(
                m => m.Email,
                new Member
                {
                    FirstName = "Ali",
                    LastName = "Yılmaz",
                    Email = "ali.yilmaz@email.com",
                    Phone = "5551112233",
                    JoinDate = referenceDate.AddMonths(-6),
                    MembershipDate = referenceDate.AddMonths(-6),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Ayşe",
                    LastName = "Kaya",
                    Email = "ayse.kaya@email.com",
                    Phone = "5552223344",
                    JoinDate = referenceDate.AddMonths(-4),
                    MembershipDate = referenceDate.AddMonths(-4),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Fatma",
                    LastName = "Demir",
                    Email = "fatma.demir@email.com",
                    Phone = "5553334455",
                    JoinDate = referenceDate.AddMonths(-3),
                    MembershipDate = referenceDate.AddMonths(-3),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Mehmet",
                    LastName = "Çelik",
                    Email = "mehmet.celik@email.com",
                    Phone = "5554445566",
                    JoinDate = referenceDate.AddMonths(-2),
                    MembershipDate = referenceDate.AddMonths(-2),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Zeynep",
                    LastName = "Aydın",
                    Email = "zeynep.aydin@email.com",
                    Phone = "5555556677",
                    JoinDate = referenceDate.AddMonths(-1),
                    MembershipDate = referenceDate.AddMonths(-1),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Ahmet",
                    LastName = "Özkan",
                    Email = "ahmet.ozkan@email.com",
                    Phone = "5556667788",
                    JoinDate = referenceDate.AddDays(-15),
                    MembershipDate = referenceDate.AddDays(-15),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Elif",
                    LastName = "Şahin",
                    Email = "elif.sahin@email.com",
                    Phone = "5557778899",
                    JoinDate = referenceDate.AddDays(-10),
                    MembershipDate = referenceDate.AddDays(-10),
                    IsActive = true
                },
                new Member
                {
                    FirstName = "Can",
                    LastName = "Yıldız",
                    Email = "can.yildiz@email.com",
                    Phone = "5558889900",
                    JoinDate = referenceDate.AddDays(-5),
                    MembershipDate = referenceDate.AddDays(-5),
                    IsActive = false // Pasif üye
                }
            );
            context.SaveChanges();

            // 6. ÖDÜNÇ İŞLEMLERİ
            var aliYilmaz = context.Members.First(m => m.Email == "ali.yilmaz@email.com");
            var ayseKaya = context.Members.First(m => m.Email == "ayse.kaya@email.com");
            var fatmaDemir = context.Members.First(m => m.Email == "fatma.demir@email.com");

            var kurkMantolu = context.Books.First(b => b.Title == "Kürk Mantolu Madonna");
            var dokuzYuz = context.Books.First(b => b.Title == "1984");
            var inceMemed = context.Books.First(b => b.Title == "İnce Memed");

            context.Loans.AddOrUpdate(
                l => new { l.MemberId, l.BookId, l.LoanDate },
                new Loan
                {
                    MemberId = aliYilmaz.MemberId,
                    BookId = kurkMantolu.BookId,
                    LoanDate = referenceDate.AddDays(-5),
                    DueDate = referenceDate.AddDays(9),
                    ReturnDate = null
                },
                new Loan
                {
                    MemberId = ayseKaya.MemberId,
                    BookId = dokuzYuz.BookId,
                    LoanDate = referenceDate.AddDays(-10),
                    DueDate = referenceDate.AddDays(4),
                    ReturnDate = null
                },
                new Loan
                {
                    MemberId = fatmaDemir.MemberId,
                    BookId = inceMemed.BookId,
                    LoanDate = referenceDate.AddDays(-20),
                    DueDate = referenceDate.AddDays(-6),
                    ReturnDate = null
                }
            );
            context.SaveChanges();

            // 7. REZERVASYONLAR
            context.Reservations.AddOrUpdate(
                r => new { r.MemberId, r.BookId },
                new Reservation
                {
                    MemberId = aliYilmaz.MemberId,
                    BookId = kurkMantolu.BookId,
                    ReservationDate = referenceDate.AddDays(-2),
                    ExpiryDate = referenceDate.AddDays(5),
                    Status = "Aktif",
                    NotificationSent = false
                },
                new Reservation
                {
                    MemberId = ayseKaya.MemberId,
                    BookId = dokuzYuz.BookId,
                    ReservationDate = referenceDate.AddDays(-1),
                    ExpiryDate = referenceDate.AddDays(6),
                    Status = "Aktif",
                    NotificationSent = false
                }
            );
            context.SaveChanges();
        }

        // Helper function to ensure DateTime is within SQL Server datetime range (1753-01-01 to 9999-12-31)
        private DateTime RoundToSqlDateTime(DateTime dateTime)
        {
            // SQL Server datetime range
            DateTime minDate = new DateTime(1753, 1, 1);
            DateTime maxDate = new DateTime(9999, 12, 31);

            // Ensure date is within valid range
            if (dateTime < minDate) dateTime = minDate;
            if (dateTime > maxDate) dateTime = maxDate;

            // Remove milliseconds and ensure seconds are 0
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 
                               dateTime.Hour, dateTime.Minute, 0);
        }
    }
}