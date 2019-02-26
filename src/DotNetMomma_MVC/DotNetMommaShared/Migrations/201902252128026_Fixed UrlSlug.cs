namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedUrlSlug : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Location");
            DropColumn("dbo.Posts", "UrlSlug");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UrlSlug", c => c.String());
            AddColumn("dbo.Posts", "Location", c => c.String());
        }
    }
}
