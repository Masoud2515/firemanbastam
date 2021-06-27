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
        [Display(Name = "شناسه مرخصی")]
        public int LeaveID { get; set; }

        [Display(Name = "شناسه فرد")]
        public int EmployeeID1 { get; set; }

        [Display(Name = "شناسه فرد جایگزین")]
        public int? EmployeeID2 { get; set; }

        [Display(Name = "شناسه شیفت")]
        public int ShiftID { get; set; }

        [Display(Name = "شناسه ثبت شیفت")]
        public int ShiftRegisterID { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }

        public virtual tbl_Employee tbl_Employee1 { get; set; }
    }
}
