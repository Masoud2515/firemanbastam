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
        [Display(Name = "شناسه")]
        public int ID { get; set; }

        [Display(Name = "شناسه ثبت شیفت")]
        public int ShiftRegisterID { get; set; }

        [Display(Name = "شناسه کارمند")]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "نوع")]
        public string Type { get; set; }

        [Display(Name = "جایگزین اول")]
        public int? Replace1 { get; set; }

        [Display(Name = "جایگزین دوم")]
        public int? Replace2 { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }

        public virtual tbl_ShiftRegister tbl_ShiftRegister { get; set; }
    }
}
