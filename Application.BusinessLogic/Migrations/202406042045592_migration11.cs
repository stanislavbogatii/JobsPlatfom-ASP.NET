namespace Application.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Vacancy = c.String(nullable: false),
                        WorkMode = c.Int(nullable: false),
                        Summary = c.String(),
                        MinExp = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UDbTables", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            AddColumn("dbo.UDbTables", "JobDbTable_Id", c => c.Int());
            CreateIndex("dbo.UDbTables", "JobDbTable_Id");
            AddForeignKey("dbo.UDbTables", "JobDbTable_Id", "dbo.Jobs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "OwnerId", "dbo.UDbTables");
            DropForeignKey("dbo.UDbTables", "JobDbTable_Id", "dbo.Jobs");
            DropIndex("dbo.UDbTables", new[] { "JobDbTable_Id" });
            DropIndex("dbo.Jobs", new[] { "OwnerId" });
            DropColumn("dbo.UDbTables", "JobDbTable_Id");
            DropTable("dbo.Jobs");
        }
    }
}
