namespace Sogeti.Capstone.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        LogoPath = c.String(),
                        LocationInformation = c.String(),
                        EventType_Id = c.Int(),
                        RegistrationType_Id = c.Int(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id)
                .ForeignKey("dbo.RegistrationTypes", t => t.RegistrationType_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.EventType_Id)
                .Index(t => t.RegistrationType_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        RegisterDateTime = c.DateTime(nullable: false),
                        Event_Id = c.Int(),
                        EventType_Id = c.Int(),
                        FoodType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id)
                .ForeignKey("dbo.FoodTypes", t => t.FoodType_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.EventType_Id)
                .Index(t => t.FoodType_Id);
            
            CreateTable(
                "dbo.FoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Events", "RegistrationType_Id", "dbo.RegistrationTypes");
            DropForeignKey("dbo.Registrations", "FoodType_Id", "dbo.FoodTypes");
            DropForeignKey("dbo.Registrations", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Registrations", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropIndex("dbo.Registrations", new[] { "FoodType_Id" });
            DropIndex("dbo.Registrations", new[] { "EventType_Id" });
            DropIndex("dbo.Registrations", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "Status_Id" });
            DropIndex("dbo.Events", new[] { "RegistrationType_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropTable("dbo.Status");
            DropTable("dbo.FoodTypes");
            DropTable("dbo.Registrations");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
            DropTable("dbo.RegistrationTypes");
        }
    }
}
