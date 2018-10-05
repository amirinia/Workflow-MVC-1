namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class files : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Workflow_Id", "dbo.Workflows");
            DropIndex("dbo.Files", new[] { "Workflow_Id" });
            CreateTable(
                "dbo.DownloadFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        File = c.String(),
                        Size = c.Long(nullable: false),
                        Url = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Workflow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId);
            
            DropTable("dbo.FileModels");
            DropTable("dbo.DownloadFiles");
            CreateIndex("dbo.Files", "Workflow_Id");
            AddForeignKey("dbo.Files", "Workflow_Id", "dbo.Workflows", "Id");
        }
    }
}
