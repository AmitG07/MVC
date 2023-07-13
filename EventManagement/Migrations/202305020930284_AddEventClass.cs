namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "User_Id", c => c.Int());
            AlterColumn("dbo.EventModels", "UserId", c => c.String());
            CreateIndex("dbo.EventModels", "User_Id");
            AddForeignKey("dbo.EventModels", "User_Id", "dbo.UserModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventModels", "User_Id", "dbo.UserModels");
            DropIndex("dbo.EventModels", new[] { "User_Id" });
            AlterColumn("dbo.EventModels", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.EventModels", "User_Id");
        }
    }
}
