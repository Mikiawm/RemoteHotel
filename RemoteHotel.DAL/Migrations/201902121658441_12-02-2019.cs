namespace RemoteHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12022019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservation", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Reservation", "Accepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservation", "Accepted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Reservation", "Status");
        }
    }
}
