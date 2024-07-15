namespace IntroEFCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeptDataChnaged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String());
        }
    }
}
