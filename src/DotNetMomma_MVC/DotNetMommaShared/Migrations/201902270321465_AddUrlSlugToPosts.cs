namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlSlugToPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UrlSlug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "UrlSlug");
        }
    }
}
