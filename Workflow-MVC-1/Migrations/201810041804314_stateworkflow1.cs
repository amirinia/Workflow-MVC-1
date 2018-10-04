namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stateworkflow1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workflows", "MyState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workflows", "MyState");
        }
    }
}
