namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSexesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        SexId = c.Byte(nullable: false,identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.SexId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sexes");
        }
    }
}
