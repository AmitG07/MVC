namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentREsolves : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "CommentAdded", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventModels", "CommentAdded");
        }
    }
}
