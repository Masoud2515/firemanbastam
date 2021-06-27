namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccidentEmplyoee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه پرسنل حادثه")]
        public int AEId { get; set; }

        [Display(Name = "شناسه کارمند")]
        public int EmployeeId { get; set; }

        [Display(Name = "شناسه حادثه")]
        public int AccidentId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }
    }
}
