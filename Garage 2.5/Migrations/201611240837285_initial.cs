namespace Garage_2._5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        PNR = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PNR);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        RegNr = c.String(),
                        Color = c.String(),
                        PNR = c.String(maxLength: 128),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Owners", t => t.PNR)
                .ForeignKey("dbo.VehicleTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.PNR)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "TypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "PNR", "dbo.Owners");
            DropIndex("dbo.Vehicles", new[] { "TypeId" });
            DropIndex("dbo.Vehicles", new[] { "PNR" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Owners");
        }
    }
}
