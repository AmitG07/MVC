namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentChangess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentModels", "EventModel_EventID", c => c.Int());
            CreateIndex("dbo.CommentModels", "EventModel_EventID");
            AddForeignKey("dbo.CommentModels", "EventModel_EventID", "dbo.EventModels", "EventID");
            DropColumn("dbo.EventModels", "CommentAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventModels", "CommentAdded", c => c.String());
            DropForeignKey("dbo.CommentModels", "EventModel_EventID", "dbo.EventModels");
            DropIndex("dbo.CommentModels", new[] { "EventModel_EventID" });
            DropColumn("dbo.CommentModels", "EventModel_EventID");
        }
    }
}
