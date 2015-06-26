namespace Sogeti.Capstone.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Registration_Id", "dbo.Registrations");
            DropIndex("dbo.Events", new[] { "Registration_Id" });
            AddColumn("dbo.Categories", "Title", c => c.String());
            AddColumn("dbo.EventTypes", "Title", c => c.String());
            AddColumn("dbo.Registrations", "Title", c => c.String());
            AddColumn("dbo.Registrations", "RegisterDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "Event_Id", c => c.Int());
            AddColumn("dbo.Registrations", "EventType_Id", c => c.Int());
            AddColumn("dbo.Status", "Title", c => c.String());
            CreateIndex("dbo.Registrations", "Event_Id");
            CreateIndex("dbo.Registrations", "EventType_Id");
            AddForeignKey("dbo.Registrations", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Registrations", "EventType_Id", "dbo.EventTypes", "Id");
            DropColumn("dbo.Events", "Registration_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Registration_Id", c => c.Int());
            DropForeignKey("dbo.Registrations", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Registrations", "Event_Id", "dbo.Events");
            DropIndex("dbo.Registrations", new[] { "EventType_Id" });
            DropIndex("dbo.Registrations", new[] { "Event_Id" });
            DropColumn("dbo.Status", "Title");
            DropColumn("dbo.Registrations", "EventType_Id");
            DropColumn("dbo.Registrations", "Event_Id");
            DropColumn("dbo.Registrations", "RegisterDateTime");
            DropColumn("dbo.Registrations", "Title");
            DropColumn("dbo.EventTypes", "Title");
            DropColumn("dbo.Categories", "Title");
            CreateIndex("dbo.Events", "Registration_Id");
            AddForeignKey("dbo.Events", "Registration_Id", "dbo.Registrations", "Id");
        }
    }
}
