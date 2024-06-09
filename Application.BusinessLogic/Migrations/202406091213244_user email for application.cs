namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useremailforapplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplicationsDbTables", "userEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplicationsDbTables", "userEmail");
        }
    }
}
