namespace Workflow_MVC_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testtimesheet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Timesheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IP = c.String(),
                        StartDay = c.DateTime(nullable: false),
                        EndDay = c.DateTime(nullable: false),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timesheets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Timesheets", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Timesheets");
        }
    }
}
