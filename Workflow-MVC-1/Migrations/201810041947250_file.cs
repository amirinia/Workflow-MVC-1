namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class file : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Workflows", t => t.Workflow_Id)
                .Index(t => t.Workflow_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Workflow_Id", "dbo.Workflows");
            DropIndex("dbo.Files", new[] { "Workflow_Id" });
            DropTable("dbo.Files");
        }
    }
}
