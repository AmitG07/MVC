namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CommentModels", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommentModels", "EventId", c => c.Int(nullable: false));
        }
    }
}
