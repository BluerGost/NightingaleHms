namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiagnosisTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        Symptoms = c.String(nullable: false),
                        DiagnosisProvided = c.String(nullable: false),
                        DateOfDiagnosis = c.DateTime(nullable: false),
                        IsFollowUpRequired = c.Boolean(nullable: false),
                        DateOfFollowUp = c.DateTime(),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiagnosisId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: false)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: false)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diagnosis", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Diagnosis", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Diagnosis", new[] { "DoctorId" });
            DropIndex("dbo.Diagnosis", new[] { "PatientId" });
            DropTable("dbo.Diagnosis");
        }
    }
}
