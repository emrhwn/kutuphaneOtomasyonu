namespace WindowsFormsApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kitaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(nullable: false, maxLength: 20),
                        Baslik = c.String(nullable: false, maxLength: 100),
                        Yazar = c.String(nullable: false, maxLength: 50),
                        Yil = c.Int(nullable: false),
                        Durum = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kitaps");
        }
    }
}
