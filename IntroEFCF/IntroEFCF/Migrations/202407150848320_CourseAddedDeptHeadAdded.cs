namespace IntroEFCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAddedDeptHeadAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CrHr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Departments", "DeptHead", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "DeptHead");
            DropTable("dbo.Courses");
        }
    }
}
