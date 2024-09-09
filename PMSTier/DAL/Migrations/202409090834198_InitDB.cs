namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.PId, cascadeDelete: true)
                .Index(t => t.PId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "PId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
