namespace GFClaim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProviderProviderTypeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "ProviderTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Providers", "ProviderTypeId");
            AddForeignKey("dbo.Providers", "ProviderTypeId", "dbo.ProviderTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Providers", "ProviderTypeId", "dbo.ProviderTypes");
            DropIndex("dbo.Providers", new[] { "ProviderTypeId" });
            DropColumn("dbo.Providers", "ProviderTypeId");
        }
    }
}
