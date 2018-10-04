namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Workflows", name: "TargetUser_Id", newName: "TargetUser1_Id");
            RenameIndex(table: "dbo.Workflows", name: "IX_TargetUser_Id", newName: "IX_TargetUser1_Id");
            AddColumn("dbo.AspNetUsers", "Workflow_Id", c => c.Int());
            AddColumn("dbo.Workflows", "OwnerUser", c => c.String());
            AddColumn("dbo.Workflows", "TargetUser", c => c.String(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Workflow_Id");
            AddForeignKey("dbo.AspNetUsers", "Workflow_Id", "dbo.Workflows", "Id");
            DropColumn("dbo.Workflows", "UserId");
            DropColumn("dbo.Workflows", "UserId2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workflows", "UserId2", c => c.String());
            AddColumn("dbo.Workflows", "UserId", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "Workflow_Id", "dbo.Workflows");
            DropIndex("dbo.AspNetUsers", new[] { "Workflow_Id" });
            DropColumn("dbo.Workflows", "TargetUser");
            DropColumn("dbo.Workflows", "OwnerUser");
            DropColumn("dbo.AspNetUsers", "Workflow_Id");
            RenameIndex(table: "dbo.Workflows", name: "IX_TargetUser1_Id", newName: "IX_TargetUser_Id");
            RenameColumn(table: "dbo.Workflows", name: "TargetUser1_Id", newName: "TargetUser_Id");
        }
    }
}
