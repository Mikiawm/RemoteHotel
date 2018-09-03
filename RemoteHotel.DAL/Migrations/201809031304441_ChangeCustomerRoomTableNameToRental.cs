namespace RemoteHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerRoomTableNameToRental : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerRoom", newName: "Rental");
            AddColumn("dbo.Rental", "CreateDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rental", "ExpiredDAteTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rental", "ExpiredDAteTime");
            DropColumn("dbo.Rental", "CreateDateTime");
            RenameTable(name: "dbo.Rental", newName: "CustomerRoom");
        }
    }
}
