namespace NewOnlineNoticeBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CH_Notice",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeType = c.String(),
                        date = c.DateTime(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.NoticeId);
            
            CreateTable(
                "dbo.EC_Notice",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeType = c.String(),
                        date = c.DateTime(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.NoticeId);
            
            CreateTable(
                "dbo.IC_Notice",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeType = c.String(),
                        date = c.DateTime(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.NoticeId);
            
            CreateTable(
                "dbo.IT_Notice",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeType = c.String(),
                        date = c.DateTime(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.NoticeId);
            
            CreateTable(
                "dbo.MH_Notice",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeType = c.String(),
                        date = c.DateTime(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.NoticeId);
            
            CreateTable(
                "dbo.TypeOfNotices",
                c => new
                    {
                        NoticeType = c.String(nullable: false, maxLength: 128),
                        Department = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.NoticeType, t.Department });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeOfNotices");
            DropTable("dbo.MH_Notice");
            DropTable("dbo.IT_Notice");
            DropTable("dbo.IC_Notice");
            DropTable("dbo.EC_Notice");
            DropTable("dbo.CH_Notice");
        }
    }
}
