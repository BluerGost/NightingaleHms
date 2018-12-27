namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Phone = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(maxLength: 300),
                        SexId = c.Byte(nullable: false),
                        BloodTypeId = c.Byte(),
                        StateId = c.Int(),
                        PlanId = c.Int(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.BloodTypes", t => t.BloodTypeId)
                .ForeignKey("dbo.Plans", t => t.PlanId)
                .ForeignKey("dbo.Sexes", t => t.SexId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.SexId)
                .Index(t => t.BloodTypeId)
                .Index(t => t.StateId)
                .Index(t => t.PlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "StateId", "dbo.States");
            DropForeignKey("dbo.Patients", "SexId", "dbo.Sexes");
            DropForeignKey("dbo.Patients", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.Patients", "BloodTypeId", "dbo.BloodTypes");
            DropIndex("dbo.Patients", new[] { "PlanId" });
            DropIndex("dbo.Patients", new[] { "StateId" });
            DropIndex("dbo.Patients", new[] { "BloodTypeId" });
            DropIndex("dbo.Patients", new[] { "SexId" });
            DropTable("dbo.Patients");
        }
    }
}
