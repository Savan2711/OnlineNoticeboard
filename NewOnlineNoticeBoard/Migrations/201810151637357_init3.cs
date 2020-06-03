namespace NewOnlineNoticeBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CE_Notice", "TitleOfNotice", c => c.String());
            AddColumn("dbo.CH_Notice", "TitleOfNotice", c => c.String());
            AddColumn("dbo.EC_Notice", "TitleOfNotice", c => c.String());
            AddColumn("dbo.IC_Notice", "TitleOfNotice", c => c.String());
            AddColumn("dbo.IT_Notice", "TitleOfNotice", c => c.String());
            AddColumn("dbo.MH_Notice", "TitleOfNotice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MH_Notice", "TitleOfNotice");
            DropColumn("dbo.IT_Notice", "TitleOfNotice");
            DropColumn("dbo.IC_Notice", "TitleOfNotice");
            DropColumn("dbo.EC_Notice", "TitleOfNotice");
            DropColumn("dbo.CH_Notice", "TitleOfNotice");
            DropColumn("dbo.CE_Notice", "TitleOfNotice");
        }
    }
}
