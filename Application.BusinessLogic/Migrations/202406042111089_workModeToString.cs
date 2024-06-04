namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workModeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "WorkMode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "WorkMode", c => c.Int(nullable: false));
        }
    }
}
