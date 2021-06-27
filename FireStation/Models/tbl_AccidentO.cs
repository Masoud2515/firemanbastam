namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccidentO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "شناسه سازمان حادثه")]
        public int AccidentOid { get; set; }

        [Display(Name = "شناسه حادثه")]
        public int AccidentId { get; set; }

        [Display(Name = "شناسه سازمان")]
        public int OrganizationsId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_Organizations tbl_Organizations { get; set; }
    }
}
