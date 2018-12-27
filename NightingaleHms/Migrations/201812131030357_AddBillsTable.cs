namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Bills",
                    c => new
                    {
                        BillId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        IsCardPayment = c.Boolean(nullable: false),
                        CardNumber = c.String(maxLength: 19),
                    })
                .PrimaryKey(t => t.BillId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Bills");
        }
    }
}
