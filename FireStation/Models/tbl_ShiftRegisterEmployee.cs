namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ShiftRegisterEmployee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int ShiftRegisterID { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        public int? Replace1 { get; set; }

        public int? Replace2 { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }

        public virtual tbl_ShiftRegister tbl_ShiftRegister { get; set; }
    }
}
