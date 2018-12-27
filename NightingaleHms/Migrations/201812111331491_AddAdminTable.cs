namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
