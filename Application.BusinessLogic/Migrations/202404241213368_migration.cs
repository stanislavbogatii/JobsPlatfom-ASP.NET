namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UDbTables", "CvId", "dbo.CVDbTables");
            DropIndex("dbo.UDbTables", new[] { "CvId" });
            AlterColumn("dbo.UDbTables", "CvId", c => c.Int());
            CreateIndex("dbo.UDbTables", "CvId");
            AddForeignKey("dbo.UDbTables", "CvId", "dbo.CVDbTables", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UDbTables", "CvId", "dbo.CVDbTables");
            DropIndex("dbo.UDbTables", new[] { "CvId" });
            AlterColumn("dbo.UDbTables", "CvId", c => c.Int(nullable: false));
            CreateIndex("dbo.UDbTables", "CvId");
            AddForeignKey("dbo.UDbTables", "CvId", "dbo.CVDbTables", "Id", cascadeDelete: true);
        }
    }
}
