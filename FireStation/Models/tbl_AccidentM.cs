namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccidentM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccidentMid { get; set; }

        public int AccidentId { get; set; }

        public int MaterialId { get; set; }

        public int tedad { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_Material tbl_Material { get; set; }
    }
}
