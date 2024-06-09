namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleted_flagjob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "deleted");
        }
    }
}
