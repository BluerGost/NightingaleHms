namespace NightingaleHms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorAndEducationOneToManyRelationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        YearOfExperience = c.Byte(),
                        DepartmentId = c.Int(),
                        PlanId = c.Int(),
                        StateId = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Plans", t => t.PlanId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PlanId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false, maxLength: 255),
                        DegreeName = c.String(maxLength: 255),
                        FieldOfStudy = c.String(maxLength: 25),
                        Grade = c.Single(),
                        PassingYear = c.DateTime(),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.EducationId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "StateId", "dbo.States");
            DropForeignKey("dbo.Doctors", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.Educations", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Educations", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "StateId" });
            DropIndex("dbo.Doctors", new[] { "PlanId" });
            DropIndex("dbo.Doctors", new[] { "DepartmentId" });
            DropTable("dbo.Educations");
            DropTable("dbo.Doctors");
        }
    }
}
