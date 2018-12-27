namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingIdColumnInStateTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.States", "Id", "StateId");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.States", "StateId", "Id");
        }
    }
}
