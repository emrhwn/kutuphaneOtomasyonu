namespace kutupHaneOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberIdToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MemberId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "MemberId");
        }
    }
}
