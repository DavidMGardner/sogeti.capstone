namespace Sogeti.Capstone.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "RegistrationTypes");
            RenameColumn(table: "dbo.Events", name: "Category_Id", newName: "RegistrationType_Id");
            RenameIndex(table: "dbo.Events", name: "IX_Category_Id", newName: "IX_RegistrationType_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_RegistrationType_Id", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Events", name: "RegistrationType_Id", newName: "Category_Id");
            RenameTable(name: "dbo.RegistrationTypes", newName: "Categories");
        }
    }
}
