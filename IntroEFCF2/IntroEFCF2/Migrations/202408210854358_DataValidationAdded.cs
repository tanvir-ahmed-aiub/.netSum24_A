namespace IntroEFCF2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataValidationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
