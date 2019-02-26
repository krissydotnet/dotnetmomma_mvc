namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedUrlSlugInPostCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PostCategories", "UrlSlug");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostCategories", "UrlSlug", c => c.String());
        }
    }
}
