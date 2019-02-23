namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Location", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String());
            DropColumn("dbo.Posts", "Location");
        }
    }
}
