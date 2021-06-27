namespace FireStation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FireStation.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FireStation.Models.Context context)
        {
            #region states
            context.tbl_State.AddOrUpdate(x => x.StateId,
                    new Models.tbl_State() { StateId = 1, StateName = "ایستگاه ۲۲ بهمن", StateAdress = "خیابان 22 بهمنرنبش چهار راه شهربانی", StateTel = "02312345678" },
                    new Models.tbl_State() { StateId = 2, StateName = "ایستگاه ولایت", StateAdress = "میدان ولایت", StateTel = "02312345678" },
                    new Models.tbl_State() { StateId = 3, StateName = "ایستگاه بهارستان", StateAdress = "بهارستان", StateTel = "02312345678" },
                    new Models.tbl_State() { StateId = 4, StateName = "ایستگاه دادگستری", StateAdress = "چهار اره دادگستری", StateTel = "02312345678" },
                    new Models.tbl_State() { StateId = 5, StateName = "ستاد فرماندهی", StateAdress = "چهار اره دادگستری", StateTel = "02312345678" }
                    );
            #endregion

            #region defultuser
            context.tbl_Employee.AddOrUpdate(x => x.EmployeeId,
                      new Models.tbl_Employee() { EmployeeId = 1, EmployeeName = "علیرضا", EmployeeLastName = "علی بیک", EmployeeAdress = "دادگستری", EmployeeBirthdate = DateTime.Now, EmployeeCode = "9906705", EmployeeMCode = "4581234567", EmployeeFName = "علی", EmployeeWork = "اتشنشان", EmployeePhone = "09121234567", EmployeePicUrl = "/new", EmployeeDateRegistered = DateTime.Now, EmployeeSex = true ,StateId=5}
                      );
            context.tbl_User.AddOrUpdate(x => x.UserId,
                      new Models.tbl_User() { EmployeeId = 1, UserId = 1, UserUserName = "Alireza", UserPassword = "Admin@8520", UserRole = "SUPERADMIN" }
                      );
            #endregion

        }
    }
}
