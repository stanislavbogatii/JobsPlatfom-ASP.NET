namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CV_updaasdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        CVDbTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CVDbTables", t => t.CVDbTable_Id)
                .Index(t => t.CVDbTable_Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        CVDbTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CVDbTables", t => t.CVDbTable_Id)
                .Index(t => t.CVDbTable_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CVDbTable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CVDbTables", t => t.CVDbTable_Id)
                .Index(t => t.CVDbTable_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "CVDbTable_Id", "dbo.CVDbTables");
            DropForeignKey("dbo.Experiences", "CVDbTable_Id", "dbo.CVDbTables");
            DropForeignKey("dbo.Educations", "CVDbTable_Id", "dbo.CVDbTables");
            DropIndex("dbo.Skills", new[] { "CVDbTable_Id" });
            DropIndex("dbo.Experiences", new[] { "CVDbTable_Id" });
            DropIndex("dbo.Educations", new[] { "CVDbTable_Id" });
            DropTable("dbo.Skills");
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
        }
    }
}
