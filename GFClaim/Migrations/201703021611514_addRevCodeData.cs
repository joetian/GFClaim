namespace GFClaim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRevCodeData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[RevCodes]([Code],[Desc]) VALUES(110, 'Ambulance')");
            Sql("INSERT INTO [dbo].[RevCodes]([Code],[Desc]) VALUES(120, 'Clean')");
            Sql("INSERT INTO [dbo].[RevCodes]([Code],[Desc]) VALUES(130, 'Operation')");
            Sql("INSERT INTO [dbo].[RevCodes]([Code],[Desc]) VALUES(210, 'Nurse')");
            Sql("INSERT INTO [dbo].[RevCodes]([Code],[Desc]) VALUES(220, 'Exam')");
            
        }
        
        public override void Down()
        {
        }
    }
}
