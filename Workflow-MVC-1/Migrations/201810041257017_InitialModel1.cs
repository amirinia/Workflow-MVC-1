namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Workflows", name: "OwnerUser_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Workflows", name: "IX_OwnerUser_Id", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.Workflows", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workflows", "UserId");
            RenameIndex(table: "dbo.Workflows", name: "IX_ApplicationUser_Id", newName: "IX_OwnerUser_Id");
            RenameColumn(table: "dbo.Workflows", name: "ApplicationUser_Id", newName: "OwnerUser_Id");
        }
    }
}
