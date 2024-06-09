namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbacksinterviewmdoels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UDbTables", "JobDbTable_Id", "dbo.Jobs");
            DropIndex("dbo.UDbTables", new[] { "JobDbTable_Id" });
            CreateTable(
                "dbo.JobFeedbackDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        JobDbTable_Id = c.Int(),
                        UDbTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobDbTable_Id)
                .ForeignKey("dbo.UDbTables", t => t.UDbTable_Id)
                .Index(t => t.JobDbTable_Id)
                .Index(t => t.UDbTable_Id);
            
            CreateTable(
                "dbo.InterviewDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        location = c.String(),
                        date = c.String(),
                        time = c.String(),
                        message = c.String(),
                        JobDbTable_Id = c.Int(),
                        UDbTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobDbTable_Id)
                .ForeignKey("dbo.UDbTables", t => t.UDbTable_Id)
                .Index(t => t.JobDbTable_Id)
                .Index(t => t.UDbTable_Id);
            
            DropColumn("dbo.UDbTables", "JobDbTable_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UDbTables", "JobDbTable_Id", c => c.Int());
            DropForeignKey("dbo.InterviewDbTables", "UDbTable_Id", "dbo.UDbTables");
            DropForeignKey("dbo.JobFeedbackDbTables", "UDbTable_Id", "dbo.UDbTables");
            DropForeignKey("dbo.InterviewDbTables", "JobDbTable_Id", "dbo.Jobs");
            DropForeignKey("dbo.JobFeedbackDbTables", "JobDbTable_Id", "dbo.Jobs");
            DropIndex("dbo.InterviewDbTables", new[] { "UDbTable_Id" });
            DropIndex("dbo.InterviewDbTables", new[] { "JobDbTable_Id" });
            DropIndex("dbo.JobFeedbackDbTables", new[] { "UDbTable_Id" });
            DropIndex("dbo.JobFeedbackDbTables", new[] { "JobDbTable_Id" });
            DropTable("dbo.InterviewDbTables");
            DropTable("dbo.JobFeedbackDbTables");
            CreateIndex("dbo.UDbTables", "JobDbTable_Id");
            AddForeignKey("dbo.UDbTables", "JobDbTable_Id", "dbo.Jobs", "Id");
        }
    }
}
