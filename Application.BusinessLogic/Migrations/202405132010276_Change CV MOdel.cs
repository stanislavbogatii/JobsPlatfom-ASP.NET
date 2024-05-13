namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCVMOdel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CVDbTables", "Skills");
            DropColumn("dbo.CVDbTables", "Experience");
            DropColumn("dbo.CVDbTables", "Educations");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CVDbTables", "Educations", c => c.String());
            AddColumn("dbo.CVDbTables", "Experience", c => c.String());
            AddColumn("dbo.CVDbTables", "Skills", c => c.String());
        }
    }
}
