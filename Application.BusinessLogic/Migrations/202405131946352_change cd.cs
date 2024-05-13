namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CVDbTables", "Summary", c => c.String());
            DropColumn("dbo.CVDbTables", "Additional");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CVDbTables", "Additional", c => c.String());
            DropColumn("dbo.CVDbTables", "Summary");
        }
    }
}
