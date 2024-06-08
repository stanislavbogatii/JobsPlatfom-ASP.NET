namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MsgtoApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplicationsDbTables", "message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplicationsDbTables", "message");
        }
    }
}
