namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workflows", "TargetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Workflows", new[] { "TargetUser_Id" });
            AddColumn("dbo.Workflows", "UserId2", c => c.String());
            AlterColumn("dbo.Workflows", "TargetUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Workflows", "TargetUser_Id");
            AddForeignKey("dbo.Workflows", "TargetUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workflows", "TargetUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Workflows", new[] { "TargetUser_Id" });
            AlterColumn("dbo.Workflows", "TargetUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Workflows", "UserId2");
            CreateIndex("dbo.Workflows", "TargetUser_Id");
            AddForeignKey("dbo.Workflows", "TargetUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
