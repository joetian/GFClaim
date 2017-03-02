namespace GFClaim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProviderTypeData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[ProviderTypes] ([TypeName], [Desc]) VALUES ('Hospital', 'Hospital Facitlity')");
            Sql("INSERT INTO [dbo].[ProviderTypes] ([TypeName], [Desc]) VALUES ('Clinic', 'Clinic Facitlity')");
            Sql("INSERT INTO [dbo].[ProviderTypes] ([TypeName], [Desc]) VALUES ('Pharmacy', 'Pharmacy')");
            Sql("INSERT INTO [dbo].[ProviderTypes] ([TypeName], [Desc]) VALUES ('Dental', 'Dental')");
            Sql("INSERT INTO [dbo].[ProviderTypes] ([TypeName], [Desc]) VALUES ('Retailer', 'Retailer')");
            Sql("INSERT INTO [dbo].[ProviderTypes] ([TypeName], [Desc]) VALUES ('Other', 'Other')");
        }
        
        public override void Down()
        {
        }
    }
}
