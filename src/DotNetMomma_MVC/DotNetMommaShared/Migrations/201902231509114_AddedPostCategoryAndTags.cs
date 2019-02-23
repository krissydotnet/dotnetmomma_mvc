namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostCategoryAndTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostTechnologies", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostTechnologies", "TechnologyId", "dbo.Technologies");
            DropIndex("dbo.PostTechnologies", new[] { "PostId" });
            DropIndex("dbo.PostTechnologies", new[] { "TechnologyId" });
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        PostCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostCategories", t => t.PostCategory_Id)
                .Index(t => t.PostCategory_Id);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "PostCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "PostCategoryId");
            AddForeignKey("dbo.Posts", "PostCategoryId", "dbo.PostCategories", "Id", cascadeDelete: true);
            DropColumn("dbo.Posts", "Category");
            DropTable("dbo.PostTechnologies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostTechnologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "Category", c => c.String());
            DropForeignKey("dbo.PostTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PostCategoryId", "dbo.PostCategories");
            DropForeignKey("dbo.PostCategories", "PostCategory_Id", "dbo.PostCategories");
            DropIndex("dbo.PostTags", new[] { "TagId" });
            DropIndex("dbo.PostTags", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "PostCategoryId" });
            DropIndex("dbo.PostCategories", new[] { "PostCategory_Id" });
            DropColumn("dbo.Posts", "PostCategoryId");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.PostCategories");
            CreateIndex("dbo.PostTechnologies", "TechnologyId");
            CreateIndex("dbo.PostTechnologies", "PostId");
            AddForeignKey("dbo.PostTechnologies", "TechnologyId", "dbo.Technologies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostTechnologies", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
