namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addworkflowvm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkflowFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerUser = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        Name = c.String(),
                        Context = c.String(),
                        TargetUser = c.String(nullable: false),
                        ImageUrl = c.String(),
                        MyState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkflowFormViewModels");
        }
    }
}
