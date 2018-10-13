namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datevm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkflowVs", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkflowVs", "Date", c => c.String());
        }
    }
}
