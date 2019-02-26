namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutUrlSlugInPostCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "UrlSlug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "UrlSlug");
        }
    }
}
