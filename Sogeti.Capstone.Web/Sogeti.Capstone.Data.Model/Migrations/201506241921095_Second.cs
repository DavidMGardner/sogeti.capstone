namespace Sogeti.Capstone.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "Registration_Id", "dbo.Registrations");
            DropForeignKey("dbo.Events", "Status_Id", "dbo.Status");
            DropIndex("dbo.Events", new[] { "Category_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropIndex("dbo.Events", new[] { "Registration_Id" });
            DropIndex("dbo.Events", new[] { "Status_Id" });
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.EventTypes");
            DropPrimaryKey("dbo.Registrations");
            DropPrimaryKey("dbo.Status");
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Events", "Category_Id", c => c.Int());
            AlterColumn("dbo.Events", "EventType_Id", c => c.Int());
            AlterColumn("dbo.Events", "Registration_Id", c => c.Int());
            AlterColumn("dbo.Events", "Status_Id", c => c.Int());
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EventTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Registrations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Status", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.EventTypes", "Id");
            AddPrimaryKey("dbo.Registrations", "Id");
            AddPrimaryKey("dbo.Status", "Id");
            CreateIndex("dbo.Events", "Category_Id");
            CreateIndex("dbo.Events", "EventType_Id");
            CreateIndex("dbo.Events", "Registration_Id");
            CreateIndex("dbo.Events", "Status_Id");
            AddForeignKey("dbo.Events", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id");
            AddForeignKey("dbo.Events", "Registration_Id", "dbo.Registrations", "Id");
            AddForeignKey("dbo.Events", "Status_Id", "dbo.Status", "Id");
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
            DropPrimaryKey("dbo.Status");
            DropPrimaryKey("dbo.Registrations");
            DropPrimaryKey("dbo.EventTypes");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Status", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Registrations", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EventTypes", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "Status_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "Registration_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "EventType_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "Category_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Status", "Id");
            AddPrimaryKey("dbo.Registrations", "Id");
            AddPrimaryKey("dbo.EventTypes", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Events", "Id");
            CreateIndex("dbo.Events", "Status_Id");
            CreateIndex("dbo.Events", "Registration_Id");
            CreateIndex("dbo.Events", "EventType_Id");
            CreateIndex("dbo.Events", "Category_Id");
            AddForeignKey("dbo.Events", "Status_Id", "dbo.Status", "Id");
            AddForeignKey("dbo.Events", "Registration_Id", "dbo.Registrations", "Id");
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id");
            AddForeignKey("dbo.Events", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
