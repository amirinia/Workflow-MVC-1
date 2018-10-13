namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class targetusers1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Workflows", name: "TargetUser1_Id", newName: "TargetUser_Id");
            RenameIndex(table: "dbo.Workflows", name: "IX_TargetUser1_Id", newName: "IX_TargetUser_Id");
            AddColumn("dbo.Workflows", "TargetUserId", c => c.Byte(nullable: false));
            DropColumn("dbo.Workflows", "TargetUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workflows", "TargetUser", c => c.String(nullable: false));
            DropColumn("dbo.Workflows", "TargetUserId");
            RenameIndex(table: "dbo.Workflows", name: "IX_TargetUser_Id", newName: "IX_TargetUser1_Id");
            RenameColumn(table: "dbo.Workflows", name: "TargetUser_Id", newName: "TargetUser1_Id");
        }
    }
}
