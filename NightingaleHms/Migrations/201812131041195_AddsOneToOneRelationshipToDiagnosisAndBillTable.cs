namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsOneToOneRelationshipToDiagnosisAndBillTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Bills");
            AlterColumn("dbo.Bills", "BillId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Bills", "BillId");
            CreateIndex("dbo.Bills", "BillId");
            AddForeignKey("dbo.Bills", "BillId", "dbo.Diagnosis", "DiagnosisId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "BillId", "dbo.Diagnosis");
            DropIndex("dbo.Bills", new[] { "BillId" });
            DropPrimaryKey("dbo.Bills");
            AlterColumn("dbo.Bills", "BillId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Bills", "BillId");
        }
    }
}
