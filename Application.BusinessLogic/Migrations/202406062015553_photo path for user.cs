namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photopathforuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UDbTables", "PhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UDbTables", "PhotoPath");
        }
    }
}
