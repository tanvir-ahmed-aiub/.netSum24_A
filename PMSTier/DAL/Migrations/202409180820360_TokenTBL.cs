namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        Uname = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Uname)
                .Index(t => t.Uname);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "Uname", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "Uname" });
            DropTable("dbo.Tokens");
        }
    }
}
