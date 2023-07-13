namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Duration = c.Int(),
                        Description = c.String(maxLength: 50),
                        OtherDetails = c.String(maxLength: 500),
                        InviteByEmail = c.String(),
                        Count = c.Int(nullable: false),
                        CommentAdded = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserModels");
            DropTable("dbo.EventModels");
        }
    }
}
