namespace AdminPanelCore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bismillah : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        SubCategoryID = c.Int(),
                        CategoryTypeID = c.Int(nullable: false),
                        IsHomePage = c.Boolean(nullable: false),
                        SeoLink = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        MetaDescription = c.String(),
                        MetaKeywords = c.String(),
                        CreatedUserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUserID = c.Int(),
                        ModifiedDate = c.DateTime(),
                        DisplayOrder = c.Int(nullable: false),
                        IsDisplay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryTypes", t => t.CategoryTypeID)
                .Index(t => t.CategoryTypeID);
            
            CreateTable(
                "dbo.CategoryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryTypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        CreatedUserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUserID = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        RoleID = c.Int(nullable: false),
                        CreatedUserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUserID = c.Int(),
                        ModifiedDate = c.DateTime(),
                        DisplayOrder = c.Int(nullable: false),
                        IsDisplay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SliderTitle = c.String(nullable: false),
                        SliderDescription = c.String(nullable: false),
                        SliderNewsUrl = c.String(nullable: false),
                        SliderImageUrlLarge = c.String(),
                        SliderImageUrlSmall = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedUserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUserID = c.Int(),
                        ModifiedDate = c.DateTime(),
                        DisplayOrder = c.Int(nullable: false),
                        IsDisplay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Categories", "CategoryTypeID", "dbo.CategoryTypes");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.Categories", new[] { "CategoryTypeID" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.CategoryTypes");
            DropTable("dbo.Categories");
        }
    }
}
