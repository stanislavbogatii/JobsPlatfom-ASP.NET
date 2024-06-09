namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolestring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UDbTables", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UDbTables", "Role", c => c.Int(nullable: false));
        }
    }
}
