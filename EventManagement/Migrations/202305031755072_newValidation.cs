namespace EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserModels", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.UserModels", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserModels", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserModels", "password", c => c.String());
            AlterColumn("dbo.UserModels", "Email", c => c.String());
            AlterColumn("dbo.UserModels", "FullName", c => c.String());
        }
    }
}
