namespace kutupHaneOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFineToLoan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "Fine", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loans", "Fine");
        }
    }
}
