namespace NewOnlineNoticeBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CE_Notice",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeType = c.String(),
                        date = c.DateTime(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.NoticeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CE_Notice");
        }
    }
}
