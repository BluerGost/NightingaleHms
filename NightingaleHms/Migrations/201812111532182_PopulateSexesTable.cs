namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSexesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sexes(Name) VALUES ('Male')");
            Sql("INSERT INTO Sexes(Name) VALUES ('Female')");
            Sql("INSERT INTO Sexes(Name) VALUES ('Other')");
        }
        
        public override void Down()
        {
        }
    }
}
