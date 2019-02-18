namespace RemoteHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16022019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "AccountType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "AccountType");
        }
    }
}
