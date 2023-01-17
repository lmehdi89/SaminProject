namespace SaminProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseInformations", "Telegram", c => c.String(maxLength: 100));
            AddColumn("dbo.BaseInformations", "Instagram", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaseInformations", "Instagram");
            DropColumn("dbo.BaseInformations", "Telegram");
        }
    }
}
