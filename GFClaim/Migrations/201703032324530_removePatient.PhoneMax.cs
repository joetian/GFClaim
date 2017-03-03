namespace GFClaim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePatientPhoneMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Phone", c => c.String(maxLength: 10));
        }
    }
}
