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
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Standard = c.Int(nullable: false),
                        Beds = c.Int(nullable: false),
                        CurrentHotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotel", t => t.CurrentHotelId, cascadeDelete: true)
                .Index(t => t.CurrentHotelId);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDateTime = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        OrderDateFrom = c.DateTime(nullable: false),
                        OrderDateTo = c.DateTime(nullable: false),
                        HotelId = c.Int(nullable: false),
                        OrderCost = c.Double(nullable: false),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        AccountType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerRoom", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Room", "CurrentHotelId", "dbo.Hotel");
            DropForeignKey("dbo.CustomerRoom", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Room", new[] { "CurrentHotelId" });
            DropIndex("dbo.CustomerRoom", new[] { "RoomId" });
            DropIndex("dbo.CustomerRoom", new[] { "CustomerId" });
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.Hotel");
            DropTable("dbo.Room");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerRoom");
        }
    }
}
