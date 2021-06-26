namespace FireStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sajjad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Accident",
                c => new
                    {
                        AccidentId = c.Int(nullable: false),
                        AccidentEventLocation = c.String(nullable: false),
                        AccidentDescrption = c.String(nullable: false),
                        AccidentTime = c.Time(nullable: false, precision: 0),
                        AccidentDate = c.DateTime(nullable: false, storeType: "date"),
                        AccidentReportUrl = c.String(),
                        AccidentWid = c.Int(nullable: false),
                        AccidentTypeId = c.Int(nullable: false),
                        AccidentZone = c.Int(nullable: false),
                        AccidentUserId = c.Int(nullable: false),
                        AccidentUsageId = c.Int(nullable: false),
                        AccidentTimeStartOperation = c.Time(nullable: false, precision: 0),
                        AccidentTimeEndOperation = c.Time(nullable: false, precision: 0),
                        AccidentTimeToClear = c.Time(precision: 0),
                        AccidentReporter = c.String(nullable: false, maxLength: 50),
                        AccidentReportReciver = c.Int(nullable: false),
                        AccidentReportType = c.Int(nullable: false),
                        AccidentSiteFloors = c.Int(),
                        AccidentBuildingType = c.String(maxLength: 50),
                        AccidentBuildingOwner = c.String(nullable: false, maxLength: 50),
                        AccidentBuildingTel = c.String(maxLength: 15, fixedLength: true),
                        AccidentBuildingTenant = c.String(maxLength: 50),
                        AccidentOtherType = c.String(),
                        AccidentPreliminaryMeasures = c.String(),
                        AccidentDescriptionOperation = c.String(),
                        AccidentDamageDescriptionO = c.String(),
                        AccidentDamageDescriptionL = c.String(),
                        AccidentReportProducer = c.Int(nullable: false),
                        AccidentOperationsCommander = c.Int(nullable: false),
                        DateAdd = c.DateTime(nullable: false),
                        AccidentOperationProblems = c.String(),
                        AccidentCause = c.Int(nullable: false),
                        Isdelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccidentId)
                .ForeignKey("dbo.tbl_Employee", t => t.AccidentReportReciver)
                .ForeignKey("dbo.tbl_Employee", t => t.AccidentReportProducer)
                .ForeignKey("dbo.tbl-User", t => t.AccidentUserId)
                .ForeignKey("dbo.tbl_AccidentType", t => t.AccidentTypeId)
                .ForeignKey("dbo.tbl_Cause", t => t.AccidentCause)
                .ForeignKey("dbo.tbl_Usage", t => t.AccidentUsageId)
                .ForeignKey("dbo.tbl_weather", t => t.AccidentWid)
                .Index(t => t.AccidentWid)
                .Index(t => t.AccidentTypeId)
                .Index(t => t.AccidentUserId)
                .Index(t => t.AccidentUsageId)
                .Index(t => t.AccidentReportReciver)
                .Index(t => t.AccidentReportProducer)
                .Index(t => t.AccidentCause);
            
            CreateTable(
                "dbo.tbl_AccidentEmplyoee",
                c => new
                    {
                        AEId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        AccidentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AEId)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeId)
                .ForeignKey("dbo.tbl_Accident", t => t.AccidentId)
                .Index(t => t.EmployeeId)
                .Index(t => t.AccidentId);
            
            CreateTable(
                "dbo.tbl_Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        EmployeeCode = c.String(nullable: false, maxLength: 50),
                        EmployeeName = c.String(nullable: false, maxLength: 30),
                        EmployeeLastName = c.String(nullable: false, maxLength: 30),
                        EmployeePhone = c.String(nullable: false, maxLength: 15, fixedLength: true),
                        EmployeeAdress = c.String(maxLength: 50),
                        EmployeePicUrl = c.String(),
                        StateId = c.Int(nullable: false),
                        EmployeeFName = c.String(maxLength: 50),
                        EmployeeMCode = c.String(nullable: false, maxLength: 50),
                        EmployeeBirthdate = c.DateTime(nullable: false, storeType: "date"),
                        EmployeeSex = c.Boolean(nullable: false),
                        EmployeeWork = c.String(nullable: false, maxLength: 50),
                        EmployeeDateRegistered = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.tbl_State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.tbl_Leave",
                c => new
                    {
                        LeaveID = c.Int(nullable: false),
                        EmployeeID1 = c.Int(nullable: false),
                        EmployeeID2 = c.Int(),
                        ShiftID = c.Int(nullable: false),
                        ShiftRegisterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveID)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeID1)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeID2)
                .Index(t => t.EmployeeID1)
                .Index(t => t.EmployeeID2);
            
            CreateTable(
                "dbo.tbl_ShiftRegisterEmployee",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ShiftRegisterID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Replace1 = c.Int(),
                        Replace2 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_ShiftRegister", t => t.ShiftRegisterID)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeID)
                .Index(t => t.ShiftRegisterID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.tbl_ShiftRegister",
                c => new
                    {
                        ShiftRegisterid = c.Int(nullable: false),
                        ShiftRegisterDec = c.String(nullable: false),
                        ShiftRegisterCommandor = c.Int(nullable: false),
                        ShiftRegisterTimeStart = c.Time(nullable: false, precision: 0),
                        ShiftRegisterTimeEnd = c.Time(nullable: false, precision: 0),
                        ShiftRegisterDateStart = c.DateTime(nullable: false, storeType: "date"),
                        ShiftRegisteridDateEnd = c.DateTime(nullable: false, storeType: "date"),
                        ShiftRegisterurl = c.String(),
                        ShiftRegisterShifId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftRegisterid)
                .ForeignKey("dbo.tbl_shift", t => t.ShiftRegisterShifId)
                .Index(t => t.ShiftRegisterShifId);
            
            CreateTable(
                "dbo.tbl_shift",
                c => new
                    {
                        ShiftId = c.Int(nullable: false),
                        ShiftName = c.String(nullable: false, maxLength: 50),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftId)
                .ForeignKey("dbo.tbl_State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.tbl_State",
                c => new
                    {
                        StateId = c.Int(nullable: false),
                        StateName = c.String(nullable: false, maxLength: 50),
                        StateAdress = c.String(nullable: false),
                        StateTel = c.String(nullable: false, maxLength: 20, fixedLength: true),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.tbl_AccidentStation",
                c => new
                    {
                        AccidentStationId = c.Int(nullable: false),
                        StationId = c.Int(nullable: false),
                        AccidentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccidentStationId)
                .ForeignKey("dbo.tbl_State", t => t.StationId)
                .ForeignKey("dbo.tbl_Accident", t => t.AccidentId)
                .Index(t => t.StationId)
                .Index(t => t.AccidentId);
            
            CreateTable(
                "dbo.tbl_Repair",
                c => new
                    {
                        RepairId = c.Int(nullable: false),
                        RepairDescription = c.String(),
                        RepairDate = c.DateTime(nullable: false, storeType: "date"),
                        RepairTitel = c.String(nullable: false, maxLength: 50),
                        MaterialId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepairId)
                .ForeignKey("dbo.tbl_Material", t => t.MaterialId)
                .ForeignKey("dbo.tbl_State", t => t.StateId)
                .Index(t => t.MaterialId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.tbl_Material",
                c => new
                    {
                        MaterialId = c.Int(nullable: false),
                        MaterialCode = c.String(maxLength: 15, fixedLength: true),
                        MaterialName = c.String(nullable: false, maxLength: 50),
                        MaterialPic = c.String(nullable: false),
                        MaterialType = c.String(nullable: false, maxLength: 20),
                        MaterialVahed = c.String(maxLength: 15, fixedLength: true),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.tbl_AccidentM",
                c => new
                    {
                        AccidentMid = c.Int(nullable: false),
                        AccidentId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        tedad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccidentMid)
                .ForeignKey("dbo.tbl_Material", t => t.MaterialId)
                .ForeignKey("dbo.tbl_Accident", t => t.AccidentId)
                .Index(t => t.AccidentId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.tbl-User",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserUserName = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        UserPassword = c.String(nullable: false, maxLength: 50),
                        EmployeeId = c.Int(nullable: false),
                        UserRole = c.String(nullable: false, maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.tbl_Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.tbl_Missives",
                c => new
                    {
                        MissiveId = c.Int(nullable: false),
                        MissiveTitel = c.String(nullable: false, maxLength: 50),
                        MissiveText = c.String(nullable: false),
                        MissiveFileUrl = c.String(),
                        MissiveDate = c.DateTime(nullable: false, storeType: "date"),
                        MissiveNumber = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        MissiveUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MissiveId)
                .ForeignKey("dbo.tbl-User", t => t.MissiveUserId)
                .Index(t => t.MissiveUserId);
            
            CreateTable(
                "dbo.tbl_AccidentInjured",
                c => new
                    {
                        AccidentInjuredid = c.Int(nullable: false),
                        AccidentId = c.Int(nullable: false),
                        InjuredId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccidentInjuredid)
                .ForeignKey("dbo.tbl_Injured", t => t.InjuredId)
                .ForeignKey("dbo.tbl_Accident", t => t.AccidentId)
                .Index(t => t.AccidentId)
                .Index(t => t.InjuredId);
            
            CreateTable(
                "dbo.tbl_Injured",
                c => new
                    {
                        InjuredID = c.Int(nullable: false),
                        InjuredName = c.String(nullable: false, maxLength: 50),
                        InjuredLastName = c.String(nullable: false, maxLength: 50),
                        InjuredSex = c.Boolean(nullable: false),
                        InjuredType = c.Boolean(nullable: false),
                        InjuredTypeinjury = c.Boolean(nullable: false),
                        InjuredDescription = c.String(nullable: false),
                        InjuredLocation = c.String(),
                    })
                .PrimaryKey(t => t.InjuredID);
            
            CreateTable(
                "dbo.tbl_AccidentO",
                c => new
                    {
                        AccidentOid = c.Int(nullable: false),
                        AccidentId = c.Int(nullable: false),
                        OrganizationsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccidentOid)
                .ForeignKey("dbo.tbl_Organizations", t => t.OrganizationsId)
                .ForeignKey("dbo.tbl_Accident", t => t.AccidentId)
                .Index(t => t.AccidentId)
                .Index(t => t.OrganizationsId);
            
            CreateTable(
                "dbo.tbl_Organizations",
                c => new
                    {
                        OrId = c.Int(nullable: false),
                        OrTel = c.String(nullable: false, maxLength: 50),
                        OrTitel = c.String(nullable: false, maxLength: 50),
                        OrAdress = c.String(),
                    })
                .PrimaryKey(t => t.OrId);
            
            CreateTable(
                "dbo.tbl_AccidentType",
                c => new
                    {
                        AccidentTypeId = c.Int(nullable: false),
                        AccidentTypeTitel = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AccidentTypeId);
            
            CreateTable(
                "dbo.tbl_Cause",
                c => new
                    {
                        CauseId = c.Int(nullable: false),
                        CauseTitel = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CauseId);
            
            CreateTable(
                "dbo.tbl_Usage",
                c => new
                    {
                        UsageId = c.Int(nullable: false),
                        UsageTitel = c.String(nullable: false, maxLength: 50),
                        UsageDescription = c.String(),
                    })
                .PrimaryKey(t => t.UsageId);
            
            CreateTable(
                "dbo.tbl_weather",
                c => new
                    {
                        WeatherId = c.Int(nullable: false),
                        WeatherTitel = c.String(maxLength: 50),
                        WeatherDec = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.WeatherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Accident", "AccidentWid", "dbo.tbl_weather");
            DropForeignKey("dbo.tbl_Accident", "AccidentUsageId", "dbo.tbl_Usage");
            DropForeignKey("dbo.tbl_Accident", "AccidentCause", "dbo.tbl_Cause");
            DropForeignKey("dbo.tbl_Accident", "AccidentTypeId", "dbo.tbl_AccidentType");
            DropForeignKey("dbo.tbl_AccidentStation", "AccidentId", "dbo.tbl_Accident");
            DropForeignKey("dbo.tbl_AccidentO", "AccidentId", "dbo.tbl_Accident");
            DropForeignKey("dbo.tbl_AccidentO", "OrganizationsId", "dbo.tbl_Organizations");
            DropForeignKey("dbo.tbl_AccidentM", "AccidentId", "dbo.tbl_Accident");
            DropForeignKey("dbo.tbl_AccidentInjured", "AccidentId", "dbo.tbl_Accident");
            DropForeignKey("dbo.tbl_AccidentInjured", "InjuredId", "dbo.tbl_Injured");
            DropForeignKey("dbo.tbl_AccidentEmplyoee", "AccidentId", "dbo.tbl_Accident");
            DropForeignKey("dbo.tbl-User", "EmployeeId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_Missives", "MissiveUserId", "dbo.tbl-User");
            DropForeignKey("dbo.tbl_Accident", "AccidentUserId", "dbo.tbl-User");
            DropForeignKey("dbo.tbl_ShiftRegisterEmployee", "EmployeeID", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_ShiftRegisterEmployee", "ShiftRegisterID", "dbo.tbl_ShiftRegister");
            DropForeignKey("dbo.tbl_shift", "StateId", "dbo.tbl_State");
            DropForeignKey("dbo.tbl_Repair", "StateId", "dbo.tbl_State");
            DropForeignKey("dbo.tbl_Repair", "MaterialId", "dbo.tbl_Material");
            DropForeignKey("dbo.tbl_AccidentM", "MaterialId", "dbo.tbl_Material");
            DropForeignKey("dbo.tbl_Employee", "StateId", "dbo.tbl_State");
            DropForeignKey("dbo.tbl_AccidentStation", "StationId", "dbo.tbl_State");
            DropForeignKey("dbo.tbl_ShiftRegister", "ShiftRegisterShifId", "dbo.tbl_shift");
            DropForeignKey("dbo.tbl_Leave", "EmployeeID2", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_Leave", "EmployeeID1", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_AccidentEmplyoee", "EmployeeId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_Accident", "AccidentReportProducer", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_Accident", "AccidentReportReciver", "dbo.tbl_Employee");
            DropIndex("dbo.tbl_AccidentO", new[] { "OrganizationsId" });
            DropIndex("dbo.tbl_AccidentO", new[] { "AccidentId" });
            DropIndex("dbo.tbl_AccidentInjured", new[] { "InjuredId" });
            DropIndex("dbo.tbl_AccidentInjured", new[] { "AccidentId" });
            DropIndex("dbo.tbl_Missives", new[] { "MissiveUserId" });
            DropIndex("dbo.tbl-User", new[] { "EmployeeId" });
            DropIndex("dbo.tbl_AccidentM", new[] { "MaterialId" });
            DropIndex("dbo.tbl_AccidentM", new[] { "AccidentId" });
            DropIndex("dbo.tbl_Repair", new[] { "StateId" });
            DropIndex("dbo.tbl_Repair", new[] { "MaterialId" });
            DropIndex("dbo.tbl_AccidentStation", new[] { "AccidentId" });
            DropIndex("dbo.tbl_AccidentStation", new[] { "StationId" });
            DropIndex("dbo.tbl_shift", new[] { "StateId" });
            DropIndex("dbo.tbl_ShiftRegister", new[] { "ShiftRegisterShifId" });
            DropIndex("dbo.tbl_ShiftRegisterEmployee", new[] { "EmployeeID" });
            DropIndex("dbo.tbl_ShiftRegisterEmployee", new[] { "ShiftRegisterID" });
            DropIndex("dbo.tbl_Leave", new[] { "EmployeeID2" });
            DropIndex("dbo.tbl_Leave", new[] { "EmployeeID1" });
            DropIndex("dbo.tbl_Employee", new[] { "StateId" });
            DropIndex("dbo.tbl_AccidentEmplyoee", new[] { "AccidentId" });
            DropIndex("dbo.tbl_AccidentEmplyoee", new[] { "EmployeeId" });
            DropIndex("dbo.tbl_Accident", new[] { "AccidentCause" });
            DropIndex("dbo.tbl_Accident", new[] { "AccidentReportProducer" });
            DropIndex("dbo.tbl_Accident", new[] { "AccidentReportReciver" });
            DropIndex("dbo.tbl_Accident", new[] { "AccidentUsageId" });
            DropIndex("dbo.tbl_Accident", new[] { "AccidentUserId" });
            DropIndex("dbo.tbl_Accident", new[] { "AccidentTypeId" });
            DropIndex("dbo.tbl_Accident", new[] { "AccidentWid" });
            DropTable("dbo.tbl_weather");
            DropTable("dbo.tbl_Usage");
            DropTable("dbo.tbl_Cause");
            DropTable("dbo.tbl_AccidentType");
            DropTable("dbo.tbl_Organizations");
            DropTable("dbo.tbl_AccidentO");
            DropTable("dbo.tbl_Injured");
            DropTable("dbo.tbl_AccidentInjured");
            DropTable("dbo.tbl_Missives");
            DropTable("dbo.tbl-User");
            DropTable("dbo.tbl_AccidentM");
            DropTable("dbo.tbl_Material");
            DropTable("dbo.tbl_Repair");
            DropTable("dbo.tbl_AccidentStation");
            DropTable("dbo.tbl_State");
            DropTable("dbo.tbl_shift");
            DropTable("dbo.tbl_ShiftRegister");
            DropTable("dbo.tbl_ShiftRegisterEmployee");
            DropTable("dbo.tbl_Leave");
            DropTable("dbo.tbl_Employee");
            DropTable("dbo.tbl_AccidentEmplyoee");
            DropTable("dbo.tbl_Accident");
        }
    }
}
