namespace IntroEFCF2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringVarChar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
