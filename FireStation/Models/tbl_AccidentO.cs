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
        public int AccidentOid { get; set; }

        public int AccidentId { get; set; }

        public int OrganizationsId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_Organizations tbl_Organizations { get; set; }
    }
}
