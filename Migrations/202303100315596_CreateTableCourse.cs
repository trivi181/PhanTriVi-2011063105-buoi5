namespace PhanTriVi_2011063105_buoi5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LectuerId = c.String(nullable: false, maxLength: 128),
                        Place = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        CategoryID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.LectuerId, cascadeDelete: true)
                .Index(t => t.LectuerId)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LectuerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropIndex("dbo.Courses", new[] { "LectuerId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
