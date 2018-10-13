namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class targetusers2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workflows", "TargetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Workflows", new[] { "TargetUser_Id" });
            DropColumn("dbo.Workflows", "TargetUserId");
            RenameColumn(table: "dbo.Workflows", name: "TargetUser_Id", newName: "TargetUserId");
            AlterColumn("dbo.Workflows", "TargetUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Workflows", "TargetUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Workflows", "TargetUserId");
            AddForeignKey("dbo.Workflows", "TargetUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workflows", "TargetUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Workflows", new[] { "TargetUserId" });
            AlterColumn("dbo.Workflows", "TargetUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Workflows", "TargetUserId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Workflows", name: "TargetUserId", newName: "TargetUser_Id");
            AddColumn("dbo.Workflows", "TargetUserId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Workflows", "TargetUser_Id");
            AddForeignKey("dbo.Workflows", "TargetUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
