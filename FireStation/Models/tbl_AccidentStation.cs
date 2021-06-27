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
        [Display(Name = "شناسه ایستگاه شرکت کننده در ایستگاه")]
        public int AccidentStationId { get; set; }

        [Display(Name = "شناسه ایستگاه")]
        public int StationId { get; set; }

        [Display(Name = "شناسه حادثه")]
        public int AccidentId { get; set; }

        public virtual tbl_Accident tbl_Accident { get; set; }

        public virtual tbl_State tbl_State { get; set; }
    }
}
