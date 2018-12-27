namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBloodTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodTypes",
                c => new
                    {
                        BloodTypeId = c.Byte(nullable: false,identity: true),
                        Name = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.BloodTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BloodTypes");
        }
    }
}
