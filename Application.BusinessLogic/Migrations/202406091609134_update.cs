namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplicationsDbTables", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.JobApplicationsDbTables", "jobId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplicationsDbTables", "jobId");
            DropColumn("dbo.JobApplicationsDbTables", "userId");
        }
    }
}
