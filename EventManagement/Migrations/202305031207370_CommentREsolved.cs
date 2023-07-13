namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentREsolved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentModels", "EventModel_EventID", "dbo.EventModels");
            DropIndex("dbo.CommentModels", new[] { "EventModel_EventID" });
            DropColumn("dbo.CommentModels", "EventModel_EventID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommentModels", "EventModel_EventID", c => c.Int());
            CreateIndex("dbo.CommentModels", "EventModel_EventID");
            AddForeignKey("dbo.CommentModels", "EventModel_EventID", "dbo.EventModels", "EventID");
        }
    }
}
