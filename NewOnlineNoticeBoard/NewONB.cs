namespace NewOnlineNoticeBoard
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewONB : DbContext
    {
        // Your context has been configured to use a 'NewONB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'NewOnlineNoticeBoard.NewONB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NewONB' 
        // connection string in the application configuration file.
        public NewONB()
            : base("name=NewONB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Models.NewAdmin> NewAdmins { get; set; }
        public virtual DbSet<Models.User> Users { get; set; }
        public virtual DbSet<Models.CE_Notice> CE_Notices { get; set; }
        public virtual DbSet<Models.IT_Notice> IT_Notices { get; set; }
        public virtual DbSet<Models.EC_Notice> EC_Notices { get; set; }
        public virtual DbSet<Models.IC_Notice> IC_Notices { get; set; }
        public virtual DbSet<Models.MH_Notice> MH_Notices { get; set; }
        public virtual DbSet<Models.CH_Notice> CH_Notices { get; set; }
        public virtual DbSet<Models.TypeOfNotice> TypeOfnotices { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}