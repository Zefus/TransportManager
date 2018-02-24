namespace TransportManager.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(unicode: false),
                        InspectionDate = c.DateTime(nullable: false, precision: 0),
                        IsHaveWheelChair = c.Boolean(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Driver_Id = c.Int(),
                        Route_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Driver", t => t.Driver_Id)
                .ForeignKey("dbo.Route", t => t.Route_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Route_Id);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(unicode: false),
                        Shift = c.String(unicode: false),
                        FirstName = c.String(nullable: false, unicode: false),
                        MiddleName = c.String(unicode: false),
                        LastName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(unicode: false),
                        Spread = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartTimeA = c.DateTime(nullable: false, precision: 0),
                        StartTimeB = c.DateTime(nullable: false, precision: 0),
                        EndTimeA = c.DateTime(nullable: false, precision: 0),
                        EndTimeB = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Number = c.String(unicode: false),
                        Status = c.Byte(nullable: false),
                        Type = c.Byte(nullable: false),
                        ActionType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Number = c.String(unicode: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Gender = c.Byte(nullable: false),
                        Phone = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        LastVisit = c.DateTime(nullable: false, precision: 0),
                        FirstName = c.String(nullable: false, unicode: false),
                        MiddleName = c.String(unicode: false),
                        LastName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bus", "Route_Id", "dbo.Route");
            DropForeignKey("dbo.Bus", "Driver_Id", "dbo.Driver");
            DropIndex("dbo.Bus", new[] { "Route_Id" });
            DropIndex("dbo.Bus", new[] { "Driver_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Transact");
            DropTable("dbo.Card");
            DropTable("dbo.Route");
            DropTable("dbo.Driver");
            DropTable("dbo.Bus");
        }
    }
}
