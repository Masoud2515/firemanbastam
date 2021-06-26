using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FireStation.Models
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<tbl_Accident> tbl_Accident { get; set; }
        public virtual DbSet<tbl_AccidentEmplyoee> tbl_AccidentEmplyoee { get; set; }
        public virtual DbSet<tbl_AccidentInjured> tbl_AccidentInjured { get; set; }
        public virtual DbSet<tbl_AccidentM> tbl_AccidentM { get; set; }
        public virtual DbSet<tbl_AccidentO> tbl_AccidentO { get; set; }
        public virtual DbSet<tbl_AccidentStation> tbl_AccidentStation { get; set; }
        public virtual DbSet<tbl_AccidentType> tbl_AccidentType { get; set; }
        public virtual DbSet<tbl_Cause> tbl_Cause { get; set; }
        public virtual DbSet<tbl_Employee> tbl_Employee { get; set; }
        public virtual DbSet<tbl_Injured> tbl_Injured { get; set; }
        public virtual DbSet<tbl_Leave> tbl_Leave { get; set; }
        public virtual DbSet<tbl_Material> tbl_Material { get; set; }
        public virtual DbSet<tbl_Missives> tbl_Missives { get; set; }
        public virtual DbSet<tbl_Organizations> tbl_Organizations { get; set; }
        public virtual DbSet<tbl_Repair> tbl_Repair { get; set; }
        public virtual DbSet<tbl_shift> tbl_shift { get; set; }
        public virtual DbSet<tbl_ShiftRegister> tbl_ShiftRegister { get; set; }
        public virtual DbSet<tbl_ShiftRegisterEmployee> tbl_ShiftRegisterEmployee { get; set; }
        public virtual DbSet<tbl_State> tbl_State { get; set; }
        public virtual DbSet<tbl_Usage> tbl_Usage { get; set; }
        public virtual DbSet<tbl_weather> tbl_weather { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Accident>()
                .Property(e => e.AccidentTime)
                .HasPrecision(0);

            modelBuilder.Entity<tbl_Accident>()
                .Property(e => e.AccidentTimeStartOperation)
                .HasPrecision(0);

            modelBuilder.Entity<tbl_Accident>()
                .Property(e => e.AccidentTimeEndOperation)
                .HasPrecision(0);

            modelBuilder.Entity<tbl_Accident>()
                .Property(e => e.AccidentTimeToClear)
                .HasPrecision(0);

            modelBuilder.Entity<tbl_Accident>()
                .Property(e => e.AccidentBuildingTel)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Accident>()
                .HasMany(e => e.tbl_AccidentEmplyoee)
                .WithRequired(e => e.tbl_Accident)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Accident>()
                .HasMany(e => e.tbl_AccidentInjured)
                .WithRequired(e => e.tbl_Accident)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Accident>()
                .HasMany(e => e.tbl_AccidentM)
                .WithRequired(e => e.tbl_Accident)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Accident>()
                .HasMany(e => e.tbl_AccidentO)
                .WithRequired(e => e.tbl_Accident)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Accident>()
                .HasMany(e => e.tbl_AccidentStation)
                .WithRequired(e => e.tbl_Accident)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_AccidentType>()
                .HasMany(e => e.tbl_Accident)
                .WithRequired(e => e.tbl_AccidentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Cause>()
                .HasMany(e => e.tbl_Accident)
                .WithRequired(e => e.tbl_Cause)
                .HasForeignKey(e => e.AccidentCause)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Employee>()
                .Property(e => e.EmployeePhone)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Employee>()
                .HasMany(e => e.tbl_Accident)
                .WithRequired(e => e.tbl_Employee)
                .HasForeignKey(e => e.AccidentReportReciver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Employee>()
                .HasMany(e => e.tbl_Accident1)
                .WithRequired(e => e.tbl_Employee1)
                .HasForeignKey(e => e.AccidentReportProducer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Employee>()
                .HasMany(e => e.tbl_AccidentEmplyoee)
                .WithRequired(e => e.tbl_Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Employee>()
                .HasMany(e => e.tbl_Leave)
                .WithRequired(e => e.tbl_Employee)
                .HasForeignKey(e => e.EmployeeID1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Employee>()
                .HasMany(e => e.tbl_Leave1)
                .WithOptional(e => e.tbl_Employee1)
                .HasForeignKey(e => e.EmployeeID2);

            modelBuilder.Entity<tbl_Employee>()
                .HasMany(e => e.tbl_ShiftRegisterEmployee)
                .WithRequired(e => e.tbl_Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Employee>()
                .HasMany(e => e.tbl_User)
                .WithRequired(e => e.tbl_Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Injured>()
                .HasMany(e => e.tbl_AccidentInjured)
                .WithRequired(e => e.tbl_Injured)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Material>()
                .Property(e => e.MaterialCode)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Material>()
                .Property(e => e.MaterialVahed)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Material>()
                .HasMany(e => e.tbl_AccidentM)
                .WithRequired(e => e.tbl_Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Material>()
                .HasMany(e => e.tbl_Repair)
                .WithRequired(e => e.tbl_Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Missives>()
                .Property(e => e.MissiveNumber)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Organizations>()
                .HasMany(e => e.tbl_AccidentO)
                .WithRequired(e => e.tbl_Organizations)
                .HasForeignKey(e => e.OrganizationsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_shift>()
                .HasMany(e => e.tbl_ShiftRegister)
                .WithRequired(e => e.tbl_shift)
                .HasForeignKey(e => e.ShiftRegisterShifId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_ShiftRegister>()
                .Property(e => e.ShiftRegisterTimeStart)
                .HasPrecision(0);

            modelBuilder.Entity<tbl_ShiftRegister>()
                .Property(e => e.ShiftRegisterTimeEnd)
                .HasPrecision(0);

            modelBuilder.Entity<tbl_ShiftRegister>()
                .HasMany(e => e.tbl_ShiftRegisterEmployee)
                .WithRequired(e => e.tbl_ShiftRegister)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_ShiftRegisterEmployee>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<tbl_State>()
                .Property(e => e.StateTel)
                .IsFixedLength();

            modelBuilder.Entity<tbl_State>()
                .HasMany(e => e.tbl_AccidentStation)
                .WithRequired(e => e.tbl_State)
                .HasForeignKey(e => e.StationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_State>()
                .HasMany(e => e.tbl_Employee)
                .WithRequired(e => e.tbl_State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_State>()
                .HasMany(e => e.tbl_Repair)
                .WithRequired(e => e.tbl_State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_State>()
                .HasMany(e => e.tbl_shift)
                .WithRequired(e => e.tbl_State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Usage>()
                .HasMany(e => e.tbl_Accident)
                .WithRequired(e => e.tbl_Usage)
                .HasForeignKey(e => e.AccidentUsageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_weather>()
                .HasMany(e => e.tbl_Accident)
                .WithRequired(e => e.tbl_weather)
                .HasForeignKey(e => e.AccidentWid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.UserUserName)
                .IsFixedLength();

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.UserRole)
                .IsFixedLength();

            modelBuilder.Entity<tbl_User>()
                .HasMany(e => e.tbl_Accident)
                .WithRequired(e => e.tbl_User)
                .HasForeignKey(e => e.AccidentUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_User>()
                .HasMany(e => e.tbl_Missives)
                .WithRequired(e => e.tbl_User)
                .HasForeignKey(e => e.MissiveUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
