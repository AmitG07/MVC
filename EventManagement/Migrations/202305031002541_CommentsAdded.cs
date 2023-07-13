namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentAdded = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommentModels");
        }
    }
}
