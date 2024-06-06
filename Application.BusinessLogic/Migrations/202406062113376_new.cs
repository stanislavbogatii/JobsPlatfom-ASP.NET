namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplicationsDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobDbTable_Id = c.Int(),
                        UDbTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobDbTable_Id)
                .ForeignKey("dbo.UDbTables", t => t.UDbTable_Id)
                .Index(t => t.JobDbTable_Id)
                .Index(t => t.UDbTable_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplicationsDbTables", "UDbTable_Id", "dbo.UDbTables");
            DropForeignKey("dbo.JobApplicationsDbTables", "JobDbTable_Id", "dbo.Jobs");
            DropIndex("dbo.JobApplicationsDbTables", new[] { "UDbTable_Id" });
            DropIndex("dbo.JobApplicationsDbTables", new[] { "JobDbTable_Id" });
            DropTable("dbo.JobApplicationsDbTables");
        }
    }
}
