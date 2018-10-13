namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workflowV : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WorkflowFormViewModels", newName: "WorkflowVs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.WorkflowVs", newName: "WorkflowFormViewModels");
        }
    }
}
