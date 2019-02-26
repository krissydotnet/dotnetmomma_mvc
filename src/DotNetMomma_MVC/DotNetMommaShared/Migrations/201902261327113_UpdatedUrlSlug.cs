namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUrlSlug : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tags", "UrlSlug");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "UrlSlug", c => c.String());
        }
    }
}
