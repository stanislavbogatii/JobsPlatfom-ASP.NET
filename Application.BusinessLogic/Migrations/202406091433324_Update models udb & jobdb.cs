namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatemodelsudbjobdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobFeedbackDbTables", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.JobFeedbackDbTables", "jobId", c => c.Int(nullable: false));
            AddColumn("dbo.InterviewDbTables", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.InterviewDbTables", "jobId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InterviewDbTables", "jobId");
            DropColumn("dbo.InterviewDbTables", "userId");
            DropColumn("dbo.JobFeedbackDbTables", "jobId");
            DropColumn("dbo.JobFeedbackDbTables", "userId");
        }
    }
}
