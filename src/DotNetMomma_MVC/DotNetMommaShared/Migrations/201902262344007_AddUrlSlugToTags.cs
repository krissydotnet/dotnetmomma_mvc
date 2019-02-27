namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlSlugToTags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "UrlSlug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "UrlSlug");
        }
    }
}
