namespace GFClaim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProviderTypeClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProviderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProviderTypes");
        }
    }
}
