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
        public int AEId { get; set; }

        public int EmployeeId { get; set; }

        public int AccidentId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_Employee tbl_Employee { get; set; }
    }
}
