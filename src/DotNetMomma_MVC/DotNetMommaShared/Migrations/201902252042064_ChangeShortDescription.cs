namespace DotNetMommaShared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeShortDescription : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "ShortDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ShortDescription", c => c.String());
        }
    }
}
