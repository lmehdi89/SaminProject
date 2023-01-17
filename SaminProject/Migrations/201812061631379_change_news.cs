namespace SaminProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_news : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Description", c => c.String());
            AddColumn("dbo.News", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Status");
            DropColumn("dbo.News", "Description");
        }
    }
}
