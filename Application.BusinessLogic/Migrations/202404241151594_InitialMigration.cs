namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CVDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Skills = c.String(),
                        Experience = c.String(),
                        Additional = c.String(),
                        Educations = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        LastLogin = c.DateTime(nullable: false),
                        LastIp = c.String(maxLength: 30),
                        Role = c.Int(nullable: false),
                        CvId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CVDbTables", t => t.CvId, cascadeDelete: true)
                .Index(t => t.CvId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UDbTables", "CvId", "dbo.CVDbTables");
            DropIndex("dbo.UDbTables", new[] { "CvId" });
            DropTable("dbo.UDbTables");
            DropTable("dbo.CVDbTables");
        }
    }
}
