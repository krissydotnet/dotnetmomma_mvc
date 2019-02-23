namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        Description = c.String(),
                        SectionId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResourceTechnologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId, cascadeDelete: true)
                .Index(t => t.ResourceId)
                .Index(t => t.TechnologyId);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Meta = c.String(),
                        UrlSlug = c.String(),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostTechnologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TechnologyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTechnologies", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.PostTechnologies", "PostId", "dbo.Posts");
            DropForeignKey("dbo.ResourceTechnologies", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.ResourceTechnologies", "ResourceId", "dbo.Resources");
            DropForeignKey("dbo.Resources", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Resources", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PostTechnologies", new[] { "TechnologyId" });
            DropIndex("dbo.PostTechnologies", new[] { "PostId" });
            DropIndex("dbo.ResourceTechnologies", new[] { "TechnologyId" });
            DropIndex("dbo.ResourceTechnologies", new[] { "ResourceId" });
            DropIndex("dbo.Resources", new[] { "CategoryId" });
            DropIndex("dbo.Resources", new[] { "SectionId" });
            DropTable("dbo.PostTechnologies");
            DropTable("dbo.Posts");
            DropTable("dbo.Technologies");
            DropTable("dbo.ResourceTechnologies");
            DropTable("dbo.Sections");
            DropTable("dbo.Resources");
            DropTable("dbo.Categories");
        }
    }
}
