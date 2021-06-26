namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccidentInjured
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccidentInjuredid { get; set; }

        public int AccidentId { get; set; }

        public int InjuredId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_Injured tbl_Injured { get; set; }
    }
}
