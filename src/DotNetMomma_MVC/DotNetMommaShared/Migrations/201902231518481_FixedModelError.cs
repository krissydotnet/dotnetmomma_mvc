namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedModelError : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostCategories", "PostCategory_Id", "dbo.PostCategories");
            DropIndex("dbo.PostCategories", new[] { "PostCategory_Id" });
            DropColumn("dbo.PostCategories", "PostCategory_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostCategories", "PostCategory_Id", c => c.Int());
            CreateIndex("dbo.PostCategories", "PostCategory_Id");
            AddForeignKey("dbo.PostCategories", "PostCategory_Id", "dbo.PostCategories", "Id");
        }
    }
}
