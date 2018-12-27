namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStatesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO States(Name) VALUES('Alabama')");
            Sql("INSERT INTO States(Name) VALUES('Alaska')");
            Sql("INSERT INTO States(Name) VALUES('Arizona')");
            Sql("INSERT INTO States(Name) VALUES('Arkansas')");
            Sql("INSERT INTO States(Name) VALUES('California')");
            Sql("INSERT INTO States(Name) VALUES('Colorado')");
            Sql("INSERT INTO States(Name) VALUES('Connecticut')");
            Sql("INSERT INTO States(Name) VALUES('Delaware')");
            Sql("INSERT INTO States(Name) VALUES('Georgia')");
        }
        
        public override void Down()
        {
        }
    }
}
