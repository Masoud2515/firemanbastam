namespace FireStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccidentStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccidentStationId { get; set; }

        public int StationId { get; set; }

        public int AccidentId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_State tbl_State { get; set; }
    }
}
