namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beforepic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workflows", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workflows", "ImageUrl");
        }
    }
}
