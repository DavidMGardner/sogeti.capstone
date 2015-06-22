namespace Sogeti.Capstone.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        LogoPath = c.String(),
                        LocationInformation = c.String(),
                        Category_Id = c.String(maxLength: 128),
                        EventType_Id = c.String(maxLength: 128),
                        Registration_Id = c.String(maxLength: 128),
                        Status_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id)
                .ForeignKey("dbo.Registrations", t => t.Registration_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.EventType_Id)
                .Index(t => t.Registration_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Events", "Registration_Id", "dbo.Registrations");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "Status_Id" });
            DropIndex("dbo.Events", new[] { "Registration_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropIndex("dbo.Events", new[] { "Category_Id" });
            DropTable("dbo.Status");
            DropTable("dbo.Registrations");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Categories");
            DropTable("dbo.Events");
        }
    }
}
