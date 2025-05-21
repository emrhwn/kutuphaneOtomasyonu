namespace kutupHaneOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Biography = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        AuthorId = c.Int(nullable: false),
                        Category = c.String(maxLength: 100),
                        ISBN = c.String(maxLength: 20),
                        Publisher = c.String(maxLength: 100),
                        PublicationYear = c.Int(nullable: false),
                        TotalCopies = c.Int(nullable: false),
                        AvailableCopies = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        LoanDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        FineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        Address = c.String(),
                        MembershipDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false),
                        Role = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Reservations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Reservations", "BookId", "dbo.Books");
            DropForeignKey("dbo.Loans", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Reservations", new[] { "MemberId" });
            DropIndex("dbo.Reservations", new[] { "BookId" });
            DropIndex("dbo.Loans", new[] { "MemberId" });
            DropIndex("dbo.Loans", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Members");
            DropTable("dbo.Loans");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
