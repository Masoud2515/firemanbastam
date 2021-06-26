namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LeaveID { get; set; }

        public int EmployeeID1 { get; set; }

        public int? EmployeeID2 { get; set; }

        public int ShiftID { get; set; }

        public int ShiftRegisterID { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }

        public virtual tbl_Employee tbl_Employee1 { get; set; }
    }
}
