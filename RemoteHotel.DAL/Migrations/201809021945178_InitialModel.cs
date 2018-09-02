namespace RemoteHotel.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerRoom",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        RoomKey = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.RoomId })
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RoomId);
            
            AddColumn("dbo.Customer", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Room", "CurrentHotelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Hotel", "HotelName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Room", "CurrentHotelId");
            AddForeignKey("dbo.Room", "CurrentHotelId", "dbo.Hotel", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerRoom", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Room", "CurrentHotelId", "dbo.Hotel");
            DropForeignKey("dbo.CustomerRoom", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Room", new[] { "CurrentHotelId" });
            DropIndex("dbo.CustomerRoom", new[] { "RoomId" });
            DropIndex("dbo.CustomerRoom", new[] { "CustomerId" });
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Login", c => c.String());
            AlterColumn("dbo.Hotel", "HotelName", c => c.String());
            DropColumn("dbo.Room", "CurrentHotelId");
            DropColumn("dbo.Customer", "CreatedDate");
            DropTable("dbo.CustomerRoom");
        }
    }
}
